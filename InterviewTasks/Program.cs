using InterviewTasks.Application.Services;
using InterviewTasks.Core.Abstractions;
using InterviewTasks.Core.Factories;
using InterviewTasks.Core.Models;
using InterviewTasks.DataAccess;
using InterviewTasks.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<InterviewTasksDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConectionString"));
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICategoryFactory, CategoryFactory>();
builder.Services.AddScoped<ITagFactory, TagFactory>();
builder.Services.AddScoped<ITestTaskFactory, TestTaskFactory>();
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
builder.Services.AddScoped<IService<TestTask>, TestTaskService>();
builder.Services.AddScoped<IService<Category>, CategoryService>();
builder.Services.AddScoped<IService<Tag>, TagService>();
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

