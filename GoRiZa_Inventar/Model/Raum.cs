using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoRiZa_Inventar.Model
{
    public class Raum
    {
        public int RaumId { get; set; }
        public string RaumName { get; set; } = null!;

    }
}
