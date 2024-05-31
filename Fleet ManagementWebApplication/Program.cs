
using Dapper;
using Fleet_ManagementWebApplication.Services;

        var builder = WebApplication.CreateBuilder(args);
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IDbService, DbService>();
        builder.Services.AddScoped<IVehicleService, VehicleService>();
        builder.Services.AddScoped<IDriver, DriverService>();
        builder.Services.AddScoped<IVehicleInformation, VehicleInformation>();
        builder.Services.AddScoped<IRouteHistoryService, RouteHistoryService>();
        builder.Services.AddScoped<IGeofencesService, GeofencesService>();
        builder.Services.AddAuthorization();
        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
             app.UseSwagger();
             app.UseSwaggerUI();
        }

        app.MapGet("/", () => "Hello World!");

        app.UseCors(options =>
        {
            options.AllowAnyHeader();
            options.AllowAnyMethod();
            options.AllowAnyOrigin();
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
