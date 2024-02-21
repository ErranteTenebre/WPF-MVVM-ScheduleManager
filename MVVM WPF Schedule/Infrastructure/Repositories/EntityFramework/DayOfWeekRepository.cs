using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

public class DayOfWeekRepository : BaseRepository, IDayOfWeekRepository
{
    public DayOfWeekRepository(AppDbContext context) : base(context)
    {

    }

    public void Add(DayOfWeek dayOfWeek)
    {
        _context.DaysOfWeek.Add(dayOfWeek);
        _context.SaveChanges();
    }
    public void Remove(DayOfWeek dayOfWeek)
    {
        _context.DaysOfWeek.Remove(dayOfWeek);
        _context.SaveChanges();
    }

    public List<DayOfWeek> GetAll()
    {
        return _context.DaysOfWeek.ToList();
    }

    public bool IsExist(DayOfWeek dayOfWeek)
    {
        return _context.DaysOfWeek.Any();
    }

    public void Update(DayOfWeek dayOfWeek)
    {
        DayOfWeek db = _context.DaysOfWeek.FirstOrDefault(t => t.Id == dayOfWeek.Id);

        if (db != null)
        {
            _context.Entry(db).CurrentValues.SetValues(dayOfWeek);
        }

        _context.SaveChanges();
    }
}