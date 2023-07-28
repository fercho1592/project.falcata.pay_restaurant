using Microsoft.EntityFrameworkCore;
using Falcata.PayRestaurant.Domain.Models.MainSchema;

namespace Falcata.PayRestaurant.Persistence.Contexts;

public interface IMainDbContext
{
    DbSet<User> Users { get; set; }
}