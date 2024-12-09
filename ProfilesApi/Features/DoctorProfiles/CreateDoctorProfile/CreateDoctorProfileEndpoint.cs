using FastEndpoints;
using ProfilesApi.Domain;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.DoctorProfiles.CreateDoctorProfile
{
    public class CreateDoctorProfileEndpoint(DoctorRepository docRep) : Endpoint<CreateDoctorProfileRequest>
    {
        public override void Configure()
        {
            Post("/doctor-profiles");
            //PreProcessor<CreatePatientProfileLoggingPreProcessor<CreatePatientProfileRequest>>();
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateDoctorProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = new DoctorProfile()
            {
                Specialization = request.Specialization,
                Office = request.Office,
                Status = request.Status,
                CareerStartYear = request.CareerStartYear,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Id = Guid.NewGuid(),
            };

            await docRep.CreateDoctorProfileAsync(profile, cancellationToken);
            await SendOkAsync(cancellationToken);
        }
    }
}
