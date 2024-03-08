using ConnectionEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
//using ConnectionEntityFramework.Models;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// inyecion de dependencia

// DBTaskManagementContextBase sdff = new DBTaskManagementContextSQL();

builder.Services.AddDbContext<DBTaskManagementContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CStringsSQL")));
//builder.Services.AddDbContext<DBTaskManagementContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CStringsSQL")));

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var myRulesCors = "RulesCord";
builder.Services.AddCors(opt => opt.AddPolicy(name: myRulesCors, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myRulesCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
