using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ocassion.DAL;

namespace ocassion.Controllers
{
    public class AreaDetailsController : Controller
    {
        private OSCEntities db = new OSCEntities();

        //
        // GET: /AreaDetails/

        public ActionResult Index()
        {
            var areas = db.Areas.Include(a => a.City).Include(a => a.Country).Include(a => a.State);
            return View(areas.ToList());
        }

        //
        // GET: /AreaDetails/Details/5

        public ActionResult Details(int id = 0)
        {
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        //
        // GET: /AreaDetails/Create

        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName");
            return View();
        }

        //
        // POST: /AreaDetails/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Area area)
        {
            if (ModelState.IsValid)
            {
                db.Areas.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", area.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", area.CountryId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", area.StateId);
            return View(area);
        }

        //
        // GET: /AreaDetails/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", area.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", area.CountryId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", area.StateId);
            return View(area);
        }

        //
        // POST: /AreaDetails/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", area.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", area.CountryId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", area.StateId);
            return View(area);
        }

        //
        // GET: /AreaDetails/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        //
        // POST: /AreaDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Area area = db.Areas.Find(id);
            db.Areas.Remove(area);
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