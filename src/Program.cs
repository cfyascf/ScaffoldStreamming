using App.Exceptions;
using App.Interfaces.Repositories;
using App.Models;
using App.Repositories;
using App.Service;
using App.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer("Data Source=CA-C-00657\\SQLEXPRESS;Initial Catalog=scaffoldstreammingdb;Integrated Security=true;Trust Server Certificate=True")
);

builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<VideoService, VideoService>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<PasswordService, PasswordService>();
builder.Services.AddScoped<UnitOfWork, UnitOfWork>();

builder.Services.AddCors(op => op
    .AddPolicy("main", policy => policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
    )
);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/*");

app.UseCors("main");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
