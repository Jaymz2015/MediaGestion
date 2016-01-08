using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LibAllocine.Dl.Dto;

namespace MediaGestion.Modele.Dl.Dlo
{
    /// <summary>
    /// Jeu
    /// </summary>
    public class Jeu : Media
    {
        private const string KS_NOM_MODULE = "LibModele - Jeu - ";

        public string Synopsys { get; set; }
        public Editeur Editeur { get; set; }
        public Developpeur Developpeur { get; set; }

        public Machine LaMachine { get; set; }

        public int NbJoueurs { get; set; }

        /// <summary>
        /// Jeu
        /// </summary>
		public Jeu() {
            this.DateSortie = DateTime.Now;
            this.LaMachine = new Machine();
            this.Developpeur = new Developpeur();
            this.Editeur = new Editeur();
            this.LeGenre = new Genre();
		}

        /// <summary>
        /// Jeu
        /// </summary>
        /// <param name="ficheJeuJVC">ficheJeuJVC</param>
        /// <param name="genre">genre</param>
        public Jeu(FicheJeuJVC ficheJeuJVC, Genre genre, Machine machine) : this()
        {
            this.Titre = ficheJeuJVC.Titre;

            this.Developpeur.Nom = ficheJeuJVC.Developpeur;
            this.Editeur.Nom = ficheJeuJVC.Editeur;

            if (!String.IsNullOrEmpty(ficheJeuJVC.DateSortie))
            {
                if (ficheJeuJVC.DateSortie.Length == 4)
                {
                    this.DateSortie = new DateTime(Int32.Parse(ficheJeuJVC.DateSortie), 1, 1);
                }
                else
                {
                    this.DateSortie = DateTime.Parse(ficheJeuJVC.DateSortie);
                }
            }

            this.Synopsys = ficheJeuJVC.Description;
            this.LeGenre = genre;
            this.Photo = ficheJeuJVC.NomPhoto;
            this.LaMachine = machine;

        }
		

		public override string ToString(){
		
			return this.Code + this.Titre;
		}
		

    }
}
