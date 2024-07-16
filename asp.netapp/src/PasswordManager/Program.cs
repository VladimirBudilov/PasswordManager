using FluentValidation.AspNetCore;
using Infrastructure_Layer;
using Microsoft.OpenApi.Models;
using PasswordManager.Exceptions;
using PasswordManager.Mappings;
using PasswordManager.Services;
using PasswordManager.Validations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PasswordEntryDtoValidator>());
builder.Services.AddInfrastructure();
builder.Services.AddScoped<PasswordManagerService>();
builder.Services.AddAutoMapper(typeof(PasswordEntryProfile));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Password API", Version = "v1" });
});
builder.Services.AddCors(options =>
    {
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();
app.UseExceptionHandler();

app.MapControllers();
app.UseSwagger();
app.UseCors();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Password Manager API V1");
    c.RoutePrefix = string.Empty;
});

var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
DbInitializer.SeedDatabase(dbContext);

app.Run();