using Inventory.DB.Models;
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
  
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } 
    [Required]
    public int StockQuantity { get; set; }
    
    [Required]
    public int LowStockThreshold { get; set; }

    [Required]
    public int UserID { get; set; }
    public User User { get; set; }

    [Required]
    public int CategoryID { get; set; }
    public Category Category { get; set; }

    [Required]
    public int SupplierID { get; set; }
    public Supplier supplier { get; set; }

    public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
