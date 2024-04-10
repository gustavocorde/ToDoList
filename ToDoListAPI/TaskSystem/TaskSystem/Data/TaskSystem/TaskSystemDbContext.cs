using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskSystem.Data.Map;
using TaskSystem.Models;

namespace TaskSystem.Data.TaskSystem
{
    public class TaskSystemDbContext : DbContext
    {
        public TaskSystemDbContext(DbContextOptions<TaskSystemDbContext> options)
            : base(options) 
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(connectionString:"DataSource=app.db;Cache=Shared");

    }
}
