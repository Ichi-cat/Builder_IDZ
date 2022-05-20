using MediatR;
using System;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
