using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
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
    public class StaffsController : Controller
    {
        private readonly PrePassContext _context;
        public StaffsController(PrePassContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string eid)
        {
            return View(await _context.Staff.OrderBy(p => p.Name).ToListAsync());
        }


        // Code below only run when using local database, commented out when database created on Azure
        public async Task<IActionResult> SeedDB()
        {
            if (ModelState.IsValid)
            {
                _context.Database.EnsureCreated();

                //_context.Applicants.Add(new Applicant()
                //{
                //    AppID = 0,
                //    LName = "Brown",
                //    FName = "Michael",
                //    PPSN = "66677T",
                //    DateOfBirth = DateTime.Parse("Jan 20, 1976"),
                //    ContactNumber = "088-123456",
                //    LastKnownAddress = "10 Main St, Naas",
                //    Gender = GenderType.Male,
                //    Ethnicity = EthnicType.Asian_Chinese,
                //    LastUpdated = DateTime.Now,
                //    EmpID = "A123",
                //    Active = true
                //}); 


                //_context.Staff.Add(new Staff() { 
                //    EmpID = "A123", 
                //    Name = "Dave Smyth",
                //    Email = "mb@gmail.com",
                //    Passwd = "Davy345!",
                //    accessLevel = AccessType.Manager, 
                //    Active = true });

                ////_context.AssessApplics.Add(new AssessApplic() { ID = 0, AssessID = "1234", AppID = 1 });

                //_context.Districts.Add(new District()
                //{
                //    DistrictID = 0,
                //    DistrictName = "Naas",                    
                //});

                //_context.Assessments.Add(new Assessment()
                //{
                //    AssessID = 0,
                //    AppID = 1,
                //    EmpID = "A123",
                //    DateCreated = DateTime.Now,
                //    LastUpdated = DateTime.Now,
                //    HousingRef = "A3422F",
                //    DistrictID = 1,
                //    Reason = PresReason.Cannot_afford_Rent,
                //    CriminalOff = true,
                //    Household = HouseholdType.Single,
                //    Income = IncomeType.Employed,
                //    ChildrenUnder18 = 4,
                //    ChildrenOver18 = 0,
                //    Addiction = AddictionType.Currently_receiving_treatment_for_active_addiction,
                //    HealthConditions = "Big nose",
                //    LegalIssues = true,
                //    TempRelease = true,
                //    ProbationOfficer = true,
                //    SocialWorker = true,
                //    DeptSocial = true,
                //    AddictionSvcs = true,
                //    MHCT = true,
                //    DoctorGP = true,
                //    Keyworker = true,
                //    OtherSupports = "Tusla",
                //    SupprtsReferred = "Hospital",
                //    FurtherInfo = "Further info here",
                //    Status = StatusType.Ongoing
                //});


                await _context.SaveChangesAsync();
            }

            return RedirectToAction("index");
        }

 

        // GET: Staffs/Create
        public IActionResult Create(string eid)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string eid, [Bind("EmpID,Name,Email,accessLevel")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Database.EnsureCreated();

                staff.EmpID = staff.EmpID.ToUpper();

                // generate password
                var rand = new Random();
                staff.Passwd = rand.Next(100000, 999999).ToString();

                staff.Active = true;

                try 
                {
                    _context.Staff.Add(staff);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index), new { eid = eid });
                }
                catch(Exception)
                {
                    ViewBag.message = "Could not create Staff Member record. You may have entered a duplicate Employee ID.";
                }
            }
            return View(staff);
        }


        // GET: Staffs/Edit
        public async Task<IActionResult> Edit(string id, string eid)
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

            ViewBag.id = id;
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string eid, [Bind("EmpID,Name,Email,Passwd,accessLevel,Active")] Staff staff)
        {
            ViewBag.id = id;

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
            return _context.Staff.Any(e => e.EmpID == id);
        }
    }
}
