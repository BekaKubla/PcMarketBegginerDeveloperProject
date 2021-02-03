﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PcMarket.Models;
using PcMarket.Repositories;
using PcMarket.ViewModels;
using PcMarket.ViewModels.PcPartViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Controllers
{
    public class PcPartController :Controller
    {
        private readonly IPcPartRepos _pcRepo;
        private readonly IPcPartOrderRepo _PcPartOrder;
        private readonly IWebHostEnvironment _webHost;

        public PcPartController(IPcPartRepos pcRepo,IPcPartOrderRepo pcPartOrder,IWebHostEnvironment webHost)
        {
            _pcRepo = pcRepo;
            _PcPartOrder = pcPartOrder;
            this._webHost = webHost;
        }
        [HttpGet]
        public ActionResult List()
        {
            var getAll = _pcRepo.GetAllParts();
            return View(getAll);
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
                pcPartDetailsViewModel.ImageFile = getID.FileName;
            }
            return View(pcPartDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
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
                FileName = stringFileName
            };
            _pcRepo.CreatePart(pcPart);
            _pcRepo.SaveChange();
            return RedirectToAction("list");
        }

        private string UploadFile(PcPartCreateViewModel pcPartCreateViewModel)
        {
            string fileName = null;
            if (pcPartCreateViewModel.ImageFile != null)
            {
                string uploadDir = Path.Combine(_webHost.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + pcPartCreateViewModel.ImageFile.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream=new FileStream(filePath, FileMode.Create))
                {
                    pcPartCreateViewModel.ImageFile.CopyTo(fileStream);
                }
            }
            
            return fileName;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var findCar = _pcRepo.GetPartByID(id);
            if (findCar == null)
            {
                return NotFound();
            }
            _pcRepo.DeletePart(findCar);
            _pcRepo.SaveChange();
            return RedirectToAction("list");
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
            return View(pcPartEditViewModel);

        }
        [HttpPost]
        public IActionResult Edit(PcPartEditViewModel pcPartEditViewModel,int id)
        {
            var findPart = _pcRepo.GetPartByID(id);
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
                _pcRepo.SaveChange();
            }
            return RedirectToAction("details", new { id = findPart.ID });
        }
        [HttpGet]
        public ActionResult Order(int id, PcPartOrderDetailsView pcPartOrderDetailsView)
        {
            var getId = _pcRepo.GetPartByID(id);
            if (getId == null)
            {
                return NotFound();
            }
            pcPartOrderDetailsView.PartName = getId.PartName;
            pcPartOrderDetailsView.PartCondition = getId.PartCondition;
            pcPartOrderDetailsView.PartPrice = getId.PartPrice;
            return View(pcPartOrderDetailsView);
        }
        [HttpPost]
        public IActionResult Order(PcPartOrderDetailsView pcPartOrderDetailsView)
        {
            var getId = _pcRepo.GetPartByID(pcPartOrderDetailsView.Id);
            pcPartOrderDetailsView.PartId = getId.ID;
            pcPartOrderDetailsView.PartName = getId.PartName;
            pcPartOrderDetailsView.PartCondition = getId.PartCondition;
            pcPartOrderDetailsView.PartPrice = getId.PartPrice;
            var datetimeNow = DateTime.Now.ToString("dd/MMMM/yyyy HH:mm");
            pcPartOrderDetailsView.DateTimeNow = datetimeNow;
            if (ModelState.IsValid)
            {
                return View();
            }
            var orderProp = new PcPartOrder
            {
                PartId = pcPartOrderDetailsView.PartId,
                Name = pcPartOrderDetailsView.Name,
                Surname = pcPartOrderDetailsView.Surname,
                Adress = pcPartOrderDetailsView.Adress,
                PhoneNumber = pcPartOrderDetailsView.PhoneNumber,
                Mail = pcPartOrderDetailsView.Mail,
                PartName = pcPartOrderDetailsView.PartName,
                PartPrice = pcPartOrderDetailsView.PartPrice,
                DateTimeNow = pcPartOrderDetailsView.DateTimeNow
            };
            _PcPartOrder.CreateOrder(orderProp);
            _PcPartOrder.SaveChange();
            return RedirectToAction("orderlist");
        }
        [HttpGet]
        public ActionResult OrderList()
        {
            var model = _PcPartOrder.GetAllOrder();
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {

            var findOrder = _PcPartOrder.GetOrderById(id);
            if (findOrder == null)
            {
                return NotFound();
            }
            _PcPartOrder.DeleteOrder(findOrder);
            _PcPartOrder.SaveChange();
            return RedirectToAction("OrderList");
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(contact.Mail, "infopcmarketgeo@gmail.com"));
            message.To.Add(new MailboxAddress(contact.Title, "infopcmarketgeo@gmail.com"));
            message.Subject = contact.Title;
            message.Body = new TextPart("plain")
            {
                Text = contact.Subject + "\n" +"\n" +"ადრესატის სახელი და გვარი : " + contact.FirstName +" "+ contact.LastName
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("infopcmarketgeo@gmail.com", "87*z7>YMH~>aPuR>");
                client.Send(message);
                client.Disconnect(true);
            }
            return RedirectToAction("list");
        }
    }
}
