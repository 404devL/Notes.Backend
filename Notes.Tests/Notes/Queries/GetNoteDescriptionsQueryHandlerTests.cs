using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteDescriptions;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Persistence;
using Notes.Tests.Common;
using Shouldly;

namespace Notes.Tests.Notes.Queries;

[Collection("QueryCollection")]
public class GetNoteDescriptionsQueryHandlerTests
{
    private readonly NotesDbContext _context;
    private readonly IMapper _mapper;

    public GetNoteDescriptionsQueryHandlerTests(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetNoteDescriptionsQueryHandler_Success()
    {
        //Arrange
        var handler = new GetNoteDescriptionsQueryHandler(_context, _mapper);

        //Act
        var result = await handler.Handle(
            new GetNoteDescriptionsQuery
            {
                UserId = NotesContextFactory.UserBId,
                Id = Guid.Parse("CB06E1BF-E2FA-435D-96EC-B17F2D534C84")
            }, CancellationToken.None);

        //Assert
        result.ShouldBeOfType<NoteDescriptionsVm>();
        result.Title.ShouldBe("Title2");
        result.CreationDate.ShouldBe(DateTime.Today);
    }
}
