using Inventory.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ID { get; set; }
    [Required]
    [MinLength(3), MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MinLength(20), MaxLength(200)]
    public string Description { get; set; }
    [Required]

    public decimal Price { get; set; }
  
    public DateTime CreatedAt { get; set; }
     
    public DateTime UpdatedAt { get; set; }
    [Required]
    public int StockQuantity { get; set; }
    
    [Required]
    public int LowStockThreshold { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }

    public int CategoryID { get; set; }
    public Category Category { get; set; }

    public ICollection<Alert> Alerts { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
