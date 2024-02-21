using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface ITeacherRepository
{
    public List<Teacher> GetAll();
    public void Add(Teacher teacher);
    public void Remove(Teacher specialty);
    public void Update(Teacher specialty);

    public bool IsExist(Teacher specialty);
}