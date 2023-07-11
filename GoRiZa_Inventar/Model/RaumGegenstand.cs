using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoRiZa_Inventar.Model
{
    public class RaumGegenstand
    {
        public int RaumGegenstandId { get; set; }
        public int RaumId { get; set; }
        public Raum Raum { get; set; }
        public int GegenstandId { get; set; }
        public Gegenstand Gegenstand { get; set; }
    }
}
