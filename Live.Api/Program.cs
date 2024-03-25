using Live.Api.Controllers;
using Live.Api.Queries;
using Live.Api.TaskService;
using Live.Domain.Repositories;
using Live.Infrastructure;
using Live.InfrastructureMongoDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB
var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//var CStringMongoDB = MyConfig.GetValue<string>("ConnectionStringsMongoDB:CStringMongoDB");
//var DatabaseName = MyConfig.GetValue<string>("ConnectionStringsMongoDB:DatabaseName");


//builder.Services.AddDbContext<DBMongoContext>(opt => opt.UseMongoDB(connectionString: CStringMongoDB!, databaseName: DatabaseName!));


builder.Services.AddControllers();

// Registra las opciones de configuración
//builder.Services.Configure<TasksControllerOptions>( .GetSection("TasksController"));
//builder.Services.AddTransient(typeof(TasksController<>));
//builder.Services.AddTransient<TasksController<Guid>>();
builder.Services.AddScoped<TaskServices<Guid>>();
builder.Services.AddScoped<TaskQueries<Guid>>();



// SQL
builder.Services.AddDbContext<DBSqlServerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CStringsSQL")));




builder.Services.AddScoped<ITaskRepository<Guid>, TaskRepository>();
//builder.Services.AddScoped<ITaskRepository, TaskRepositoryMongoDB>();





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
