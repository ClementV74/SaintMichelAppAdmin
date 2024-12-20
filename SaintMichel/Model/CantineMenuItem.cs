using System;

namespace SaintMichel.Model
{
    public class CantineMenuItem
    {
        public int IdMenu { get; set; }
        public DateTime DateMenu { get; set; }
        public string Categorie { get; set; }
        public string Contenu { get; set; }
        public string Jour { get; set; }
    }
}
