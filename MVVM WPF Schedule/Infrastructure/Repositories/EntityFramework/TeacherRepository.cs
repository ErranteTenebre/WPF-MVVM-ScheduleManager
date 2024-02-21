using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

public class TeacherRepository : BaseRepository, ITeacherRepository
{
    public TeacherRepository(AppDbContext context) : base(context)
    {

    }

    public void Add(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        _context.SaveChanges();
    }
    public void Remove(Teacher teacher)
    {
        _context.Teachers.Remove(teacher);
        _context.SaveChanges();
    }

    public List<Teacher> GetAll()
    {
        return _context.Teachers.ToList();
    }

    public bool IsExist(Teacher teacher)
    {
        return _context.Teachers.Any();
    }

    public void Update(Teacher teacher)
    {
        Teacher db = _context.Teachers.FirstOrDefault(t => t.Id == teacher.Id);

        if (db != null)
        {
            _context.Entry(db).CurrentValues.SetValues(teacher);
        }

        _context.SaveChanges();
    }
}