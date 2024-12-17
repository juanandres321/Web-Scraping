using Due_Diligence.Repository;
using Due_Diligence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web_Scraping.Mappers;
using Web_Scraping.Models;
using Web_Scraping.Repository;
using Web_Scraping.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios antes de Build()

// Configura el DbContext
builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura los controladores
builder.Services.AddControllers();

// Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configura Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JWT TOKEN
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
});
// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularApp", policyBuilder =>
    {
        policyBuilder
            .WithOrigins("http://localhost:4200")  
            .AllowAnyHeader()                       
            .AllowAnyMethod()                       
            .AllowCredentials();                   
    });
});

// Dependencias
builder.Services.AddScoped<IScrapperService, ScrapperService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AngularApp");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
