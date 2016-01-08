using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class SupportDAO
    {
        /// <summary>
        /// Requête de récupération de la liste des supports
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_SUPPORTS = "SELECT code, libelle, icone FROM SUPPORT order by libelle";

        /// <summary>
        /// Requête de récupération d'un support
        /// </summary>
        private string REQUETE_OBTENIR_SUPPORT = "SELECT code, libelle, icone FROM SUPPORT where code=@pCode";

        /// <summary>
        /// Requête d'ajout d'un support
        /// </summary>
        private string REQUETE_AJOUTER_SUPPORT = "INSERT into SUPPORT (code, libelle) VALUES (@pCode, @pLibelle)";

        /// <summary>
        /// Requête de modification d'un support
        /// </summary>
        private string REQUETE_MODIFICATION_SUPPORT = "UPDATE SUPPORT set code=@pCode, libelle=@pLibelle, icone=@pIcone where code=@pCode";

        /// <summary>
        /// Requête de modification d'un support
        /// </summary>
        private string REQUETE_SUPPRESSION_SUPPORT = "DELETE FROM SUPPORT where code=@pCode";


        /// <summary>
        /// ObtenirListeSupports
        /// </summary>
        /// <returns>Liste supports</returns>
        public List<Support> ObtenirListeSupports()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Support>(REQUETE_OBTENIR_LISTE_SUPPORTS, new SupportRowMapper(), false,  null);
        }

        /// <summary>
        /// ObtenirSupport
        /// </summary>
        /// <returns>support</returns>
        public Support ObtenirSupport(string pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequete<Support>(REQUETE_OBTENIR_SUPPORT, new SupportRowMapper(), false, pCode);
        }

        /// <summary>
        /// InsertSupport
        /// </summary>
        /// <returns>Liste supports</returns>
        public int InsertSupport(Support s)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_AJOUTER_SUPPORT, false, s.Code, s.Libelle);
        }

        /// <summary>
        /// UpdateSupport
        /// </summary>
        /// <returns>Liste supports</returns>
        public int UpdateSupport(Support s)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_MODIFICATION_SUPPORT, false, s.Code, s.Libelle, s.Icone);
        }

        /// <summary>
        /// DeleteSupport
        /// </summary>
        /// <returns>Liste supports</returns>
        public int DeleteSupport(string pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_SUPPRESSION_SUPPORT, false, pCode);
        }
    }
}
