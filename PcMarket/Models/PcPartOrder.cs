using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class PcPartOrder
    {
        public int Id { get; set; }
        [Display(Name = "პროდუქტის სრულად ნახვა")]
        public int PartId { get; set; }
        [Required]
        [Display(Name ="სახელი")]
        public string Name { get; set; }
        [Required]
        [Display(Name="გვარი")]
        public string Surname { get; set; }
        [Required]
        [Display(Name ="მისამართი")]
        public string Adress { get; set; }
        [Required]
        [MaxLength(9,ErrorMessage ="გთხოვთ გადაამოწმოთ შეყვანილი ტელეფონის ნომერი")]
        [Display(Name="ტელეფონის ნომერი")]
        public string PhoneNumber { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        [Display(Name="საკონტაქტო ფოსტა")]
        public string Mail { get; set; }
        [Display(Name="პროდუქტის დასახელება")]
        public string PartName { get; set; }
        [Display(Name="პროდუქტის ფასი")]
        public int PartPrice { get; set; }
        [Display(Name="შეკვეთის თარიღი")]
        public string DateTimeNow { get; set; }
    }
}
