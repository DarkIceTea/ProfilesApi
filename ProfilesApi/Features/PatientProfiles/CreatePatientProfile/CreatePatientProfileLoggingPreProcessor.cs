using FastEndpoints;
using Serilog;
using System;

namespace ProfilesApi.Features.PatientProfiles.CreatePatientProfile
{
    public class CreatePatientProfileLoggingPreProcessor<TRequest> : IPreProcessor<TRequest>
    {
        public Task PreProcessAsync(IPreProcessorContext<TRequest> ctx, CancellationToken ct)
        {
            Log.Information("Post request");
            var req = ctx.Request;
            if (req is CreatePatientProfileRequest patientRequest)
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
