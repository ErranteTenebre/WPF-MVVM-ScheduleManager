using System.Text.RegularExpressions;
using MVVM_WPF_Schedule.Infrastructure.DataValidators.Base;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataValidators;

public class TeacherValidator : BaseModelValidator, IModelValidator<Teacher>
{
    public TeacherValidator(AppDbContext dbContext) : base(dbContext)
    {
    }

    public bool ValidateModel(Teacher model)
    {
        return (IsWorkloadCorrect(model) && IsPhoneCorrect(model) && IsFIOCorrect(model));
    }

    private bool IsWorkloadCorrect(Teacher model)
    {
        if (model.Workload > 0)
        {
            return true;
        }
        ErrorMessage = "Рабочая нагрузка должна превышать 0";
        return false;
    }

    private bool IsPhoneCorrect(Teacher model)
    {
        string pattern = @"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$";

        if (Regex.IsMatch(model.Phone, pattern) == true)
        {
            return true;
        }
        ErrorMessage = "Неверный формат телефона (Пример: +7(908)446-55-32)";
        return false;
    }

    private bool IsFIOCorrect(Teacher model)
    {
        string pattern = @"^\w+\s\w+\s\w+$"; // Паттерн для трех подстрок, разделенных пробелами
        if (Regex.IsMatch(model.FIO, pattern) == true)
        {
            return true;
        }
        ErrorMessage = "Неверный формат ФИО";
        return false;
    }
}