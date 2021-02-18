using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.ViewModels.PcPartViewModels
{
    public class PcPartOrderDetailsView : PcPartDetailsViewModel
    {
        [Required(ErrorMessage ="სახელი აუცილებელია")]
        [Display(Name = "სახელი")]
        public string Name { get; set; }
        [Required(ErrorMessage ="გვარი აუცილებელია")]
        [Display(Name = "გვარი")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="მისამართი აუცილებელია")]
        [Display(Name = "მისამართი")]
        public string Adress { get; set; }
        [Required(ErrorMessage ="ტელეფონის ნომერი აუცილებელია")]
        [MaxLength(9, ErrorMessage = "გთხოვთ გადაამოწმოთ შეყვანილი ტელეფონის ნომერი")]
        [Display(Name = "ტელეფონის ნომერი")]
        public string PhoneNumber { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "მეილი არასწორია")]
        [Required(ErrorMessage ="საკონტაქტო ელ-ფოსტა აუცილებელია")]
        [Display(Name = "საკონტაქტო ფოსტა")]
        public string Mail { get; set; }
        [Display(Name = "შეკვეთის თარიღი")]
        public string DateTimeNow { get; set; }
    }
}
