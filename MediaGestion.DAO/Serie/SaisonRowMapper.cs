using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using System.Data.SqlClient;
using MediaGestion.Modele.Dl.Dlo.Series;

namespace MediaGestion.DAO
{
    public class SaisonRowMapper : RowMapper<Saison>
    {
        /// <summary>
        /// Construction d'un objet de type serie à partir d'une ligne de la table serie
        /// </summary>
        /// <param name="pReader">pReader</param>
        /// <returns>serie</returns>
        public override Saison ExtraireDonneesReader(SqlDataReader pReader)
        {
            Saison saison = new Saison();

            try
            {
                saison.CodeSaison = pReader.GetGuid(pReader.GetOrdinal("codeSaison"));
                saison.Numero = pReader.GetInt32(pReader.GetOrdinal("numeroSaison"));
                saison.AnneeSortie = pReader.GetInt32(pReader.GetOrdinal("annee"));
                saison.NbEpisodes = pReader.GetInt32(pReader.GetOrdinal("nbEpisodes"));
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saison;
        }
    }
}
