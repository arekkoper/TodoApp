using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Shared.Tasks.Commands;

namespace TodoApp.Application.Tasks.Commands
{
    public class EditTaskCommandHandler : IRequestHandler<EditTaskCommand>
    {
        private readonly IApplicationDbContext _context;

        public EditTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context
                .Tasks
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if(task == null)
            {
                throw new Exception("not found");
            }

            task.IsExecuted = request.IsExecuted;
            task.Description = request.Description;
            task.Title = request.Title;
            task.Term = request.Term;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
