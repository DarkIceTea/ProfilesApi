using Microsoft.EntityFrameworkCore;
using ProfilesApi.Domain;

namespace ProfilesApi.Data
{
    public class ProfilesContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PatientProfile> PatientProfiles { get; set; }

    }
}
