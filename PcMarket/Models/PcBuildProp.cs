using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class PcBuildProp
    {
        public int ID { get; set; }
        [Display(Name ="დედაპლატა")]
        [Required]
        public string MotherBoard { get; set; }
        [Display(Name ="პროცესორი")]
        [Required]
        public string Cpu { get; set; }
        [Display(Name ="გაგრილება")]
        [Required]
        public string Cooling { get; set; }
        [Display(Name ="ოპერატიული მეხსიერება")]
        [Required]
        public string Ram { get; set; }
        [Display(Name ="ვიდეო კარტა")]
        [Required]
        public string Gpu { get; set; }
        [Display(Name ="SSD ვინჩესტერი")]
        [Required]
        public string Ssd { get; set; }
        [Display(Name ="HDD ვინჩესტერი")]
        [Required]
        public string Hdd { get; set; }
        [Display(Name ="კვების ბლოკი")]
        [Required]
        public string Psu { get; set; }
        [Display(Name ="კეისი")]
        [Required]
        public string Case { get; set; }
        [Display(Name ="სისტემა")]
        [Required]
        public string System { get; set; }
        [Display(Name ="აღწერა")]
        [MaxLength(150)]
        public string Describtion { get; set; }
    }
}
