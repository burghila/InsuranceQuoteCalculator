using System.Data.Entity;

namespace InsuranceApp.Models
{
    public class InsuranceContext : DbContext
    {
        public DbSet<Insuree> Insurees { get; set; }
    }
}
