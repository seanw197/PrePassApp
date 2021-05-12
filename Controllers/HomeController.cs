using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrePass.Data;
using PrePass.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using PrePass.Utilities;
using System.Globalization;
using PrePass.ActionFilters;

namespace PrePass.Controllers
{
    [EidActionFilter]
    public class HomeController : Controller
    {        
        private readonly PrePassContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PrePassContext context)
        {
            _logger = logger;

            _context = context;
        }

        public IActionResult Index(string? eid, bool? unauth )
        {
            if (unauth == true)
            {
                ViewBag.msg = "You have been redirected to this page because you tried to access an unauthorised area";
            }
            return View();
        }

        public IActionResult signout(string? eid)
        {
            Session s = _context.Sessions.FirstOrDefault(p => p.Eid == eid);
            _context.Sessions.Remove(s);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SignIn(Staff staff, string sign, string forgot)
        {
            ViewBag.usermail = staff.Email;

            if (!string.IsNullOrEmpty(sign))
            {
                string eid = "";

                Staff s = _context.Staff.FirstOrDefault(p => p.Email == staff.Email && p.Passwd == staff.Passwd && p.Active == true);

                if (s != null)
                {
                    // generate token
                    var rand = new Random();
                    eid = rand.Next(1000000, 9999999).ToString();
                    ViewBag.eid = eid;
                    await  _context.Sessions.AddAsync(new Session() { EmpID = s.EmpID, dateTime = DateTime.Now, Eid = eid });
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewBag.sm_message = "Invalid login, please try again.";
                    return View(nameof(Index));
                }

                return RedirectToAction(nameof(Index), new { eid = eid });
            }
            // forgot password
            if (!string.IsNullOrEmpty(forgot) && !string.IsNullOrEmpty(staff.Email))
            {
                Staff s = _context.Staff.FirstOrDefault(p => p.Email.ToUpper() == staff.Email.ToUpper());
                if (s != null)
                {
                    // to simulate an email being sent to user with their password, displayed on screen for demonstration purposes
                    ViewBag.sm_message = "Your password is: " + s.Passwd;
                }
                return View(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
