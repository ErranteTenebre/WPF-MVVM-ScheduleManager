using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

public class SpecialtyDisciplinesRepository : BaseRepository, ISpecialtyDisciplinesRepository
{
    public SpecialtyDisciplinesRepository(AppDbContext context) : base(context)
    {

    }

    public void Add(SpecialtyDiscipline specialtyDisciline)
    {
        _context.SpecialtiesDisciplines.Add(specialtyDisciline);
        _context.SaveChanges();
    }
    public void Remove(SpecialtyDiscipline specialtyDisciline)
    {
        _context.SpecialtiesDisciplines.Remove(specialtyDisciline);
        _context.SaveChanges();
    }

    public List<SpecialtyDiscipline> GetAll()
    {
        return _context.SpecialtiesDisciplines.ToList();
    }

    public List<SpecialtyDiscipline> GetAllBySpecialty(string specialtyCode)
    {
        return _context.SpecialtiesDisciplines.Where(sd=>sd.SpecialtyCode == specialtyCode).ToList();
    }

    public List<Discipline> GetUnusedDisciplines(string specialtyCode)
    {
        int[] disciplines = _context.SpecialtiesDisciplines.Where(sd => sd.SpecialtyCode == specialtyCode).Select(sd=>sd.DisciplineId).ToArray();

        return _context.Disciplines.Where(d =>!disciplines.Contains(d.Id)).ToList();
    }

    public bool IsExist(SpecialtyDiscipline specialtyDiscipline)
    {
        return _context.SpecialtiesDisciplines.Any(sd=>sd.DisciplineId == specialtyDiscipline.DisciplineId || sd.SpecialtyCode == specialtyDiscipline.SpecialtyCode);
    }

    public void Update(SpecialtyDiscipline specialty)
    {
        SpecialtyDiscipline dbSpecialty = _context.SpecialtiesDisciplines.FirstOrDefault(s => s.Id == specialty.Id);

        if (dbSpecialty != null)
        {
            _context.Entry(dbSpecialty).CurrentValues.SetValues(specialty);
        }

        _context.SaveChanges();
    }
}