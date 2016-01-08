using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Exemplaire
    {
        public Media LeMedia { get; set; }
        
        public Proprietaire LeProprietaire { get; set; }

        public Support LeSupport { get; set; }

        public bool EstDispo { get; set; }
        
        public string NomEmprunteur { get; set; }

        public DateTime DateEmprunt { get; set; }


        public bool EstSouhait { get; set; }

        public string ExemplaireExistant { get; set; }

    }
}
