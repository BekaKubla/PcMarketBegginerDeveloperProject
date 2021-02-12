using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PcMarket.Data;
using PcMarket.Models;
using PcMarket.Repositories;
using PcMarket.ViewModels;
using PcMarket.ViewModels.PcPartViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PartController:Controller
    {
        private readonly AppDbContext _context;
        private readonly IPcPartRepos _repo;
        private readonly IWebHostEnvironment _env;

        public PartController(AppDbContext context, IPcPartRepos repo, IWebHostEnvironment env)
        {
            _context = context;

            _repo = repo;

            _env = env;
        }

        public ActionResult Index()
        {
            var getPart = _context.GetPcParts;
            return View(getPart);
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(PcPartCreateViewModel pcPartCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string stringFileName = UploadFile(pcPartCreateViewModel);
            var pcPart = new PcPartProp
            {
                PartName = pcPartCreateViewModel.PartName,
                PartCondition = pcPartCreateViewModel.PartCondition,
                PartCategory = pcPartCreateViewModel.PartCategory,
                PartPrice = pcPartCreateViewModel.PartPrice,
                PartDescribtion = pcPartCreateViewModel.PartDescribtion,
                PartOrBuild = PartOrBuild.ნაწილი,
                FileName = stringFileName
            };
            _repo.CreatePart(pcPart);
            _repo.SaveChange();
            TempData["Success"] = "პროდუქტი დამატებულია!";
            return RedirectToAction("index");
        }
        private string UploadFile(PcPartCreateViewModel pcPartCreateViewModel)
        {
            string fileName = null;
            if (pcPartCreateViewModel.ImageFile != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + pcPartCreateViewModel.ImageFile.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pcPartCreateViewModel.ImageFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public IActionResult Delete(int id)
        {
            var getPart = _repo.GetPartByID(id);
            _repo.DeletePart(getPart);
            _repo.SaveChange();
            TempData["Delete"] = "პროდუქტი წაშლილია!";
            
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var findPart = _repo.GetPartByID(id);
            PcPartEditViewModel pcPartEditViewModel = new PcPartEditViewModel();
            pcPartEditViewModel.PartName = findPart.PartName;
            pcPartEditViewModel.PartCondition = findPart.PartCondition;
            pcPartEditViewModel.PartCategory = findPart.PartCategory;
            pcPartEditViewModel.PartPrice = findPart.PartPrice;
            pcPartEditViewModel.PartDescribtion = findPart.PartDescribtion;
            return View(pcPartEditViewModel);

        }
        [HttpPost]
        public IActionResult Edit(PcPartEditViewModel pcPartEditViewModel, int id)
        {
            var findPart = _repo.GetPartByID(id);
            if (findPart == null)
            {
                return NotFound();
            }
            else
            {
                findPart.PartName = pcPartEditViewModel.PartName;
                findPart.PartCategory = pcPartEditViewModel.PartCategory;
                findPart.PartCondition = pcPartEditViewModel.PartCondition;
                findPart.PartPrice = pcPartEditViewModel.PartPrice;
                findPart.PartDescribtion = pcPartEditViewModel.PartDescribtion;
                _repo.SaveChange();
            }
            return RedirectToAction("index");
        }
    }
}
