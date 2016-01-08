using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class EtatMedia
    {
        public int Code { get; set; }
        public string Libelle { get; set; }

		public EtatMedia()
        {
		
        }

        public EtatMedia(int pCode, string pLibelle)
        {
            Code = pCode;
            Libelle = pLibelle;
        }

        public override string ToString()
        {
            return Libelle;
        }

    }
}
