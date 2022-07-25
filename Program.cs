using ApirestNet.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// all paths are lowercase
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

// Add database 
builder.Services.AddDbContext<CustomerDatabaseContext>(mysqlbuilder => {
    mysqlbuilder.UseMySQL(builder.Configuration.GetConnectionString("ConectionDatabase"));
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
