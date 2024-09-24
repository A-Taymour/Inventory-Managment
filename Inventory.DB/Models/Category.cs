using System.ComponentModel.DataAnnotations;

public class Category
{
   
    public int ID { get; set; }
    [Required]
    [MinLength(3), MaxLength(50)]
    [RegularExpression("[0-9A-Za-z_]")]
    public string CategoryName { get; set; }
    [Required]
    [MinLength(20), MaxLength(200)]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }
}
