using Falcata.PayRestaurant.Application.Interfaces.Repositories.Notes;
using Falcata.PayRestaurant.Domain.Models.MainSchema;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Application.Features.Notes.GetNotes;

public class GetNotesQueryHandler: IRequestHandler<GetNotesQuery, List<NoteDto>>
{
    private readonly INotesQueryRepository _notesQueryRepository;
    private readonly ILogger<GetNotesQuery> _logger;

    public GetNotesQueryHandler(
        INotesQueryRepository notesQueryRepository,
        ILogger<GetNotesQuery> logger)
    {
        _notesQueryRepository = notesQueryRepository ?? throw new ArgumentNullException(nameof(notesQueryRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public async Task<List<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Start {nameof(GetNotesQueryHandler)}");
            var query = _notesQueryRepository.NewQueryBuilder();

            if (request.NoteIds is not {Length: 0})
                query.SetPredicate(x => request.NoteIds.Contains(x.NoteId));

            var notes = await _notesQueryRepository.ListAsync(query, cancellationToken);

            return notes.Select(MapNoteDto).ToList();
        }
        finally
        {
            _logger.LogInformation($"Ends {nameof(GetNotesQueryHandler)}");
        }
    }

    public NoteDto MapNoteDto(Note note) => new NoteDto()
    {
        NoteId = note.NoteId,
        Note = note.Message,
    };
}