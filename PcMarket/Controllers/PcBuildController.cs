using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PcMarket.Models;
using PcMarket.Repositories;
using PcMarket.ViewModels;
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
        private readonly IWebHostEnvironment _host;

        public PcBuildController(IPcBuildRepo pcBuildRepo,IWebHostEnvironment host)
        {
            _pcBuild = pcBuildRepo;
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
    }
}
