using Microsoft.AspNetCore.Mvc;
using PcMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PartController : Controller
    {
        private readonly AppDbContext _context;

        public PartController(AppDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
