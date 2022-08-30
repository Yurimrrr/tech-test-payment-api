using Microsoft.EntityFrameworkCore;
using Payment.Domain.Handlers;
using Payment.Domain.Infra.Contexts;
using Payment.Domain.Infra.Repositories;
using Payment.Domain.Repositores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ProductHandle, ProductHandle>();
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
