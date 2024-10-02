﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DB.ViewModels
{
    public class TransactionViewModel
    {
        public string TransactionType { get; set; }
        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
        [Display(Name = "User")]

        public IEnumerable<SelectListItem> Users { get; set; }
        [Display(Name = "Product")]

        public IEnumerable<SelectListItem> products { get; set; }
    }
}