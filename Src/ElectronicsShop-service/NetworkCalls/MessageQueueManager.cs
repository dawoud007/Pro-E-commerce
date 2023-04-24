using System.Text;
using ElectronicsShop_service.Helpers;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ElectronicsShop_service.NetworkCalls;
public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    private readonly IServiceProvider serviceProvider;
    public MessageQueueManager(IOptions<RabbitMqConnectionHelper> options, IServiceProvider serviceProvider)
    {
        var connectionHelper = options.Value;
        var connectionFactory = new ConnectionFactory
        {
            HostName = connectionHelper.Host,
            UserName = connectionHelper.UserName,
            Password = connectionHelper.Password
        };
        channel = connectionFactory.CreateConnection().CreateModel();
        this.serviceProvider = serviceProvider;
    }
    public void SubscribeToUsersQueue()
    {

        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthenticationExchange,
            type: ExchangeType.Fanout,
            durable: false,
            autoDelete: false
        );
        channel.QueueDeclare(
            queue: RabbitMQConstants.UserToBusiness,
            durable: false,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueBind(
            queue: RabbitMQConstants.UserToBusiness,
            exchange: RabbitMQConstants.AuthenticationExchange,
            RabbitMQConstants.UserToBusiness);

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var options = new DbContextOptions<ApplicationDbContext>();
            var dbcontext = new ApplicationDbContext(options, serviceProvider.GetRequiredService<IConfiguration>());
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            System.Console.WriteLine(message);
            var customer = JsonConvert.DeserializeObject<Customer>(message)!;
            await dbcontext.Customers!.AddAsync(customer);
            await dbcontext.SaveChangesAsync();
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.UserToBusiness,
            autoAck: true,
            consumer: consumer);
    }
}