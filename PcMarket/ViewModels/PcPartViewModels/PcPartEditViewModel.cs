using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels.PcPartViewModels
{
    public class PcPartEditViewModel
    {
        public int ID { get; set; }
        [Display(Name = "ნივთის სახელი")]
        public string PartName { get; set; }
        [Display(Name = "მდგომარეობა")]
        public Condition PartCondition { get; set; }
        [Display(Name = "კატეგორია")]
        public Category PartCategory { get; set; }
        [Display(Name = "ფასი")]
        public int PartPrice { get; set; }
        [Display(Name = "აღწერა")]
        [MaxLength(450)]
        public string PartDescribtion { get; set; }
    }
}
