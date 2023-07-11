using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoRiZa_Inventar.Model
{
    public class Benutzer
    {
        public int BenutzerId { get; set; }
        public string Name { get; set; } = null!;
        public string Vorname { get; set; } = null!;
        public List<Computer>? ComputerList { get; set; }
    }
}
