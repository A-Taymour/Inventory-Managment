using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.DB.ViewModels
{
    [Keyless]
    public class ProductViewModel
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

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public int StockQuantity { get; set; }


        public int LowStockThreshold { get; set; }

        [Display(Name = "User")]

        public IEnumerable<SelectListItem> Users { get; set; }
        [Display(Name = "Category")]

        public IEnumerable<SelectListItem> categories { get; set; }
        [Display(Name = "Supplier")]
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }


        public IEnumerable<SelectListItem> Suppliers { get; set; }
        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }


}
