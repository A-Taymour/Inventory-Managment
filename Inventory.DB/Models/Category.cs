using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Category
{
   
    public int ID { get; set; }
    [Required]
    [MinLength(3), MaxLength(50)]
    
    public string CategoryName { get; set; }
    [Required]
    [MinLength(20), MaxLength(200)]
    public string Description { get; set; } = "sssssssssssssssssssssssssss";
    public ICollection<Product> Products { get; set; }
}
