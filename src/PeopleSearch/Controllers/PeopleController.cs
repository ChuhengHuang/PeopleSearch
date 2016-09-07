using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Data;
using PeopleSearch.Models;

namespace PeopleSearch.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: People/Index
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //GET: P//eople/Index
        public JsonResult SearchPeople(string searchString)
        {   
            var people = from p in _context.Person
                             select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            return Json(people);
        }       

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Address,Age,FirstName,Interests,LastName,Picture")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }    
    }
}
