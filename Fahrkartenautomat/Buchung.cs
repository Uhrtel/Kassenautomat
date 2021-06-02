using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrkartenautomat
{
    public class Buchung
    {
        public double gesamtKosten { get; set; } = 0.0;
        public double preisstufe { get; set; } = 0.0;
        public bool vierFahrten { get; set; } = false;
        public bool tagesTicket { get; set; } = false;
        public bool ersteKlasse { get; set; } = false;
        public bool verguenstigung { get; set; } = false;
        public string verguenstigungText { get; set; } = string.Empty;
        public string klasseText { get; set; } = string.Empty;


    }
}
