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
    public class SnacksController : Controller
    {
        private FightingObesityEntities2 db = new FightingObesityEntities2();

        // GET: Snacks
        public ActionResult Index()
        {
            return View(db.Snacks.ToList());
        }

        // GET: Snacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snack snack = db.Snacks.Find(id);
            if (snack == null)
            {
                return HttpNotFound();
            }
            return View(snack);
        }

        // GET: Snacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Snacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SnackID,Image,Ingredients,Instructions")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                db.Snacks.Add(snack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(snack);
        }

        // GET: Snacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snack snack = db.Snacks.Find(id);
            if (snack == null)
            {
                return HttpNotFound();
            }
            return View(snack);
        }

        // POST: Snacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SnackID,Image,Ingredients,Instructions")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(snack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(snack);
        }

        // GET: Snacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snack snack = db.Snacks.Find(id);
            if (snack == null)
            {
                return HttpNotFound();
            }
            return View(snack);
        }

        // POST: Snacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Snack snack = db.Snacks.Find(id);
            db.Snacks.Remove(snack);
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
