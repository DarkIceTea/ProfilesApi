using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using ProfilesApi.Domain;

namespace ProfilesApi.Data
{
    public class ProfilesContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PatientProfile> PatientProfiles { get; set; } = null!;
        public DbSet<DoctorProfile> DoctorProfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientProfile>().ToCollection("PatientProfile");
            modelBuilder.Entity<DoctorProfile>().ToCollection("DoctorProfile");
        }
    }
}
