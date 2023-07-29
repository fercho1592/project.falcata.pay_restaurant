using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Domain.Models.MainSchema;

namespace Falcata.PayRestaurant.Persistence.QueryBuilder;

public class UserQueryBuilder: BaseQueryBuilder<User>, IUserQueryBuilder
{
    public UserQueryBuilder(IQueryable<User> queryEntity) : base(queryEntity)
    {
    }
}