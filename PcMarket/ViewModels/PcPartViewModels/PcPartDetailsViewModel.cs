using Microsoft.AspNetCore.Http;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels
{
    public class PcPartDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name ="პროდუქტის სრულად ნახვა")]
        public int PartId { get; set; }
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
        public string PartPrice { get; set; }
        [Display(Name = "აღწერა")]
        [Required]
        [MaxLength(450)]
        public string PartDescribtion { get; set; }
        public string ImageFile { get; set; }
        [Display(Name = "ნივთის კატეგორია კატეგორია")]
        [Required]
        public PartOrBuild? PartOrBuild { get; set; }
    }
}
