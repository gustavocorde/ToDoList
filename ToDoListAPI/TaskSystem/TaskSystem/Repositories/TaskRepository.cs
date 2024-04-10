using Microsoft.EntityFrameworkCore;
using TaskSystem.Data.TaskSystem;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
        public class TaskRepository : ITaskRepository
        {
            private readonly TaskSystemDbContext _dbContext;

            public TaskRepository(TaskSystemDbContext TaskSystemDBContext) 
            {
                _dbContext = TaskSystemDBContext;
            }

            public async Task<TaskModel> SearchById(int id)
            {
                return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<List<TaskModel>> SearchAllTasks()
            {
                return await _dbContext.Tasks.ToListAsync();
            }

            public async Task<TaskModel> Add(TaskModel task)
            {
                await _dbContext.Tasks.AddAsync(task);
                await _dbContext.SaveChangesAsync();

                return task;
            }

            public async Task<TaskModel> Update(TaskModel task, int id)
            {
                TaskModel taskById = await SearchById(id);

                if(taskById == null)
                {
                    throw new Exception("No task with an Id: " +  id + "was found");
                }

                taskById.Name = task.Name;
                taskById.TaskStatus = task.TaskStatus;

                _dbContext.Tasks.Update(taskById);
                await _dbContext.SaveChangesAsync();

                return taskById;
            }

            public async Task<bool> Delete(int id)
            {
                TaskModel taskById = await SearchById(id);

                if (taskById == null)
                {
                    throw new Exception("No task with and Id" + id + "was found.");
                }

                _dbContext.Tasks.Remove(taskById);
                await _dbContext.SaveChangesAsync();

                return true;
            }
        }
    }

