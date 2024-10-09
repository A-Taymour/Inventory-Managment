using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.DB.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, ErrorMessage = "Name cannot be longer than 40 characters")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number," +
        " one special character, and be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Email Address")]
        //[Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^(012|011|010|015)\d{8}$",
        ErrorMessage = "Phone number is Invalid.")]
        [StringLength(11, ErrorMessage = "Phone number cannot be longer than 11 characters")]
        public string Phone { get; set; }

    
        public string role { get; set; }


        [Display(Name = "Role")]

        public IEnumerable<SelectListItem> Roles { get; set; }

    }
}
