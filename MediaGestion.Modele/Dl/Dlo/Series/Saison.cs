using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaGestion.Modele.Dl.Dlo.Series
{
    public class Saison
    {
        public int NbEpisodes { get; set; }

        public int AnneeSortie { get; set; }

        public int Numero { get; set; }

        public Guid CodeSaison { get; set; }
    }
}
