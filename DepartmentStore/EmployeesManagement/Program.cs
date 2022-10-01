using EmployeesManagement.Models.dto;
using EmployeesManagement.Models.entities;
using EmployeesManagement.Repositories;
using EmployeesManagement.Repositories.Impl;
using EmployeesManagement.Services;
using EmployeesManagement.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
configuration.AddEnvironmentVariables ();

// Add services to the container.

// add DBContext
builder.Services.AddDbContext<employeesContext>(options =>
{
    var connectionString = configuration.GetConnectionString ("EmployeesDBConnection");
    var version = ServerVersion.Parse ("8.0.26-mysql");
    options.UseMySql (connectionString, version);
});

// add custom services
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeesService, EmployeeService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDeptEmpRepository, DeptEmpRepository>();

builder.Services.AddControllers();

#region auth
// enable jwt
var jwtSection = builder.Configuration.GetSection("JwtSettings");
var jwtSettings = jwtSection.Get<JwtSettings>();
var key = System.Text.Encoding.ASCII.GetBytes (jwtSettings.Secret);

builder.Services.Configure<JwtSettings>(jwtSection);

builder.Services.AddAuthentication (authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer (bearerOptions =>
{
    bearerOptions.RequireHttpsMetadata = false;
    bearerOptions.SaveToken = true;
    bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey (key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

