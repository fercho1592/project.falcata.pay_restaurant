using Falcata.PayRestaurant.Domain.Models.MainSchema;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories.Notes;

public interface INotesCommandRepository: 
    ICreateCommandRepository<Note, int>,
    IUpdateCommandRepository<Note, int>,
    IDeleteCommandRepository<Note, int>
{
    
}