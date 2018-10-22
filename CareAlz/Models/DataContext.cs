
namespace CareAlz.Models
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DataContext : DbContext
    {

        public DataContext() : base ("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public DbSet<State> States { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<Colony> Colonies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<CareAlz.Models.Administrator> Administrators { get; set; }

        public System.Data.Entity.DbSet<CareAlz.Models.RequestInstitute> RequestInstitutes { get; set; }
    }
}