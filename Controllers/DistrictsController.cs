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
    public class DistrictsController : Controller
    {
        private readonly PrePassContext _context;


        public DistrictsController(PrePassContext context)
        {
            _context = context;
        }

        // GET: Districts
        public async Task<IActionResult> Index(string eid)
        {
            Utils ul = new Utils(_context);

            return View(await _context.Districts.ToListAsync());
        }


        public IActionResult Create(string eid)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string eid, [Bind("DistrictID,DistrictName")] District district)
        {
            if (ModelState.IsValid)
            {
                _context.Database.EnsureCreated();

                District dist = new District() { DistrictID = district.DistrictID, DistrictName = district.DistrictName, Active = true };

                _context.Districts.Add(dist);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { eid = eid });
            }
            return View(district);
        }

        public async Task<IActionResult> Edit(int? id, string eid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string eid, [Bind("DistrictID,DistrictName,Active")] District district)
        {
            if (id != district.DistrictID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictExists(district.DistrictID))
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
            return View(district);
        }

        public bool DistrictExists(int id)
        {
            return _context.Districts.Any(e => e.DistrictID == id);
        }
    }
}
