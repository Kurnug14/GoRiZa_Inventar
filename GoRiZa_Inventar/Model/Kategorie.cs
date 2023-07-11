using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoRiZa_Inventar.Model
{
    public class Kategorie
    {
        public int KategorieId { get; set; }
        public string KategorieName { get; set; } = null!;
    }
}
