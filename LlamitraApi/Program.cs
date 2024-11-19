using LlamitraApi.Models;
using Microsoft.EntityFrameworkCore;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using LlamitraApi.Services;
using LlamitraApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using MimeKit;
using System.Security.Claims;
using LlamitraApi.Commons.Enum;
using LlamitraApi.Models.Validations.DtosValidation.CourseDtosValidation;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Bearer
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Llamitra API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization. <br /> <br />
          Coloca 'Bearer' [Espacio] y pega el Token de autorizacion.<br /> <br />
          Ejemplo: 'Bearer 23891ddad1'<br /> <br />",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
});

builder.Services.AddDbContext<ProyectoIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault"))
);



//Services
var key = builder.Configuration.GetValue<string>("JwtSettings:Key");
var keyBytes = Encoding.ASCII.GetBytes(key);
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("administrador", policy => policy.RequireClaim(ClaimTypes.Role, Roles.administrador.ToString()));
    options.AddPolicy("profesor", policy => policy.RequireClaim(ClaimTypes.Role, Roles.profesor.ToString()));
    options.AddPolicy("usuario", policy => policy.RequireClaim(ClaimTypes.Role, Roles.usuario.ToString()));
});
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PublicationPostDtoValidator>();
builder.Services.AddScoped<IStartRatingService, StartRatingService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IAuthorizacionService, AuthorizacionService>();
builder.Services.AddScoped<IPublicationServices, PublicationServices>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<IPublicationTypeServices, PublicationTypeServices>();

builder.Services.AddScoped<IStartRatingRepository, StartRatingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPublicationTypeRepository,  PublicationTypeRepository>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
//Mappes
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
