using FastEndpoints;
using Serilog;

namespace ProfilesApi.Features.PatientProfiles.UpdatePatientProfile
{
    public class UpdatePatientProfileLoggingPreProcessor<TRequest> : IPreProcessor<TRequest>
    {
        public Task PreProcessAsync(IPreProcessorContext<TRequest> ctx, CancellationToken ct)
        {
            var guid = ctx.HttpContext.Request.RouteValues["UserGuid"]?.ToString();
            Log.Information("Update request with guid {0}", guid);
            var req = ctx.Request;
            if (req is UpdatePatientProfileRequest patientRequest)
            {
                Log.Information("Patient FirstName {0}\n" +
                                    "Patient LastName {1}\n" +
                                    "Patient MiddleName {2}\n" +
                                    "Patient PhoneNumber {3}\n" +
                                    "Patient DateOfBirth {4}",
                                    patientRequest.FirstName,
                                    patientRequest.LastName,
                                    patientRequest.MiddleName,
                                    patientRequest.PhoneNumber,
                                    patientRequest.DateOfBirth);
                return Task.CompletedTask;
            }
            throw new ArgumentException($"Invalid request {req}");
        }
    }
}
