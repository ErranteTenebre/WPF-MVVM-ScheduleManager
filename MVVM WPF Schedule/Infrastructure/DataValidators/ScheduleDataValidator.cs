using MVVM_WPF_Schedule.Infrastructure.DataValidators.Base;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataValidators
{
    public class ScheduleDataValidator : BaseModelValidator, IModelValidator<ScheduleItem>
    {
        public bool ValidateModel(ScheduleItem model)
        {
            return true;
        }

        public ScheduleDataValidator(AppDbContext context) : base(context)
        {
        }
    }
}
