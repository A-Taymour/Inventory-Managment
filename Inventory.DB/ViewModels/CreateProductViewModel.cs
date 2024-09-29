using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DB.ViewModels
{
    [Keyless]
    public class CreateProductViewModel
    {
        
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(20), MaxLength(200)]
        public string Description { get; set; }
        [Required]

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }=DateTime.Now;
        [Required]
        public int StockQuantity { get; set; }

        
        public int LowStockThreshold { get; set; }

        [Required]
        public int UserID { get; set; }
        public User User { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required]
        public int SupplierID { get; set; }
        public Supplier supplier { get; set; }

        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
