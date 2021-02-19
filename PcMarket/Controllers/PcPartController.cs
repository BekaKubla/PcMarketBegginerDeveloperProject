using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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
    public class PcPartController :Controller
    { 

        private readonly IPcPartRepos _pcRepo;


        public PcPartController(IPcPartRepos pcRepo)
        {
            _pcRepo = pcRepo;
        }
        [HttpGet]
        public ActionResult List([FromQuery]Category? category)
        {
            var getAll = _pcRepo.GetAllParts(category);
            if (category != null)
            {
                ViewBag.Title = category.DisplayName();
            }
            else
            {
                ViewBag.Title = "ნაწილები";
            }
            return View(getAll);
        }
        
        [HttpGet]
        public ActionResult Details(int id)
        {
            var getID = _pcRepo.GetPartByID(id);
            PcPartDetailsViewModel pcPartDetailsViewModel = new PcPartDetailsViewModel();
            if (getID == null)
            {
                return NotFound();
            }
            else
            {
                pcPartDetailsViewModel.Id = getID.ID;
                pcPartDetailsViewModel.PartName = getID.PartName;
                pcPartDetailsViewModel.PartCondition = getID.PartCondition;
                pcPartDetailsViewModel.PartCategory = getID.PartCategory;
                //pcPartDetailsViewModel.PartPrice = getID.PartPrice;
                pcPartDetailsViewModel.PartDescribtion = getID.PartDescribtion;
                pcPartDetailsViewModel.ImageFile = getID.FileName;
            }
            return View(pcPartDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Contact() => View();
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
