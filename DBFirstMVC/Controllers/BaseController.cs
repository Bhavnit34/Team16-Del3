using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstMVC.Controllers
{
    /*The purpose of this controller is act as an overide on each action of the other controllers, so that each time
    it will check that a user has logged in succesfully. This is done by checking for a valid session.
     */
    public class BaseController : Controller
    {
        private team16Entities db = new team16Entities();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["User"] != null)
            {
                ViewBag.CurrentUser = getCurrentUser(); // get user logged in
                ViewBag.LogOut = true; //set button to 'logout', instead of 'login'

                //get current round and semester
                RoundAndSemester RandS = (from d in db.RoundAndSemesters
                                          where d.CurrentRound == true
                                          select d).FirstOrDefault();
                if (RandS.RoundID > 5)
                {
                    ViewBag.CurrentRound = RandS.RoundID + " (adhoc)";
                }
                else
                {
                    ViewBag.CurrentRound = RandS.RoundID + " ";

                }
                ViewBag.RoundEnd = RandS.EndDate.ToString().Substring(0, 10);
                ViewBag.CurrentSemester = RandS.Semester;

                //check a regular user isnt accessing an admin page
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string actionName = filterContext.ActionDescriptor.ActionName;
                if (controllerName == "Admin" && ViewBag.Admin == false)
                {
                    if (actionName != "EditPool" && actionName != "Delete" && actionName != "EditRoom")
                    {
                        TempData["Message"] = "You do not have admin right to access this page"; //This message will show once
                        filterContext.Result = new RedirectResult("~/Request/Index");
                    }
                }


                base.OnActionExecuting(filterContext); //Continue as normal
            }
            else
            {
                TempData["Message"] = "Please log in to use the timetabling system"; //This message will show once
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
        private string getCurrentUser()
        {
            ViewBag.Admin = false;
            User userSession = (User)HttpContext.Session["User"];
            if (userSession.Username == "CA")
                ViewBag.Admin = true;

            var row = db.Depts.Find(userSession.Username);
            return (row.FullDept);
        }

    }
}
