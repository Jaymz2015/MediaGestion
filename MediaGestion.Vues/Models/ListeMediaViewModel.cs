﻿using System;
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
    public class ListeMediaViewModel
    {

        public List<Media> ListeMedias { get; set; }

        public List<Film> ListeFilms { get; set; }

        public List<Jeu> ListeJeux { get; set; }

        public List<Serie> ListeSeries { get; set; }

        public int NbPages { get; set; }

        public int NumeroPage { get; set; }

        public int NbResultats { get; set; }


    }
}
