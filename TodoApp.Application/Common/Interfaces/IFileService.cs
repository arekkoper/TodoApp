using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.Common.Interfaces;

public interface IFileService
{
    Task Upload(IFormFile file);
}
