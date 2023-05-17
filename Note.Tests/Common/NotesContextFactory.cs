using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Note.Tests.Common;

public static class NotesContextFactory
{
    public static Guid UserAId { get; set; }

    public static Guid UserBId { get; set; }

    public static Guid NoteIdForDelete { get; set; }

    public static Guid NoteIdForUpdate { get; set; }

    public static NotesDbContext Create()
    {
        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new NotesDbContext(options);

        context.Database.EnsureCreated();
        context.Notes.AddRange(new Note
        {

        })
    }
}
