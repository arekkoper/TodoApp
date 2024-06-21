using System.Net.Http.Json;
using TodoApp.Client.HttpRepository.Interfaces;
using TodoApp.Shared.Tasks.Commands;

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
    }
}
