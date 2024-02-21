namespace MVVM_WPF_Schedule.Infrastructure.Repositories;

public abstract class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}