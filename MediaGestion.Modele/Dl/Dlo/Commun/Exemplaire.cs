using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Exemplaire
    {

        public Guid Code { get; set; }

        public Media LeMedia { get; set; }
        
        public Proprietaire LeProprietaire { get; set; }

        public Support LeSupport { get; set; }
        public Machine LaMachine { get; set; }
        public bool EstDispo { get; set; }

        public EtatMedia Etat { get; set; }
        
        public string NomEmprunteur { get; set; }

        public DateTime DateEmprunt { get; set; }

        public bool EstSouhait { get; set; }

        public string ExemplaireExistant { get; set; }

        public bool EstCopie { get; set; }

        public DateTime DateAcquisition { get; set; }
        public DateTime DateEnregistrement { get; set; }

        public Guid CodeEmprunt { get; set; }


        public Exemplaire()
        {
            Etat = new EtatMedia();
            Etat.Code = 0;
        }


        public override string ToString()
        {
            return LeMedia.Titre + " : " + LeProprietaire.Nom;
        }
    }
}
