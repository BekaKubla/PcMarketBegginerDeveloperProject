using Microsoft.AspNetCore.Http;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels
{
    public class PcPartCreateViewModel
    {
        [Required]
        [Display(Name = "ნივთის სახელი")]
        public string PartName { get; set; }
        [Required]
        [Display(Name = "მდგომარეობა")]
        public Condition PartCondition { get; set; }
        [Required]
        [Display(Name = "კატეგორია")]
        public Category PartCategory { get; set; }
        [Required]
        [Display(Name = "ფასი")]
        public int PartPrice { get; set; }
        [Display(Name = "აღწერა")]
        [Required]
        [MaxLength(450)]
        public string PartDescribtion { get; set; }
        [NotMapped]
        [Display(Name ="ფოტო")]
        public IFormFile ImageFile { get; set; }
    }
}
