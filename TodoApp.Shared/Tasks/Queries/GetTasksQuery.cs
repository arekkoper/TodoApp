using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Shared.Tasks.Dtos;

namespace TodoApp.Shared.Tasks.Queries
{
    public class GetTasksQuery : IRequest<IEnumerable<TaskDto>>
    {
    }
}
