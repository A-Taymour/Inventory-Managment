using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DB.ViewModels
{
    public class CategoryProductViewModel
    {
        [Required]
        [MinLength(3), MaxLength(50)]

        public string CategoryName { get; set; }

        [Required]
        [MinLength(20), MaxLength(200)]
        public string Description { get; set; } = "sssssssssssssssssssssssssss";
    }
}
