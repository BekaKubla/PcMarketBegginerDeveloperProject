using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get { return Quantity * Price; } }
        public string Image { get; set; }
        public CartItem()
        {

        }
        public CartItem(PcPartProp pcPart)
        {
            ProductId = pcPart.ID;
            ProductName = pcPart.PartName;
            Quantity = 1;
            Price = pcPart.PartPriceWithoutC2;
            Image = pcPart.FileName;
        }

    }
}
