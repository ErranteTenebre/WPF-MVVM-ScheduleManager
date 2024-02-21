using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface IDisciplineRepository
{
    public List<Discipline> GetAll();
    public void Add(Discipline discipline);
    public void Remove(Discipline discipline);
    public void Update(Discipline discipline);
    public bool IsExist(Discipline discipline);
}