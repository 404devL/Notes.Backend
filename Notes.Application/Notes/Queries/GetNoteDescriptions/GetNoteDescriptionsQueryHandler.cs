using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDescriptions;

public class GetNoteDescriptionsQueryHandler : IRequestHandler<GetNoteDescriptionsQuery, NoteDescriptionsVm>
{
    private readonly INotesDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetNoteDescriptionsQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteDescriptionsVm> Handle(GetNoteDescriptionsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => 
        note.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        return _mapper.Map<NoteDescriptionsVm>(entity);
    }
}
