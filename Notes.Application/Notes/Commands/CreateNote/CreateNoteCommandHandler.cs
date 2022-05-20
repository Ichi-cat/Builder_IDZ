using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _context;
        private readonly CreateNoteCommandValidating _valid;

        public CreateNoteCommandHandler(INotesDbContext context, CreateNoteCommandValidating valid)
        {
            _context = context;
            _valid = valid;
        }
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            _valid.Valid(request);
            //проверка на существование категории
            var note = new Note {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Text = request.Text
            };
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
