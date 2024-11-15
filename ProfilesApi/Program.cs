using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ProfilesApi.Data;
using ProfilesApi.ExceptionHandlers;
using ProfilesApi.Repositories;

namespace ProfilesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<ProfilesContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLProfilesApi")//,
            //    /*x => x.MigrationsAssembly("Migrations")*/));

            //var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            //builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

            //builder.Services.AddDbContext<ProfilesContext>(options =>
            //options.UseMongoDB(mongoDBSettings.AtlasURI ?? "", mongoDBSettings.DatabaseName ?? ""));

            builder.Services.AddDbContext<ProfilesContext>(options =>
            options.UseMongoDB("mongodb://localhost:27017/", "ProfilesApi")); //TODO: move to appsetings

            builder.Services.AddTransient<ProfileRepository, ProfileRepository>();

            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<InvalidOperationExceptionToProblemDetailsHandler>();
            builder.Services.AddExceptionHandler<DefaultExceptionToProblemDetailsHandler>();

            builder.Services.AddFastEndpoints();
            var app = builder.Build();

            //app.UseStatusCodePages();
            app.UseExceptionHandler();

            app.UseFastEndpoints();

            app.Run();
        }
    }
}
