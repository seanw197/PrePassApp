using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrePass.Data;
using PrePass.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PrePass.Utilities
{
    public static class EnumDisplayName
    {
        // get the display name for a given enum value
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .GetName();
        }
    }
    public class Utils
    {
        private readonly PrePassContext _context;

        public Utils(PrePassContext context)
        {
            _context = context;
        }

    //public Utils()
    //{
    //}


    public List<AssessmentDetailsVM> GetAssessments()
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
 
        public Report CreateReport(DateTime start, DateTime end)
        {
            Report myreport = new Report();

            var query = GetAssessments();

            var uptoenddate = from p in query
                              where p.assessment.LastUpdated <= end
                              select p;

            var flist = from p in query
                        where p.assessment.LastUpdated >= start && p.assessment.LastUpdated <= end
                        select p;


            var repapps = from u in uptoenddate
                             group u by u.assessment.AppID into ugroup
                             where ugroup.Count() > 1
                             select new
                             {
                                 Appid = ugroup.Key,
                                 Count = ugroup.Count()
                             };

            // get count of one-time applicants, all assessments

            var uniqueapps = from u in uptoenddate
                             group u by u.assessment.AppID into ugroup
                             where ugroup.Count() == 1
                             select new
                             {
                                 Appid = ugroup.Key,
                                 Count = ugroup.Count()
                             };

            // get one-time applicants who were assessed in specified time period

            var firsttimeapps = (from f in flist
                                 join u in uniqueapps on f.assessment.AppID equals u.Appid
                                 where f.assessment.AppID == u.Appid
                                 select f).Count();

            var repeatapps = (from f in flist
                                 join u in repapps on f.assessment.AppID equals u.Appid
                                 where f.assessment.AppID == u.Appid
                                 select f).Count();


            myreport.RepeatApp = repeatapps;

            myreport.FirstTimeApp = firsttimeapps;

            myreport.AssessmentCount = flist.Count();

            myreport.StartDate = start;
            myreport.EndDate = end;

            foreach (var g in flist.GroupBy(p => p.assessment.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Statuses.Add(new ReportItem() { Item = g.Status.GetDisplayName(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.applicant.Gender)
                .Select(g => new { Gender = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Genders.Add(new ReportItem() { Item = g.Gender.GetDisplayName(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.applicant.Ethnicity)
                .Select(g => new { Ethnicity = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Ethnicities.Add(new ReportItem() { Item = g.Ethnicity.GetDisplayName(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.assessment.Reason)
                .Select(g => new { Reason = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Reasons.Add(new ReportItem() { Item = g.Reason.GetDisplayName(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.assessment.Household)
                .Select(g => new { Household = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Households.Add(new ReportItem() { Item = g.Household.GetDisplayName(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.assessment.Addiction)
                 .Select(g => new { Addiction = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Addictions.Add(new ReportItem() { Item = g.Addiction.GetDisplayName(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.assessment.Income)
                 .Select(g => new { Income = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Incomes.Add(new ReportItem() { Item = g.Income.GetDisplayName(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.DistrictName)
                .Select(g => new { District = g.Key, Count = g.Count() }).OrderByDescending(p => p.Count).ToList())
            {
                myreport.Districts.Add(new ReportItem() { Item = g.District.ToString(), Count = g.Count });
            }

            foreach (var g in flist.GroupBy(p => p.assessment.ChildrenUnder18 > 0)
                .Select(g => new { haschildrenunder18 = g.Key, Count = g.Count() }).ToList())
            {
                if (g.haschildrenunder18)
                {
                    myreport.Children.Add(new ReportItem() { Item = "Families with children under 18", Count = g.Count });
                }
                else
                {
                    myreport.Children.Add(new ReportItem() { Item = "Families with no children under 18", Count = g.Count });
                }
            }

            return (myreport);
        }


        public DateTime[] CheckDates(string? sd, string? ed)
        {
            // if no start date provided, set it to start of current month
            // if no end date provided, set it to tomorrow's date

            CultureInfo culture = new CultureInfo("pt-BR");
            string format = "d/M/yyyy";

            DateTime sdate;
            DateTime edate;
            DateTime dt;
 
            if (sd == null || !DateTime.TryParseExact(sd, format, culture, DateTimeStyles.None, out dt))
            {
                sdate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            }
            else
            {
                sdate = DateTime.ParseExact(sd, format, culture);
            }

            if (ed == null || !DateTime.TryParseExact(ed, format, culture, DateTimeStyles.None, out dt))
            {
                edate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month + 1, 1);
            }
            else
            {
                edate = DateTime.ParseExact(ed, format, culture);
            }

            DateTime[] st = new DateTime[] { sdate, edate };

            return (st);
        }
    }
}

