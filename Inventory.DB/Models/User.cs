using Inventory.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
 
public class User
{
  
    public int ID { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
