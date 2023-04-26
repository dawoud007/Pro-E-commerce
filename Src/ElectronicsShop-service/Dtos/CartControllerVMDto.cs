namespace ElectronicsShop_service.Dtos
{
    public class CartControllerVMDto:BaseDto
    {

public CartControllerVMDto() { }


        public Guid ProductId { get; set; }

        /* public byte[]? image { get; set; }*/

        public Guid? customerId { get; set; }



     



    }
}
