using CursachApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CursachApp.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }


        public bool Authentificate(NetworkCredential credential)
        {
            User user = _context.Users.FirstOrDefault(u=>u.Login == credential.UserName && u.Password == credential.Password);

            if (user == null) return false;
            return true;
        }
        public User GetByUsername(string username)
        {
            User user = _context.Users.FirstOrDefault(u=>u.Login == username);

            return user;
        }
    }
}
