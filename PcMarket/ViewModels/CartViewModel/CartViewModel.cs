using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels.CartViewModel
{
    public class CartViewModel
    {
        public List<CartItem>CartItems { get; set; }
        [Display(Name ="გადასახდელი თანხა")]
        public double GrandTotal { get; set; }
    }
}
