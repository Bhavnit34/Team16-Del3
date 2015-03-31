using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstMVC.Controllers
{
    public class TestController : Controller
    {
        private team16Entities db = new team16Entities();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Module).Include(r => r.Week);
            return View(requests.ToList());
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title");
            ViewBag.WeekID = new SelectList(db.Weeks, "WeekID", "WeekID");
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            ViewBag.WeekID = new SelectList(db.Weeks, "WeekID", "WeekID", request.WeekID);
            return View(request);
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            ViewBag.WeekID = new SelectList(db.Weeks, "WeekID", "WeekID", request.WeekID);
            return View(request);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            ViewBag.WeekID = new SelectList(db.Weeks, "WeekID", "WeekID", request.WeekID);
            return View(request);
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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