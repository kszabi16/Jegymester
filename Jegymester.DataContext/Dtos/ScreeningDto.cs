using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegymester.DataContext.Dtos
{
    public class ScreeningDto
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
    }

    public class CreateScreeningDto
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
