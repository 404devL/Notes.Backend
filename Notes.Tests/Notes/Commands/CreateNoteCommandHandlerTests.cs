using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands;

public class CreateNoteCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateNoteCommandHandler_Success()
    {
        //Arrange
        var handler = new CreateNoteCommandHandler(Context);
        var noteName = "note name";
        var noteDescription = "note description";

        //Act
        var noteId = await handler.Handle(
            new CreateNoteCommand
            {
                Title = noteName,
                Description = noteDescription,
                UserId = NotesContextFactory.UserAId
            },
            CancellationToken.None);

        //Assert
        Assert.NotNull(
            await Context.Notes.SingleOrDefaultAsync(note => note.Id == noteId
            && note.Title == noteName
            && note.Description == noteDescription));
    }
}
