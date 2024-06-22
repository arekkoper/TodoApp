using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Client.Services.Interfaces;
using TodoApp.Shared.Tasks.Commands;

namespace TodoApp.Client.Pages
{
    public partial class TaskAdd
    {
        private bool _isLoading = false;
        private string _imageFullUrl;

        private AddTaskCommand _task = new AddTaskCommand() { Term = DateTime.Now };

        [Inject] public ITaskHttpRepository TaskRepository { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IToastrService ToastrService { get; set; }
        [Inject] public IConfiguration Configuration { get; set; }

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

        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            var selectedFile = e.File;

            if (selectedFile == null)
                return;

            await TaskRepository.UploadImage(selectedFile);

            _imageFullUrl = $"{Configuration["ApiConfiguration:BaseAddress"]}/content/files/{selectedFile.Name}";

            _task.ImageUrl = _imageFullUrl;
        }
    }
}