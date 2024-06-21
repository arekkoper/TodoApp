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
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTaskCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            _context.Tasks.Remove(new Domain.Entities.Task { Id = request.Id });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
