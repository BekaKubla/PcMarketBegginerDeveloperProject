using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        [Display(Name ="პროდუქტის დასახელება")]
        public string ProductName { get; set; }
        [Display(Name ="რაოდენობა")]
        public int Quantity { get; set; }
        [Display(Name ="ფასი")]
        public double Price { get; set; }
        public string DisplayPrice { get; set; }
        [Display(Name ="მთლიანი ღირებულება")]
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
            DisplayPrice = pcPart.PartPrice;
            Image = pcPart.FileName;
        }

    }
}
