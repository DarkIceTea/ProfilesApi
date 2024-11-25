using ProfilesApi.Data;
using ProfilesApi.Domain;

namespace ProfilesApi.Repositories
{
    public class DoctorRepository(ProfilesContext context)
    {
        public async Task CreatePatientProfileAsync(DoctorProfile profile, CancellationToken cancellationToken)
        {
            await context.DoctorProfiles.AddAsync(profile, cancellationToken);
            await context.SaveChangesAsync();
        }
        public async Task<PatientProfile> GetPatientProfileByIdAsync(Guid guid, CancellationToken cancellationToken)
        {
            var profile = await context.PatientProfiles.FindAsync(guid, cancellationToken);
            if (profile is null)
                throw new InvalidOperationException($"PatientProfile with ID {guid} not found.");
            return profile;
        }
        public async Task<PatientProfile> UpdatePatientProfileAsync(Guid guid, PatientProfile profile, CancellationToken cancellationToken)
        {
            var oldProfile = await GetPatientProfileByIdAsync(guid, cancellationToken);

            oldProfile.DateOfBirth = profile.DateOfBirth;
            oldProfile.PhoneNumber = profile.PhoneNumber;
            oldProfile.FirstName = profile.FirstName;
            oldProfile.LastName = profile.LastName;
            oldProfile.MiddleName = profile.MiddleName;

            await context.SaveChangesAsync(cancellationToken);

            return oldProfile;
        }
        public async Task DeletePatientProfileAsync(Guid guid, CancellationToken cancellationToken)
        {
            var profile = await GetPatientProfileByIdAsync(guid, cancellationToken);
            context.PatientProfiles.Remove(profile);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
