using System.Net;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    public bool Authentificate(NetworkCredential credential);

    public User GetByUsername(string username);

    public string GetUserRole(string username);
}