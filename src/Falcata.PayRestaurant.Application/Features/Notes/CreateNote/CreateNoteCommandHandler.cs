using Falcata.PayRestaurant.Application.Interfaces.Repositories.Notes;
using Falcata.PayRestaurant.Domain.Models.MainSchema;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Application.Features.Notes.CreateNote;

public class CreateNoteCommandHandler: IRequestHandler<CreateNoteCommand, int>
{
    private readonly ILogger<CreateNoteCommandHandler> _logger;
    private readonly INotesCommandRepository _notesCommandRepository;

    public CreateNoteCommandHandler(ILogger<CreateNoteCommandHandler> logger,
        INotesCommandRepository notesCommandRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _notesCommandRepository = notesCommandRepository ?? throw new ArgumentNullException(nameof(notesCommandRepository));
    }
    
    public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Start {nameof(CreateNoteCommandHandler)}");

            var note = new Note()
            {
                Message = request.Note,
            };

            var result = await _notesCommandRepository.CreateAsync(note, cancellationToken);
            
            return note.NoteId;
        }
        finally
        {
            _logger.LogInformation($"Ends {nameof(CreateNoteCommandHandler)}");
        }
    }
}