﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jegymester.DataContext.Dtos
{
    public class ScreeningDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }

        public string Location { get; set; }
        public DateTime StartTime { get; set; }
    }

    public class CreateScreeningDto
    {
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }

        public string Location { get; set; }
    }
}
