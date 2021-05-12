using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrePass.ActionFilters;
using PrePass.Data;
using PrePass.Models;
using PrePass.Models.ViewModels;
using PrePass.Utilities;

namespace PrePass.Controllers
{
    [EidActionFilter]
    public class ApplicantsController : Controller
    {
        private readonly PrePassContext _context;

        public ApplicantsController(PrePassContext context)
        {
            _context = context;
        }
         

        // GET: Applicants
        public async Task<IActionResult> Index(string? eid, string AssessID, string srch, bool sta)
        {
            Utils ul = new Utils(_context);
            ViewBag.AssessID = AssessID;
            ViewBag.searchtext = srch;
            ViewBag.sta = sta;

            List<ApplicantVM> flist = await (from Applicant in _context.Applicants
                                             join Staff in _context.Staff on Applicant.EmpID equals Staff.EmpID
                                             where EF.Functions.Like(Applicant.LName, srch + "%")
                                             || EF.Functions.Like(Applicant.FName, srch + "%")
                                             || Applicant.DateOfBirth.Year.ToString() == srch
                                             orderby Applicant.LName
                                             select new ApplicantVM()
                                             {
                                                 applicant = Applicant,
                                                 staff = Staff
                                             }).ToListAsync();


            var filteredlist = flist.Take(20);

            if (filteredlist.Count() == 0) 
            {
                ViewBag.message = "Search has returned 0 results. Please try a different search.";
            }
            else if(filteredlist.Count() == 20)
            {
                ViewBag.message = "Search has returned more than 20 results. Please refine your search.";
            }
            else
            {
                ViewBag.message = "Search has returned " + filteredlist.Count() + " results.";
            }

            return View(filteredlist.ToList());
        }

        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(int? id, string eid, string AssessID, bool sta)
        {
            ViewBag.AssessID = AssessID;
            ViewBag.sta = sta;

            if (id == null)
            {
                return NotFound();
            }

            var query = await (from Applicant in _context.Applicants
                                             join Staff in _context.Staff on Applicant.EmpID equals Staff.EmpID
                                             select new ApplicantVM()
                                             {
                                                 applicant = Applicant,
                                                 staff = Staff
                                             }).ToListAsync();


            var applicant = query.FirstOrDefault(m => m.applicant.AppID == id);

            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }


        // GET: Applicants/Create?eid=XXX123
        public IActionResult Create(string eid, string AssessID, bool sta)
        {
            ViewBag.AssessID = AssessID;
            ViewBag.sta = sta;
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string eid, string AssessID, [Bind("AppID, PPSN, LName, FName, DateOfBirth,ContactNumber,LastKnownAddress,Gender,Ethnicity,EmpID")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                Applicant app = new Applicant() { AppID = applicant.AppID, PPSN = applicant.PPSN, LName = applicant.LName, FName = applicant.FName,
                    DateOfBirth = applicant.DateOfBirth,
                    ContactNumber = applicant.ContactNumber, LastKnownAddress = applicant.LastKnownAddress,
                    Gender = applicant.Gender, Ethnicity =  applicant.Ethnicity, LastUpdated = DateTime.Now, EmpID = applicant.EmpID.ToUpper(),
                    Active = true };

                _context.Applicants.Add(app);
                await _context.SaveChangesAsync();

                return RedirectToAction( "Create","Assessments", new { eid = eid, appid = app.AppID });
            }
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        // http://localhost:xxxx/Applicants/Edit/1?eid=A123
        public async Task<IActionResult> Edit(int? id, string? eid, string AssessID, bool sta)
        {
            ViewBag.AssessID = AssessID;
            ViewBag.sta = sta;

            if (id == null)
            {
                return NotFound();
            }


            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(applicant.EmpID);

            ViewBag.staffname = staff.Name;

            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string eid, bool sta, string AssessID, [Bind("AppID,PPSN,EmpID, LName, FName, DateOfBirth, ContactNumber, LastKnownAddress, Gender, Ethnicity, StaffMemberID,Active")] Applicant applicant)
        {
            if (id != applicant.AppID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Applicant appl = new Applicant()
                    {
                        AppID = applicant.AppID,
                        PPSN = applicant.PPSN,
                        LName = applicant.LName,
                        FName = applicant.FName,
                        DateOfBirth = applicant.DateOfBirth,
                        ContactNumber = applicant.ContactNumber,
                        LastKnownAddress = applicant.LastKnownAddress,
                        Gender = applicant.Gender,
                        Ethnicity = applicant.Ethnicity,
                        LastUpdated = DateTime.Now,
                        EmpID = applicant.EmpID.ToUpper(),
                        Active = applicant.Active
                    };

                    _context.Update(appl); 
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(applicant.AppID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { eid = eid, AssessID  = AssessID, sta = sta });
            }
           
            return View(applicant);
        }

        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.AppID == id);
        }
    }
}
