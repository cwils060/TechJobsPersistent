using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;
       

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext; 
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> Employers = context.Employers.ToList();
             
            return View(Employers);
        }

        public IActionResult Add()
        {


            AddEmployerViewModel addEmployerModel = new AddEmployerViewModel();
               
        
            return View(addEmployerModel);
        }

        [HttpPost]
        public IActionResult ProcessAddEmployerForm( AddEmployerViewModel addEmployerModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerModel.Name,
                    Location = addEmployerModel.Location
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();

                return Redirect("/Employer");
            }
            return View( "Add", addEmployerModel);
        }

        public IActionResult About(int id)
        {
            
            Employer newEmployer = context.Employers
                .Find(id);
            context.SaveChanges();

            return View(newEmployer);
        }
    }
}
