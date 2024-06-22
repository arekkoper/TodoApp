using System.Net.Http.Json;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Shared.Tasks.Commands;
using TodoApp.Shared.Tasks.Dtos;

namespace TodoApp.Client.HttpRepository
{
    public class TaskHttpRepository : ITaskHttpRepository
    {
        private readonly HttpClient _client;

        public TaskHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task Add(AddTaskCommand command) => await _client.PostAsJsonAsync("tasks", command);
        public async Task Delete(int id) => await _client.DeleteAsync($"tasks/{id}");
        public async Task Edit(EditTaskCommand command) => await _client.PutAsJsonAsync("tasks", command);
        public async Task<IList<TaskDto>> GetAll() => await _client.GetFromJsonAsync<IList<TaskDto>>("tasks");
        public async Task<EditTaskCommand> GetEdit(int id) => await _client.GetFromJsonAsync<EditTaskCommand>($"tasks/edit/{id}");

    }
}
