using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegymester.DataContext.Entities
{
    public class Screening
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Location { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
