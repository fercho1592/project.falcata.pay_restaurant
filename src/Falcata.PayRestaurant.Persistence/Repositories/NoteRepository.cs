using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Application.Interfaces.Repositories.Notes;
using Falcata.PayRestaurant.Domain.Models.MainSchema;
using Falcata.PayRestaurant.Persistence.Contexts;
using Falcata.PayRestaurant.Persistence.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Persistence.Repositories;

public class NoteRepository: BaseRepository<Note, int, IMainDbContext>, INotesQueryRepository, INotesCommandRepository
{
    public NoteRepository(IMainDbContext context, ILogger<NoteRepository> logger) : base(context, logger)
    {
    }

    protected override DbSet<Note> Entities => _context.Notes;
    public INotesQueryBuilder NewQueryBuilder() => new NoteQueryBuilder(Entities.AsQueryable());
}