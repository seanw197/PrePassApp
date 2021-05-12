using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrePass.ActionFilters;
using PrePass.Data;
using PrePass.Models;
using PrePass.Utilities;

namespace PrePass.Controllers
{
    [EidActionFilter]
    public class AssessorsController : Controller
    {
        private readonly PrePassContext _context;

        public AssessorsController(PrePassContext context)
        {
            _context = context;
        }

        // GET: Assessor
        public async Task<IActionResult> Index(string eid)
        {
            Utils ul = new Utils(_context);

            AccessType access_level = AccessType.Assessor;

            var assessor = from m in _context.Staff
                         select m;

            assessor = assessor.Where(s => s.accessLevel.Equals(access_level));

            return View(await assessor.ToListAsync());
        }

 
        
        public IActionResult Create(string eid)
        {
            return View();
        }

        
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string eid, [Bind("EmpID,Name,Email")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Database.EnsureCreated();

                // generating unique password here

                staff.EmpID = staff.EmpID.ToUpper();

                // generate password
                var rand = new Random();
                string passw = rand.Next(100000, 999999).ToString();

                Staff st = new Staff() { EmpID = staff.EmpID.ToUpper(), Name = staff.Name, Email = staff.Email, Passwd = passw, accessLevel = AccessType.Assessor, Active = true };

                try
                {
                    _context.Staff.Add(st);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index), new { eid = eid });
                }
                catch (Exception)
                {
                    ViewBag.message = "Could not create Assessor record. You may have entered a duplicate Employee ID.";
                }
            }
            return View(staff);
        }

        public async Task<IActionResult> Edit(string eid, string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string eid, [Bind("EmpID,Name,Email, Passwd, accessLevel,Active")] Staff staff)
         {
            if (id != staff.EmpID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.EmpID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(Index), new { eid = eid });
            }
            return View(staff);
        }


        private bool StaffExists(string id)
        {
            return _context.Staff.Any(e => e.EmpID.ToUpper() == id);
        }
    }
}
