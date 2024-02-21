using MVVM_WPF_Schedule.Infrastructure.DataValidators.Base;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataValidators;

public class GroupValidator : BaseModelValidator, IModelValidator<Group>
{
    public GroupValidator(AppDbContext dbContext) : base(dbContext)
    {
    }

    public bool ValidateModel(Group model)
    {
        return (!IsExist(model));
    }

    private bool IsExist(Group model)
    {
        if (context.Groups.Any(g => g.Number == model.Number == true))
        {
            ErrorMessage = "Группа с такими данными существует";
            return true;
        }
        return false;
    }
}