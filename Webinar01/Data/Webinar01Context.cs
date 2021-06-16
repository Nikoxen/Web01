
using System.Data.Entity;


namespace Webinar01.Data
{
    public class Webinar01Context : DbContext
    {
        
        public Webinar01Context() : base("name=Webinar01Context")//connectionstring istendiginde
        {
        }

        public DbSet<Models.Coffee> Coffees { get; set; }

        public DbSet<Models.Company> Companies { get; set; }
    }
}
