using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class Login
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),Required,MinLength(4,ErrorMessage ="პაროლი უნდა შეიცავდეს მინიმუმ 4 სიმბოლოს")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
