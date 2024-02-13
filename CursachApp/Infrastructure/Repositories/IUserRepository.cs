using CursachApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CursachApp.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public bool Authentificate(NetworkCredential credential);

        public User GetByUsername(string username);
    }
}
