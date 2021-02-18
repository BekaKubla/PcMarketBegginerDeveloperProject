using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels.PcComputerViewModel
{
    public class PcBuildOrderDetailsView : PcPartViewModels.PcPartOrderDetailsView
    {
        public int ID { get; set; }
        [Display(Name = "კომპიუტერის სახელი")]
        [Required]
        public string BuildName { get; set; }
        [Display(Name = "ფასი")]
        [Required]
        public string BuildPrice { get; set; }
    }
}
