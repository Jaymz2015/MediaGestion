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
    public class FilmViewModel
    {

        public Film LeFilm { get; set; }

        public List<Proprietaire> ListeProprietaire { get; set; }

        public List<Support> ListeSupports { get; set; }

        public List<Genre> ListeGenres { get; set; }

        public Proprietaire LeProprietaire { get; set; }

        public Support LeSupport { get; set; }
        public Support OldSupport { get; set; }

        public bool EstSouhait { get; set; }

        public int NumPage { get; set; }

        public DateTime DateAcquisition { get; set; }

        public Emprunteur Lemprunteur { get; set; }

        public Exemplaire Lexemplaire { get; set; }

        public EtatMedia Etat { get; set; }


        public FilmViewModel()
        {
            ListeProprietaire = new List<Proprietaire>();
            LeFilm = new Film();
            LeProprietaire = new Proprietaire();
            ListeSupports = new List<Support>();
            LeSupport = new Support();
            OldSupport = new Support();
            EstSouhait = false;
            DateAcquisition = DateTime.Now;
            Lexemplaire = new Exemplaire();
            Etat = new EtatMedia();
        }

    }
}
