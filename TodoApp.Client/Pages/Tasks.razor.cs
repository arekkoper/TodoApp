using Microsoft.AspNetCore.Components;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Shared.Tasks.Dtos;

namespace TodoApp.Client.Pages
{
    public partial class Tasks
    {
        private IList<TaskDto> _tasks;

        [Inject] public ITaskHttpRepository TaskRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _tasks = await TaskRepository.GetAll();
        }
    }
}