using Microsoft.AspNetCore.Http;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels
{
    public class PcComputerCreateViewModel
    {
        public int ID { get; set; }
        [Display(Name = "კომპიუტერის სახელი")]
        [Required]
        public string BuildName { get; set; }
        [Display(Name = "პროცესორის ტიპი")]
        [Required]
        public ProcesorType ProcesorType { get; set; }
        [Display(Name = "პროცესორის სახელი")]
        [Required]
        public string ProcesorName { get; set; }
        [Display(Name = "დედა დაფის სახელი")]
        [Required]
        public string Motherboard { get; set; }
        [Display(Name = "მეხსიერების მოდულის ტიპი")]
        [Required]
        public MemoryType MemoryType { get; set; }
        [Display(Name = "მეხსიერების მოდულის სახელი")]
        [Required]
        public string MemoryName { get; set; }
        [Display(Name = "ვინჩესტერის ტიპი")]
        [Required]
        public StorageType StorageType { get; set; }
        [Display(Name = "ვინჩესტერის სახელი")]
        [Required]
        public string StorageName { get; set; }
        [Display(Name = "ვიდეო დაფის ტიპი")]
        [Required]
        public GPUType GPUType { get; set; }
        [Display(Name = "ვიდეო დაფის სახელი")]
        [Required]
        public string GPUName { get; set; }
        [Display(Name = "კეისის სახელი")]
        [Required]
        public string Case { get; set; }
        [Display(Name = "კვების ბლოკის სახელი")]
        [Required]
        public string PowerSupply { get; set; }
        [Display(Name = "ფასი")]
        [Required]
        public int BuildPrice { get; set; }
        [Display(Name = "აღწერა")]
        [Required]
        public string CustomDescription { get; set; }
        [Display(Name ="კომპიუტერის მონაცემები")]
        public string AutoDescription { get; set; }
        [Display(Name ="ფოტო")]
        public IFormFile FileName { get; set; }
        [Display(Name = "ფოტო")]
        public string StringFileName { get; set; }
        [Display(Name = "ნივთის კატეგორია კატეგორია")]
        [Required]
        public new PartOrBuild PartOrBuild { get; set; }
    }
}
