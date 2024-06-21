using TodoApp.Client.HttpRepository.Interfaces;

namespace TodoApp.Client.HttpRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly HttpClient _client;

        public TaskRepository(HttpClient client)
        {
            _client = client;
        }
    }
}
