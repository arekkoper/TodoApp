using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Shared.Tasks.Commands
{
    public class UploadImageCommand : IRequest
    {
        public IFormFile File { get; set; }
    }
}
