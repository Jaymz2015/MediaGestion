using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LibAllocine.Dl.Dto;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Film : Media
    {
        private const string KS_NOM_MODULE = "LibModele - Film - ";

        public string Synopsys { get; set; }
        public string Realisateur { get; set; }
        public string Acteurs { get; set; }
        public int Duree { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateDerniereModification { get; set; }

		public Film() {
            this.DateSortie = DateTime.Now;
           
		}

        public Film(Guid pCode) : this()
        {
            this.Code = pCode;
        }

		public Film(FicheFilmAllocine ficheFilmAllocine, Genre genre) {
            this.Titre = ficheFilmAllocine.Titre;
            this.Acteurs = ficheFilmAllocine.Casting.Acteurs;

            if (ficheFilmAllocine.InfosSortie.DateSortie == null || ficheFilmAllocine.InfosSortie.DateSortie.Year == 1900)
            {
                this.DateSortie = new DateTime(ficheFilmAllocine.AnneeProduction, 1, 1);
            }
            else
            {
                this.DateSortie = ficheFilmAllocine.InfosSortie.DateSortie;               
            }

            
            this.Duree = ficheFilmAllocine.Duree/60;
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
