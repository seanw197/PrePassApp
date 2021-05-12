using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrePass.Data;
using PrePass.Models;
using System.Data.SqlClient;
using PrePass.Utilities;
using System.Net.Http;
using System.Globalization;
using PrePass.ActionFilters;

namespace PrePass.Controllers
{
    [EidActionFilter]
    public class AssessmentsController : Controller
    {
        private readonly PrePassContext _context;

        public AssessmentsController(PrePassContext context)
        {
            _context = context;
        }
 

        // GET: Assessments
        //public async Task<IActionResult> Index(string eid, StatusType stat, string sdate, string edate)
        public async Task<IActionResult> Index(string eid, int? stat, string sd, string ed)
        {
            ViewBag.stat = stat;
         
            // check user permissions

            Utils ul = new Utils(_context);

            DateTime[] dat = ul.CheckDates(sd, ed);
            DateTime sdate = dat[0];
            DateTime edate = dat[1];

            ViewBag.startdate = sdate.ToString("d/M/yyyy");
            ViewBag.enddate = edate.ToString("d/M/yyyy");

            // retrieve assessor's name, assessor name and district name for displaying in list of assessments

            var query = GetAssessmentDetails();

            int allstatus = 100;

            if (stat == null)
            {
                allstatus = -1;
            }

            var flist = from p in query
                        where p.assessment.LastUpdated >= sdate && p.assessment.LastUpdated <= edate
                        && ((int)p.assessment.Status == stat || (int)p.assessment.Status > allstatus)
                        orderby p.assessment.LastUpdated descending
                        select p;

            var filteredlist = flist.Take(20);

            if (filteredlist.Count() == 0)
            {
                ViewBag.message = "Search has returned 0 results. Please try a different search.";
            }
            else if (filteredlist.Count() == 20)
            {
                ViewBag.message = "Search has returned more than 20 results. Please refine your search.";
            }
            else
            {
                ViewBag.message = "Search has returned " + filteredlist.Count() + " results.";
            }

            return View(filteredlist.ToList());
        }

        // GET: Assessments/Details/5
        public async Task<IActionResult> Details(int id, string eid)
        {
            Utils ul = new Utils(_context);

            if (id == null)
            {
                return NotFound();
            }

            var joinquery = GetAssessmentDetails();

            var assessment = joinquery.FirstOrDefault(m => m.assessment.AssessID == id);

            if (assessment == null)
            {
                return NotFound();
            }

             return View(assessment);
        }


        // create AssessmentDetailsVM

        public List<AssessmentDetailsVM> GetAssessmentDetails()
        {
 
            var query = (from Assessment in _context.Assessments
                         join Staff in _context.Staff on Assessment.EmpID equals Staff.EmpID
                         join District in _context.Districts on Assessment.DistrictID equals District.DistrictID
                         join Applicant in _context.Applicants on Assessment.AppID equals Applicant.AppID
                         select new AssessmentDetailsVM()
                         {
                             applicant = Applicant,
                             AssessorName = Staff.Name,
                             DistrictName = District.DistrictName,
                             assessment = Assessment
                         });

            var asn = query.ToList();

            return asn;
        }


        // create viewmodel
         public AssessmentVM CreateViewModel(int? id)
        {
            var model = new AssessmentVM();

            var dlist = from p in _context.Districts
                        where p.Active == true
                        orderby p.DistrictID
                        select new { p.DistrictID, p.DistrictName };

            model.Dist_list = dlist.Select(c => new SelectListItem
            {
                Text = c.DistrictName,
                Value = c.DistrictID.ToString()
            }).ToList();

            model.Dist_list.Insert(0, new SelectListItem { Text = "Select Local Authority", Value = "" });

            if (id != null)
            {
                model.Assm = _context.Assessments.FirstOrDefault(a => a.AssessID == id);
                model.Appl = _context.Applicants.FirstOrDefault(a => a.AppID == model.Assm.AppID);
            }

            return model;
        }

        // GET: Assessments/Create
        public IActionResult Create(string eid, int? appid)
        {
            Utils ul = new Utils(_context);

            var vmodel = CreateViewModel(null);

            ViewBag.AppID = appid;

            return View(vmodel);
        }


