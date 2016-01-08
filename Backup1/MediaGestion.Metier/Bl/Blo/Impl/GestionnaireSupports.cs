using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;

namespace MediaGestion.Metier.Bl.Blo.Impl
{
    public class GestionnaireSupports
    {
        /// <summary>
        /// Construction de la liste des supports
        /// </summary>
        /// <returns></returns>
        public List<Support> ObtenirSupports()
        {

            SupportDAO supportDAO = new SupportDAO();
            return supportDAO.ObtenirListeSupports();

        }

        /// <summary>
        /// Récupération d'un support
        /// </summary>
        /// <returns></returns>
        public Support ObtenirSupport(string pCode)
        {

            SupportDAO supportDAO = new SupportDAO();
            return supportDAO.ObtenirSupport(pCode);

        }

        /// <summary>
        /// Ajout d'un support
        /// </summary>
        /// <param name="s">support à ajouter</param>
        /// <returns></returns>
        public List<Support> AjouterSupport(Support s)
        {

            SupportDAO supportDAO = new SupportDAO();
            supportDAO.InsertSupport(s);
            return supportDAO.ObtenirListeSupports();

        }

        /// <summary>
        /// Modification d'un support
        /// </summary>
        /// <param name="s">support à modifier</param>
        /// <returns></returns>
        public List<Support> MettreAJourSupport(Support s)
        {

            SupportDAO supportDAO = new SupportDAO();

            supportDAO.UpdateSupport(s);

            return supportDAO.ObtenirListeSupports();

        }

        /// <summary>
        /// Suppression d'un support
        /// </summary>
        /// <param name="s">support à supprimer</param>
        /// <returns></returns>
        public List<Support> SupprimerSupport(string pCode)
        {

            SupportDAO supportDAO = new SupportDAO();

            supportDAO.DeleteSupport(pCode);

            return supportDAO.ObtenirListeSupports();

        }


    }
}
