using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;
using MediaGestion.Modele;

namespace MediaGestion.Metier
{
    public class GestionnaireJeux : GestionnaireMedias
    {
        private  List<Jeu> listeJeux = null;
        private JeuDAO JeuDAO;

        public GestionnaireJeux()
            : base()
        {

            JeuDAO = new JeuDAO();
        }

        /// <summary>
        /// Retourne le film dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idJeu"></param>
        /// <returns></returns>
        public Jeu ObtenirLeJeu(Guid idJeu)
        {
            return JeuDAO.ObtenirJeu(idJeu);  
        }

        /// <summary>
        /// Retourne le film dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idJeu">idJeu</param>
        /// <returns></returns>
        public Jeu ObtenirLeJeuComplet(Guid idJeu)
        {
            Jeu jeu = JeuDAO.ObtenirJeuComplet(idJeu);

            List<Exemplaire> listeExpl = JeuDAO.ObtenirListeExemplairesMedia(jeu.Code);
            List<Exemplaire> listeSouhaits = JeuDAO.ObtenirListeSouhaitsMedia(jeu.Code);

            //On associe le film à chaque exemplaire
            foreach (Exemplaire expl in listeExpl)
            {
                expl.LeMedia = jeu;
            }

            //On associe le film à chaque exemplaire
            foreach (Exemplaire expl in listeSouhaits)
            {
                expl.LeMedia = jeu;
            }

            jeu.ListeExemplaire = listeExpl;
            jeu.ListeSouhaits = listeSouhaits;

            return jeu;        
        }

        /// <summary>
        /// CreerJeuEtExemplaire
        /// </summary>
        /// <param name="pJeu"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public Jeu CreerJeuEtExemplaire(Jeu pJeu, Guid pCodeProprietaire, EtatMedia pEtat, DateTime dateAcquisition)
        {
            return JeuDAO.CreerJeuEtExemplaire(pJeu, pCodeProprietaire, pEtat, dateAcquisition);        
        }

        /// <summary>
        /// CreerJeuEtSouhait
        /// </summary>
        /// <param name="pJeu"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public Jeu CreerJeuEtSouhait(Jeu pJeu, Guid pCodeProprietaire)
        {
            return JeuDAO.CreerJeuEtSouhait(pJeu, pCodeProprietaire);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCodeJeu"></param>
        public void SupprimerJeu(Guid pCodeJeu)
        {
            JeuDAO filmDAO = new JeuDAO();
            filmDAO.SupprimerJeu(pCodeJeu);         
        }



        /// <summary>
        /// Modification d'un film
        /// </summary>
        /// <param name="s">film à modifier</param>
        /// <returns></returns>
        public List<Media> MettreAJourJeu(Jeu f)
        {

            JeuDAO jeuDAO = new JeuDAO();

            jeuDAO.UpdateJeu(f);

            MediaDAO mediaDAO = new MediaDAO();

            return mediaDAO.ObtenirListeMedias(Constantes.EnumTypeMedia.JEU);
        }

        /// <summary>
        /// Construction de la liste des films
        /// </summary>
        /// <returns></returns>
        public List<Jeu> ObtenirJeux()
        {
            if (listeJeux == null)
            {
                listeJeux = JeuDAO.ObtenirListeJeux();
            }

            return listeJeux;
        }

    }
}
