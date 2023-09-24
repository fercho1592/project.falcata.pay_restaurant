using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Domain.Models.MainSchema;

namespace Falcata.PayRestaurant.Persistence.QueryBuilder;

public class NoteQueryBuilder: BaseQueryBuilder<Note>, INotesQueryBuilder
{
    public NoteQueryBuilder(IQueryable<Note> queryEntity) : base(queryEntity)
    {
    }
}