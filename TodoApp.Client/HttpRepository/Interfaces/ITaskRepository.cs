using TodoApp.Client.Pages;
using TodoApp.Shared.Tasks.Commands;
using TodoApp.Shared.Tasks.Dtos;

namespace TodoApp.Client.HttpRepository.Interfaces
{
    public interface ITaskRepository
    {
        Task Add(AddTaskCommand command);
        Task<IList<TaskDto>> GetAll();
    }
}
