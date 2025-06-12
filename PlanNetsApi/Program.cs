using Microsoft.EntityFrameworkCore;
using PlanNetsModule.Data.PlanNetsModule.Data;
using PlanNetsModule.Mappings;
using PlanNetsModule.Repositories;
using PlanNetsModule.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Enable CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Custom classes
builder.Services.AddAutoMapper(typeof(PlanNetsProfile).Assembly);

// Register DbContext with SQLite
builder.Services.AddDbContext<PlanNetsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanTypeRepository, PlanTypeRepository>();
builder.Services.AddScoped<IPlanPurposeRepository, PlanPurposeRepository>();
builder.Services.AddScoped<IPlanStatusRepository, PlanStatusRepository>();
builder.Services.AddScoped<IPlanService, PlanService>();

// Register Services
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IPlanTypeService, PlanTypeService>();
builder.Services.AddScoped<IPlanPurposeService, PlanPurposeService>();
builder.Services.AddScoped<IPlanStatusService, PlanStatusService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Use CORS
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();// Entry point
