namespace ElectronicsShop_service.Dtos;
public record CartVMDto
{

    public IEnumerable<CartDto> ListCart { get; set; }
}