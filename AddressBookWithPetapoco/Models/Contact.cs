using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBookWithPetapoco.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(\\+\\d{1,3}[- ]?)?\\d{10}$", ErrorMessage = "Please Enter Valid Mobile Number")]
        public string Mobile { get; set; }

        public string Landline { get; set; }

        [Required]
        [RegularExpression("^(https:\\/\\/)?(www.)?([a-zA-Z0-9]+).[a-zA-Z0-9]*.[a-z]{3}.?([a-z]+)?$", ErrorMessage = "Please Enter Valid Website Address")]
        public string Website { get; set; }

        public string Address { get; set; }
    }
}