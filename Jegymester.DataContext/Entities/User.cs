using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegymester.DataContext.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; } // Jelszó hash elkészítés?? idk mi az
        public Role Role { get; set; } = Role.RegularUser; // Alapértelmezett érték: RegularUser

        public List<Ticket> Tickets { get; set; }
    }
}
