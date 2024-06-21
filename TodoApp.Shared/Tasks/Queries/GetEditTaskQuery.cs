using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Shared.Tasks.Commands;

namespace TodoApp.Shared.Tasks.Queries
{
    public class GetEditTaskQuery : IRequest<EditTaskCommand>
    {
        public int Id { get; set; }
    }
}
