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
//swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Password API", Version = "v1" });
});
//corse
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

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

//seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    DbInitializer.SeedDatabase(context);
}

app.Run();