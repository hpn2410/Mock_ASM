using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Mapping;
using AutoMapper;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using DataAccessLayer.Sorting;
using Microsoft.OpenApi.Any;
using Mock_ASM;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
//builder.Services.AddControllers(options =>
//{
//    options.ReturnHttpNotAcceptable = true;
//}).AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//    options.JsonSerializerOptions.IgnoreNullValues = true;
//}).AddXmlDataContractSerializerFormatters();

builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddExceptionHandler<AppExceptionHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });

    // Customize sortFieldDisplay parameter description
    c.MapType<SortField>(() => new OpenApiSchema
    {
        Description = "Choose a field to sort by: StudentName, DateOfBirth, Phone, Email",
        Enum = Enum.GetNames(typeof(SortField)).Select(x => new OpenApiString(x)).ToList().OfType<IOpenApiAny>().ToList()
    });
    c.MapType<SortType>(() => new OpenApiSchema
    {
        Description = "Choose a type to sort: Ascending, Descending",
        Enum = Enum.GetNames(typeof(SortType)).Select(x => new OpenApiString(x)).ToList().OfType<IOpenApiAny>().ToList()
    });
});

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
var connectionString = builder.Configuration.GetConnectionString("Mock_ASM_Db");
builder.Services.AddDbContext<MockAsmContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();