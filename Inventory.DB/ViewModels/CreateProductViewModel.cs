using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public string Description { get; set; } = "sekosekosekosekosekosekosekosekoseko";
        [Required]

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public int StockQuantity { get; set; }


        public int LowStockThreshold { get; set; }

        public int UserID { get; set; }
         
         public IEnumerable<SelectListItem> Users { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }


        public int SupplierID { get; set; }
        public IEnumerable<SelectListItem> Suppliers { get; set; }
        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
