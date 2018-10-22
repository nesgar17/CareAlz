using CareAlz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareAlz.Clases
{
    public class CombosHelper : IDisposable
    {


        private static DataContext db = new DataContext();

        public static List<State> GetStates()
        {
            var state = db.States.ToList();
            state.Add(new State
            {
                StateId = 0,
                Description = "[--Selecciona un Estado--]",
            });

            return state.OrderBy(e => e.Description).ToList();
        }

        public  static List<Category> GetCategories()
        {
            var category = db.Categories.ToList();
            category.Add(new Category
            {
                CategoryId = 0,
                Description = "[--Selecciona una Categoria--]",
            });

            return category.OrderBy(e => e.Description).ToList();
        }

        public static List<Municipality> GetMunicipalities()
        {
            var municipality = db.Municipalities.ToList();
            municipality.Add(new Municipality
            {
                MunicipalityId = 0,
                Description = "[--Selecciona un Municipio--]",
            });

            return municipality.OrderBy(e => e.Description).ToList();
        }
        public static List<Municipality> GetMunicipalities(int stateId)
        {
            var municipality = db.Municipalities.Where(m => m.StateId == stateId).ToList();
            municipality.Add(new Municipality
            {
                MunicipalityId = 0,
                Description = "[--Selecciona un Municipio--]",
            });

            return municipality.OrderBy(e => e.Description).ToList();
        }


        public static List<Colony> GetColonies()
        {
            var colonies = db.Colonies.ToList();
            colonies.Add(new Colony
            {
                ColonyId = 0,
                Description = "[--Selecciona una Colonia--]",
            });

            return colonies.OrderBy(e => e.Description).ToList();
        }

        public static List<Colony> GetColonies(int idMunicipality)
        {
            var colonies = db.Colonies.Where(m => m.MunicipalityId == idMunicipality).ToList();
            colonies.Add(new Colony
            {
                ColonyId = 0,
                Description = "[--Selecciona una Colonia--]",
            });

            return colonies.OrderBy(e => e.Description).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}