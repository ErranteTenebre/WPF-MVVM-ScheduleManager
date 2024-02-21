using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces
{
    public interface IScheduleItemRepository
    {
        public List<ScheduleItem> GetAll();
        public ScheduleItem Get(int id);
        public void Add(ScheduleItem model);
        public void Remove(ScheduleItem model);
        public void Update(ScheduleItem model);
    }
}
