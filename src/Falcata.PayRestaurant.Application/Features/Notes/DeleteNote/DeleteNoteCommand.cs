using MediatR;

namespace Falcata.PayRestaurant.Application.Features.Notes.DeleteNote;

public class DeleteNoteCommand: IRequest<bool>
{
    public int NoteId { get; set; }
}