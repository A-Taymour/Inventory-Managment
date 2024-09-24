public class Transaction
{
    public int TransactionID { get; set; }
    public string TransactionType { get; set; }
    public int Quantity { get; set; }
    public DateTime TransactionDate { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; }
}
