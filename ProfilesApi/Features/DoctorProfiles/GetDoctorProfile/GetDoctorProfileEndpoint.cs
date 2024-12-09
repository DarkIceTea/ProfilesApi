using FastEndpoints;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.DoctorProfiles.GetDoctorProfile
{
    public class GetDoctorProfileEndpoint(DoctorRepository docRep) : EndpointWithoutRequest<GetDoctorProfileResponse>
    {
        public override void Configure()
        {
            Get("/doctor-profile/{UserGuid}");
            //PreProcessor<GetPatientProfileLoggingPreProcessor<EmptyRequest>>();
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var userGuid = Route<Guid>("UserGuid");
            var profile = await docRep.GetDoctorProfileByIdAsync(userGuid, cancellationToken);
            var response = new GetDoctorProfileResponse()
            {
                Specialization = profile.Specialization,
                Office = profile.Office,
                Status = profile.Status,
                CareerStartYear = profile.CareerStartYear,
                Email = profile.Email,
                DateOfBirth = profile.DateOfBirth,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                MiddleName = profile.MiddleName
            };
            await SendOkAsync(response, cancellationToken);

        }
    }
}
