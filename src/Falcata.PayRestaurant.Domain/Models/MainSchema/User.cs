namespace Falcata.PayRestaurant.Domain.Models.MainSchema;

public class User: BaseEntity<int>
{
    public int UserId { get; set; }
    public int Email { get; set; }
    
    public override int GetIdentity() => UserId;
}