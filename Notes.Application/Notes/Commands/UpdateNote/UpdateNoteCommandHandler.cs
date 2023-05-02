using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
{
    private readonly INotesDbContext _dbContext;

    public UpdateNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => 
        note.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
