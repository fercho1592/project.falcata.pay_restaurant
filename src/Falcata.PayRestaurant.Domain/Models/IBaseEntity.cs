namespace Falcata.PayRestaurant.Domain.Models;

public interface IBaseEntity<TIdentity>
{
    TIdentity GetIdentity();
}