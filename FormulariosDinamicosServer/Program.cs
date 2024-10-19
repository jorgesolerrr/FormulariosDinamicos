using FormulariosDinamicosServer.Data;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using FormulariosDinamicos.Services.FormService;
using System.Text.Json.Serialization;
using FormulariosDinamicosServer.Services.TypeService;
using FormulariosDinamicosServer.Services.FormFieldService;
using FormulariosDinamicosServer.Services.FormValueService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
                // .AddJsonOptions(options =>
                // {
                //     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                // }
                // );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    var host = builder.Configuration["DBHOST"] ?? "localhost";
    var port = builder.Configuration["DBPORT"] ?? "3306";
    var password = builder.Configuration["MYSQL_PASSWORD"] ?? "1234";
    var user = builder.Configuration["MYSQL_USER"] ?? "root";
    var usersDataBase = builder.Configuration["MYSQL_DATABASE"] ?? "DynamicForms";
    var connString = $"server={host}; user={user};password={password};port={port};database={usersDataBase}; Persist Security Info=False; Connect Timeout=300";

    options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IFormRepository, FormService>();
builder.Services.AddScoped<IFormValueRepository, FormValueService>();
builder.Services.AddScoped<IFormFieldRepository, FormFieldService>();
builder.Services.AddScoped<ITypeRepository, TypeService>();


var app = builder.Build();

app.UseCors("AllowAll");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
