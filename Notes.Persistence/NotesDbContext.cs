﻿using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityNoteConfiguration;

namespace Notes.Persistence;

public class NotesDbContext : DbContext, INotesDbContext
{
    public DbSet<Note> Notes { get; set; }

    public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new NoteConfiguration());
        base.OnModelCreating(builder);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
