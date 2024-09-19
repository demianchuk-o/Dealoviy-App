namespace Dealoviy.Infrastructure.Persistence.Repositories.Abstract;

public abstract class BaseRepository
{
    private protected readonly DealoviyDbContext DbContext;

    protected BaseRepository(DealoviyDbContext dbContext)
    {
        DbContext = dbContext;
    }
}