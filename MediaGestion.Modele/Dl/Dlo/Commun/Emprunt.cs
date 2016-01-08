using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Emprunt
    {
        public Exemplaire Lexemplaire { get; set; }
        public Emprunteur Lemprunteur {get; set;}
        public DateTime DatePrete { get; set; }
        public DateTime DateRendu { get; set; }

        public override string ToString()
        {
            return Lexemplaire.LeMedia.Titre + " : " + Lemprunteur.Nom;
        }
    }
}
