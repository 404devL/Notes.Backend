using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common;

public class NotesContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();

    public static Guid NoteIdForDelete = Guid.NewGuid();
    public static Guid NoteForUpdate = Guid.NewGuid();

    public static NotesDbContext Create()
    {
        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new NotesDbContext(options);

        context.Database.EnsureCreated();
        context.Notes.AddRange(
        new Note
        {
            CreationDate = DateTime.Today,
            Description = "Description1",
            EditDate = null,
            Id = Guid.Parse("3F8F1B18-00A3-4DC2-852A-C4DCE1FD4437"),
            Title = "Title1",
            UserId = UserAId
        },
        new Note
        {
            CreationDate = DateTime.Today,
            Description = "Description2",
            EditDate = null,
            Id = Guid.Parse("{CB06E1BF-E2FA-435D-96EC-B17F2D534C84}"),
            Title = "Title2",
            UserId = UserBId
        },
        new Note
        {
            CreationDate = DateTime.Today,
            Description = "Description3",
            EditDate = null,
            Id = NoteIdForDelete,
            Title = "Title3",
            UserId = UserAId
        },
        new Note
        {
            CreationDate = DateTime.Today,
            Description = "Description3",
            EditDate = null,
            Id = NoteForUpdate,
            Title = "Title4",
            UserId = UserBId
        });
        context.SaveChanges();

        return context;
    }

    public static void Destroy(NotesDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
