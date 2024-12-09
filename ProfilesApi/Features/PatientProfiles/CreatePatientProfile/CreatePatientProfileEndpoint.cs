using FastEndpoints;
using ProfilesApi.Domain;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.PatientProfiles.CreatePatientProfile
{
    public class CreatePatientProfileEndpoint(ProfileRepository profRep) : Endpoint<CreatePatientProfileRequest>
    {
        public override void Configure()
        {
            Post("/patient-profiles");
            PreProcessor<CreatePatientProfileLoggingPreProcessor<CreatePatientProfileRequest>>();
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreatePatientProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = new PatientProfile()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                MiddleName = request.MiddleName,
                Id = Guid.NewGuid()
            };

            await profRep.CreatePatientProfileAsync(profile, cancellationToken);
            await SendOkAsync(cancellationToken);
        }
    }
}
