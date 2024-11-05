using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ProfilesApi.Data;
using ProfilesApi.Repositories;

namespace ProfilesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ProfilesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLProfilesApi")//,
                /*x => x.MigrationsAssembly("Migrations")*/));

            builder.Services.AddTransient<ProfileRepository, ProfileRepository>();

            builder.Services.AddFastEndpoints();
            var app = builder.Build();

            app.UseFastEndpoints();

            app.Run();
        }
    }
}
