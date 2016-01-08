using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using System.Data.SqlClient;

namespace MediaGestion.DAO
{
    public class JeuRowMapper : RowMapper<Jeu>
    {
        /// <summary>
        /// Construction d'un objet de type jeu à partir d'une ligne de la table Jeu
        /// </summary>
        /// <param name="pReader">pReader</param>
        /// <returns>Jeu</returns>
        public override Jeu ExtraireDonneesReader(SqlDataReader pReader)
        {
            Jeu jeu = new Jeu();

            try
            {
                jeu.Code = pReader.GetGuid(pReader.GetOrdinal("codeMedia"));

                if (pReader.FieldCount > 1)
                {
                    jeu.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
                    jeu.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));
                    jeu.TypeMedia = Modele.Constantes.EnumTypeMedia.JEU;

                    Genre genre = new Genre();
                    genre.Code = pReader.GetString(pReader.GetOrdinal("codeGenre"));
                    genre.Libelle = pReader.GetString(pReader.GetOrdinal("libelleGenre"));
                    genre.Media = pReader.GetByte(pReader.GetOrdinal("media"));

                    jeu.LeGenre = genre;

                    jeu.LaMachine.Code = pReader.GetString(pReader.GetOrdinal("codeMachine"));
                    jeu.LaMachine.Nom = pReader.GetString(pReader.GetOrdinal("nomMachine"));

                    if (!pReader.IsDBNull(pReader.GetOrdinal("codeEditeur")))
                    {
                        jeu.Editeur.Code = pReader.GetGuid(pReader.GetOrdinal("codeEditeur"));
                        jeu.Editeur.Nom = pReader.GetString(pReader.GetOrdinal("nomEditeur"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("codeDeveloppeur")))
                    {
                        jeu.Developpeur.Code = pReader.GetGuid(pReader.GetOrdinal("codeDeveloppeur"));
                        jeu.Developpeur.Nom = pReader.GetString(pReader.GetOrdinal("nomDeveloppeur"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("photo")))
                    {
                        jeu.Photo = pReader.GetString(pReader.GetOrdinal("photo"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("synopsys")))
                    {
                        jeu.Synopsys = pReader.GetString(pReader.GetOrdinal("synopsys"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("dateCreation")))
                    {
                        jeu.DateCreation = pReader.GetDateTime(pReader.GetOrdinal("dateCreation"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("dateDerniereModification")))
                    {
                        jeu.DateDerniereModification = pReader.GetDateTime(pReader.GetOrdinal("dateDerniereModification"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("notePublic")))
                    {
                        jeu.Note = Decimal.ToDouble(pReader.GetDecimal(pReader.GetOrdinal("notePublic")));
                    }
                }
            }
            catch (Exception ex)
            {
                jeu = null;
            }

            return jeu;
        }
    }
}
