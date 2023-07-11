using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoRiZa_Inventar.Model
{
    public class Computer
    {
        public int ComputerId { get; set; }
        public int? BenutzerId { get; set; }
        public Benutzer Benutzer { get; set; }
        public int? GegenstandId { get; set; }
        public Gegenstand Gegenstand { get; set; }
    }
}
