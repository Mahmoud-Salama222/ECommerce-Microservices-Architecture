using Catalog.Application.Mapper;
using Catalog.Application.Queries;
using Catalog.Core.Repositries;
using Catalog.Infrastructure.Data.Context;
using Catalog.Infrastructure.Repositries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(ProudctMappingProfile).Assembly);
builder.Services.AddMediatR(config =>
config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(GetProudctByIdQuery))));

//make scan in this apil layer amd register services that implement interface IRqequesthanlder
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProudctRepositories, ProudctRepositry>();
builder.Services.AddScoped<IBrandRepository, ProudctRepositry>();
builder.Services.AddScoped<ITypeRepository, ProudctRepositry>();

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
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
