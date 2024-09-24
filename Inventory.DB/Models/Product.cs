using Inventory.Models;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int StockQuantity { get; set; }
    public int LowStockThreshold { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }

    public int CategoryID { get; set; }
    public Category Category { get; set; }

    public ICollection<Alert> Alerts { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
