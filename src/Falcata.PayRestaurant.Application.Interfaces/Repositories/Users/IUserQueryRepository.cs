using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Domain.Models.MainSchema;

namespace Falcata.PayRestaurant.Application.Interfaces.Repositories.Users;

public interface IUserQueryRepository : IQueryRepository<User, int>, 
    IQueryBuilderProvider<IUserQueryBuilder, User>
{
}