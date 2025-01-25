using BLL.Automapper;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer();
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILinkRepository, LinkRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILinkService, LinkService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));

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
