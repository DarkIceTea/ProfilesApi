using FastEndpoints;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.PatientProfiles.GetPatientProfile
{
    public class GetPatientProfileEndpoint(ProfileRepository profRep) : Endpoint<GetPatientProfileRequest, GetPatientProfileResponse>
    {
        public override void Configure()
        {
            Get("/Profiles/Patient/Get");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetPatientProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = await profRep.GetPatientProfileById(request.Id, cancellationToken);
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
