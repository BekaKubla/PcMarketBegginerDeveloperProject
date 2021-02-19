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
            PcComputerProp pcComputerProp = _context.GetComputers.Where(e => e.ID == id).FirstOrDefault();
            if (pcPart!=null)
            {
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
            }
            else
            {
                List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
                CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();
                if (cartItem == null)
                {
                    cart.Add(new CartItem(pcComputerProp));
                }
                else
                {
                    cartItem.Quantity += 1;
                }
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Decrease(int id)
        {
            PcPartProp pcPart = _context.GetPcParts.Where(e => e.ID == id).FirstOrDefault();
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            cart.RemoveAll(x => x.ProductId == id);
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");

        }
    }
}
