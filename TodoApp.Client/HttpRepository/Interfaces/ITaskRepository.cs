using TodoApp.Client.Pages;
using TodoApp.Shared.Tasks.Commands;

namespace TodoApp.Client.HttpRepository.Interfaces
{
    public interface ITaskRepository
    {
        Task Add(AddTaskCommand command);
    }
}
