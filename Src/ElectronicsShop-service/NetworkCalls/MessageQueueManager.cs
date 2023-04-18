using System.Text;
using ElectronicsShop_service.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Authentication.Infrastructure.NetworkCalls.MessageQueue;
public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    public MessageQueueManager()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };
        channel = connectionFactory.CreateConnection().CreateModel();

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
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            System.Console.WriteLine(message);
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.UserToBusiness,
            autoAck: true,
            consumer: consumer);
    }
}