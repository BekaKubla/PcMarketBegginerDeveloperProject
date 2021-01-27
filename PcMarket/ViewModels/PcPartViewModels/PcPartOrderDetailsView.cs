using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels.PcPartViewModels
{
    public class PcPartOrderDetailsView : PcPartDetailsViewModel
    {
        [Required]
        [Display(Name = "სახელი")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "გვარი")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "მისამართი")]
        public string Adress { get; set; }
        [Required]
        [MaxLength(9, ErrorMessage = "გთხოვთ გადაამოწმოთ შეყვანილი ტელეფონის ნომერი")]
        [Display(Name = "ტელეფონის ნომერი")]
        public string PhoneNumber { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        [Display(Name = "საკონტაქტო ფოსტა")]
        public string Mail { get; set; }
    }
}
