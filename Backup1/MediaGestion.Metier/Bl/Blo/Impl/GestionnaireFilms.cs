using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;

namespace MediaGestion.Metier
{
    public class GestionnaireFilms : AGestionnaireMedias
    {
        List<Film> listeFilms = null;

        /// <summary>
        /// Construction de la liste des films
        /// </summary>
        /// <returns></returns>
        public List<Film> ObtenirFilms(){

            if (listeFilms == null)
            {
                FilmDAO filmDAO = new FilmDAO();
                listeFilms = filmDAO.ObtenirListeFilms();  
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
            FilmDAO filmDAO = new FilmDAO();
            return filmDAO.ObtenirFilm(idFilm);  
        }

        /// <summary>
        /// Retourne le film dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idFilm"></param>
        /// <returns></returns>
        public Film ObtenirLeFilmComplet(Guid idFilm)
        {
            FilmDAO filmDAO = new FilmDAO();
            return filmDAO.ObtenirFilmComplet(idFilm);        
        }

        /// <summary>
        /// CreerFilmEtExemplaire
        /// </summary>
        /// <param name="pFilm"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public Film CreerFilmEtExemplaire(Film pFilm, string pCodeSupport, Guid pCodeProprietaire)
        {
            FilmDAO filmDAO = new FilmDAO();

            return filmDAO.CreerFilmEtExemplaire(pFilm, pCodeSupport, pCodeProprietaire);        
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
            FilmDAO filmDAO = new FilmDAO();

            return filmDAO.CreerFilmEtSouhait(pFilm, pCodeSupport, pCodeProprietaire);
        }


        /// <summary>
        /// AjouterExemplaire
        /// </summary>
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        public void AjouterExemplaire(Guid pCodeFilm, string pCodeSupport, Guid pCodeProprietaire)
        {
            FilmDAO filmDAO = new FilmDAO();

            filmDAO.AjouterExemplaire(pCodeFilm, pCodeSupport, pCodeProprietaire);
        }

        /// <summary>
        /// AjouterEmprunt
        /// </summary>
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pNom"></param>
        /// <param name="pPrenom"></param>
        public void AjouterEmprunt(Guid pCodeFilm, string pCodeSupport, Guid pCodeProprietaire, Emprunteur pEmprunteur)
        {
            FilmDAO filmDAO = new FilmDAO();

            filmDAO.AjouterEmprunt(pCodeFilm, pCodeProprietaire, pCodeSupport, pEmprunteur);
        }

        /// <summary>
        /// Modification d'un emprunt
        /// </summary>
        /// <param name="s">film à modifier</param>
        /// <returns></returns>
        public bool CloreEmprunt(Guid pCodeFilm, string pCodeSupport, Guid pCodeProprietaire)
        {
            FilmDAO filmDAO = new FilmDAO();

            return (filmDAO.UpdateEmprunt(pCodeFilm, pCodeProprietaire, pCodeSupport) == 1);

            //return filmDAO.ObtenirListeFilms();
        }

        /// <summary>
        /// Retourne le film dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idFilm"></param>
        /// <returns></returns>
        public void AjouterSouhait(Guid pCodeFilm, string pCodeSupport, Guid pCodeProprietaire)
        {
            FilmDAO filmDAO = new FilmDAO();

            filmDAO.AjouterSouhait(pCodeFilm, pCodeSupport, pCodeProprietaire);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCodeFilm"></param>
        public void SupprimerFilm(Guid pCodeFilm)
        {
            FilmDAO filmDAO = new FilmDAO();
            filmDAO.SupprimerFilm(pCodeFilm);         
        }

        /// <summary>
        /// SupprimerExemplaire
        /// </summary>
        /// <param name="pCodeFilm">pCodeFilm</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        public void SupprimerExemplaire(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport)
        {
            FilmDAO filmDAO = new FilmDAO();
            filmDAO.SupprimerExemplaire(pCodeFilm, pCodeProprietaire, pCodeSupport);
        }

        /// <summary>
        /// SupprimerSouhait
        /// </summary>
        /// <param name="pCodeFilm">pCodeFilm</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        public void SupprimerSouhait(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport)
        {
            FilmDAO filmDAO = new FilmDAO();
            filmDAO.SupprimerSouhait(pCodeFilm, pCodeProprietaire, pCodeSupport);
        }

        /// <summary>
        /// ObtenirSouhaitsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        public List<Exemplaire> ObtenirSouhaitsProprietaire(Guid pCodeProprietaire)
        {
            FilmDAO filmDAO = new FilmDAO();
            return filmDAO.ListeSouhaitsProprietaire(pCodeProprietaire);
        }

        /// <summary>
        /// ObtenirEmpruntsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public List<Emprunt> ObtenirEmpruntsProprietaire(Guid pCodeProprietaire)
        {
            FilmDAO filmDAO = new FilmDAO();
            return filmDAO.ListeEmpruntsProprietaire(pCodeProprietaire);
        }

        /// <summary>
        /// Modification d'un film
        /// </summary>
        /// <param name="s">film à modifier</param>
        /// <returns></returns>
        public List<Film> MettreAJourFilm(Film f)
        {

            FilmDAO filmDAO = new FilmDAO();

            filmDAO.UpdateFilm(f);

            return filmDAO.ObtenirListeFilms();
        }

    }
}
