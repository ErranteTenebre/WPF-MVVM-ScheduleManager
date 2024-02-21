using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface IGroupRepository
{
    public List<Group> GetAll();
    public void Add(Group group);
    public void Remove(Group group);
    public void Update(Group group);
    public bool IsExist(string groupNumber);
}