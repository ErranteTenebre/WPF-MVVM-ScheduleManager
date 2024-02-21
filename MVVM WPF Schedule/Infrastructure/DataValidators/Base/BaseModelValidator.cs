namespace MVVM_WPF_Schedule.Infrastructure.DataValidators.Base;

public abstract class BaseModelValidator
{
    private string _errorMessage;
    protected AppDbContext context;
    public BaseModelValidator(AppDbContext context)
    {
        this.context = context;
    }
    public string ErrorMessage
    {
        get
        {
            return _errorMessage;   
        }
        set
        {
            _errorMessage = value;
        }
    }
}