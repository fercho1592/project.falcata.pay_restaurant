using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Domain.Models.MainSchema;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories.Notes;

public interface INotesQueryRepository: IQueryRepository<Note, int>, IQueryBuilderProvider<INotesQueryBuilder, Note>
{
    
}