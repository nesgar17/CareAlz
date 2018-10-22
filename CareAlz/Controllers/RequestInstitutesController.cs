
namespace CareAlz.Controllers
{
    using CareAlz.Clases;
    using CareAlz.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;


    public class RequestInstitutesController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            var requestInstitutes = db.RequestInstitutes
                .Include(r => r.Category)
                .Include(r => r.Colony)
                .Include(r => r.Municipality)
                .Include(r => r.State);
            return View(requestInstitutes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestInstitute requestInstitute = db.RequestInstitutes.Find(id);
            if (requestInstitute == null)
            {
                return HttpNotFound();
            }
            return View(requestInstitute);
        }

        
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(), "CategoryId", "Description");
            ViewBag.ColonyId = new SelectList(CombosHelper.GetColonies(0), "ColonyId", "Description");
            ViewBag.MunicipalityId = new SelectList(CombosHelper.GetMunicipalities(0), "MunicipalityId", "Description");
            ViewBag.StateId = new SelectList(CombosHelper.GetStates(), "StateId", "Description");
            return View();
        }

        public ActionResult Mensage()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestInstitute requestInstitute)
        {
            if (ModelState.IsValid)
            {
                db.RequestInstitutes.Add(requestInstitute);
                var response =  DbHelper.SaveChanges(db);
                if (response.Successfully)
                {
                    return RedirectToAction("Index");


                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(), "CategoryId", "Description", requestInstitute.CategoryId);
            ViewBag.ColonyId = new SelectList(CombosHelper.GetColonies(requestInstitute.ColonyId), "ColonyId", "Description", requestInstitute.ColonyId);
            ViewBag.MunicipalityId = new SelectList(CombosHelper.GetMunicipalities(requestInstitute.MunicipalityId), "MunicipalityId", "Description", requestInstitute.MunicipalityId);
            ViewBag.StateId = new SelectList(CombosHelper.GetStates(), "StateId", "Description", requestInstitute.StateId);
            return View(requestInstitute);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestInstitute requestInstitute = db.RequestInstitutes.Find(id);
            if (requestInstitute == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(), "CategoryId", "Description", requestInstitute.CategoryId);
            ViewBag.ColonyId = new SelectList(CombosHelper.GetColonies(0), "ColonyId", "Description", requestInstitute.ColonyId);
            ViewBag.MunicipalityId = new SelectList(CombosHelper.GetMunicipalities(0), "MunicipalityId", "Description", requestInstitute.MunicipalityId);
            ViewBag.StateId = new SelectList(CombosHelper.GetStates(), "StateId", "Description", requestInstitute.StateId);
            return View(requestInstitute);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RequestInstitute requestInstitute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestInstitute).State = EntityState.Modified;
                var response = DbHelper.SaveChanges(db);
                if (response.Successfully)
                {
                    return RedirectToAction("Index");

                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(), "CategoryId", "Description", requestInstitute.CategoryId);
            ViewBag.ColonyId = new SelectList(CombosHelper.GetColonies(requestInstitute.ColonyId), "ColonyId", "Description", requestInstitute.ColonyId);
            ViewBag.MunicipalityId = new SelectList(CombosHelper.GetMunicipalities(requestInstitute.MunicipalityId), "MunicipalityId", "Description", requestInstitute.MunicipalityId);
            ViewBag.StateId = new SelectList(CombosHelper.GetStates(), "StateId", "Description", requestInstitute.StateId);
            return View(requestInstitute);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestInstitute requestInstitute = db.RequestInstitutes.Find(id);
            if (requestInstitute == null)
            {
                return HttpNotFound();
            }
            return View(requestInstitute);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestInstitute requestInstitute = db.RequestInstitutes.Find(id);
            db.RequestInstitutes.Remove(requestInstitute);
            var response = DbHelper.SaveChanges(db);
            if (response.Successfully)
            {
                return RedirectToAction("Index");

            }

            ModelState.AddModelError(string.Empty, response.Message);
            return View();
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
