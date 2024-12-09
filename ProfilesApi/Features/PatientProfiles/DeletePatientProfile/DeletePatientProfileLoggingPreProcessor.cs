using FastEndpoints;
using Serilog;

namespace ProfilesApi.Features.PatientProfiles.DeletePatientProfile
{
    public class DeletePatientProfileLoggingPreProcessor<TRequest> : IPreProcessor<TRequest>
    {
        public Task PreProcessAsync(IPreProcessorContext<TRequest> ctx, CancellationToken ct)
        {
            var guid = ctx.HttpContext.Request.RouteValues["UserGuid"]?.ToString();
            Log.Information("Delete request with guid {0}", guid);
            return Task.CompletedTask;
        }
    }
}
