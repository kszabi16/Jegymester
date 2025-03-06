using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegymester.DataContext.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = null!;
        public int? UserId { get; set; } // Lehet null, ha nem regisztrált a vásárló
        public User? User { get; set; }
        public string BuyerEmail { get; set; } = string.Empty; // Ha nincs regisztrált vásárló, ide kell bekerülnie az email címnek
        public string BuyerPhoneNumber { get; set; } = string.Empty; // Ha nincs regisztrált vásárló, ide kell bekerülnie a telefonszámnak

    }
}
