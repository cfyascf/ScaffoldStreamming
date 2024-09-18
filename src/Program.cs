using App.Interfaces.Repositories;
using App.Models;
using App.Repositories;
using App.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer("Data Source=SJP-C-00002\\SQLEXPRESS01;Initial Catalog=scaffoldstreammingdb;Integrated Security=true;Trust Server Certificate=True")
);

builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<VideoService, VideoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
