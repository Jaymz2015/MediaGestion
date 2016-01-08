using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;

namespace MediaGestion.Metier.Bl.Blo.Impl
{
    public class GestionnaireGenres
    {
        /// <summary>
        /// Construction de la liste des Genres
        /// </summary>
        /// <returns></returns>
        public List<Genre> ObtenirGenres()
        {
            GenreDAO GenreDAO = new GenreDAO();
            return GenreDAO.ObtenirListeGenres();
        }

        /// <summary>
        /// Récupération d'un Genre
        /// </summary>
        /// <returns></returns>
        public Genre ObtenirGenre(string pCode)
        {
            GenreDAO GenreDAO = new GenreDAO();
            return GenreDAO.ObtenirGenre(pCode);
        }

        /// <summary>
        /// Ajout d'un Genre
        /// </summary>
        /// <param name="s">Genre à ajouter</param>
        /// <returns></returns>
        public List<Genre> AjouterGenre(Genre s)
        {
            GenreDAO GenreDAO = new GenreDAO();
            GenreDAO.InsertGenre(s);
            return GenreDAO.ObtenirListeGenres();
        }

        /// <summary>
        /// Modification d'un Genre
        /// </summary>
        /// <param name="s">Genre à modifier</param>
        /// <returns></returns>
        public List<Genre> MettreAJourGenre(Genre s, string pOldCode)
        {
            GenreDAO GenreDAO = new GenreDAO();
            GenreDAO.UpdateGenre(s, pOldCode);
            return GenreDAO.ObtenirListeGenres();
        }

        /// <summary>
        /// Suppression d'un Genre
        /// </summary>
        /// <param name="s">Genre à supprimer</param>
        /// <returns></returns>
        public List<Genre> SupprimerGenre(string pCode)
        {
            GenreDAO GenreDAO = new GenreDAO();
            GenreDAO.DeleteGenre(pCode);
            return GenreDAO.ObtenirListeGenres();
        }
    }
}
