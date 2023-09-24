namespace Falcata.PayRestaurant.Domain.Models.MainSchema;

public class Note: BaseEntity<int>
{
    public int NoteId { get; set; }
    public string Message { get; set; }
}