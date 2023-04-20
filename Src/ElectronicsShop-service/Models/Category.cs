using CommonGenericClasses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models;
public class Category : BaseEntity
{
    [Required]
        public string Name { get; set; }
    [DisplayName("Display Order")]
    public int? DisplayOrder { get; set; }
}