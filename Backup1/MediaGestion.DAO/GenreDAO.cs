using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class GenreDAO
    {
        /// <summary>
        /// Requête de récupération de la liste des Genres
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_GENRES = "SELECT codeGenre, libelle FROM GENRE where media in (0,1) order by libelle ";

        /// <summary>
        /// Requête de récupération d'un Genre
        /// </summary>
        private string REQUETE_OBTENIR_GENRE = "SELECT codeGenre, libelle FROM GENRE where codeGenre=@pCode";

        /// <summary>
        /// Requête d'ajout d'un Genre
        /// </summary>
        private string REQUETE_AJOUTER_GENRE = "INSERT into GENRE (codeGenre, libelle, media) VALUES (@pCode, @pLibelle,1)";

        /// <summary>
        /// Requête de modification d'un Genre
        /// </summary>
        private string REQUETE_MODIFICATION_GENRE = "UPDATE GENRE set codeGenre=@pCode, libelle=@pLibelle where codeGenre=@pOldCode";

        /// <summary>
        /// Requête de modification d'un Genre
        /// </summary>
        private string REQUETE_SUPPRESSION_GENRE = "DELETE FROM GENRE where codeGenre=@pCode";


        /// <summary>
        /// ObtenirListeGenres
        /// </summary>
        /// <returns>Liste Genres</returns>
        public List<Genre> ObtenirListeGenres()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Genre>(REQUETE_OBTENIR_LISTE_GENRES, new GenreRowMapper(), false, null);
        }

        /// <summary>
        /// ObtenirGenre
        /// </summary>
        /// <returns>Genre</returns>
        public Genre ObtenirGenre(string pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequete<Genre>(REQUETE_OBTENIR_GENRE, new GenreRowMapper(), false, pCode);
        }

        /// <summary>
        /// InsertGenre
        /// </summary>
        /// <returns>Liste Genres</returns>
        public int InsertGenre(Genre s)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_AJOUTER_GENRE, false, s.Code, s.Libelle);
        }

        /// <summary>
        /// UpdateGenre
        /// </summary>
        /// <returns>Liste Genres</returns>
        public int UpdateGenre(Genre s, string pOldCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_MODIFICATION_GENRE, false, s.Code, s.Libelle, pOldCode);
        }

        /// <summary>
        /// DeleteGenre
        /// </summary>
        /// <returns>Liste Genres</returns>
        public int DeleteGenre(string pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_SUPPRESSION_GENRE, false, pCode);
        }
    }
}
