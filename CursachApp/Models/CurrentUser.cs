using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachApp.Models
{
    public class CurrentUser
    {
        private static CurrentUser _singletone;

        public int Id { get; set; } 
        public string FIO { get; set; } 
        public string Post { get; set; }

        public static CurrentUser GetSingletone()
        {
            return _singletone;
        }
    }
}
