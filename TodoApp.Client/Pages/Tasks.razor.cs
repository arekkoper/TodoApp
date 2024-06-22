using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Client.Services.Interfaces;
using TodoApp.Shared.Tasks.Dtos;

namespace TodoApp.Client.Pages
{
    public partial class Tasks
    {
        private IList<TaskDto> _tasks;
        private bool _showDeleteDialog;
        private MarkupString _deleteDialogBody;
        private int _deleteTaskId;

        [Inject] public ITaskHttpRepository TaskRepository { get; set; }
        [Inject] public IToastrService ToastrService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await RefreshTasks();
        }

        private void DeleteTask(int id, string title)
        {
            _deleteDialogBody = (MarkupString)$"Are you sure you want to delete task:<br><b>{title}</b>?";

            _deleteTaskId = id;

            _showDeleteDialog = true;

        }

        private async Task RefreshTasks()
        {
            _tasks = await TaskRepository.GetAll();
        }

        private async Task DeleteConfirmed(MouseEventArgs e)
        {
            _showDeleteDialog = false;

            await TaskRepository.Delete(_deleteTaskId);

            await ToastrService.ShowSuccessMessage("Task was deleted!");

            await RefreshTasks();
        }

        private void DeleteCanceled(MouseEventArgs e)
        {
            _showDeleteDialog= false;
        }
    }
}