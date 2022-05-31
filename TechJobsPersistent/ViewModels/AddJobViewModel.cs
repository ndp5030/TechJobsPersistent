using System;
using TechJobsPersistent.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "EmployerId is required")]
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers { get; set; }
        public List<Skill> Skills { get; set; }

        public AddJobViewModel(List<Employer> registeredEmployers, List<Skill> selectedSkills)
        {
            Employers = new List<SelectListItem>();

            foreach (var employer in registeredEmployers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }

            Skills = selectedSkills;
        }

        public AddJobViewModel() { }
    }
}
