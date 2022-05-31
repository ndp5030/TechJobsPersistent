using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {   
            AddJobViewModel addJobViewModel = new AddJobViewModel();
            addJobViewModel.Skills = context.Skills.ToList();
            return View(addJobViewModel);
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Employer registeredEmployer = context.Employers.Find(addJobViewModel.EmployerId);
                Job newjob = new Job
                {
                    Name = addJobViewModel.Name,
                    Id = registeredEmployer.Id
                };

                context.Jobs.Add(newjob);

                foreach (string skillId in selectedSkills)
                {
                    JobSkill newJobSkill = new JobSkill
                    {
                        SkillId = int.Parse(skillId),
                        JobId = newjob.Id
                    };
                context.JobSkills.Add(newJobSkill);
                }

                context.SaveChanges();
                return Redirect("/Home");
            }
            return View("AddJob", addJobViewModel);

        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
