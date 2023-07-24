namespace Falcata.PayRestaurant.Domain.Models;

public abstract class BaseEntity<TIdentity>: IBaseEntity<TIdentity>
{
    public abstract TIdentity GetIdentity();
}