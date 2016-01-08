using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class FilmRowMapper : RowMapper<Film>
    {
        /// <summary>
        /// Construction d'un objet de type film à partir d'une ligne de la table Film
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Film ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            Film film = new Film();

            try
            {
                
                film.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
                film.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));
                film.Code = pReader.GetGuid(pReader.GetOrdinal("code"));
                film.Duree = pReader.GetInt32(pReader.GetOrdinal("duree"));

                Genre genre = new Genre();
                genre.Code = pReader.GetString(pReader.GetOrdinal("codeGenre"));
                genre.Libelle = pReader.GetString(pReader.GetOrdinal("libelle"));

                film.LeGenre = genre;

                
                if (!pReader.IsDBNull(pReader.GetOrdinal("resume")))
                {
                    film.Synopsys = pReader.GetString(pReader.GetOrdinal("resume"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("realisateur")))
                {
                    film.Realisateur = pReader.GetString(pReader.GetOrdinal("realisateur"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("acteurs")))
                {
                    film.Acteurs = pReader.GetString(pReader.GetOrdinal("acteurs"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("jaquette")))
                {
                    film.Jaquette = pReader.GetString(pReader.GetOrdinal("jaquette"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("dateCreation")))
                {
                    film.DateCreation = pReader.GetDateTime(pReader.GetOrdinal("dateCreation"));
                }

                //film.Note = pReader.IsDBNull(pReader.GetOrdinal("note"))?-1:pReader.GetInt16(pReader.GetOrdinal("note"));

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return film;
        }
    }
}
