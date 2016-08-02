using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ocassion.Models
{
    public class LoginVM
    {
        public LoginVM()
        {
            login = new loginProperty();
            registration = new UserRegistration();
        }
       public loginProperty login { get; set; }
       public UserRegistration registration { get; set; }

    }


    public class loginProperty
    {   
        [Required(ErrorMessage="Please Enter Email Address.")]
        [EmailAddress(ErrorMessage="Invalid Email Address.")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password.")]
        [StringLength(20)]
        public string password { get; set; }
    }
    public class UserRegistration
    {
        [Required(ErrorMessage = "Please Enter UserEmail")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [Range(8,20,ErrorMessage="Password must be more than 8 digit")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Compare("password", ErrorMessage = "Password does not match.")]
        public string confirmpassword { get; set; }

         [Required(ErrorMessage = "Please Enter MobileNumber.")]
         [StringLength(10, ErrorMessage = "The Mobile must contains 10 degits")]
        public string MobileNO { get; set; }
    }
}

