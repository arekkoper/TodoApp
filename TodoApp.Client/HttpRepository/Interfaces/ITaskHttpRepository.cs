using Microsoft.AspNetCore.Components.Forms;
using TodoApp.Client.Pages;
using TodoApp.Shared.Tasks.Commands;
using TodoApp.Shared.Tasks.Dtos;

namespace TodoApp.Client.HttpRepository.Interfaces
{
    public interface ITaskHttpRepository
    {
        Task Add(AddTaskCommand command);
        Task Edit(EditTaskCommand command);
        Task Delete(int id);
        Task<IList<TaskDto>> GetAll();
        Task<EditTaskCommand> GetEdit(int id);
        Task UploadImage(IBrowserFile file);
    }
}
