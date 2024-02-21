using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface ISpecialtyDisciplinesRepository
{
    public List<SpecialtyDiscipline> GetAll();
    public List<SpecialtyDiscipline> GetAllBySpecialty(string specialtyCode);
    public List<Discipline> GetUnusedDisciplines(string specialtyCode);
    public void Add(SpecialtyDiscipline teacher);
    public void Remove(SpecialtyDiscipline specialty);
    public void Update(SpecialtyDiscipline specialty);

    public bool IsExist(SpecialtyDiscipline specialty);
}