using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrePass.Data;
using PrePass.Models;
using PrePass.Utilities;

namespace PrePass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIReportsController : ControllerBase
    {
        private readonly PrePassContext _context;

        public APIReportsController(PrePassContext context)
        {
            _context = context;
        }




        // GET: api/APIReports
        [HttpGet]

        public IActionResult GetReport()
        {

            Utils ul = new Utils(_context);

            DateTime sdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            DateTime edate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Report myreport = ul.CreateReport(sdate, edate);

            if (myreport != null)
            {
                return Ok(myreport);
            }
            else
            {
                ReturnMessage Msg = new ReturnMessage() { Message = "No information found"};
                return NotFound(Msg);
            }

        }

    }
}
