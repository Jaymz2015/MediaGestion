using System.Collections.Generic;
using MediaGestion.DAO;
using MediaGestion.Modele.Dl.Dlo;
using System;

namespace MediaGestion.Metier.Bl.Blo.Impl
{
    public class GestionnaireProprietaires
    {

        /// <summary>
        /// Construction de la liste des propriétaires
        /// </summary>
        /// <returns></returns>
        public List<Proprietaire> ObtenirProprietaires()
        {

            ProprietaireDAO proprietaireDAO = new ProprietaireDAO();
            return proprietaireDAO.ObtenirListeProprietaires();

        }

        /// <summary>
        /// Récupération d'un propriétaire
        /// </summary>
        /// <returns></returns>
        public Proprietaire ObtenirProprietaire(string login)
        {

            ProprietaireDAO proprietaireDAO = new ProprietaireDAO();
            return proprietaireDAO.ObtenirProprietaire(login);

        }

        /// <summary>
        /// Ajout d'un propriétaire
        /// </summary>
        /// <param name="pCode">pProprietaire</param>
        /// <returns>Liste des propriétaires</returns>
        public List<Proprietaire> AjouterProprietaire(Proprietaire pProprietaire)
        {

            //ProprietaireDAO proprietaireDAO = new ProprietaireDAO();
            //return proprietaireDAO.ObtenirListeProprietaires();
            return null;
        }

        /// <summary>
        /// Suppression d'un propriétaire
        /// </summary>
        /// <param name="pCode">pCode</param>
        /// <returns>Liste des propriétaires</returns>
        public List<Proprietaire> SupprimerProprietaire(Guid pCode)
        {
            ProprietaireDAO proprietaireDAO = new ProprietaireDAO();
            proprietaireDAO.DeleteProprietaire(pCode);

            return proprietaireDAO.ObtenirListeProprietaires();
        }

        /// <summary>
        /// Modification d'un propriétaire
        /// </summary>
        /// <param name="pCode">pProprietaire</param>
        /// <returns>Liste des propriétaires</returns>
        public List<Proprietaire> ModifierProprietaire(Proprietaire pProprietaire, String pNewPassword)
        {

            ProprietaireDAO proprietaireDAO = new ProprietaireDAO();

            proprietaireDAO.UpdateProprietaire(pProprietaire, pNewPassword);

            return ObtenirProprietaires();
        }


    }
}
