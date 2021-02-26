using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Models
{
    public class User
    {
        [Required,MinLength(2,ErrorMessage ="შეყვანილი ინფორმაცია არ შეესაბამება სტანდარტებს")]
        public string UserName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),Required,MinLength(4,ErrorMessage ="პაროლი უნდა შეიცავდეს მინიმუმ 4 სიმბოლოს")]
        public string Password { get; set; }
        public User() { }
        public User(AppUser appUser)
        {
            UserName = appUser.UserName;
            Email = appUser.Email;
            Password = appUser.PasswordHash;
        }
    }
}
