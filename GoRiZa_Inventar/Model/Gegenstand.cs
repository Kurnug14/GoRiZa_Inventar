using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GoRiZa_Inventar.Model
{
    public class Gegenstand
    {
        /*Id wird automatisch generiert.*/
        public int GegenstandId { get; set; }
        /*null!; heisst das das Feld gefüllt werden muss*/
        public string GegenstandName { get; set; } = null!;
        /*Fremdschlüssel aus einer anderen Tabelle brauchen. Fragezeichen steht für ein Feld das leer/null gelassen werden kann*/
        public int? KategorieId { get; set; }
        public Kategorie Kategorie { get; set; }
        public string Beschreib { get; set; } = null!;
        public int Anzahl { get; set; }
        /*Ermöglicht das abrufen der Id der Klasse*/
    }
}
