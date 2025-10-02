using Ordering.Infrastructure.Extensions;
using Ordering.Application.Extensions;
using Ordering.API.Extension;
using Ordering.Infrastructure.Data;
using Ordering.Application.Commends;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);



}

);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Catolog Api",
        Version = "v1",
        Description = "This Catalog for Microservices Ecommerce Application",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Email = "Mahmoud222Salama@gmail.com",
            Name = "Mahmoud Salama",
            Url = new Uri("https://yourWebsite.com")

        }






    });


});

// Add services to the container.




builder.Services.AddApplicationServices();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CheckoutOrderCommand).Assembly));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();
// Apply migration & seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<OrderContext>();
        var logger = services.GetRequiredService<ILogger<OrderContextSeed>>();

        // Apply migrations
        context.Database.Migrate();

        // Seed data
        await OrderContextSeed.SeedAsync(context, logger);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during migration or seeding");
        throw;
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
