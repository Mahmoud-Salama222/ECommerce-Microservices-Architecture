using EventBus.Messages.Common;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Ordering.API.EventBusConsumer;
using Ordering.Application.Commends;
using Ordering.Application.Extensions;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
        Title = " Ordering Api",
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
builder.Services.AddScoped<BasketOrderingConsumer>();
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketOrderingConsumer>();
    config.UsingRabbitMq((ct, cfg) =>
    {

        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstant.BasketCheckOutQueue, c =>
        {
            c.ConfigureConsumer<BasketOrderingConsumer>(ct);
        });
    });
});
builder.Services.AddMassTransitHostedService();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CheckoutOrderCommand).Assembly));

builder.Services.AddOpenApi();

var app = builder.Build();
//Apply migration & seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<OrderContext>();
        var logger = services.GetRequiredService<ILogger<OrderContextSeed>>();

        // Apply migrations
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

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
