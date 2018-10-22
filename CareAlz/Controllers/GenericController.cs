namespace CareAlz.Controllers
{
    using CareAlz.Models;
    using System.Linq;
    using System.Web.Mvc;


    public class GenericController : Controller
    {
        private DataContext db = new DataContext();

        public JsonResult GetMunicipalities(int idstate)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var municipios = db.Municipalities.Where(e => e.StateId == idstate);
            return Json(municipios);

        }

        public JsonResult GetColonies(int idMunicipality)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var colonias = db.Colonies.Where(e => e.MunicipalityId == idMunicipality);
            return Json(colonias);
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