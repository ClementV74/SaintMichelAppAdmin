using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Model
{
    public class OffrePro
    {
        public int IDInterim { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string NameEntreprise { get; set; }
        public string NameVille { get; set; }   
        public string Tache { get; set; }
        public string type_offre { get; set; }
        public string SecteurActivite { get; set; }
    }
}
