using MediatR;

namespace Falcata.PayRestaurant.Application.Features.Notes.ModifyNote;

public class ModifyNoteCommand: IRequest<bool>
{
    public int NoteId { get; set; }
    public string Message { get; set; }
    
}