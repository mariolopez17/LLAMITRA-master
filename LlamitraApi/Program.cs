using LlamitraApi.Models;
using Microsoft.EntityFrameworkCore;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using LlamitraApi.Services;
using LlamitraApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProyectoIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault"))
);


//Services
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IVideoServices, VideoServices>();
builder.Services.AddScoped<IPresentialServices, PresentialServices>();
builder.Services.AddScoped<IInLiveServices, InLiveServices>();

//Repository
builder.Services.AddScoped<IInLiveRepository, InLiveRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPresentialRepository, PresentialRepository>();
builder.Services.AddScoped<IVideoRepository,VideoRepository>();

//Mappes
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
