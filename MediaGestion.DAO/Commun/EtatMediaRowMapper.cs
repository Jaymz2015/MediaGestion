using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;

namespace MediaGestion.DAO
{
    public class EtatMediaRowMapper : RowMapper<EtatMedia>
    {
        /// <summary>
        /// Construction d'un objet de type EtatMedia à partir d'une ligne de la table ETAT_MEDIA
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override EtatMedia ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            EtatMedia etatMedia = new EtatMedia(pReader.GetByte(pReader.GetOrdinal("code")), pReader.GetString(pReader.GetOrdinal("libelle")));

            return etatMedia; 
        }
    }
}
