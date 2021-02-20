using Microsoft.AspNetCore.Mvc;
using PcMarket.Models;
using PcMarket.ViewModels.CartViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Infrastructure
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel smallCartVm;
            if (cart==null||cart.Count==0)
            {
                smallCartVm = null;
            }
            else
            {
                smallCartVm = new SmallCartViewModel
                {
                    NumbersOfItem = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price),
                };
            }
            return View(smallCartVm);

        }
    }
}
