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
        public async Task<PatientProfile> GetPatientProfileByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.PatientProfiles.FindAsync(id, cancellationToken);
        }
        public async Task<PatientProfile> UpdatePatientProfileAsync(Guid guid, PatientProfile profile, CancellationToken cancellationToken)
        {
            var oldProfile = await context.PatientProfiles.FindAsync(guid, cancellationToken);

            oldProfile.DateOfBirth = profile.DateOfBirth;
            oldProfile.PhoneNumber = profile.PhoneNumber;
            oldProfile.FirstName = profile.FirstName;
            oldProfile.LastName = profile.LastName;
            oldProfile.MiddleName = profile.MiddleName;

            await context.SaveChangesAsync(cancellationToken);

            return oldProfile;
        }
    }
}
