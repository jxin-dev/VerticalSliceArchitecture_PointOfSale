using Asp.Versioning;
using Asp.Versioning.Builder;
using Carter;
using Microsoft.OpenApi.Models;
using Web.Api.Database;
using Web.Api.Features.Categories;
using Web.Api.Features.Products;
using Web.Api.Features.Suppliers;
using Web.Api.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddProductFeature();
builder.Services.AddCategoryFeature();
builder.Services.AddSupplierFeature();



builder.Services.AddCarter();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
    });


builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

var app = builder.Build();




ApiVersionSet apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .HasApiVersion(new ApiVersion(2))
    .HasApiVersion(new ApiVersion(3))
    .Build();

RouteGroupBuilder versionGroup = app.MapGroup("api/v{version:apiVersion}")
    .WithApiVersionSet(apiVersionSet);

versionGroup.MapCarter();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseHttpsRedirection();


app.Run();

