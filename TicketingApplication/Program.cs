using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using TicketingApplication.Entities;
using TicketingApplication.Repository;
using TicketingApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TSDBContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("TSConnectionString"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITicketsrv, Ticketsrv>();
builder.Services.AddTransient<IUsersrv, Usersrv>();
builder.Services.AddTransient<ITicketTransactionsrv, TicketTransactionsrv>();
builder.Services.AddTransient<IActionsrv, Actionsrv>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
