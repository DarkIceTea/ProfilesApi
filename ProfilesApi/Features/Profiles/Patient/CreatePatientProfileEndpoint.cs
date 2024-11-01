using FastEndpoints;

namespace ProfilesApi.Features.Profiles.Patient
{
    public class CreatePatientProfileEndpoint : Endpoint<CreatePatientProfileRequest, CreatePatientProfileResponse>
    {
        public override void Configure()
        {
            Post("/Profiles/Patient/Create");
            AllowAnonymous();
        }

        public override Task HandleAsync(CreatePatientProfileRequest request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
