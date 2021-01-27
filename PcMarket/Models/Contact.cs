using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class Contact
    {
        [Required(ErrorMessage ="*** სახელის შეყვანა აუცილებელია")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="*** გვარის შეყვანა აუცილებელია")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="*** ელ-ფოსტა აუცილებელია")]
        public string Mail { get; set; }
        [Required(ErrorMessage ="*** სათაურის მითითება აუცილებელია")]
        public string Title { get; set; }
        [Required(ErrorMessage ="*** აუცილებელია შეიყვანოთ ტექსტი")]
        public string Subject { get; set; }
    }
}
