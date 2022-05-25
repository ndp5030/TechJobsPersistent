using System;
using TechJobsPersistent.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        // Employer has constructor (string name, string location)
        // Can I do?
        //public AddEmployerViewModel(Employer theEmployer)
        //{
            
        //}
        //     OR....
        //public AddEmployerViewModel(string Name, string Location)
        //{
        //    Name = name;
        //    Location = location;
        //}



    }
}
