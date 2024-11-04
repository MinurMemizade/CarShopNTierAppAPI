using Microsoft.OpenApi.Models;
using App.Business;
using NTierApp.Dal;
using App.API;
using NTierApp.Dal.Context;
using NTierApp.Dal.Repositories.Interfaces;
using NTierApp.Dal.Repositories.Abstractions;
using NTierApp.Bussiness.Services.Abstractions;
using NTierApp.Bussiness.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NTierApp.Core.Entities.Identity;
using App.DAL.Presistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "App.API", Version = "v1" });
});
builder.Services.AddSwagger();
builder.Services.AddJwt(builder.Configuration);

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
})
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Run database migrations and seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await AutomatedMigration.MigrateAsync(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.AddMiddlewares(); // Custom middlewares
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
