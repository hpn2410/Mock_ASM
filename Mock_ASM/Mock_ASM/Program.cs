using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<IStudentInfoService, StudentInfoService>();
// Add repository
builder.Services.AddScoped<IStudentInfoRepository, StudentInfoRepository>();

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("Student_Management");
builder.Services.AddDbContext<MockAsmContext>(options =>
    options.UseSqlServer(connectionString));

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