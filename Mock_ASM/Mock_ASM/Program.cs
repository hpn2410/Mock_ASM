using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Mapping;
using AutoMapper;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.IgnoreNullValues = true;
    }).AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<IStudentInfoService, StudentInfoService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<InstructorService, InstructorBLLService>();
builder.Services.AddScoped<IClassService, ClassService>();
// Add repository
builder.Services.AddScoped<IStudentInfoRepository, StudentInfoRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<InstructorRepository, InstructorDbRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingInfo));

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
