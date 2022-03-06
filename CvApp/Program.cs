using CvApp.Middleware;
using CvApp.Repositories;
using CvApp.Services;
using CvApp.Services.Covers;
using CvApp.Services.Resumes;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddRepositories(builder.Configuration.GetSection(nameof(RepositoryOptions)))
    .AddServices(builder.Configuration.GetSection(nameof(ResumeServiceOptions)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app
    .UseHttpsRedirection()
    .UseMiddleware<ApiExceptionMiddleware>();

app.MapGet("/{id}/resume", (string id, IResumeService resumeService) => resumeService.GetByCoverIdAsync(id));
app.MapGet("/{id}/cover", (string id, ICoverService coverService) => coverService.GetCoverContentAsync(id));

app.Run();