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
    public class JeuViewModel
    {

        public Jeu LeJeu { get; set; }

        public List<Proprietaire> ListeProprietaire { get; set; }
        public List<Genre> ListeGenres { get; set; }
        public List<Machine> ListeMachines { get; set; }
        public List<EtatMedia> ListeEtatsMedia { get; set; }

        public Proprietaire LeProprietaire { get; set; }

        public bool EstSouhait { get; set; }

        public int NumPage { get; set; }

        public Emprunteur Lemprunteur { get; set; }

        public EtatMedia Etat { get; set; }

        public string Developpeur { get; set; }
        public string Editeur { get; set; }
        public string AnneeSortie { get; set; }

        public DateTime DateAcquisition { get; set; }

        public Exemplaire Lexemplaire { get; set; }

        public JeuViewModel()
        {
            ListeProprietaire = new List<Proprietaire>();
            ListeMachines = new List<Machine>();
            ListeEtatsMedia = new List<EtatMedia>();
            LeJeu = new Jeu();
            LeProprietaire = new Proprietaire();
            Etat = new EtatMedia();
            EstSouhait = false;
            DateAcquisition = DateTime.Now;
            Lexemplaire = new Exemplaire();
        }

    }
}
