using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

class GroupRepository : BaseRepository, IGroupRepository
{

    public GroupRepository(AppDbContext context) : base(context)
    {
  
    }

    public void Add(Group group)
    {
        _context.Add(group);

        
        _context.SaveChanges();
    }

    public List<Group> GetAll()
    {
        return _context.Groups.ToList();
    }

    public bool IsExist(string groupNumber)
    {
        return _context.Groups.Any(g => g.Number == groupNumber);
    }

    public void Remove(Group group)
    {
        _context.Remove(group);
        _context.SaveChanges();
    }

    public void Update(Group group)
    {
        Group dbGroup = _context.Groups.FirstOrDefault(g => g.Number == group.Number);

        if (dbGroup != null)
        {
            _context.Entry(dbGroup).CurrentValues.SetValues(group);
        }
        _context.SaveChanges();
    }

    private void AddGroupSpecialties(Group group)
    {

    }
}