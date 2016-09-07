using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeopleSearch.Data;
using PeopleSearch.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Create([Bind("ID,Address,Age,FirstName,Interests,LastName")] Person person, IFormFile uploadFIle)
        {
            if (ModelState.IsValid)
            {
                if (uploadFIle != null)
                {
                    using (var reader = new StreamReader(uploadFIle.OpenReadStream()))
                    {
                        var bytes = default(byte[]);
                        using (var memstream = new MemoryStream())
                        {
                            reader.BaseStream.CopyTo(memstream);
                            bytes = memstream.ToArray();

                        }

                        person.Picture = bytes;
                    }
                }

                _context.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}
