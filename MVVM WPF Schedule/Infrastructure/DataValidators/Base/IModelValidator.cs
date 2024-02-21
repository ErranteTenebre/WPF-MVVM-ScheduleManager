namespace MVVM_WPF_Schedule.Infrastructure.DataValidators.Base;

public interface IModelValidator<T>
{
    bool ValidateModel(T model);
}