using MediatR;

namespace Falcata.PayRestaurant.Application.Features.Notes.CreateNote;

public class CreateNoteCommand: IRequest<int>
{
    public string Note { get; set; }
}