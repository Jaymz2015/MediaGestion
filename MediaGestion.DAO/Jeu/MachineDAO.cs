using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class MachineDAO
    {
        /// <summary>
        /// Requête de récupération de la liste des machine
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_MACHINES = "SELECT m.code, m.nom, m.logo, m.photo, c.code codeConstructeur, c.nom nomConstructeur, dateSortie, m.historique, m.caracteristiques FROM MACHINES m left outer join CONSTRUCTEUR c on c.code = m.codeConstructeur order by nom";

        /// <summary>
        /// Requête de récupération d'un machine
        /// </summary>
        private string REQUETE_OBTENIR_MACHINE = "SELECT code, libelle, icone FROM MACHINES where code=@pCode";

        /// <summary>
        /// Requête d'ajout d'une machine
        /// </summary>
        private string REQUETE_AJOUTER_MACHINE = "INSERT into MACHINES (code, nom, historique, caracteristiques,dateSortie) " + 
            " VALUES (@pCode, @pNom, @pHistorique, @pCaracteristiques, @pDateSortie)";

        /// <summary>
        /// Requête de modification d'un machine
        /// </summary>
        private string REQUETE_MODIFICATION_MACHINE = "UPDATE MACHINES set code=@pCode, nom=@pNom, dateSortie=@pDateSortie, " + 
            " caracteristiques=@Caracteristiques, historique=@Historique " +
            " where code=@pOldCode";

        /// <summary>
        /// Requête de modification d'un logo
        /// </summary>
        private string REQUETE_MODIFICATION_LOGO = "UPDATE MACHINES set logo=@pLogo " +
            " where code=@pCode";

        /// <summary>
        /// Requête de modification d'une photo
        /// </summary>
        private string REQUETE_MODIFICATION_PHOTO = "UPDATE MACHINES set photo=@pPhoto " +
            " where code=@pCode";


        /// <summary>
        /// Requête de modification d'un support
        /// </summary>
        private string REQUETE_SUPPRESSION_MACHINE = "DELETE FROM MACHINES where code=@pCode";

        /// <summary>
        /// ObtenirListeMachines
        /// </summary>
        /// <returns>Liste supports</returns>
        public List<Machine> ObtenirListeMachines()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Machine>(REQUETE_OBTENIR_LISTE_MACHINES, new MachineRowMapper(), false,  null);
        }

        /// <summary>
        /// ObtenirMachine
        /// </summary>
        /// <returns>support</returns>
        public Machine ObtenirMachine(string pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequete<Machine>(REQUETE_OBTENIR_MACHINE, new MachineRowMapper(), false, pCode);
        }

        /// <summary>
        /// InsertMachine
        /// </summary>
        /// <returns>Liste supports</returns>
        public int InsertMachine(Machine s)
        {
            int result = -1;
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                result = maDataSource.ExecuterDML(REQUETE_AJOUTER_MACHINE, true, s.Code, s.Nom, s.Historique, s.Caracteristiques, s.DateSortie);

                maDataSource.CommitGlobalTransaction();

            }
            catch (Exception ex)
            {
                maDataSource.RollBackGlobalTransaction();

                throw ex;
            }
            finally
            {
                
            }

            return result;
        }

        /// <summary>
        /// UpdateMachine
        /// </summary>
        /// <returns>Liste supports</returns>
        public int UpdateMachine(Machine s, string OldCode)
        {
            int result = -1;
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {

                maDataSource.StartGlobalTransaction();

                result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_MACHINE, true, s.Code, s.Nom,
                    s.DateSortie, s.Caracteristiques, s.Historique, OldCode);

                if (result == 1 && s.Logo != null)
                {
                    result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_LOGO, true, s.Logo, s.Code);
                }

                if (result == 1 && s.Photo != null)
                {
                    result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_PHOTO, true, s.Photo, s.Code);
                }

                maDataSource.CommitGlobalTransaction();

            }
            catch (Exception ex)
            {
                maDataSource.RollBackGlobalTransaction();

                throw ex;
            }
            finally
            {

            }

            return result;
            
        }


         //"UPDATE MACHINES set code=@pCode, nom=@pNom, logo=ISNULL(@pLogo, logo), photo=ISNULL(@pPhoto, photo), dateSortie=@pDateSortie, " + 
         //   " codeConstructeur=@CodeConstructeur, caracteristiques=@Caracteristiques, historique=@Historique " +
         //   " where code=@pOldCode";
        /// <summary>
        /// DeleteMachine
        /// </summary>
        /// <returns>Liste supports</returns>
        public int DeleteMachine(string pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_SUPPRESSION_MACHINE, false, pCode);
        }
    }
}
