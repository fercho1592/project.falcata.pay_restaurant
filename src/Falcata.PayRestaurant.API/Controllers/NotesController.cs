using Falcata.PayRestaurant.Application.Features.Notes;
using Falcata.PayRestaurant.Application.Features.Notes.CreateNote;
using Falcata.PayRestaurant.Application.Features.Notes.DeleteNote;
using Falcata.PayRestaurant.Application.Features.Notes.GetNotes;
using Falcata.PayRestaurant.Application.Features.Notes.ModifyNote;
using MediatR;

namespace Falcata.PayRestaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController: BaseController
{
    private readonly IMediator _mediator;

    public NotesController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("")]
    public async Task<List<NoteDto>> GetNotesAsync()
    {
        return await _mediator.Send(new GetNotesQuery());
    }
    
    [HttpPut("")]
    public async Task<int> CreateNotesAsync(CreateNoteCommand command)
    {
        return await _mediator.Send(command);
    }
    
    [HttpPost("{noteId:int}")]
    public async Task<bool> UpdateNotesAsync(int noteId, ModifyNoteCommand command)
    {
        command.NoteId = noteId;
        return await _mediator.Send(command);
    }
    
    [HttpDelete("{noteId:int}")]
    public async Task<bool> GetNotesAsync(int noteId)
    {
        return await _mediator.Send(new DeleteNoteCommand(){NoteId = noteId});
    }
}