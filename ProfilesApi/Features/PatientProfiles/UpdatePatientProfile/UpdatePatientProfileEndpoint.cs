using FastEndpoints;
using ProfilesApi.Domain;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.PatientProfiles.UpdatePatientProfile
{
    public class UpdatePatientProfileEndpoint(ProfileRepository profRep) : Endpoint<UpdatePatientProfileRequest, UpdatePatientProfileResponse>
    {
        public override void Configure()
        {
            Put("/patient-profile/{UserGuid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdatePatientProfileRequest request, CancellationToken cancellationToken)
        {
            var userGuid = Route<Guid>("UserGuid");
            Logger.LogInformation("Get user guid {0}", userGuid.ToString());
            var requestProfile = new PatientProfile()
            {
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber
            };

            var profile = await profRep.UpdatePatientProfileAsync(userGuid, requestProfile, cancellationToken);
            var response = new UpdatePatientProfileResponse()
            {
                DateOfBirth = profile.DateOfBirth,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                MiddleName = profile.MiddleName,
                PhoneNumber = profile.PhoneNumber
            };
            await SendOkAsync(response, cancellationToken);

        }
    }
}
