using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface ISpecialtyRepository
{
    public List<Specialty> GetAll();
    public void Add(Specialty specialty);
    public void Remove(Specialty specialty);
    public void Update(Specialty specialty);

    public bool IsExist(string specialtyCode, string specialtyName, string specialtyAcronym);
}