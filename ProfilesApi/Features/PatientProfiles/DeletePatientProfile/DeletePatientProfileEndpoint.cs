using FastEndpoints;
using ProfilesApi.Repositories;

namespace ProfilesApi.Features.PatientProfiles.DeletePatientProfile
{
    public class DeletePatientProfileEndpoint(ProfileRepository profRep) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Delete("/patient-profile/{UserGuid}");
            PreProcessor<DeletePatientProfileLoggingPreProcessor<EmptyRequest>>();
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var userGuid = Route<Guid>("UserGuid");
            await profRep.DeletePatientProfileAsync(userGuid, cancellationToken);

            await SendOkAsync(cancellationToken);
        }
    }
}
