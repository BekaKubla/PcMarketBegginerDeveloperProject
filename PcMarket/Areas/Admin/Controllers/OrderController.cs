using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcMarket.Data;
using PcMarket.Repositories;

namespace PcMarket.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPcPartOrderRepo _repo;

        public OrderController(AppDbContext context,IPcPartOrderRepo repo)
        {
            _context = context;
            _repo = repo;
        }
        public IActionResult Delete(int id)
        {
            var findOrder = _repo.GetOrderById(id);
            _repo.DeleteOrder(findOrder);
            _repo.SaveChange();
            return RedirectToAction("partorder");
        }
        public IActionResult GetOrders()
        {
            var getOrders = _repo.GetAllOrder();
            return View(getOrders);
        }
        [HttpGet]
        public ActionResult BuildOrder()
        {
            var getOrders = _repo.GetOrderOnlyBuild();
            return View(getOrders);
        }
        [HttpGet]
        public ActionResult PartOrder()
        {
            var getOrders = _repo.GetOrderOnlyPart();
            return View(getOrders);
        }
    }
}
