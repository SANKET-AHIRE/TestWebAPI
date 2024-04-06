using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebAPI.Models
{
    public class Request_Employee
    {
   
     [Display(Name ="Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        public string Mobile { get; set; }


        [Display(Name = "E-mailID")]
        [Required(ErrorMessage = "E-mailID is required")]
       [EmailAddress]
        public string EmailID { get; set; }

    
    }
}