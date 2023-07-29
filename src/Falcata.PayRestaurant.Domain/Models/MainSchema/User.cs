namespace Falcata.PayRestaurant.Domain.Models.MainSchema;

public class User: BaseEntity<int>
{
    public int UserId { get; set; }
    public string Email { get; set; }
    
    public override int GetIdentity() => UserId;
}