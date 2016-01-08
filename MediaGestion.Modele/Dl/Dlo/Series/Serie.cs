using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LibAllocine.Dl.Dto;
using MediaGestion.Modele.Dl.Dlo.Series;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Serie : Media
    {
        private const string KS_NOM_MODULE = "LibModele - Serie - ";

        public string Synopsys { get; set; }
        public string Realisateur { get; set; }
        public string Acteurs { get; set; }
        public int NbSaisons { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateDerniereModification { get; set; }
        public List<Saison> ListeSaisons { get; set; }
        public int AnneeDebut { get; set; }
        public string Format { get; set; }

		public Serie() {
            this.DateSortie = DateTime.Now;          
		}

        public Serie(Guid pCode) : this()
        {
            this.Code = pCode;
        }

        public Serie(FicheFilmAllocine ficheFilmAllocine, Genre genre)
        {
            this.Titre = ficheFilmAllocine.Titre;
            this.Acteurs = ficheFilmAllocine.Casting.Acteurs;

            this.ListeSaisons = new List<Saison>();

            if (ficheFilmAllocine.InfosSortie.DateSortie == null || ficheFilmAllocine.InfosSortie.DateSortie.Year == 1900)
            {
                this.DateSortie = new DateTime(ficheFilmAllocine.AnneeProduction, 1, 1);
            }
            else
            {
                this.DateSortie = ficheFilmAllocine.InfosSortie.DateSortie;               
            }

            //this.NbSaisons = ficheFilmAllocine.Duree / 60;
            this.Realisateur = ficheFilmAllocine.Casting.Realisateur;
            this.Synopsys = ficheFilmAllocine.LeSynopsis;
            this.LeGenre = genre;
            this.Photo = ficheFilmAllocine.NomPhoto;

            if (ficheFilmAllocine.UrlFiche != null)
            {
                this.UrlFiche = ficheFilmAllocine.UrlFiche.Url;
            }
            
		}
		
		public override string ToString(){
		
			return this.Code + this.Titre;
		}
		

    }
}
