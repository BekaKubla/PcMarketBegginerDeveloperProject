using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels.CartViewModel
{
    public class CartViewModel
    {
        public List<CartItem>CartItems { get; set; }
        public double GrandTotal { get; set; }
    }
}
