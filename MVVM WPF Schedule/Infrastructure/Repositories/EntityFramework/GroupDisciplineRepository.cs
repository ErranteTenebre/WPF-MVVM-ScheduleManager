using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

public class GroupDisciplineRepository : BaseRepository, IGroupDisciplineRepository
{
    public GroupDisciplineRepository(AppDbContext context) : base(context)
    {

    }

    public void Add(GroupDiscipline groupDiscipline)
    {
        _context.GroupsDisciplines.Add(groupDiscipline);
        _context.SaveChanges();
    }
    public void Remove(GroupDiscipline groupDiscipline)
    {
        _context.GroupsDisciplines.Remove(groupDiscipline);
        _context.SaveChanges();
    }

    public List<GroupDiscipline> GetAll()
    {
        return _context.GroupsDisciplines.ToList();
    }

    public void Update(GroupDiscipline groupDiscipline)
    {
        GroupDiscipline dbSpecialty = _context.GroupsDisciplines.FirstOrDefault(s => s.Id == groupDiscipline.Id);

        if (dbSpecialty != null)
        {
            _context.Entry(dbSpecialty).CurrentValues.SetValues(groupDiscipline);
        }

        _context.SaveChanges();
    }
}