using Notes.Application;
using Notes.Application.Common.Mappings;
using Notes.Application.Interfaces;
using Notes.Persistence;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Notes.WebAPI;

class Program
{
    public static void Main(string[] args)
    {
        //Builder
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
        });

        builder.Services.AddApplication();
        builder.Services.AddPersistance(builder.Configuration);
        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        //App
        var app = builder.Build();

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");

#pragma warning disable ASP0014
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
#pragma warning restore ASP0014

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<NotesDbContext>();
                DbInitialize.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Intialize Db");
            }
        }

        app.Run();
    }
}

