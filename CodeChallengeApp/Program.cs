using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CodeChallengeApp.Application.Factories;
using CodeChallengeApp.Application.Mapping;
using CodeChallengeApp.Application.Services;
using CodeChallengeApp.Infrastructure.Data;
using CodeChallengeApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// EF Core configuration
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories.
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register business services and factory pattern.
builder.Services.AddScoped<ITransactionProcessorFactory, TransactionProcessorFactory>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

// Add AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add Controllers.
builder.Services.AddControllers();

// Configure Swagger.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transaction API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transaction API v1"));
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

