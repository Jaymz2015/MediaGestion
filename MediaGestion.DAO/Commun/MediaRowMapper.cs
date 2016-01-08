using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using MediaGestion.Modele;

namespace MediaGestion.DAO
{
    public class MediaRowMapper : RowMapper<Media>
    {
        /// <summary>
        /// Construction d'un objet de type film à partir d'une ligne de la table Film
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Media ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            Media media = new Media();

            try
            {

                media.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
                media.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));
                media.Code = pReader.GetGuid(pReader.GetOrdinal("codeMedia"));
                media.TypeMedia = (Constantes.EnumTypeMedia)pReader.GetByte(pReader.GetOrdinal("typeMedia"));

                Genre genre = new Genre();
                genre.Code = pReader.GetString(pReader.GetOrdinal("codeGenre"));
                genre.Libelle = pReader.GetString(pReader.GetOrdinal("libelle"));

                media.LeGenre = genre;

                if (!pReader.IsDBNull(pReader.GetOrdinal("photo")))
                {
                    media.Photo = pReader.GetString(pReader.GetOrdinal("photo"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("dateCreation")))
                {
                    media.DateCreation = pReader.GetDateTime(pReader.GetOrdinal("dateCreation"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("dateDerniereModification")))
                {
                    media.DateDerniereModification = pReader.GetDateTime(pReader.GetOrdinal("dateDerniereModification"));
                }

                //if (!pReader.IsDBNull(pReader.GetOrdinal("notePublic")))
                //{
                //    media.Note = pReader.GetFloat(pReader.GetOrdinal("notePublic"));
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return media;
        }
    }
}
