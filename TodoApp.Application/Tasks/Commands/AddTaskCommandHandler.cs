using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Shared.Tasks.Commands;

namespace TodoApp.Application.Tasks.Commands
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Entities.Task
            {
                Description = request.Description,
                Title = request.Title,
                IsExecuted = request.IsExecuted,
                Term = request.Term,
            };

            _context.Tasks.Add(task);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
