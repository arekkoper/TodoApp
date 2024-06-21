using Microsoft.JSInterop;
using TodoApp.Client.Services.Interfaces;

namespace TodoApp.Client.Services
{
    public class ToastrService : IToastrService
    {
        private readonly IJSRuntime _jSRuntime;

        public ToastrService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task ShowErrorMessage(string message)
        {
            await _jSRuntime.InvokeVoidAsync("toastrFunctions.showToastrInfo", message);
        }

        public async Task ShowInfoMessage(string message)
        {
            await _jSRuntime.InvokeVoidAsync("toastrFunctions.showToastrSuccess", message);
        }

        public async Task ShowSuccessMessage(string message)
        {
            await _jSRuntime.InvokeVoidAsync("toastrFunctions.showToastrError", message);
        }
    }
}
