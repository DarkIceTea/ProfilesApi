namespace ProfilesApi.Features.DoctorProfiles.CreateDoctorProfile
{
    public class CreateDoctorProfileEndpoint
    {
        public override void Configure()
        {
            Post("/patient-profiles");
            PreProcessor<CreatePatientProfileLoggingPreProcessor<CreatePatientProfileRequest>>();
            AllowAnonymous();
        }
    }
}
