using Microsoft.AspNetCore.Mvc;
using PcMarket.Data;
using PcMarket.Infrastructure;
using PcMarket.Models;
using PcMarket.ViewModels.CartViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel vm = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };
            return View(vm);
        }
        public IActionResult Add(int id)
        {
            PcPartProp pcPart = _context.GetPcParts.Where(e => e.ID == id).FirstOrDefault();
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();
            if (cartItem == null)
            {
                cart.Add(new CartItem(pcPart));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToAction("Index");
        }
    }
}
