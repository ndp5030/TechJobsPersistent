using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        // GET: /<controller>/
        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();

            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel employerViewModel = new AddEmployerViewModel();
            return View(employerViewModel);
        }

        [HttpPost]
        //[Route("/add")]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newemployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers.Add(newemployer);
                context.SaveChanges();
                return Redirect("/Employer");
            }
            return View("Add", addEmployerViewModel);
            
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }
    }
}
