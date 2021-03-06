﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DBFirstMVC.Controllers
{
    public class LoginController : Controller
    {
        private team16Entities db = new team16Entities();

        //
        // GET: /Login/

        public ActionResult Index()
        {
            ViewBag.LogOut = false;
            //get current round and semester
            RoundAndSemester RandS = (from d in db.RoundAndSemesters
                                      where d.CurrentRound == true
                                      select d).FirstOrDefault();
            ViewBag.CurrentRound = RandS.RoundID;
            ViewBag.CurrentSemester = RandS.Semester;

            ViewBag.Usernames = new SelectList(db.Depts,"Username");
            ViewBag.Users = db.Depts;
            return View();
        }

     

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid) //Check the username and password are valid inputs
            {
                //find rows that match the input (if any)
                var results = from d in db.Users
                              where (d.Username == model.Username && d.Password == model.Password)
                              select d;
                var id = from d in db.Users
                         where (d.Username == model.Username && d.Password == model.Password)
                         select d.UserID;

                if (results.FirstOrDefault() != null) //if a row has been found
                {
                    //Create a session for the user
                    model.UserID = id.FirstOrDefault();
                    Session["User"] = model;
                    Session.Timeout = 10;
                    if (model.Username == "CA")
                        return RedirectToAction("Index", "Admin");
                    //Advance to request page
                    return RedirectToAction("CreateNew", "Request");
                }
            }

            // If we got this far, something failed, redisplay form
            TempData["Message"] = "The password provided is incorrect";
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Logout()
        {
            Session.Remove("User"); //Remove user's session status and log out
            Session.Remove("State");
            return RedirectToAction("Index","Home");
        }



        //
        // GET: /Login/Details/5

        public ActionResult Details(short id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Login/Create

        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Depts, "DeptCode", "DeptName");
            return View();
        }

        //
        // POST: /Login/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Depts, "DeptCode", "DeptName", user.Username);
            return View(user);
        }

        //
        // GET: /Login/Edit/5

        public ActionResult Edit(short id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.Depts, "DeptCode", "DeptName", user.Username);
            return View(user);
        }

        //
        // POST: /Login/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Depts, "DeptCode", "DeptName", user.Username);
            return View(user);
        }

        //
        // GET: /Login/Delete/5

        public ActionResult Delete(short id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Login/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}