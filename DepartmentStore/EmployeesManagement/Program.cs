using EmployeesManagement.Models.dto;
using EmployeesManagement.Models.entities;
using EmployeesManagement.Repositories;
using EmployeesManagement.Repositories.Impl;
using EmployeesManagement.Services;
using EmployeesManagement.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MariaDB.Extensions;

var builder = WebApplication.CreateBuilder (args); 

var configuration = builder.Configuration;
configuration.AddEnvironmentVariables ();

// add policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy ("WritePermission", policy => policy.RequireClaim ("CanWrite", "True"));
    options.AddPolicy ("ReadPermission", policy => policy.RequireClaim ("CanRead", "True"));
});

//enable Serilog
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information);
    lc.WriteTo.MariaDB(connectionString: configuration.GetConnectionString("EmployeesDBConnection"),
        tableName: "logs",
        autoCreateTable: true,
        useBulkInsert: false,
        options: new Serilog.Sinks.MariaDB.MariaDBSinkOptions());
});

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

builder.Services.AddCors (options =>
{
    options.AddPolicy ("MY_CORS", policy =>
    {
        policy.AllowAnyOrigin ();
        policy.AllowAnyMethod ();
        policy.AllowAnyHeader ();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen (c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors ("MY_CORS");

app.MapControllers();

app.Run();

