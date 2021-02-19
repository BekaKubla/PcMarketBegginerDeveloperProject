using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PcMarket.Models;
using PcMarket.Repositories;
using PcMarket.ViewModels;
using PcMarket.ViewModels.PcComputerViewModel;
using PcMarket.ViewModels.PcPartViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Controllers
{
    public class PcBuildController:Controller
    {
        private readonly IPcBuildRepo _pcBuild;
        private readonly IPcPartOrderRepo _partOrder;
        private readonly IWebHostEnvironment _host;

        public PcBuildController(IPcBuildRepo pcBuildRepo, IPcPartOrderRepo partOrderRepo,IWebHostEnvironment host)
        {
            _pcBuild = pcBuildRepo;
            _partOrder = partOrderRepo;
            _host = host;
        }
        [HttpGet]
        public ActionResult PcList()
        {
            var getAll = _pcBuild.GetAllPc();
            
            return View(getAll);
        }
        [HttpGet]
        public ActionResult PcBuildDetails(int id,PcComputerCreateViewModel pcComputerCreateViewModel)
        {
            var findId = _pcBuild.GetBuildById(id);
            if (findId == null)
            {
                return NotFound();
            }
            else
            {
                pcComputerCreateViewModel.BuildName = findId.BuildName;
                pcComputerCreateViewModel.ProcesorName = findId.ProcesorName;
                pcComputerCreateViewModel.ProcesorType = findId.ProcesorType;
                pcComputerCreateViewModel.Motherboard = findId.Motherboard;
                pcComputerCreateViewModel.MemoryType = findId.MemoryType;
                pcComputerCreateViewModel.MemoryName = findId.MemoryName;
                pcComputerCreateViewModel.StorageType = findId.StorageType;
                pcComputerCreateViewModel.StorageName = findId.StorageName;
                pcComputerCreateViewModel.GPUType = findId.GPUType;
                pcComputerCreateViewModel.GPUName = findId.GPUName;
                pcComputerCreateViewModel.Case = findId.Case;
                pcComputerCreateViewModel.PowerSupply = findId.PowerSupply;
                pcComputerCreateViewModel.DisplayBuildPrice = findId.BuildPrice;
                pcComputerCreateViewModel.CustomDescription = findId.CustomDescription;
                pcComputerCreateViewModel.StringFileName = findId.FileName;
                ViewBag.Title = findId.BuildName;
            }
            return View(pcComputerCreateViewModel);
        }
        [HttpGet]
        public ActionResult PcBuildOrder(int id, PcBuildOrderDetailsView pcBuildOrderDetailsView)
        { 
            var getId = _pcBuild.GetBuildById(id);
            if (getId == null)
            {
                return NotFound();
            }
            pcBuildOrderDetailsView.BuildName = getId.BuildName;
            pcBuildOrderDetailsView.BuildPrice = getId.BuildPrice;
            pcBuildOrderDetailsView.PartOrBuild = getId.PartOrBuild;
            return View(pcBuildOrderDetailsView);
        }
        [HttpPost]
        public IActionResult PcBuildOrder(PcBuildOrderDetailsView pcBuildOrderDetailsView)
        {
            var findComputer = _pcBuild.GetBuildById(pcBuildOrderDetailsView.ID);
            pcBuildOrderDetailsView.Id = findComputer.ID;
            pcBuildOrderDetailsView.BuildName = findComputer.BuildName;
            pcBuildOrderDetailsView.BuildPrice = findComputer.BuildPrice;
            pcBuildOrderDetailsView.PartOrBuild = findComputer.PartOrBuild;
            var DateTimeNow = DateTime.Now.ToString("dd/MMMM/yyyy HH:mm");
            pcBuildOrderDetailsView.DateTimeNow = DateTimeNow;
            if (!ModelState.IsValid)
            {
                return View();
            }
            var pcBuildOrder = new PcPartOrder
            {
                PartId = pcBuildOrderDetailsView.ID,
                Name = pcBuildOrderDetailsView.Name,
                Surname = pcBuildOrderDetailsView.Surname,
                Adress = pcBuildOrderDetailsView.Adress,
                PhoneNumber = pcBuildOrderDetailsView.PhoneNumber,
                Mail = pcBuildOrderDetailsView.Mail,
                PartName = pcBuildOrderDetailsView.BuildName,
                PartPrice = pcBuildOrderDetailsView.BuildPrice,
                DateTimeNow = pcBuildOrderDetailsView.DateTimeNow,
                PartOrBuild=pcBuildOrderDetailsView.PartOrBuild
            };
            _partOrder.CreateOrder(pcBuildOrder);
            _partOrder.SaveChange();
            return RedirectToAction("pclist");
        }
        [HttpGet]
        public ActionResult PcBuildOrderList()
        {
            var getOrders = _partOrder.GetOrderOnlyBuild();
            return View(getOrders);
        }
    }
}
