using Microsoft.AspNetCore.Components;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Client.Services.Interfaces;
using TodoApp.Shared.Tasks.Commands;

namespace TodoApp.Client.Pages
{
    public partial class TaskAdd
    {
        private bool _isLoading = false;

        private AddTaskCommand _task = new AddTaskCommand() { Term = DateTime.Now };

        [Inject] public ITaskRepository TaskRepository { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IToastrService ToastrService { get; set; }

        private async Task Save()
        {
            try
            {
                _isLoading = true;

                await TaskRepository.Add(_task);

                NavigationManager.NavigateTo("/");

                await ToastrService.ShowSuccessMessage("You added a new task!");
            }
            finally
            {
                _isLoading = false;
            }
        }
    }
}