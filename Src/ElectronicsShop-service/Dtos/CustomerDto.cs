namespace ElectronicsShop_service.Dtos;
public class CustomerDto : BaseDto
{
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
}