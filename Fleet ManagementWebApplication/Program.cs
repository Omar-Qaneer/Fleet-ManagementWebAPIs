
using Fleet_ManagementWebApplication.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<IDbService, DbService>();
        builder.Services.AddScoped<IVehicleService, VehicleService>();
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}