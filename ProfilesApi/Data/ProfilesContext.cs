using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using ProfilesApi.Domain;

namespace ProfilesApi.Data
{
    public class ProfilesContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PatientProfile> PatientProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientProfile>().ToCollection("PatientProfile");
        }
    }
}
