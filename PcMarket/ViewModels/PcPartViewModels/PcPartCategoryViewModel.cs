using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels.PcPartViewModels
{
    public class PcPartCategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "*** შეიყვანეთ სახელი")]
        [Display(Name = "ნივთის სახელი")]
        public string PartName { get; set; }
        [Required(ErrorMessage = "*** აირჩიეთ მდგომარეობა")]
        [Display(Name = "მდგომარეობა")]
        public Condition PartCondition { get; set; }
        [Required(ErrorMessage = "*** აირჩიეთ კატეგორია")]
        [Display(Name = "კატეგორია")]
        public Category PartCategory { get; set; }
        [Range(0, 100000, ErrorMessage = "გთხოვთ მიუთითეთ ფასი")]
        [Display(Name = "ფასი")]
        public int PartPrice { get; set; }
        [Display(Name = "აღწერა")]
        [Required(ErrorMessage = "*** აუცილებელია დაწერეთ ნივთის აღწერა")]
        [MaxLength(450)]
        public string PartDescribtion { get; set; }
        public string FileName { get; set; }
    }
}
