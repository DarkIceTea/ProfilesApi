using ProfilesApi.Data;
using ProfilesApi.Features.Profiles.Domain;

namespace ProfilesApi.Features.Profiles.Repositories
{
    public class ProfileRepository(ProfilesContext context)
    {
        public async Task CreatePatientProfileAsync(PatientProfile profile, CancellationToken cancellationToken)
        {
            await context.PatientProfiles.AddAsync(profile, cancellationToken);
            await context.SaveChangesAsync();
        }
    }
}
