﻿using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly INotesDbContext _dbContext;

    public DeleteNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        _dbContext.Notes.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
