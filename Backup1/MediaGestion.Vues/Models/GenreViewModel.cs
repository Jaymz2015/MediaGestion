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
using MediaGestion.Modele.Dl.Dlo;
using System.Collections.Generic;

namespace MediaGestion.Vues.Models
{
    public class GenreViewModel : Genre
    {

        public string OldCode { get; set; }

        public GenreViewModel()
        {

        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="pGenre"></param>
        public GenreViewModel(Genre pGenre)
        {
            this.Code = pGenre.Code;
            this.OldCode = pGenre.Code;
            this.Libelle = pGenre.Libelle;
        }
    }
}
