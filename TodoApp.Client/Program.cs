using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoApp.Client;
using TodoApp.Client.HttpRepository;
using TodoApp.Client.HttpRepository.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TodoAppAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiConfiguration:BaseAddress"] + "/api/");
    client.Timeout = TimeSpan.FromMinutes(5);
});

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("TodoAppAPI"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

await builder.Build().RunAsync();
