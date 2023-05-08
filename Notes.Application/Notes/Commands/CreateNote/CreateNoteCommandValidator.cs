using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        RuleFor(createNoteCommand => createNoteCommand.Title).NotEmpty().MaximumLength(230);

        RuleFor(createNoteCommand => createNoteCommand.UserId).NotEqual(Guid.Empty);
    }
}
