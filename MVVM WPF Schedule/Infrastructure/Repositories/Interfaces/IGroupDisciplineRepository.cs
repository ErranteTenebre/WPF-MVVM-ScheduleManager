using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface IGroupDisciplineRepository
{
    public List<GroupDiscipline> GetAll();
    public void Add(GroupDiscipline groupDiscipline);
    public void Remove(GroupDiscipline groupDiscipline);
    public void Update(GroupDiscipline groupDiscipline);
}