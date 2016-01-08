using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using System.Data.SqlClient;

namespace MediaGestion.DAO
{
    public class FilmRowMapper : RowMapper<Film>
    {
        /// <summary>
        /// Construction d'un objet de type film à partir d'une ligne de la table Film
        /// </summary>
        /// <param name="pReader">pReader</param>
        /// <returns>Film</returns>
        public override Film ExtraireDonneesReader(SqlDataReader pReader)
        {
            Film film = new Film();

            try
            {                
                film.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
                film.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));
                film.Code = pReader.GetGuid(pReader.GetOrdinal("codeMedia"));
                film.TypeMedia = Modele.Constantes.EnumTypeMedia.FILM;

                Genre genre = new Genre();
                genre.Code = pReader.GetString(pReader.GetOrdinal("codeGenre"));
                genre.Libelle = pReader.GetString(pReader.GetOrdinal("libelle"));

                film.LeGenre = genre;


                if (!pReader.IsDBNull(pReader.GetOrdinal("dateCreation"))) {
                    film.DateCreation = pReader.GetDateTime(pReader.GetOrdinal("dateCreation"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("dateDerniereModification")))
                {
                    film.DateDerniereModification = pReader.GetDateTime(pReader.GetOrdinal("dateDerniereModification"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("photo")))
                {
                    film.Photo = pReader.GetString(pReader.GetOrdinal("photo"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("realisateur")))
                {
                    film.Realisateur = pReader.GetString(pReader.GetOrdinal("realisateur"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("acteurs")))
                {
                    film.Acteurs = pReader.GetString(pReader.GetOrdinal("acteurs"));
                }

                if (pReader.FieldCount > 12) {

                    if (!pReader.IsDBNull(pReader.GetOrdinal("synopsys")))
                    {
                        film.Synopsys = pReader.GetString(pReader.GetOrdinal("synopsys"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("url")))
                    {
                        film.UrlFiche = pReader.GetString(pReader.GetOrdinal("url"));
                    }

                    film.Duree = pReader.GetInt32(pReader.GetOrdinal("duree"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return film;
        }
    }
}
