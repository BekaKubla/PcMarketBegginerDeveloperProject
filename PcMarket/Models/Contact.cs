using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class Contact
    {
        [Display(Name ="სახელი")]
        public string FirstName { get; set; }
        [Display(Name ="გვარი")]
        public string LastName { get; set; }
        [Display(Name ="ელ-ფოსტა")]
        public string Mail { get; set; }
        [Display(Name ="შეტყობინება")]
        public string Subject { get; set; }
    }
}
