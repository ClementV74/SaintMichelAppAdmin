using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Model
{
    public class Event
    {
        public int IDevent { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Lieu { get; set; }
        public int state { get; set; }
        public int user_iduser { get; set; }
    }
}
