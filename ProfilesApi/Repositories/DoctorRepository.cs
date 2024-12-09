using ProfilesApi.Data;
using ProfilesApi.Domain;

namespace ProfilesApi.Repositories
{
    public class DoctorRepository(ProfilesContext context)
    {
        public async Task CreateDoctorProfileAsync(DoctorProfile profile, CancellationToken cancellationToken)
        {
            await context.DoctorProfiles.AddAsync(profile, cancellationToken);
            await context.SaveChangesAsync();
        }
        public async Task<DoctorProfile> GetDoctorProfileByIdAsync(Guid guid, CancellationToken cancellationToken)
        {
            var profile = await context.DoctorProfiles.FindAsync(guid, cancellationToken);
            if (profile is null)
                throw new InvalidOperationException($"DoctorProfile with ID {guid} not found.");
            return profile;
        }
        public async Task<DoctorProfile> UpdateDoctorProfileAsync(Guid guid, DoctorProfile profile, CancellationToken cancellationToken)
        {
            var oldProfile = await GetDoctorProfileByIdAsync(guid, cancellationToken);

            oldProfile.Specialization = profile.Specialization;
            oldProfile.Office = profile.Office;
            oldProfile.Status = profile.Status;
            oldProfile.CareerStartYear = profile.CareerStartYear;
            oldProfile.Email = profile.Email;
            oldProfile.DateOfBirth = profile.DateOfBirth;
            oldProfile.FirstName = profile.FirstName;
            oldProfile.LastName = profile.LastName;
            oldProfile.MiddleName = profile.MiddleName;

            await context.SaveChangesAsync(cancellationToken);

            return oldProfile;
        }
        public async Task DeleteDoctorProfileAsync(Guid guid, CancellationToken cancellationToken)
        {
            var profile = await GetDoctorProfileByIdAsync(guid, cancellationToken);
            context.DoctorProfiles.Remove(profile);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
