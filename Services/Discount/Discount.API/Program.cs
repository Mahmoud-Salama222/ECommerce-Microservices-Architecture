using Catalog.Application.commends;
using Catalog.Application.Mapper;
using Discount.API.Services;
using Discount.Core.Repositries;
using Discount.Infrastructure.Data;
using Discount.Infrastructure.Repositries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(DiscountProfile).Assembly);
builder.Services.AddMediatR(config =>
config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(CreateCouponCommend))));
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddGrpc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MigrateDarabase<Program>();
app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<DiscountServices>();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("communction with Grpc endpoints made be throw a grpc client");
    });

});



app.Run();
