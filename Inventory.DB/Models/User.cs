using Inventory.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class User
{
  
    public int ID { get; set; }
    [RegularExpression("[0-9A-Za-z_]")]
    [DisplayName("User Name")]
    public string Name { get; set; }
    [PasswordPropertyText]
    [Required]
    public string Password { get; set; }
    public bool Admin { get; set; }
    public bool Supplier { get; set; }
    public bool Client { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [StringLength(11, MinimumLength = 11, ErrorMessage = "phone number must be 11")]
    [Required]
    public string Phone { get; set; }

    public ICollection<Product> Products { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
