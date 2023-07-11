using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoRiZa_Inventar.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        public int? GegenstandId { get; set; }
        public Gegenstand Gegenstand { get; set; }
        public int Lagerbestand { get; set; }
    }
}
