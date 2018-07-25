using Microsoft.EntityFrameworkCore;

namespace hateSpeach.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbOptions) : base(dbOptions)
        {
        }
        public virtual DbSet<HateSpeechReport> HateSpeechReports { get; set; }
    }
}