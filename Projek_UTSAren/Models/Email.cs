using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Models
{
    public class Email
    {
        public string NamaClientnya { get; set; }
        public int Portnya { get; set; }
        public string EmailKita { get; set; }
        public string PasswordEmailKita { get; set; }
    }

    public class Dashboard
    {
        public List<Alumni> alumni { get; set; }
        public List<Event> even { get; set; }
        public List<Tahun> tahun { get; set; }
        public List<User> user { get; set; }

        public Dashboard()

        {
            alumni = new List<Alumni>();
            even = new List<Event>();
            tahun = new List<Tahun>();
            user = new List<User>();
        }
    }
}
