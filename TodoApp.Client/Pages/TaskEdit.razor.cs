using Microsoft.AspNetCore.Components;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Client.Services.Interfaces;
using TodoApp.Shared.Tasks.Commands;

namespace TodoApp.Client.Pages
{
    public partial class TaskEdit
    {
        [Parameter] public int Id { get; set; }

        private EditTaskCommand _task = new EditTaskCommand();
        private bool _isLoading = false;

        [Inject] public ITaskHttpRepository TaskRepository { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IToastrService ToastrService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _task = await TaskRepository.GetEdit(Id);
        }

        private async Task Save()
        {
            try
            {
                _isLoading = true;

                await TaskRepository.Edit(_task);

                NavigationManager.NavigateTo("/");

                await ToastrService.ShowSuccessMessage("Task was edited");

            }
            finally
            {
                _isLoading = false;
            }
        }
    }
}