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

namespace MediaGestion.Vues
{
    public static class DataManager
    {
        //TODO à synchroniser
        public static List<Genre> ListeGenre { get; set; }

        public static List<Support> ListeSupports { get; set; }

        public static List<Proprietaire> ListeProprietaires{ get; set; }

    }
}
