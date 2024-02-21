using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

public class SpecialtyRepository : BaseRepository, ISpecialtyRepository
{
    public SpecialtyRepository(AppDbContext context) : base(context)
    {

    }

    public void Add(Specialty specialty)
    {
        _context.Specialties.Add(specialty);
        _context.SaveChanges();
    }
    public void Remove(Specialty specialty)
    {
        _context.Specialties.Remove(specialty);
        _context.SaveChanges();
    }

    public List<Specialty> GetAll()
    {
        return _context.Specialties.ToList();
    }

    public bool IsExist(string specialtyCode, string specialtyName, string specialtyAcronym)
    {
        return _context.Specialties.Any(s => s.Code == specialtyCode || s.Name == specialtyName || s.Acronym == specialtyAcronym);
    }

    public void Update(Specialty specialty)
    {
        Specialty dbSpecialty = _context.Specialties.FirstOrDefault(s => s.Code == specialty.Code);

        if (dbSpecialty != null)
        {
            _context.Entry(dbSpecialty).CurrentValues.SetValues(specialty);
        }

        _context.SaveChanges();
    }
}