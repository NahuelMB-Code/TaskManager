using Live.Api.Queries;
using Live.Api.TaskService;
using Live.Domain.Repositories;
using Live.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB


// SQL
builder.Services.AddDbContext<DBSqlServerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CStringsSQL")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskServices>();
builder.Services.AddScoped<TaskQueries>();



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
