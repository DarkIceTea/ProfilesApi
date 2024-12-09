using FastEndpoints;
using ProfilesApi.Domain;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.DoctorProfiles.UpdateDoctorProfile
{
    public class UpdateDoctorProfileEndpoint(DoctorRepository docRep) : Endpoint<UpdateDoctorProfileRequest, UpdateDoctorProfileResponse>
    {
        public override void Configure()
        {
            Put("/doctor-profile/{UserGuid}");
            //PreProcessor<UpdatePatientProfileLoggingPreProcessor<UpdatePatientProfileRequest>>();
            AllowAnonymous();
        }
        public override async Task HandleAsync(UpdateDoctorProfileRequest request, CancellationToken cancellationToken)
        {
            var userGuid = Route<Guid>("UserGuid");
            var requestProfile = new DoctorProfile()
            {
                Specialization = request.Specialization,
                Office = request.Office,
                Status = request.Status,
                CareerStartYear = request.CareerStartYear,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName
            };

            var profile = await docRep.UpdateDoctorProfileAsync(userGuid, requestProfile, cancellationToken);
            var response = new UpdateDoctorProfileResponse()
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
