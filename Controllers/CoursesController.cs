using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityWebApp.Data;
using UniversityWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityWebApp.Controllers
{
    public class CoursesController : Controller
    {

        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            this._context = context;
        }

        // GET:  Courses
        public async Task<IActionResult> Index()
        {
            var courses = _context.Courses
                .Include(c => c.Department)
                .AsNoTracking();
            return View(await courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
