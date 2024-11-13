using FastEndpoints;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.PatientProfiles.GetPatientProfile
{
    public class GetPatientProfileEndpoint(ProfileRepository profRep) : EndpointWithoutRequest<GetPatientProfileResponse>
    {
        public override void Configure()
        {
            Get("/Profiles/Patient/Get/{UserGuid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var userGuid = Route<Guid>("UserGuid");
            var profile = await profRep.GetPatientProfileByIdAsync(userGuid, cancellationToken);
            var response = new GetPatientProfileResponse()
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
