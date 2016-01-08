using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using System.Data.SqlClient;

namespace MediaGestion.DAO
{
    public class SerieRowMapper : RowMapper<Serie>
    {
        /// <summary>
        /// Construction d'un objet de type serie à partir d'une ligne de la table serie
        /// </summary>
        /// <param name="pReader">pReader</param>
        /// <returns>serie</returns>
        public override Serie ExtraireDonneesReader(SqlDataReader pReader)
        {
            Serie serie = new Serie();

            try
            {                
                serie.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
                serie.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));
                serie.Code = pReader.GetGuid(pReader.GetOrdinal("codeMedia"));
                serie.TypeMedia = Modele.Constantes.EnumTypeMedia.SERIE;

                Genre genre = new Genre();
                genre.Code = pReader.GetString(pReader.GetOrdinal("codeGenre"));
                genre.Libelle = pReader.GetString(pReader.GetOrdinal("libelle"));

                serie.LeGenre = genre;


                if (!pReader.IsDBNull(pReader.GetOrdinal("dateCreation"))) {
                    serie.DateCreation = pReader.GetDateTime(pReader.GetOrdinal("dateCreation"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("dateDerniereModification")))
                {
                    serie.DateDerniereModification = pReader.GetDateTime(pReader.GetOrdinal("dateDerniereModification"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("photo")))
                {
                    serie.Photo = pReader.GetString(pReader.GetOrdinal("photo"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("realisateur")))
                {
                    serie.Realisateur = pReader.GetString(pReader.GetOrdinal("realisateur"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("acteurs")))
                {
                    serie.Acteurs = pReader.GetString(pReader.GetOrdinal("acteurs"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("nbSaisons")))
                {
                    serie.NbSaisons = pReader.GetInt32(pReader.GetOrdinal("nbSaisons"));
                }

                if (pReader.FieldCount > 12) {

                    if (!pReader.IsDBNull(pReader.GetOrdinal("synopsys")))
                    {
                        serie.Synopsys = pReader.GetString(pReader.GetOrdinal("synopsys"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("url")))
                    {
                        serie.UrlFiche = pReader.GetString(pReader.GetOrdinal("url"));
                    }

                    
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return serie;
        }
    }
}
