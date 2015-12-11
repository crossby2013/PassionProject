using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FightObesity.Models;

namespace FightObesity.Controllers
{
    public class BreakfastsController : Controller
    {
        private FightingObesityEntities2 db = new FightingObesityEntities2();

        // GET: Breakfasts
        public ActionResult Index()
        {
            return View(db.Breakfasts.ToList());
        }

        // GET: Breakfasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breakfast breakfast = db.Breakfasts.Find(id);
            if (breakfast == null)
            {
                return HttpNotFound();
            }
            return View(breakfast);
        }

        // GET: Breakfasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Breakfasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BreakfastID,Image,Ingredients,Instructions")] Breakfast breakfast)
        {
            if (ModelState.IsValid)
            {
                db.Breakfasts.Add(breakfast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(breakfast);
        }

        // GET: Breakfasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breakfast breakfast = db.Breakfasts.Find(id);
            if (breakfast == null)
            {
                return HttpNotFound();
            }
            return View(breakfast);
        }

        // POST: Breakfasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BreakfastID,Image,Ingredients,Instructions")] Breakfast breakfast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(breakfast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(breakfast);
        }

        // GET: Breakfasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breakfast breakfast = db.Breakfasts.Find(id);
            if (breakfast == null)
            {
                return HttpNotFound();
            }
            return View(breakfast);
        }

        // POST: Breakfasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Breakfast breakfast = db.Breakfasts.Find(id);
            db.Breakfasts.Remove(breakfast);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
