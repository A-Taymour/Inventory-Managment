using Inventory.Models;

public class User
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Admin { get; set; }
    public bool Supplier { get; set; }
    public bool Client { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
