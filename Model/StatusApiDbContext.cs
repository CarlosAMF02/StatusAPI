using Microsoft.EntityFrameworkCore;

namespace Checkpoint03API.Model
{
    public class StatusApiDbContext : DbContext
    {
        public StatusApiDbContext(DbContextOptions<StatusApiDbContext> options) : base(options)
        {

        }

        public DbSet<Status> Status { get; set; }
    }
}
