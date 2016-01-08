using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;
using MediaGestion.Modele;

namespace MediaGestion.Metier
{
    public class GestionnaireFilms : GestionnaireMedias
    {
        List<Film> listeFilms = null;
        private FilmDAO LeFilmDAO = null;

        public GestionnaireFilms() : base()
        {
            try
            {
                LeFilmDAO = new FilmDAO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        /// <summary>
        /// Construction de la liste des films
        /// </summary>
        /// <returns></returns>
        public List<Film> ObtenirFilms()
        {
            if (listeFilms == null)
            {
                listeFilms = LeFilmDAO.ObtenirListeFilms();
            }

            return listeFilms;
        }

        /// <summary>
        /// Retourne le film dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idFilm"></param>
        /// <returns></returns>
        public Film ObtenirLeFilm(Guid idFilm)
        {
            return LeFilmDAO.ObtenirFilm(idFilm);  
        }

        /// <summary>
        /// Retourne le film dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idFilm"></param>
        /// <returns></returns>
        public Film ObtenirLeFilmComplet(Guid idFilm)
        {
        
            Film film = LeFilmDAO.ObtenirFilmComplet(idFilm);

            List<Exemplaire> listeExpl = LeFilmDAO.ObtenirListeExemplairesMedia(film.Code);
            List<Exemplaire> listeSouhaits = LeFilmDAO.ObtenirListeSouhaitsMedia(film.Code);

            //On associe le film à chaque exemplaire
            foreach (Exemplaire expl in listeExpl) {
                expl.LeMedia = film;
            }

            //On associe le film à chaque exemplaire
            foreach (Exemplaire expl in listeSouhaits)
            {
                expl.LeMedia = film;
            }

            film.ListeExemplaire = listeExpl;
            film.ListeSouhaits = listeSouhaits;
            

            return film;        
        }

        /// <summary>
        /// CreerFilmEtExemplaire
        /// </summary>
        /// <param name="pFilm"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public Film CreerFilmEtExemplaire(Film pFilm, string pCodeSupport, Guid pCodeProprietaire, DateTime pDateAcquisition, int pEtat)
        {

            return LeFilmDAO.CreerFilmEtExemplaire(pFilm, pCodeSupport, pCodeProprietaire, pDateAcquisition, pEtat);        
        }

        /// <summary>
        /// CreerFilmEtSouhait
        /// </summary>
        /// <param name="pFilm"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public Film CreerFilmEtSouhait(Film pFilm, string pCodeSupport, Guid pCodeProprietaire)
        {

            return LeFilmDAO.CreerFilmEtSouhait(pFilm, pCodeSupport, pCodeProprietaire);
        }


        /// <summary>
        /// SupprimerSouhait
        /// </summary>
        /// <param name="pCodeFilm">pCodeFilm</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        public void SupprimerSouhait(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport)
        {
            LeFilmDAO.SupprimerSouhait(pCodeFilm, pCodeProprietaire, pCodeSupport);
        }


        /// <summary>
        /// Modification d'un film
        /// </summary>
        /// <param name="s">film à modifier</param>
        /// <returns></returns>
        public List<Media> MettreAJourFilm(Film f)
        {
            LeFilmDAO.UpdateFilm(f);

            MediaDAO mediaDAO = new MediaDAO();

            return mediaDAO.ObtenirListeMedias(Constantes.EnumTypeMedia.FILM);
        }

    }
}
