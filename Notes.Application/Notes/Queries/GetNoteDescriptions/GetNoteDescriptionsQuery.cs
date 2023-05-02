using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteDescriptions;

public class GetNoteDescriptionsQuery : IRequest<NoteDescriptionsVm>
{
    public Guid UserId { get; set; }

    public Guid Id { get; set; }
}
