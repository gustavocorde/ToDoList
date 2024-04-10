using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Data.TaskSystem;
using TaskSystem.Repositories;
using TaskSystem.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlite()
    .AddDbContext<TaskSystemDbContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
    

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
