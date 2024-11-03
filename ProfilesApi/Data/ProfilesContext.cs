using Microsoft.EntityFrameworkCore;
using ProfilesApi.Features.Profiles.Domain;

namespace ProfilesApi.Data
{
    public class ProfilesContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<PatientProfile> PatientProfiles { get; set; }

    }
}
