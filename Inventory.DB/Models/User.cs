using Inventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;


public class User:IdentityUser
{
  

   
 

    
    public ICollection<Product> Products { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
