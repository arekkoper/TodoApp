using System.Net.Http.Json;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Shared.Tasks.Commands;
using TodoApp.Shared.Tasks.Dtos;

namespace TodoApp.Client.HttpRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly HttpClient _client;

        public TaskRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task Add(AddTaskCommand command) => await _client.PostAsJsonAsync("tasks", command);

        public async Task<IList<TaskDto>> GetAll() => await _client.GetFromJsonAsync<IList<TaskDto>>("tasks");
    }
}
