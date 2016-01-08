using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Genre
    {
        public string Code { get; set; }
        public string Libelle { get; set; }
        public int Media { get; set; }

		public Genre()
        {
		
        }

        public Genre(string pCode, string pLibelle)
        {
            Code = pCode;
            Libelle = pLibelle;
        }

    }
}
