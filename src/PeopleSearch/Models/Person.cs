using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
    //First Name, Last Name, address, age, interests, and  a picture
    public class Person
    {
        public int ID { get; set; } // the ID field is required by the DB
        [Required]       
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]       
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Interests { get; set; }
        public byte[] Picture { get; set; } // For store the image in database
        public string ImageScr { get; set; }  //For display the image
    }
}
