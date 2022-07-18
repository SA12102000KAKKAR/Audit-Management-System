using Microsoft.EntityFrameworkCore;

namespace AuditManagmentPortal.Models.Context
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
        {

        }


        public DbSet<StoreAuditResponce> storeAuditResponses { set; get; }

    }
}
