using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

class DisciplineRepository : BaseRepository, IDisciplineRepository
{
    public DisciplineRepository(AppDbContext context) : base(context)
    {
    }

    public void Add(Discipline Discipline)
    {
        _context.Add(Discipline);
        _context.SaveChanges();
    }

    public List<Discipline> GetAll()
    {
        return _context.Disciplines.ToList();
    }

    public bool IsExist(Discipline discipline)
    {
        return _context.Disciplines.Any(d=>d.Name == discipline.Name);
    }

    public void Remove(Discipline Discipline)
    {
        _context.Remove(Discipline);
        _context.SaveChanges();
    }

    public void Update(Discipline Discipline)
    {
        Discipline dbDiscipline = _context.Disciplines.FirstOrDefault(g => g.Id == Discipline.Id);

        if (dbDiscipline != null)
        {
            _context.Entry(dbDiscipline).CurrentValues.SetValues(Discipline);
        }
        _context.SaveChanges();
    }
}