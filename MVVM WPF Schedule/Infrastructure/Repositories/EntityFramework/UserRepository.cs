using System.Net;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {

    }


    public bool Authentificate(NetworkCredential credential)
    {
        User user = _context.Users.FirstOrDefault(u => u.Login == credential.UserName && u.Password == credential.Password);

        if (user == null) return false;
        return true;
    }
    public User GetByUsername(string username)
    {
        User user = _context.Users.FirstOrDefault(u => u.Login == username);

        return user;
    }

    public string GetUserRole(string username)
    {
        User user = GetByUsername(username);

        return user.Post.Name;
    }
}