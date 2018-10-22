using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareAlz.Clases;
using CareAlz.Models;

namespace CareAlz.Controllers
{
    public class AdministratorsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Administrators
        public ActionResult Index()
        {
            var administrators = db.Administrators
                .Include(a => a.Colony)
                .Include(a => a.Municipality)
                .Include(a => a.State);
            return View(administrators.ToList());
        }

        // GET: Administrators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // GET: Administrators/Create
        public ActionResult Create()
        {
            ViewBag.IdColony = new SelectList(CombosHelper.GetColonies(0), "IdColony", "Description");
            ViewBag.IdMunicipality = new SelectList(CombosHelper.GetMunicipalities(0), "IdMunicipality", "Description");
            ViewBag.IdState = new SelectList(CombosHelper.GetStates(), "IdState", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                db.Administrators.Add(administrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdColony = new SelectList(CombosHelper.GetColonies(administrator.ColonyId), "IdColony", "Description", administrator.ColonyId);
            ViewBag.IdMunicipality = new SelectList(CombosHelper.GetMunicipalities(administrator.MunicipalityId), "IdMunicipality", "Description", administrator.MunicipalityId);
            ViewBag.IdState = new SelectList(CombosHelper.GetStates(), "IdState", "Description", administrator.StateId);
            return View(administrator);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdColony = new SelectList(CombosHelper.GetColonies(0), "IdColony", "Description", administrator.ColonyId);
            ViewBag.IdMunicipality = new SelectList(CombosHelper.GetMunicipalities(0), "IdMunicipality", "Description", administrator.MunicipalityId);
            ViewBag.IdState = new SelectList(CombosHelper.GetStates(), "IdState", "Description", administrator.StateId);
            return View(administrator);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdColony = new SelectList(CombosHelper.GetColonies(administrator.ColonyId), "IdColony", "Description", administrator.ColonyId);
            ViewBag.IdMunicipality = new SelectList(CombosHelper.GetMunicipalities(administrator.MunicipalityId), "IdMunicipality", "Description", administrator.MunicipalityId);
            ViewBag.IdState = new SelectList(CombosHelper.GetStates(), "IdState", "Description", administrator.StateId);
            return View(administrator);
        }

        // GET: Administrators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrator administrator = db.Administrators.Find(id);
            db.Administrators.Remove(administrator);
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
