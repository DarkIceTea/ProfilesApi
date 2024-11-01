using Microsoft.EntityFrameworkCore;
using ProfilesApi.Features.Profiles.Domain;

namespace ProfilesApi.Data
{
    public class ProfilesContext : DbContext
    {
        DbSet<PatientProfile> patientProfiles;

    }
}
