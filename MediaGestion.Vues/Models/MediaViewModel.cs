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
using MediaGestion.Modele;
using MediaGestion.Modele.Dl.Dlo.Series;

namespace MediaGestion.Vues.Models
{
    public class MediaViewModel
    {
        public Jeu LeJeu { get; set; }
        public Film LeFilm { get; set; }
        public Serie LaSerie { get; set; }


        private Constantes.EnumTypeMedia pTypeMedia;

        public Constantes.EnumTypeMedia TypeMedia {
            
            get
            {

                if (pTypeMedia == Constantes.EnumTypeMedia.TOUT)
                {

                        if (this.LeFilm != null)
                        {
                            pTypeMedia = Constantes.EnumTypeMedia.FILM;
             
                        }
                        if (this.LaSerie != null)
                        {
                            pTypeMedia = Constantes.EnumTypeMedia.SERIE;

                        }
                        else if (this.LeJeu != null)
                        {
                            pTypeMedia = Constantes.EnumTypeMedia.JEU;

                        }
                }

                return pTypeMedia;
            }
            
            set {
                pTypeMedia = value;
            }
        
        }

        /// <summary>
        /// LeMedia
        /// </summary>
        public Media LeMedia
        {

            set
            {
                TypeMedia = value.TypeMedia;

                switch (value.TypeMedia)
                {
                    case Constantes.EnumTypeMedia.TOUT:
                        break;
                    case Constantes.EnumTypeMedia.FILM:
                        this.LeFilm = new Film();
                        this.LeFilm.Code = value.Code;
                        this.LeFilm.Titre = value.Titre;
                        break;
                    case Constantes.EnumTypeMedia.SERIE:
                        this.LaSerie = new Serie();
                        this.LaSerie.Code = value.Code;
                        this.LaSerie.Titre = value.Titre;
                        break;
                    case Constantes.EnumTypeMedia.JEU:
                        this.LeJeu = new Jeu();
                        this.LeJeu.Code = value.Code;
                        this.LeJeu.Titre = value.Titre;
                        break;
                    default:
                        break;
                }
            }
            get
            {
                switch (TypeMedia)
                {
                    case Constantes.EnumTypeMedia.TOUT:
                        return null;
                    case Constantes.EnumTypeMedia.FILM:
                        return (Media)this.LeFilm;
                    case Constantes.EnumTypeMedia.SERIE:
                        return (Media)this.LaSerie;
                    case Constantes.EnumTypeMedia.JEU:
                        return (Media)this.LeJeu;
                    default:
                       return null;
                }              
            }
        }

        /// <summary>
        /// NomControlleur
        /// </summary>
        public String NomControlleur
        {
            get
            {
                switch (TypeMedia)
                {
                    case Constantes.EnumTypeMedia.TOUT:
                        return null;
                    case Constantes.EnumTypeMedia.FILM:
                        return "Film";
                    case Constantes.EnumTypeMedia.SERIE:
                        return "Serie";
                    case Constantes.EnumTypeMedia.JEU:
                        return "Jeu";
                    default:
                        return null;
                }  
            }
        }

        /// <summary>
        /// NomControlDetail
        /// </summary>
        public String NomControlDetail
        {
            get
            {
                switch (TypeMedia)
                {
                    case Constantes.EnumTypeMedia.TOUT:
                        return null;
                    case Constantes.EnumTypeMedia.FILM:
                        return "~/Views/Film/DetailFilmControl.ascx";
                    case Constantes.EnumTypeMedia.SERIE:
                        return "~/Views/Serie/DetailSerieControl.ascx";
                    case Constantes.EnumTypeMedia.JEU:
                        return "~/Views/Jeu/DetailJeuControl.ascx";
                    default:
                        return null;
                }
            }
        }

        public List<Machine> ListeMachines { get; set; }
        public List<EtatMedia> ListeEtatsMedia { get; set; }

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

        public string Developpeur { get; set; }
        public string Editeur { get; set; }
        public string AnneeSortie { get; set; }

        public Saison LaSaison { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public MediaViewModel()
        {
            ListeMachines = new List<Machine>();
            ListeEtatsMedia = new List<EtatMedia>();
            ListeProprietaire = new List<Proprietaire>();
            LeProprietaire = new Proprietaire();
            ListeSupports = new List<Support>();
            EstSouhait = false;
            DateAcquisition = DateTime.Now;
            Lexemplaire = new Exemplaire();
            Etat = new EtatMedia();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="pTypeMedia">pTypeMedia</param>
        public MediaViewModel(Constantes.EnumTypeMedia pTypeMedia) : this()
        {
            TypeMedia = pTypeMedia;

            switch (pTypeMedia)
            {
                case Constantes.EnumTypeMedia.TOUT:
                    break;
                case Constantes.EnumTypeMedia.FILM:
                    LeFilm = new Film();
                    LeSupport = new Support();
                    OldSupport = new Support();
                    break;
                case Constantes.EnumTypeMedia.SERIE:
                    LaSerie = new Serie();
                    LeSupport = new Support();
                    OldSupport = new Support();
                    break;
                case Constantes.EnumTypeMedia.JEU:
                    LeJeu = new Jeu();
                    break;
                default:
                    break;
            }
        }

    }
}
