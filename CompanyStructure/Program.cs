using Microsoft.EntityFrameworkCore;
using Serilog;
using CompanyStructure.Data;
using CompanyStructure.Configurations;
using Microsoft.AspNetCore.Identity;
using CompanyStructure.Contract;
using CompanyStructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("CompanyDbConnection");
builder.Services.AddDbContext<CompanyDBContext>(opt =>
    opt.UseSqlServer(connString));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CompanyDBContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddCors(opt =>
    opt.AddPolicy("AllowAll", 
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()));

builder.Services.AddScoped<IAuthManager, AuthManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
