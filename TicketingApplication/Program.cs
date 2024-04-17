using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Reflection;
using TicketingApplication.Entities;
using TicketingApplication.Repository;
using TicketingApplication.Services;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TicketingApplicationDBContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("TSConnectionString"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITicketTransactionService, TicketTransactionService>();
builder.Services.AddTransient<IActionService, ActionService>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(loggingBuilder =>
{
	loggingBuilder.ClearProviders();
	loggingBuilder.AddNLog();
});

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
