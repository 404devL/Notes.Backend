using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands;

public class DeleteNoteCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteNoteCommandHandler_Success()
    {
        //Arrange
        var handler = new DeleteNoteCommandHandler(Context);

        //Act
        await handler.Handle(new DeleteNoteCommand
        {
            Id = NotesContextFactory.NoteIdForDelete,
            UserId = NotesContextFactory.UserAId
        }, CancellationToken.None);

        //Asert
        Assert.Null(Context.Notes.SingleOrDefault(note => 
        note.Id == NotesContextFactory.NoteIdForDelete));
    }

    [Fact]
    public async Task DeleteNoteCommandHandler_FailOrWrong()
    {
        //Arrange
        var handler = new DeleteNoteCommandHandler(Context);

        //Act


        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteNoteCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = NotesContextFactory.UserAId
                }, CancellationToken.None));

    }
}
