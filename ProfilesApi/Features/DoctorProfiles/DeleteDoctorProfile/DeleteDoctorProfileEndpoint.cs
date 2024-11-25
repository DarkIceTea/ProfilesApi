using FastEndpoints;
using ProfilesApi.Features.PatientProfiles.DeletePatientProfile;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.DoctorProfiles.DeleteDoctorProfile
{
    public class DeleteDoctorProfileEndpoint(DoctorRepository docRep) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Delete("/doctor-profile/{UserGuid}");
            PreProcessor<DeletePatientProfileLoggingPreProcessor<EmptyRequest>>();
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var userGuid = Route<Guid>("UserGuid");
            await docRep.DeleteDoctorProfileAsync(userGuid, cancellationToken);

            await SendOkAsync(cancellationToken);
        }
    }
}
