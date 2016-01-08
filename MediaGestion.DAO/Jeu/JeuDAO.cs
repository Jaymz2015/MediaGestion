using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using Utilitaires;
using MediaGestion.Modele;

namespace MediaGestion.DAO
{
    public class JeuDAO : MediaDAO
    {
        private static string KS_NOM_MODULE = "MediaGestion.DAO - JeuDAO - ";

        /// <summary>
        /// Requête de récupération de la liste des jeux
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_JEUX = "SELECT codeMedia, typeMedia, titre, m.dateSortie, m.dateCreation, m.dateDerniereModification, " +
            "m.photo, notePublic, ma.code codeMachine, ma.nom nomMachine, j.synopsys, " +
            "g.codeGenre, g.libelle libelleGenre, g.media, e.code codeEditeur, e.nom nomEditeur, d.code codeDeveloppeur, d.nom nomDeveloppeur " +
            "FROM MEDIA m, GENRE g, JEUX j, EDITEUR e, DEVELOPPEUR d, MACHINES ma " +
            "WHERE m.codeGenre=g.codeGenre " +
            "and j.codeJeu = m.codeMedia " +
            "and e.code = j.codeEditeur " +
            "and d.code = j.codeDeveloppeur " +
            "and ma.code = j.codeMachine " + 
            "order by titre";

        /// <summary>
        /// Requête permettant de vérifier si un jeu n'existe pas déjà
        /// </summary>
        private string REQUETE_EXISTE_JEU = "SELECT TOP 1 m.codeMedia from JEUX j, MEDIA m " +
                                                                        " WHERE j.codeJeu = m.codeMedia and m.titre like @pTitre " +
                                                                        " AND j.codeMachine=@pMachine ";

        /// <summary>
        /// Requête permettant de vérifier si un developpeur n'existe pas déjà
        /// </summary>
        private string REQUETE_EXISTE_DEVELOPPEUR = "SELECT TOP 1 * from DEVELOPPEUR d " +
                                                                        " WHERE LOWER(d.nom)=LOWER(@pNom)";

        /// <summary>
        /// Requête permettant de vérifier si un editeur n'existe pas déjà
        /// </summary>
        private string REQUETE_EXISTE_EDITEUR = "SELECT TOP 1 * from EDITEUR e " +
                                                                        " WHERE LOWER(e.nom)=LOWER(@pNom)";

        /// <summary>
        /// Requête de récupération d'un jeu
        /// </summary>
        private string REQUETE_OBTENIR_JEU = "SELECT codeMedia, typeMedia, titre, m.dateSortie, m.dateCreation, m.dateDerniereModification, m.photo, " + 
        " m.notePublic, ma.code codeMachine, ma.nom nomMachine, j.synopsys, j.nbJoueurs, " + 
        " m.url, m.PEGI, g.codeGenre, g.libelle libelleGenre, g.media, e.code codeEditeur,  " + 
        " e.nom nomEditeur, d.code codeDeveloppeur, d.nom nomDeveloppeur " + 
        " FROM MEDIA m left outer join GENRE g on m.codeGenre=g.codeGenre " + 
        " left outer join JEUX j on j.codeJeu = m.codeMedia " + 
        " left outer join EDITEUR e on e.code = j.codeEditeur " + 
        " left outer join  DEVELOPPEUR d on d.code = j.codeDeveloppeur " + 
        " left outer join  MACHINES ma on ma.code = j.codeMachine " +
        " WHERE j.codeJeu=@pCodeJeu";

        /// <summary>
        /// Requête de suppression d'un jeu (cascade)
        /// </summary>
        private string REQUETE_SUPPRIMER_JEUX = "DELETE from JEUX WHERE code=@codeJeu";
        
        /// <summary>
        /// Requête d'ajout d'un jeu
        /// </summary>
        private string REQUETE_AJOUTER_JEU = "INSERT INTO [CatalogueMedias].[dbo].[JEUX] " + 
                                                       "([codeJeu]" + 
                                                       ",[synopsys]" + 
                                                       ",[codeDeveloppeur]" + 
                                                       ",[codeEditeur]" +
                                                       ",[codeMachine])" + 
                                                   "VALUES" + 
                                                       "(@codeJeu" + 
                                                       ",@synopsys" +
                                                       ",@codeDeveloppeur" +
                                                       ",@codeEditeur" +
                                                       ",@codeMachine)";

        /// <summary>
        /// REQUETE_AJOUTER_DEVELOPPEUR
        /// </summary>
        private string REQUETE_AJOUTER_DEVELOPPEUR = "INSERT INTO [CatalogueMedias].[dbo].[DEVELOPPEUR] " +
                                                       "([code]" +
                                                       ",[nom])" +
                                                   "VALUES" +
                                                       "(@code" +
                                                       ",@nom)";

        /// <summary>
        /// REQUETE_AJOUTER_EDITEUR
        /// </summary>
        private string REQUETE_AJOUTER_EDITEUR = "INSERT INTO [CatalogueMedias].[dbo].[EDITEUR] " +
                                                       "([code]" +
                                                       ",[nom])" +
                                                   "VALUES" +
                                                       "(@code" +
                                                       ",@nom)";


