using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework
{
    public class ScheduleRepository : BaseRepository, IScheduleItemRepository
    {
        public ScheduleRepository(AppDbContext context) : base(context)
        {
        }

        public List<ScheduleItem> GetAll()
        {
            return _context.ScheduleItems.ToList();
        }

        public ScheduleItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(ScheduleItem model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Remove(ScheduleItem model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public void Update(ScheduleItem model)
        {
            ScheduleItem dbModel = _context.ScheduleItems.FirstOrDefault(s => s.Id == model.Id);

            if (dbModel != null)
            {
                _context.Entry(dbModel).CurrentValues.SetValues(model);
            }

            _context.SaveChanges();
        }
    }
}