        // POST: Assessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string eid, int AssessID, int appid, AssessmentVM vmodel)
        {      
            DateTime curr = DateTime.Now;

            Utils ul = new Utils(_context);

            var mymodel = CreateViewModel(null);

            vmodel.Dist_list = mymodel.Dist_list;  //vmodel returns with dist_list null, repopulate it here

                Assessment assessment = new Assessment()
                {
                    AssessID = 0,
                    EmpID = vmodel.Assm.EmpID.ToUpper(),
                    AppID = vmodel.Assm.AppID,
                    DateCreated = curr,
                    LastUpdated = curr,
                    HousingRef = vmodel.Assm.HousingRef,
                    DistrictID = vmodel.Assm.DistrictID,
                    Reason = vmodel.Assm.Reason,
                    CriminalOff = vmodel.Assm.CriminalOff,
                    Household = vmodel.Assm.Household,
                    Income = vmodel.Assm.Income,
                    ChildrenUnder18 = vmodel.Assm.ChildrenUnder18,
                    ChildrenOver18 = vmodel.Assm.ChildrenOver18,
                    Addiction = vmodel.Assm.Addiction,
                    HealthConditions = vmodel.Assm.HealthConditions,
                    LegalIssues = vmodel.Assm.LegalIssues,
                    TempRelease = vmodel.Assm.TempRelease,
                    ProbationOfficer = vmodel.Assm.ProbationOfficer,
                    SocialWorker = vmodel.Assm.SocialWorker,
                    DeptSocial = vmodel.Assm.DeptSocial,
                    AddictionSvcs = vmodel.Assm.AddictionSvcs,
                    MHCT = vmodel.Assm.MHCT,
                    DoctorGP = vmodel.Assm.DoctorGP,
                    Keyworker = vmodel.Assm.Keyworker,
                    OtherSupports = vmodel.Assm.OtherSupports,
                    SupprtsReferred = vmodel.Assm.SupprtsReferred,
                    FurtherInfo = vmodel.Assm.FurtherInfo,
                    Status = StatusType.Ongoing
                };

                _context.Add(assessment);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { eid = eid });
        }

        // GET: Assessments/Edit/5
        public async Task<IActionResult> Edit(int id, string eid)
        {
            Utils ul = new Utils(_context);

            var vmodel = CreateViewModel(id);

            var assess = await _context.Assessments.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }

            var dname = await _context.Districts.FindAsync(assess.DistrictID);

            ViewBag.districtname = dname.DistrictName;

            vmodel.Assm = assess;

            return View(vmodel);
        }

        // POST: Assessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string eid, AssessmentVM model)
        {
            Utils ul = new Utils(_context);

            Assessment assessment = new Assessment()
            {
                AssessID = id,
                AppID = model.Assm.AppID,
                EmpID = model.Assm.EmpID,
                DateCreated = model.Assm.DateCreated,
                LastUpdated = DateTime.Now,
                HousingRef = model.Assm.HousingRef,
                DistrictID = model.Assm.DistrictID,
                Reason = model.Assm.Reason,
                CriminalOff = model.Assm.CriminalOff,
                Household = model.Assm.Household,
                Income = model.Assm.Income,
                ChildrenUnder18 = model.Assm.ChildrenUnder18,
                ChildrenOver18 = model.Assm.ChildrenOver18,
                Addiction = model.Assm.Addiction,
                HealthConditions = model.Assm.HealthConditions,
                LegalIssues = model.Assm.LegalIssues,
                TempRelease = model.Assm.TempRelease,
                ProbationOfficer = model.Assm.ProbationOfficer,
                SocialWorker = model.Assm.SocialWorker,
                DeptSocial = model.Assm.DeptSocial,
                AddictionSvcs = model.Assm.AddictionSvcs,
                MHCT = model.Assm.MHCT,
                DoctorGP = model.Assm.DoctorGP,
                Keyworker = model.Assm.Keyworker,
                OtherSupports = model.Assm.OtherSupports,
                SupprtsReferred = model.Assm.SupprtsReferred,
                FurtherInfo = model.Assm.FurtherInfo,
                Status = model.Assm.Status
            };

           

            if (id != assessment.AssessID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessment);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.AssessID))
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
            return View(assessment);
        }

        private bool AssessmentExists(int id)
        {
            return _context.Assessments.Any(e => e.AssessID == id);
        }
    }
}
