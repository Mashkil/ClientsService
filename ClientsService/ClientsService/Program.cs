using ClientsService.Application.Services;
using ClientsService.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClientsService, ClientService>();
builder.Services.AddDbContext<ClientsDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("ClientsService.DataAccess")));

var bul = builder.Services.BuildServiceProvider();

bul.GetService<ClientsDbContext>().Database.EnsureCreated();


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