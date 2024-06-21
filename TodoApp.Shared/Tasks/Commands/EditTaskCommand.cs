using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Shared.Tasks.Commands
{
    public class EditTaskCommand : IRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Filed Title is required.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsExecuted { get; set; }
        public DateTime? Term { get; set; }
    }
}
