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
    public class ReportsController : Controller
    {
        private readonly PrePassContext _context;
 
        public ReportsController(PrePassContext context)
        {
            _context = context;
        }

 
        // GET: Reports
        public async Task<IActionResult> Index(string eid, string? sd, string? ed)
        {
            Utils ul = new Utils(_context);

            // validate dates entered
            DateTime[] dat = ul.CheckDates(sd, ed);
            Report myreport = ul.CreateReport(dat[0], dat[1]);

            ViewBag.StartDate = dat[0].ToString("d/M/yyyy");
            ViewBag.EndDate = dat[1].ToString("d/M/yyyy");

            return View(myreport);
        }
    }
}
