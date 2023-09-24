using Falcata.PayRestaurant.Application.Interfaces.Repositories.Notes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Application.Features.Notes.ModifyNote;

public class ModifyNoteCommandHandler: IRequestHandler<ModifyNoteCommand, bool>
{
    private readonly ILogger<ModifyNoteCommandHandler> _logger;
    private readonly INotesCommandRepository _notesCommandRepository;
    private readonly INotesQueryRepository _notesQueryRepository;

    public ModifyNoteCommandHandler(ILogger<ModifyNoteCommandHandler> logger,
        INotesCommandRepository notesCommandRepository,
        INotesQueryRepository notesQueryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _notesCommandRepository = notesCommandRepository ?? throw new ArgumentNullException(nameof(notesCommandRepository));
        _notesQueryRepository = notesQueryRepository ?? throw new ArgumentNullException(nameof(notesQueryRepository));
    }
    
    public async Task<bool> Handle(ModifyNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Start {nameof(ModifyNoteCommandHandler)}");

            var query = _notesQueryRepository.NewQueryBuilder()
                .Tracking()
                .SetPredicate(x => x.NoteId == request.NoteId);
            
            var note = (await _notesQueryRepository.ListAsync(query, cancellationToken)).FirstOrDefault();

            if (note is null)
                throw new KeyNotFoundException($"NoteId({request.NoteId}) not found");

            note.Message = request.Message;
            
            var result = await _notesCommandRepository.UpdateAsync(note, cancellationToken);
                
            return result;
        }
        finally
        {
            _logger.LogInformation($"Ends {nameof(ModifyNoteCommandHandler)}");
        }
    }
}