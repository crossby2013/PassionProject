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
    public class ActivitiesChartsController : Controller
    {
        private FightingObesityEntities2 db = new FightingObesityEntities2();

        // GET: ActivitiesCharts
        public ActionResult Index()
        {
            return View(db.ActivitiesCharts.ToList());
        }

        // GET: ActivitiesCharts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivitiesChart activitiesChart = db.ActivitiesCharts.Find(id);
            if (activitiesChart == null)
            {
                return HttpNotFound();
            }
            return View(activitiesChart);
        }

        // GET: ActivitiesCharts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivitiesCharts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivitiesChartID,Indoor,Outdoor")] ActivitiesChart activitiesChart)
        {
            if (ModelState.IsValid)
            {
                db.ActivitiesCharts.Add(activitiesChart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activitiesChart);
        }

        // GET: ActivitiesCharts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivitiesChart activitiesChart = db.ActivitiesCharts.Find(id);
            if (activitiesChart == null)
            {
                return HttpNotFound();
            }
            return View(activitiesChart);
        }

        // POST: ActivitiesCharts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivitiesChartID,Indoor,Outdoor")] ActivitiesChart activitiesChart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activitiesChart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activitiesChart);
        }

        // GET: ActivitiesCharts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivitiesChart activitiesChart = db.ActivitiesCharts.Find(id);
            if (activitiesChart == null)
            {
                return HttpNotFound();
            }
            return View(activitiesChart);
        }

        // POST: ActivitiesCharts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivitiesChart activitiesChart = db.ActivitiesCharts.Find(id);
            db.ActivitiesCharts.Remove(activitiesChart);
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
