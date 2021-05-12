using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrePass.Data;
using PrePass.Models;
using PrePass.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


// this action filter gets the user id from the eid and compares the userlevel to the required level for the 
// controller. if user does not have permission, they are routed to the home page.

namespace PrePass.ActionFilters
{
	public class EidActionFilter : ActionFilterAttribute
	{
		public struct Permission
		{
			public string cname;
			public int level;
		}

		static List<Permission> permissions = new List<Permission>()
		{
			new Permission(){cname = "PrePass.Controllers.HomeController", level = 0 },
			new Permission(){cname = "PrePass.Controllers.AssessmentsController", level = 0 },
			new Permission(){cname = "PrePass.Controllers.ApplicantsController", level = 0 },
			new Permission(){cname = "PrePass.Controllers.ReportsController", level = 0 },
			new Permission(){cname = "PrePass.Controllers.AssessorsController", level = 1 },
			new Permission(){cname = "PrePass.Controllers.DistrictsController", level = 2 },
			new Permission(){cname = "PrePass.Controllers.StaffsController", level = 2 },
		};



		public async override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var _context = filterContext.HttpContext.RequestServices.GetRequiredService<PrePassContext>();

			Controller mycontroller = (Controller)filterContext.Controller;

			if (filterContext.ActionArguments.TryGetValue("eid", out object value))
			{

				if (filterContext.Controller is Controller controller)
				{
					controller.ViewData["eid"] = value.ToString();

					string eid = value.ToString();

					controller.ViewBag.eid = eid;

					string controllerName = filterContext.Controller.ToString(); //filterContext.RouteData.Values["controller"];

					int level = permissions.FirstOrDefault(p => p.cname.Equals(controllerName)).level;

					int userlevel = -1;

					string empid = "";

					string username = "";

					// delete logins not used in more than 3 hours

					var oldDate = DateTime.Now.AddHours(-3);
					var dates = _context.Sessions.Where(p => p.dateTime < oldDate);
					_context.Sessions.RemoveRange(dates);
					_context.SaveChanges();

					// check if session token is valid

					if (eid != null)
					{
						Session s = _context.Sessions.FirstOrDefault(p => p.Eid == eid);

						// if session is valid , get staff member's employee ID and access level

						if (s != null)
						{
							// update datetime of session							
							s.dateTime = DateTime.Now;
							_context.SaveChanges();

							Staff st = _context.Staff.FirstOrDefault(p => p.EmpID.ToUpper() == s.EmpID.ToUpper() && p.Active == true);
							if (st != null)
							{
								userlevel = (int)st.accessLevel;
								empid = st.EmpID;
								username = st.Name;
							}
						}
					}

					if (userlevel < level && controllerName != "PrePass.Controllers.HomeController")
					{
						filterContext.Result = controller.RedirectToAction("Index", "Home", new { eid = eid, unauth = true });
					}
					else
					{
						controller.ViewBag.userlevel = userlevel;
						controller.ViewBag.EmpID = empid;
						controller.ViewBag.username = username;
					}
				}
			}
			else if (mycontroller.ToString() != "PrePass.Controllers.HomeController")
			{
				filterContext.Result = mycontroller.RedirectToAction("Index", "Home", new { unauth = true });
			}
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{

		}
	}
}