using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;
using MediaGestion.Modele;

namespace MediaGestion.Metier
{
    public class GestionnaireMedias : AGestionnaireMedias
    {
        List<Media> listeMedias = null;

        private MediaDAO MediaDAO;

        public GestionnaireMedias()
        {
            MediaDAO = new MediaDAO();
        }

        /// <summary>
        /// Construction de la liste des jeux
        /// </summary>
        /// <returns></returns>
        public List<Media> ObtenirMedias(Constantes.EnumTypeMedia pTypeMedia)
        {

            if (listeMedias == null)
            {
                listeMedias = MediaDAO.ObtenirListeMedias(pTypeMedia);
            }

            return listeMedias;
        }

        /// <summary>
        /// ObtenirMedia
        /// </summary>
        /// <param name="pCodeMedia">pCodeMedia</param>
        /// <returns>Media</returns>
        public Media ObtenirMedia(Guid pCodeMedia)
        {
            return MediaDAO.ObtenirMedia(pCodeMedia);
        }

        /// <summary>
        /// ObtenirMediaEtExemplaire
        /// </summary>
        /// <param name="pCodeMedia">pCodeMedia</param>
        /// <returns>Media</returns>
        public Media ObtenirMediaEtExemplaire(Guid pCodeMedia)
        {
            return MediaDAO.ObtenirMedia(pCodeMedia);
        }

        /// <summary>
        /// ObtenirExemplaire
        /// </summary>
        /// <param name="pCodeExemplaire">pCodeExemplaire</param>
        /// <returns>Exemplaire</returns>
        public Exemplaire ObtenirExemplaire(Guid pCodeExemplaire)
        {
            return MediaDAO.ObtenirExemplaire(pCodeExemplaire);
        }

        /// <summary>
        /// ObtenirSouhait
        /// </summary>
        /// <param name="pCodeExemplaire">pCodeSouhait</param>
        /// <returns>Exemplaire</returns>
        public Exemplaire ObtenirSouhaitAchat(Guid pCodeSouhait)
        {
            return MediaDAO.ObtenirSouhaitAchat(pCodeSouhait);
        }

        /// <summary>
        /// AjouterExemplaire
        /// </summary>
        /// <param name="pCodeMedia"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pEtat"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pDateAcquisition"></param>
        public void AjouterExemplaire(Guid pCodeMedia, Guid pCodeProprietaire, int pEtat, String pCodeSupport, DateTime pDateAcquisition)
        {
            MediaDAO.AjouterExemplaire(pCodeMedia, pCodeProprietaire, pEtat, pCodeSupport, pDateAcquisition);
        }

        /// <summary>
        /// AjouterExemplaire
        /// </summary>
        /// <param name="pCodeMedia"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pEtat"></param>
        /// <param name="pDateAcquisition"></param>
        public void AjouterExemplaire(Guid pCodeMedia, Guid pCodeProprietaire, int pEtat, DateTime pDateAcquisition)
        {
            MediaDAO.AjouterExemplaire(pCodeMedia, pCodeProprietaire, pEtat, null, pDateAcquisition);
        }

        /// <summary>
        /// ModifierExemplaire
        /// </summary>
        /// <param name="pCodeJeu"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pEtat"></param>
        /// <param name="pDateAcquisition"></param>
        public void ModifierExemplaire(Guid pCodeExemplaire, string pCodeSupport, int pEtat, DateTime pDateAcquisition)
        {
            MediaDAO.ModifierExemplaire(pCodeExemplaire, pCodeSupport, pEtat, pDateAcquisition);
        }

        /// <summary>
        /// ModifierExemplaire
        /// </summary>
        /// <param name="pCodeExemplaire"></param>
        /// <param name="pEtat"></param>
        /// <param name="pDateAcquisition"></param>
        public void ModifierExemplaire(Guid pCodeExemplaire, int pEtat, DateTime pDateAcquisition)
        {
            MediaDAO.ModifierExemplaire(pCodeExemplaire, null, pEtat, pDateAcquisition);
        }

        /// <summary>
        /// AjouterEmprunt
        /// </summary>
        /// <param name="pCodeExemplaire"></param>
        /// <param name="pEmprunteur"></param>
        public void AjouterEmprunt(Guid pCodeExemplaire, Emprunteur pEmprunteur)
        {
            MediaDAO.AjouterEmprunt(pCodeExemplaire, pEmprunteur);
        }

        /// <summary>
        /// Modification d'un emprunt
        /// </summary>
        /// <param name="s">film à modifier</param>
        /// <returns></returns>
        public bool CloreEmprunt(Guid pCodeEmprunt)
        {
            return (MediaDAO.UpdateEmprunt(pCodeEmprunt) == 1);
        }

        /// <summary>
        /// Retourne le film dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idJeu"></param>
        /// <returns></returns>
        public void AjouterSouhaitAchat(Guid pCodeMedia, Guid pCodeProprietaire, string pCodeSupport)
        {
            MediaDAO.AjouterSouhaitAchat(pCodeMedia, pCodeProprietaire, pCodeSupport);
        }

        /// <summary>
        /// AjouterSouhait
        /// </summary>
        /// <param name="pCodeMedia"></param>
        /// <param name="pCodeProprietaire"></param>
        public void AjouterSouhaitAchat(Guid pCodeMedia, Guid pCodeProprietaire)
        {
            MediaDAO.AjouterSouhaitAchat(pCodeMedia, pCodeProprietaire, null);
        }


        /// <summary>
        /// SupprimerExemplaire
        /// </summary>
        /// <param name="pCodeJeu">pCodeJeu</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        public void SupprimerExemplaire(Guid pCodeExemplaire)
        {
            MediaDAO.SupprimerExemplaire(pCodeExemplaire);
        }

        /// <summary>
        /// SupprimerSouhait
        /// </summary>
        /// <param name="pCodeJeu">pCodeJeu</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        public void SupprimerSouhaitAchat(Guid pCodeSouhait)
        {
            MediaDAO.SupprimerSouhaitAchat(pCodeSouhait);
        }

        /// <summary>
        /// ObtenirSouhaitsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        public List<Exemplaire> ObtenirSouhaitsAchatFilmsProprietaire(Guid pCodeProprietaire)
        {
            return MediaDAO.ListeSouhaitsAchatFilmsProprietaire(pCodeProprietaire);
        }


        /// <summary>
        /// SupprimerMedia
        /// </summary>
        /// <param name="pCodeMedia">pCodeMedia</param>
        public int SupprimerMedia(Guid pCodeMedia)
        {
            return MediaDAO.SupprimerMedia(pCodeMedia);
        }

        /// <summary>
        /// ObtenirSouhaitsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        public List<Exemplaire> ObtenirSouhaitsAchatJeuxProprietaire(Guid pCodeProprietaire)
        {
            return MediaDAO.ListeSouhaitsAchatJeuxProprietaire(pCodeProprietaire);
        }

        /// <summary>
        /// ObtenirPretsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <returns>List<Emprunt></returns>
        public List<Emprunt> ObtenirPretsProprietaire(Guid pCodeProprietaire)
        {
            return MediaDAO.ListePretsProprietaire(pCodeProprietaire);
        }


        /// <summary>
        /// ObtenirEmpruntsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <returns>List<Emprunt></returns>
        public List<Emprunt> ObtenirEmpruntsProprietaire(Guid pCodeProprietaire)
        {
            return MediaDAO.ListeEmpruntsProprietaire(pCodeProprietaire);
        }

        
    }
}
