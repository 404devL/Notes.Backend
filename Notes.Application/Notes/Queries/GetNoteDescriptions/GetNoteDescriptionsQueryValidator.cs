using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteDescriptions;

public class GetNoteDescriptionsQueryValidator : AbstractValidator<GetNoteDescriptionsQuery>
{
    public GetNoteDescriptionsQueryValidator()
    {
        RuleFor(note => note.UserId).NotEqual(Guid.Empty);

        RuleFor(note => note.Id).NotEqual(Guid.Empty);
    }
}
