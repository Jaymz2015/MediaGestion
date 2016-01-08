using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;

namespace MediaGestion.DAO
{
    public class ProprietaireRowMapper : RowMapper<Proprietaire>
    {
        /// <summary>
        /// Construction d'un objet de type film à partir d'une ligne de la table Film
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Proprietaire ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            Proprietaire proprio = new Proprietaire();
            proprio.Code = pReader.GetGuid(pReader.GetOrdinal("code"));

            proprio.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
            proprio.Prenom = pReader.IsDBNull(pReader.GetOrdinal("prenom")) ? "" : pReader.GetString(pReader.GetOrdinal("prenom"));

            if (!pReader.IsDBNull(pReader.GetOrdinal("cp")))
            {
                proprio.CP = pReader.GetInt32(pReader.GetOrdinal("cp"));
            }

            if (!pReader.IsDBNull(pReader.GetOrdinal("adresse")))
            {
                proprio.Adresse = pReader.GetString(pReader.GetOrdinal("adresse"));
            }

            if (!pReader.IsDBNull(pReader.GetOrdinal("ville")))
            {
                proprio.Ville = pReader.GetString(pReader.GetOrdinal("ville"));
            }

            proprio.Login = pReader.IsDBNull(pReader.GetOrdinal("login"))? "" : pReader.GetString(pReader.GetOrdinal("login"));
            proprio.PasswordHash = pReader.IsDBNull(pReader.GetOrdinal("passwordHash"))? "" : pReader.GetString(pReader.GetOrdinal("passwordHash"));

            proprio.Habilitation = (Proprietaire.enmHabilitation)pReader.GetInt16(pReader.GetOrdinal("habilitation"));

            return proprio; 
        }
    }
}
