using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jegymester.DataContext.Entities;

namespace Jegymester.DataContext.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }
        public int? UserId { get; set; } // Lehet null, ha nem regisztrált a vásárló

        [JsonIgnore]
        public User? User { get; set; } // Lehet null, ha nem regisztrált a vásárló
        public string? BuyerEmail { get; set; } // Ha nincs regisztrált vásárló, ide kell bekerülnie az email címnek
        public string? BuyerPhone { get; set; } // Ha nincs regisztrált vásárló, ide kell bekerülnie a telefonszámnak

        public bool IsValidated { get; set; } = false; // Ha a belépőjegyet érvényesítették, akkor ez true lesz


    }
}
