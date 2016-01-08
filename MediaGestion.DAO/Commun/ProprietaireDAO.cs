using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class ProprietaireDAO
    {
        /// <summary>
        /// Requête de récupération de la liste des propriétaires
        /// </summary>
        public string REQUETE_OBTENIR_LISTE_PROPRIETAIRES = "SELECT code, login, passwordHash, nom, prenom, adresse, cp, ville, habilitation FROM PROPRIETAIRE order by nom, prenom";

        /// <summary>
        /// Requête de récupération d'un propriétaire
        /// </summary>
        public string REQUETE_OBTENIR_PROPRIETAIRE = "SELECT code, login, passwordHash, nom, prenom, adresse, cp, ville, habilitation FROM PROPRIETAIRE where login = @pLogin COLLATE french_cs_as";

        /// <summary>
        /// Requête de modification d'un propriétaire
        /// </summary>
        public string REQUETE_MODIFIER_PROPRIETAIRE = "UPDATE PROPRIETAIRE SET login=@pLogin, nom=@pNom, prenom=@pPrenom, adresse=@pAdresse, cp=@pCP, ville=@pVille where code = @pCode";

        /// <summary>
        /// Requête de modification d'un propriétaire
        /// </summary>
        public string REQUETE_MODIFIER_PROPRIETAIRE_ET_PASSWORD = "UPDATE PROPRIETAIRE SET login=@pLogin, nom=@pNom, prenom=@pPrenom, adresse=@pAdresse, cp=@pCP, ville=@pVille, passwordHash=@pPasswordHash where code = @pCode";

        /// <summary>
        /// Requête d'enregistrement de la tentative de connexion
        /// </summary>
        public string REQUETE_HISTORIQUE_CONNEXION = "INSERT INTO HISTORIQUE_CONNEXION (Login, DateAcces) VALUES (@pLogin, GETDATE())";

        /// <summary>
        /// Requête de création d'un propriétaire
        /// </summary>
        public string REQUETE_CREER_PROPRIETAIRE = "INSERT INTO PROPRIETAIRE (code, login, passwordHash, nom, prenom, adresse, cp, ville, habilitation) values (@pCode, @pLogin, @pPasswordHash, @pNom, @pPrenom, @pAdresse, @pCP, @pVille, 2)";

        /// <summary>
        /// Requête de suppression d'un propriétaire
        /// </summary>
        public string REQUETE_SUPPRIMER_PROPRIETAIRE = "DELETE FROM PROPRIETAIRE where code = @pCode";

        /// <summary>
        /// ObtenirListeFilms
        /// </summary>
        /// <returns>Liste films</returns>
        public List<Proprietaire> ObtenirListeProprietaires()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Proprietaire>(REQUETE_OBTENIR_LISTE_PROPRIETAIRES, new ProprietaireRowMapper(), false, null);
        }

        /// <summary>
        /// ObtenirProprietaire
        /// </summary>
        /// <returns>Le proprietaire</returns>
        public Proprietaire ObtenirProprietaire(string pLogin)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_HISTORIQUE_CONNEXION, false, pLogin);

            return maDataSource.ExecuterRequete<Proprietaire>(REQUETE_OBTENIR_PROPRIETAIRE, new ProprietaireRowMapper(), false, pLogin);
       
        }

        /// <summary>
        /// ObtenirProprietaire
        /// </summary>
        /// <returns>Le proprietaire</returns>
        public int UpdateProprietaire(Proprietaire p, string pPasswordHash)
        {

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            if (String.IsNullOrEmpty(pPasswordHash))
            {
                return maDataSource.ExecuterDML(REQUETE_MODIFIER_PROPRIETAIRE, false, p.Login, p.Nom, p.Prenom, p.Adresse, p.CP, p.Ville, p.Code);

            }
            else
            {
                return maDataSource.ExecuterDML(REQUETE_MODIFIER_PROPRIETAIRE_ET_PASSWORD, false, p.Login, p.Nom, p.Prenom, p.Adresse, p.CP, p.Ville, pPasswordHash, p.Code);
            }
            
            
        }

        /// <summary>
        /// ObtenirProprietaire
        /// </summary>
        /// <returns>Le proprietaire</returns>
        public int DeleteProprietaire(Guid pCode)
        {

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_SUPPRIMER_PROPRIETAIRE, false, pCode);

        }


    }
}
