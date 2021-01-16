using Microsoft.AspNetCore.Mvc;
using PcMarket.Models;
using PcMarket.Repositories;
using PcMarket.ViewModels;
using PcMarket.ViewModels.PcPartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Controllers
{
    public class PcPartController :Controller
    {
        private readonly IPcPartRepos _pcRepo;

        public PcPartController(IPcPartRepos pcRepo)
        {
            _pcRepo = pcRepo;
        }
        [HttpGet]
        public ActionResult List()
        {
            var model = _pcRepo.GetAllParts();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id,PcPartDetailsViewModel pcPartDetailsViewModel)
        {
            var getID = _pcRepo.GetPartByID(id);
            if (getID == null)
            {
                return NotFound();
            }
            else
            {
                pcPartDetailsViewModel.PartName = getID.PartName;
                pcPartDetailsViewModel.PartCondition = getID.PartCondition;
                pcPartDetailsViewModel.PartCategory = getID.PartCategory;
                pcPartDetailsViewModel.PartPrice = getID.PartPrice;
                pcPartDetailsViewModel.PartDescribtion = getID.PartDescribtion;
            }
            return View(pcPartDetailsViewModel);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PcPartProp pcPartProp,PcPartCreateViewModel pcPartCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                PcPartProp partProp = _pcRepo.CreatePart(pcPartProp);
                pcPartCreateViewModel.PartName = partProp.PartName;
                pcPartCreateViewModel.PartCondition = partProp.PartCondition;
                pcPartCreateViewModel.PartCategory = partProp.PartCategory;
                pcPartCreateViewModel.PartPrice = partProp.PartPrice;
                pcPartCreateViewModel.PartDescribtion = partProp.PartDescribtion;
            }
            _pcRepo.SaveChange();
            return RedirectToAction("index");
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var findCar = _pcRepo.GetPartByID(id);
            if (findCar == null)
            {
                return NotFound();
            }
            _pcRepo.SaveChange();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id, PcPartEditViewModel pcPartEditViewModel)
        {
            var findPart = _pcRepo.GetPartByID(id);
            pcPartEditViewModel.PartName = findPart.PartName;
            pcPartEditViewModel.PartCondition = findPart.PartCondition;
            pcPartEditViewModel.PartCategory = findPart.PartCategory;
            pcPartEditViewModel.PartPrice = findPart.PartPrice;
            pcPartEditViewModel.PartDescribtion = findPart.PartDescribtion;
            _pcRepo.SaveChange();
            return View(pcPartEditViewModel);

        }
        [HttpPost]
        public IActionResult Edit(PcPartEditViewModel pcPartEditViewModel)
        {
            PcPartProp pcPartProp = _pcRepo.GetPartByID(pcPartEditViewModel.ID);
            pcPartProp.ID = pcPartEditViewModel.ID;
            pcPartProp.PartName = pcPartEditViewModel.PartName;
            pcPartProp.PartCondition = pcPartEditViewModel.PartCondition;
            pcPartProp.PartCategory = pcPartEditViewModel.PartCategory;
            pcPartProp.PartPrice = pcPartEditViewModel.PartPrice;
            pcPartProp.PartDescribtion = pcPartEditViewModel.PartDescribtion;

            PcPartProp newPart = new PcPartProp
            {
                ID = pcPartEditViewModel.ID,
                PartName = pcPartEditViewModel.PartName,
                PartCondition = pcPartEditViewModel.PartCondition,
                PartCategory = pcPartEditViewModel.PartCategory,
                PartPrice = pcPartEditViewModel.PartPrice,
                PartDescribtion = pcPartEditViewModel.PartDescribtion
            };
            _pcRepo.UpdatePart(newPart);
            _pcRepo.SaveChange();
            return RedirectToAction("Details", new { id = newPart.ID });
        }
    }
}
