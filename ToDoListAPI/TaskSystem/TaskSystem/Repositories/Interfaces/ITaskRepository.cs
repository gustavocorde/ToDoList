using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> SearchAllTasks();
        Task<TaskModel> SearchById(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task, int id);

        Task<bool> Delete(int id);
    }
}
