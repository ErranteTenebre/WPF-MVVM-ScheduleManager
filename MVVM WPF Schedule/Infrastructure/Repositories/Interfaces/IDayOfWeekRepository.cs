using DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface IDayOfWeekRepository
{
    public List<DayOfWeek> GetAll();
    public void Add(DayOfWeek teacher);
    public void Remove(DayOfWeek specialty);
    public void Update(DayOfWeek specialty);
}