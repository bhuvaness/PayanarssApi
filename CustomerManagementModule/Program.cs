using Microsoft.EntityFrameworkCore;
using CustomerManagementModule.Mappings;
using CustomerManagementModule.Repositories;
using CustomerManagementModule.Services;
using AutoMapper;
using CustomerManagementModule.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom classes
builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);

// Register DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Register Services
builder.Services.AddScoped<CustomerService>();

builder.Services.AddScoped<CustomerService>();

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

app.Run();// Entry point