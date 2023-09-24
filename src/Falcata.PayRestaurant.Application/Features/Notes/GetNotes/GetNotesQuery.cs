using MediatR;

namespace Falcata.PayRestaurant.Application.Features.Notes.GetNotes;

public class GetNotesQuery: IRequest<List<NoteDto>>
{
    public GetNotesQuery(params int[] noteIds)
    {
        NoteIds = noteIds;
    }

    public int[] NoteIds { get; set; }
}