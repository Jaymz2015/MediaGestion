using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class EtatMediaDAO
    {
        /// <summary>
        /// Requête de récupération de la liste des Etats
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_ETATS = "SELECT code, libelle FROM ETAT_MEDIA order by code ";

        /// <summary>
        /// ObtenirListeEtats
        /// </summary>
        /// <returns>Liste Etats</returns>
        public List<EtatMedia> ObtenirListeEtats()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<EtatMedia>(REQUETE_OBTENIR_LISTE_ETATS, new EtatMediaRowMapper(), false, null);
        }

    }
}
