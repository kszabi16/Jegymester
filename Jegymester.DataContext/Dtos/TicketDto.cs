using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegymester.DataContext.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BuyerEmail { get; set; } = string.Empty; 
        public string BuyerPhone { get; set; } = string.Empty;
    }

    public class CreateTicketDto
    {
        public int ScreeningId { get; set; }

     
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? BuyerEmail { get; set; } // Ha nincs regisztrált vásárló, ide kell bekerülnie az email címnek
        public string? BuyerPhone { get; set; }  // Ha nincs regisztrált vásárló, ide kell bekerülnie a telefonszámnak

    }
}
