using ProfilesApi.Data;
using ProfilesApi.Domain;

namespace ProfilesApi.Repositories
{
    public class ProfileRepository(ProfilesContext context)
    {
        public async Task CreatePatientProfileAsync(PatientProfile profile, CancellationToken cancellationToken)
        {
            await context.PatientProfiles.AddAsync(profile, cancellationToken);
            await context.SaveChangesAsync();
        }
        public async Task<PatientProfile> GetPatientProfileById(Guid id, CancellationToken cancellationToken)
        {
            return await context.PatientProfiles.FindAsync(id, cancellationToken);
        }
    }
}
