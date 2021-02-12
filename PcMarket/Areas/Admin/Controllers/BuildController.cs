using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PcMarket.Data;
using PcMarket.Models;
using PcMarket.Repositories;
using PcMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BuildController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPcBuildRepo _repo;
        private readonly IWebHostEnvironment _env;

        public BuildController(AppDbContext context, IPcBuildRepo repo,IWebHostEnvironment env)
        {
            _context = context;
            _repo = repo;
            _env = env;
        }
        public IActionResult Index()
        {
            var getBuild = _context.GetComputers;
            return View(getBuild);
        }
        public IActionResult Delete(int id)
        {
            var findBuild = _repo.GetBuildById(id);
            _repo.DeletePcBuild(findBuild);
            _repo.SaveChange();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(PcComputerCreateViewModel pcComputerCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string stringFileName = UploadFile(pcComputerCreateViewModel);
            var pcBuild = new PcComputerProp
            {
                BuildName = pcComputerCreateViewModel.BuildName,
                ProcesorType = pcComputerCreateViewModel.ProcesorType,
                ProcesorName = pcComputerCreateViewModel.ProcesorName,
                Motherboard = pcComputerCreateViewModel.Motherboard,
                MemoryType = pcComputerCreateViewModel.MemoryType,
                MemoryName = pcComputerCreateViewModel.MemoryName,
                StorageType = pcComputerCreateViewModel.StorageType,
                StorageName = pcComputerCreateViewModel.StorageName,
                GPUType = pcComputerCreateViewModel.GPUType,
                GPUName = pcComputerCreateViewModel.GPUName,
                Case = pcComputerCreateViewModel.Case,
                PowerSupply = pcComputerCreateViewModel.PowerSupply,
                BuildPrice = pcComputerCreateViewModel.BuildPrice,
                CustomDescription = pcComputerCreateViewModel.CustomDescription,
                PartOrBuild = PartOrBuild.კომპიუტერი,
                FileName = stringFileName

            };
            _repo.CreatePcBuild(pcBuild);
            _repo.SaveChange();
            return RedirectToAction("index");
        }

        private string UploadFile(PcComputerCreateViewModel pcComputerCreateViewModel)
        {
            string fileName = null;
            if (pcComputerCreateViewModel.FileName != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + pcComputerCreateViewModel.FileName.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pcComputerCreateViewModel.FileName.CopyTo(fileStream);
                }
            }

            return fileName;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var findProduct = _repo.GetBuildById(id);
            PcComputerCreateViewModel buildVm = new PcComputerCreateViewModel();
            buildVm.BuildName = findProduct.BuildName;
            buildVm.BuildPrice = findProduct.BuildPrice;
            buildVm.Case = findProduct.Case;
            buildVm.CustomDescription = findProduct.CustomDescription;
            buildVm.GPUName = findProduct.GPUName;
            buildVm.GPUType = findProduct.GPUType;
            buildVm.MemoryName = findProduct.MemoryName;
            buildVm.MemoryType = findProduct.MemoryType;
            buildVm.Motherboard = findProduct.Motherboard;
            buildVm.PowerSupply = findProduct.PowerSupply;
            buildVm.ProcesorName = findProduct.ProcesorName;
            buildVm.ProcesorType = findProduct.ProcesorType;
            buildVm.StorageName = findProduct.StorageName;
            buildVm.StorageType = findProduct.StorageType;
            return View(buildVm);
        }
        [HttpPost]
        public IActionResult Edit(PcComputerCreateViewModel pcComputerCreateViewModel, int id)
        {
            var findPart = _repo.GetBuildById(id);
            if (findPart == null)
            {
                return NotFound();
            }
            else
            {
                findPart.BuildName = pcComputerCreateViewModel.BuildName;
                findPart.BuildPrice = pcComputerCreateViewModel.BuildPrice;
                findPart.Case = pcComputerCreateViewModel.Case;
                findPart.CustomDescription = pcComputerCreateViewModel.CustomDescription;
                findPart.GPUName = pcComputerCreateViewModel.GPUName;
                findPart.GPUType = pcComputerCreateViewModel.GPUType;
                findPart.MemoryName = pcComputerCreateViewModel.MemoryName;
                findPart.MemoryType = pcComputerCreateViewModel.MemoryType;
                findPart.Motherboard = pcComputerCreateViewModel.Motherboard;
                findPart.PowerSupply = pcComputerCreateViewModel.PowerSupply;
                findPart.ProcesorName = pcComputerCreateViewModel.ProcesorName;
                findPart.ProcesorType = pcComputerCreateViewModel.ProcesorType;
                findPart.StorageName = pcComputerCreateViewModel.StorageName;
                findPart.StorageType = pcComputerCreateViewModel.StorageType;
                _repo.SaveChange();
            }
            return RedirectToAction("index");
        }

    }
}
