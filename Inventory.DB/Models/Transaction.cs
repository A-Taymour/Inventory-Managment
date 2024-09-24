using System.ComponentModel.DataAnnotations;

public class Transaction
{   
 
    public int ID { get; set; }
    [Required]

    public string TransactionType { get; set; }
    [Required]
    public int Quantity { get; set; }
    public DateTime TransactionDate { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; }
}
