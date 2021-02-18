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
        [Required(ErrorMessage = "*** შეიყვანეთ სახელი")]
        [Display(Name = "ნივთის სახელი")]
        public string PartName { get; set; }
        [Required(ErrorMessage = "*** აირჩიეთ მდგომარეობა")]
        [Display(Name = "მდგომარეობა")]
        public Condition PartCondition { get; set; }
        [Required(ErrorMessage = "*** აირჩიეთ კატეგორია")]
        [Display(Name = "კატეგორია")]
        public Category PartCategory { get; set; }
        [Required(ErrorMessage ="aeee")]
        [Display(Name = "ფასი")]
        public double PartPrice { get; set; }
        [Display(Name = "აღწერა")]
        [Required(ErrorMessage = "*** აუცილებელია დაწერეთ ნივთის აღწერა")]
        [MaxLength(450)]
        public string PartDescribtion { get; set; }
        [NotMapped]
        [Display(Name ="ფოტო")]
        public IFormFile ImageFile { get; set; }
        [Display(Name ="კატეგორია")]
        [Required]
        public PartOrBuild PartOrBuild { get; set; }
    }
}