        ///// <summary>
        ///// Requête d'ajout d'un exemplaire
        ///// </summary>
        //private string REQUETE_AJOUTER_SOUHAIT = "INSERT INTO [CatalogueMedias].[dbo].[SOUHAIT_JEU]" +
        //                                                       "([codeProprietaire]" +
        //                                                       ",[codeJeu])" +
        //                                                 "VALUES" +
        //                                                       "(@codeProprietaire" +
        //                                                       ",@codeJeu)";

        /// <summary>
        /// Requête de modification d'un jeu
        /// </summary>
        private string REQUETE_MODIFICATION_JEU = "UPDATE JEUX SET " +
                                                    "codeMachine=@pCodeMachine, " +
                                                    "synopsys=@pSynopsys, " + 
                                                    "codeDeveloppeur=@pCodeDeveloppeur, " +
                                                    "codeEditeur=@pCodeEditeur, " +
                                                    "nbJoueurs=@pNbJoueurs " +
                                                    "where codeJeu=@pCodeJeu";


        /// <summary>
        /// ObtenirJeu
        /// </summary>
        /// <param name="pCode">code jeu</param>
        /// <returns>Le jeu trouvé en base</returns>
        public Jeu ObtenirJeu(Guid pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            Jeu leJeu = maDataSource.ExecuterRequete<Jeu>(REQUETE_OBTENIR_JEU, new JeuRowMapper(), false, pCode);

            return leJeu;

        }

        /// <summary>
        /// ObtenirListeJeux
        /// </summary>
        /// <returns>Liste jeux</returns>
        public List<Jeu> ObtenirListeJeux()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Jeu>(REQUETE_OBTENIR_LISTE_JEUX, new JeuRowMapper(), false, null);
        }


        /// <summary>
        /// ObtenirJeuComplet
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Jeu ObtenirJeuComplet(Guid pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            Jeu leJeu = maDataSource.ExecuterRequete<Jeu>(REQUETE_OBTENIR_JEU, new JeuRowMapper(), false, pCode);

            return leJeu;
        }
       
        /// <summary>
        /// ObtenirJeu
        /// </summary>
        /// <param name="pCode">code jeu</param>
        /// <returns>Le jeu trouvé en base</returns>
        public Jeu CreerJeuEtExemplaire(Jeu pJeu, Guid pCodeProprietaire, EtatMedia pEtat, DateTime dateAcquisition)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début CreerJeuEtExemplaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                pJeu.Code = Guid.NewGuid();

                //TODO : échec
                Jeu jeuExistant = maDataSource.ExecuterRequete<Jeu>(REQUETE_EXISTE_JEU, new JeuRowMapper(), false, pJeu.Titre, pJeu.LaMachine.Code);

                if (jeuExistant == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le jeu n'existe pas, on l'ajoute");

                    if (!String.IsNullOrEmpty(pJeu.Developpeur.Nom))
                    {
                        pJeu.Developpeur = CreerDeveloppeur(maDataSource, pJeu.Developpeur.Nom);
                    }
                    else
                    {
                        pJeu.Developpeur = new Developpeur();
                    }

                    if (!String.IsNullOrEmpty(pJeu.Editeur.Nom))
                    {
                        pJeu.Editeur = CreerEditeur(maDataSource, pJeu.Editeur.Nom);
                    }
                    else
                    {
                        pJeu.Editeur = new Editeur();
                    }

                    maDataSource.ExecuterDML(
                        REQUETE_AJOUTER_MEDIA, true,
                        pJeu.Code, Constantes.EnumTypeMedia.JEU, pJeu.Titre, pJeu.DateSortie, pJeu.Photo, pJeu.UrlFiche, pJeu.PEGI, pJeu.LeGenre.Code, pJeu.Note);


                    maDataSource.ExecuterDML(
                        REQUETE_AJOUTER_JEU, true, pJeu.Code, pJeu.Synopsys, pJeu.Developpeur.Code, pJeu.Editeur.Code, pJeu.LaMachine.Code);
                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le jeu existe déjà");

                    pJeu.Code = jeuExistant.Code;
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EXEMPLAIRE, true, pCodeProprietaire, pJeu.Code, pEtat.Code, null, DateTime.Now, dateAcquisition);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");

