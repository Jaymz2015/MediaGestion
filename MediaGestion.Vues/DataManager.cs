using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.Modele;

namespace MediaGestion.Vues
{
    public static class DataManager
    {
        //TODO à synchroniser
        public static List<Genre> ListeGenre { private get; set; }

        public static List<Support> ListeSupports { get; set; }

        public static List<Proprietaire> ListeProprietaires{ get; set; }

        public static List<Machine> ListeMachines { get; set; }

        public static List<EtatMedia> ListeEtatsMedia { get; set; }

        public static List<Genre> ObtenirListeGenre(Constantes.EnumTypeMedia pTypeMedia)
        {
            switch (pTypeMedia)
            {
                case Constantes.EnumTypeMedia.FILM:
                    return ListeGenre.Where<Genre>(item => item.Media == 1 | item.Media == 0).ToList<Genre>();
                case Constantes.EnumTypeMedia.JEU:
                    return ListeGenre.Where<Genre>(item => item.Media == 2 | item.Media == 0).ToList<Genre>();
                default:
                    return ListeGenre;
            }

        }




    }
}
