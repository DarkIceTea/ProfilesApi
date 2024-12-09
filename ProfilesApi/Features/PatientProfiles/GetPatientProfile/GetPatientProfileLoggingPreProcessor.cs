using FastEndpoints;
using Serilog;

namespace ProfilesApi.Features.PatientProfiles.GetPatientProfile
{
    public class GetPatientProfileLoggingPreProcessor<TRequest> : IPreProcessor<TRequest>
    {
        public Task PreProcessAsync(IPreProcessorContext<TRequest> ctx, CancellationToken ct)
        {
            var guid = ctx.HttpContext.Request.RouteValues["UserGuid"]?.ToString();
            Log.Information("Get request with guid {0}", guid);
            return Task.CompletedTask;
        }
    }
}