                return pJeu;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin CreerJeuEtExemplaire");
            }
        }

        /// <summary>
        /// CreerJeuEtSouhait
        /// </summary>
        /// <param name="pJeu">pJeu</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <returns></returns>
        public Jeu CreerJeuEtSouhait(Jeu pJeu, Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début CreerJeuEtSouhait");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                pJeu.Code = Guid.NewGuid();

                //TODO : échec
                Jeu jeuExistant = maDataSource.ExecuterRequete<Jeu>(REQUETE_EXISTE_JEU, new JeuRowMapper(), false, pJeu.Titre, pJeu.LaMachine.Code);

                if (jeuExistant == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le jeu n'existe pas, on l'ajoute");

                    if (!String.IsNullOrEmpty(pJeu.Developpeur.Nom))
                    {
                        pJeu.Developpeur = CreerDeveloppeur(maDataSource, pJeu.Developpeur.Nom);
                    }
                    else
                    {
                        pJeu.Developpeur = new Developpeur();
                    }

                    if (!String.IsNullOrEmpty(pJeu.Editeur.Nom))
                    {
                        pJeu.Editeur = CreerEditeur(maDataSource, pJeu.Editeur.Nom);
                    }
                    else
                    {
                        pJeu.Editeur = new Editeur();
                    }

                    maDataSource.ExecuterDML(REQUETE_AJOUTER_JEU, true, pJeu.Code, pJeu.Titre,
                        pJeu.LeGenre.Code, pJeu.DateSortie, pJeu.Synopsys, pJeu.Photo, pJeu.Developpeur.Code, pJeu.Editeur.Code, pJeu.LaMachine.Code, 1, pJeu.Note);

                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le jeu existe déjà");

                    pJeu.Code = jeuExistant.Code;
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SOUHAIT_ACHAT, true, pCodeProprietaire, pJeu.Code, null, DateTime.Now);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");

                return pJeu;
                
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin CreerJeuEtSouhait");
            }
        }

        /// <summary>
        /// CreerDeveloppeur
        /// </summary>
        /// <param name="pDataSource"></param>
        /// <param name="pNomDeveloppeur"></param>
        /// <returns></returns>
        private Developpeur CreerDeveloppeur(CustomDataSource pDataSource, string pNomDeveloppeur) 
        {
            Developpeur developpeur = null;

            if (!String.IsNullOrEmpty(pNomDeveloppeur))
            {
                Developpeur developpeurExistant = pDataSource.ExecuterRequete<Developpeur>(REQUETE_EXISTE_DEVELOPPEUR, new DeveloppeurRowMapper(), false, pNomDeveloppeur);

                //Création du développeur
                if (developpeurExistant == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le développeur n'existe pas, on l'ajoute");

                    developpeur = new Developpeur();
                    developpeur.Nom = pNomDeveloppeur;
                    developpeur.Code = Guid.NewGuid();
                    pDataSource.ExecuterDML(REQUETE_AJOUTER_DEVELOPPEUR, true, developpeur.Code, developpeur.Nom);
                }
                else
                {
                    developpeur = developpeurExistant;
                }
            }

            return developpeur;
        }

        /// <summary>
        /// CreerEditeur
        /// </summary>
        /// <param name="pDataSource"></param>
        /// <param name="pNomEditeur"></param>
        /// <returns></returns>
        public Editeur CreerEditeur(CustomDataSource pDataSource, string pNomEditeur)
        {
            Editeur editeur = null;

            if (!String.IsNullOrEmpty(pNomEditeur))
            {
                Editeur editeurExistant = pDataSource.ExecuterRequete<Editeur>(REQUETE_EXISTE_EDITEUR, new EditeurRowMapper(), false, pNomEditeur);

                //Création de l'éditeur
                if (editeurExistant == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "L'éditeur n'existe pas, on l'ajoute");

                    editeur = new Editeur();

                    editeur.Nom = pNomEditeur;
                    editeur.Code = Guid.NewGuid();
                    pDataSource.ExecuterDML(REQUETE_AJOUTER_EDITEUR, true, editeur.Code, editeur.Nom);
                }
                else
                {
                    editeur = editeurExistant;
                }
            }

            return editeur;
        }

        /// <summary>
        /// SupprimerJeu (et exemplaires associés)
        /// </summary>
        /// <param name="pCode">pCode</param>
        public void SupprimerJeu(Guid pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_SUPPRIMER_JEUX, false, pCode);
        }

        /// <summary>
        /// UpdateJeu
        /// </summary>
        /// <returns>int</returns>
        public int UpdateJeu(Jeu pJeu)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début UpdateJeu");

            int result = -1;
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                pJeu.Developpeur = CreerDeveloppeur(maDataSource, pJeu.Developpeur.Nom);
                pJeu.Editeur = CreerEditeur(maDataSource, pJeu.Editeur.Nom);

                result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_JEU, false, pJeu.LaMachine.Code,
                   pJeu.Synopsys, pJeu.Developpeur.Code, pJeu.Editeur.Code, pJeu.NbJoueurs, pJeu.Code);

                if (result == 1)
                {
                    result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_MEDIA, false, pJeu.Titre,
                        pJeu.LeGenre.Code, pJeu.DateSortie, pJeu.Photo, pJeu.UrlFiche, pJeu.PEGI, pJeu.Note, pJeu.Code);
                }

                if (result == 1)
                {
                    maDataSource.CommitGlobalTransaction();
                }
                else
                {
                    maDataSource.RollBackGlobalTransaction();
                }

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement du jeu OK");

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin UpdateJeu");
            }

            return result;
        }




    }
}
