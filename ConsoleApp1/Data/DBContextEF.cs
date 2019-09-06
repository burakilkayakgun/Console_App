using ConsoleApp1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConsoleApp1.Data
{
    public class DBContextEF : System.Data.Entity.DbContext
    {
        public DBContextEF(string constr)
        {
            this.Database.Connection.ConnectionString = constr;
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<animal>().Property(a => a.id).IsConcurrencyToken();

            modelBuilder.Entity<info>().Property(a => a.id).IsConcurrencyToken();

        }

        public DbSet<animal> Animals { get; set; }
        public DbSet<info> Informations { get; set; }
    }
}
