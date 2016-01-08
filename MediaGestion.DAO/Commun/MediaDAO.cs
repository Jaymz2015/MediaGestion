using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using Utilitaires;
using MediaGestion.Modele;

namespace MediaGestion.DAO
{
    public class MediaDAO
    {
        private static string KS_NOM_MODULE = "MediaGestion.DAO - MediaDAO - ";

        /// <summary>
        /// Requête de récupération de la liste des medias
        /// </summary>
        protected string REQUETE_OBTENIR_LISTE_MEDIAS = "SELECT codeMedia, typeMedia, titre, dateSortie, photo, url, PEGI, dateCreation, dateDerniereModification, " + 
            " g.codeGenre, g.libelle FROM MEDIA m, GENRE g WHERE typeMedia=@typeMedia and m.codeGenre=g.codeGenre order by titre";

        /// <summary>
        /// Requête de récupération d'un media
        /// </summary>
        protected string REQUETE_OBTENIR_MEDIA = "SELECT codeMedia, typeMedia, titre, dateSortie, photo, url, PEGI, dateCreation, dateDerniereModification, " +
            " g.codeGenre, g.libelle FROM MEDIA m, GENRE g WHERE codeMedia=@codeMedia and m.codeGenre=g.codeGenre";

        /// <summary>
        /// Requête de suppression d'un film (cascade)
        /// </summary>
        protected string REQUETE_SUPPRIMER_MEDIA = "DELETE from MEDIA WHERE codeMedia=@codeMedia";

        /// <summary>
        /// Requête de suppression d'un exemplaire
        /// </summary>
        protected string REQUETE_SUPPRIMER_EXEMPLAIRE = "DELETE from EXEMPLAIRE WHERE codeExemplaire=@codeExemplaire";

        /// <summary>
        /// Requête de suppression d'un souhait
        /// </summary>
        protected string REQUETE_SUPPRIMER_SOUHAIT_ACHAT = "DELETE from SOUHAIT_ACHAT WHERE codeSouhait=@codeSouhait";

        /// <summary>
        /// Requête de récupération de la liste des exemplaires d'un media
        /// </summary>
        protected string REQUETE_OBTENIR_LISTE_EXEMPLAIRES_MEDIA = "select m.titre, m.typeMedia, m.photo, g.codeGenre, g.libelle libelleGenre, ex.codeExemplaire, codeProprietaire,p.nom,p.prenom,m.codeMedia,codeSupport,s.libelle as libelleSupport, estCopie," +
            " etat,et.libelle as libelleEtat,dateAcquisition,dateEnregistrement,p.nom,p.prenom, ma.code codeMachine, ma.nom nomMachine, " +
            " emp.codeEmprunt, emp.codeEmprunteur codeEmprunteur, emp.nom nomEmprunteur, emp.prenom prenomEmprunteur, emp.datePrete, case when emp.datePrete is not null and emp.dateRendu is null then 0 else 1 end as dispo " +
            " from EXEMPLAIRE ex " +
            " left outer join MEDIA m on ex.codeMedia = m.codeMedia left outer join GENRE g on g.codeGenre = m.codeGenre " +
            " left outer join ETAT_MEDIA et on ex.etat = et.code " +
            " left outer join PROPRIETAIRE p on codeProprietaire = p.code " + 
            " left outer join SUPPORT s on s.code = codeSupport " +
            " LEFT OUTER JOIN EMPRUNT emp on emp.codeExemplaire = ex.codeExemplaire and emp.dateRendu is null " +
            " left outer join JEUX j on j.codeJeu = m.codeMedia " +
            " left outer join MACHINES ma on ma.code = j.codeMachine " +
            " where ex.codeMedia=@codeMedia";


        /// <summary>
        /// Requête de récupération d'un exemplaire
        /// </summary>
        protected string REQUETE_OBTENIR_EXEMPLAIRE = "select m.codeMedia, m.titre, m.typeMedia, m.photo, g.codeGenre, g.libelle libelleGenre, ex.codeExemplaire, codeProprietaire, p.nom, p.prenom, codeSupport, s.libelle as libelleSupport, estCopie," +
            " etat,et.libelle as libelleEtat,dateAcquisition,dateEnregistrement,p.nom,p.prenom, ma.code codeMachine, ma.nom nomMachine, " +
            " emp.codeEmprunt, emp.codeEmprunteur codeEmprunteur, emp.nom nomEmprunteur, emp.prenom prenomEmprunteur, emp.datePrete, case when emp.datePrete is not null and emp.dateRendu is null then 0 else 1 end as dispo " +
            " from EXEMPLAIRE ex " +
            " left outer join MEDIA m on ex.codeMedia = m.codeMedia left outer join GENRE g on g.codeGenre = m.codeGenre " +
            " left outer join ETAT_MEDIA et on ex.etat = et.code " +
            " left outer join PROPRIETAIRE p on codeProprietaire = p.code " + 
            " left outer join SUPPORT s on s.code = codeSupport " +
            " LEFT OUTER JOIN EMPRUNT emp on emp.codeExemplaire = ex.codeExemplaire and emp.dateRendu is null " +
            " left outer join JEUX j on j.codeJeu = m.codeMedia " +
            " left outer join MACHINES ma on ma.code = j.codeMachine " +
            " where ex.codeExemplaire=@codeExemplaire";

        /// <summary>
        /// Requête de récupération d'un souhait
        /// </summary>
        protected string REQUETE_OBTENIR_SOUHAIT_ACHAT = "select so.codeSouhait codeExemplaire, codeProprietaire,p.nom,p.prenom,m.codeMedia,m.titre, m.typeMedia, m.photo, " +
            " codeSupport, s.libelle as libelleSupport, dateEnregistrement, g.codeGenre, g.libelle libelleGenre, ma.code codeMachine, ma.nom nomMachine " +
            " from SOUHAIT_ACHAT so " +
            " left outer join MEDIA m on m.codeMedia = so.codeMedia left outer join GENRE g on g.codeGenre = m.codeGenre " +
            " left outer join PROPRIETAIRE p on codeProprietaire = p.code " + 
            " left outer join SUPPORT s on s.code = codeSupport " +
            " left outer join JEUX j on j.codeJeu = m.codeMedia " +
            " left outer join MACHINES ma on ma.code = j.codeMachine " +
            " where so.codeSouhait=@codeSouhait";

        /// <summary>
        /// Requête de récupération de la liste des souhaits pour un film
        /// </summary>
        protected string REQUETE_OBTENIR_LISTE_SOUHAITS_MEDIA = "select codeSouhait codeExemplaire, m.codeMedia, m.titre, m.typeMedia, m.photo, " +
            " codeProprietaire,p.nom,p.prenom, codeSupport, g.codeGenre, g.libelle libelleGenre, s.libelle as libelleSupport, p.nom,p.prenom, ma.code codeMachine, ma.nom nomMachine " +
            " from SOUHAIT_ACHAT so " +
            " left outer join MEDIA m on m.codeMedia = so.codeMedia left outer join GENRE g on g.codeGenre = m.codeGenre " +
            " left outer join PROPRIETAIRE p on so.codeProprietaire = p.code " + 
            " left outer join SUPPORT s on s.code = codeSupport " +
            " left outer join JEUX j on j.codeJeu = m.codeMedia " +
            " left outer join MACHINES ma on ma.code = j.codeMachine " +
            " where so.codeMedia=@codeMedia";

        /// <summary>
        /// Requête de récupération de la liste des souhaits d'un propriétaire
        /// </summary>
        protected string REQUETE_OBTENIR_LISTE_SOUHAITS_FILMS_PROPRIETAIRE = "select m.codeMedia codeMedia, m.typeMedia, so.codeSouhait codeExemplaire, m.titre, m.codeGenre codeGenre, " +
                                                                        " g.libelle libelleGenre, g.media, m.photo photo, p.code codeProprietaire, p.nom nom, " +
                                                                        " p.prenom prenom, s.code codeSupport, s.libelle libelleSupport, " +
                                                                        " p2.nom + ' ' + p2.prenom + ' ' + s2.libelle as exemplaire_existant  " +
                                                                        " from SOUHAIT_ACHAT so " +
                                                                        " left outer join MEDIA m on so.codeMedia = m.codeMedia " +
                                                                        " 	left outer join EXEMPLAIRE ex on m.codeMedia = ex.codeMedia " +
                                                                        " 	left outer join SUPPORT s2 on ex.codeSupport = s2.code " +
                                                                        " 	left outer join PROPRIETAIRE p2 on ex.codeProprietaire = p2.code " +
                                                                        " left outer join PROPRIETAIRE p on so.codeProprietaire = p.code " +
                                                                        " left outer join SUPPORT s on so.codeSupport = s.code " +
                                                                        " left outer join GENRE g on g.codeGenre = m.codeGenre " +
                                                                        " where p.code = @codeProprietaire and typeMedia=1 " +
                                                                        " order by titre";

        /// <summary>
        /// Requête de récupération de la liste des souhaits d'un propriétaire
        /// </summary>
        protected string REQUETE_OBTENIR_LISTE_SOUHAITS_JEUX_PROPRIETAIRE = "select m.codeMedia codeMedia, m.typeMedia, so.codeSouhait codeExemplaire, m.titre, m.codeGenre codeGenre, " +
                                                                        " g.libelle libelleGenre, g.media, m.photo photo, p.code codeProprietaire, p.nom nom, " +
                                                                        " p.prenom prenom, ma.code codeMachine, ma.nom nomMachine, " +
                                                                        " p2.nom + ' ' + p2.prenom + ' ' + s2.libelle as exemplaire_existant  " +
                                                                        " from SOUHAIT_ACHAT so " +
                                                                        " left outer join MEDIA m on so.codeMedia = m.codeMedia " +
                                                                        " 	left outer join EXEMPLAIRE ex on m.codeMedia = ex.codeMedia " +
                                                                        " 	left outer join SUPPORT s2 on ex.codeSupport = s2.code " +
                                                                        " 	left outer join PROPRIETAIRE p2 on ex.codeProprietaire = p2.code " +
                                                                        " left outer join PROPRIETAIRE p on so.codeProprietaire = p.code " +
                                                                        " left outer join GENRE g on g.codeGenre = m.codeGenre " +
                                                                        " left outer join JEUX j on j.codeJeu = m.codeMedia " +
                                                                        " left outer join MACHINES ma on ma.code = j.codeMachine " +
                                                                        " where p.code = @codeProprietaire  and typeMedia=2" +
                                                                        " order by titre";

        /// <summary>
        /// Requête de récupération de la liste des prets d'un propriétaire
        /// </summary>
        protected string REQUETE_OBTENIR_LISTE_PRETS_PROPRIETAIRE = "select emp.codeEmprunteur, emp.nom nomEmprunteur, emp.prenom prenomEmprunteur, emp.datePrete datePrete, emp.dateRendu dateRendu, " +
                                                                " m.codeMedia codeMedia, m.typeMedia, m.titre, m.photo photo, p.code codeProprietaire, p.nom nom, p.prenom prenom, s.code codeSupport, s.libelle libelleSupport " +
                                                                "from EMPRUNT emp, EXEMPLAIRE ex, PROPRIETAIRE p, MEDIA m, SUPPORT s " +
                                                                "where emp.codeExemplaire = ex.codeExemplaire " +
                                                                "and ex.codeMedia = m.codeMedia " +
                                                                "and ex.codeProprietaire = p.code " +
                                                                "and ex.codeSupport = s.code " +
                                                                "and p.code = @codeProprietaire " +
                                                                " order by typeMedia, titre";

        /// <summary>
        /// Requête de récupération de la liste des emprunts d'un propriétaire
        /// </summary>
        protected string REQUETE_OBTENIR_LISTE_EMPRUNTS_PROPRIETAIRE = "select emp.codeEmprunteur, emp.nom nomEmprunteur, emp.prenom prenomEmprunteur, emp.datePrete datePrete, emp.dateRendu dateRendu, " +
                                                                " m.codeMedia codeMedia, m.typeMedia, m.titre, m.photo photo, p.code codeProprietaire, p.nom nom, p.prenom prenom, s.code codeSupport, s.libelle libelleSupport " +
                                                                "from EMPRUNT emp, EXEMPLAIRE ex, PROPRIETAIRE p, MEDIA m, SUPPORT s " +
                                                                "where emp.codeExemplaire = ex.codeExemplaire " +
                                                                "and ex.codeMedia = m.codeMedia " +
                                                                "and ex.codeProprietaire = p.code " +
                                                                "and ex.codeSupport = s.code " +
                                                                "and emp.codeEmprunteur = @codeProprietaire " +
                                                                " order by typeMedia, titre";

        /// <summary>
        /// Requête d'ajout d'un exemplaire
        /// </summary>
        protected string REQUETE_AJOUTER_EXEMPLAIRE = "INSERT INTO [CatalogueMedias].[dbo].[EXEMPLAIRE]" +
                                                               "([codeExemplaire]" + 
                                                               ",[codeProprietaire]" +
                                                               ",[codeMedia]" +
                                                               ",[etat]" +
                                                               ",[codeSupport]" +
                                                               ",[dateEnregistrement]" +
                                                               ",[dateAcquisition])" +
                                                         "VALUES" +
                                                               "(NEWID()" + 
                                                               ",@codeProprietaire" +
                                                               ",@codeMedia" +
                                                               ",@codeEtat" +
                                                               ",@codeSupport" +
                                                               ",@dateEnregistrement" +
                                                               ",@dateAcquisition)";

        /// <summary>
        /// Requête de modification d'un exemplaire
        /// </summary>
        protected string REQUETE_MODIFIER_EXEMPLAIRE = "UPDATE [CatalogueMedias].[dbo].[EXEMPLAIRE] " +
                                                        " SET etat=@pEtatMedia, codeSupport=@pCodeSupport, dateAcquisition=@dateAcquisition " +
                                                        " WHERE codeExemplaire=@pCodeExemplaire";

        /// <summary>
        /// Requête d'ajout d'un exemplaire
        /// </summary>
        protected string REQUETE_AJOUTER_SOUHAIT_ACHAT = "INSERT INTO [CatalogueMedias].[dbo].[SOUHAIT_ACHAT]" +
                                                               "([codeSouhait]" +
                                                               ",[codeProprietaire]" +
                                                               ",[codeMedia]" +
                                                               ",[codeSupport]" +
                                                               ",[dateEnregistrement])" +
                                                         "VALUES" +
                                                               "(NEWID()" +
                                                               ",@codeProprietaire" +
                                                               ",@codeMedia" +
                                                               ",@codeSupport" +
                                                               ",@dateEnregistrement)";
        // <summary>
        /// Requête d'ajout d'un emprunt
        /// </summary>
        protected string REQUETE_AJOUTER_EMPRUNT = "INSERT INTO [CatalogueMedias].[dbo].[EMPRUNT]" +
                                                               "([codeEmprunt]" +
                                                               ",[codeExemplaire]" +
                                                               ",[codeEmprunteur]" +
                                                               ",[nom]" +
                                                               ",[prenom]" +
                                                               ",[datePrete])" +
                                                         "VALUES" +
                                                               "(NEWID()" +
                                                               ",@pCodeExemplaire" +
                                                               ",@pCodeEmprunteur" +
                                                               ",@pNom" +
                                                               ",@pPrenom" +
                                                               ",@pDatePrete)";

        /// <summary>
        /// Requête de modification d'un emprunt
        /// </summary>
        protected string REQUETE_CLORE_EMPRUNT = "UPDATE [CatalogueMedias].[dbo].[EMPRUNT] SET " +
                                                    "dateRendu=@pDateRendu " +
                                                    "where codeEmprunt=@pCodeEmprunt " +
                                                    "and dateRendu is null";


        /// <summary>
        /// Requête de modification d'un media
        /// </summary>
        protected string REQUETE_MODIFICATION_MEDIA = "UPDATE MEDIA SET " +
                                                    "titre=@titre, " +
                                                    "codeGenre=@codeGenre, " +
                                                    "dateSortie=@dateSortie, " +
                                                    "photo=@photo, " +
                                                    "url=@url, " +
                                                    "PEGI=@PEGI, " +
                                                    "notePublic=@notePublic, " +
                                                    "dateDerniereModification=GETDATE() " +
                                                    "where codeMedia=@pCodeMedia";

        /// <summary>
        /// Requête d'ajout d'un film
        /// </summary>
        protected string REQUETE_AJOUTER_MEDIA = "INSERT INTO [CatalogueMedias].[dbo].[MEDIA] " +
                                                       "([codeMedia]" +
                                                       ",[typeMedia]" +
                                                       ",[titre]" +
                                                       ",[dateSortie]" +
                                                       ",[photo]" +
                                                       ",[url]" +
                                                       ",[PEGI]" +
                                                       ",[codeGenre]" +
                                                       ",[notePublic]" +
                                                       ",[dateCreation])" +
                                                   "VALUES" +
                                                       "(@code" +
                                                       ",@typeMedia" +
                                                       ",@titre" +
                                                       ",@dateSortie" +
                                                       ",@photo" +
                                                       ",@url" +
                                                       ",@PEGI" +
                                                       ",@codeGenre" +
                                                       ",@notePublic" +
                                                       ",GETDATE())";

        public MediaDAO()
        {

        }
        
        
        /// <summary>
        /// ObtenirListeMedias
        /// </summary>
        /// <param name="typeMedia">typeMedia</param>
        /// <returns>Liste medias</returns>
        public List<Media> ObtenirListeMedias(Constantes.EnumTypeMedia typeMedia)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Media>(REQUETE_OBTENIR_LISTE_MEDIAS, new MediaRowMapper(), false, typeMedia);
        }

        /// <summary>
        /// ObtenirListeMedias
        /// </summary>
        /// <param name="typeMedia">typeMedia</param>
        /// <returns>Liste medias</returns>
        public Media ObtenirMedia(Guid pCodeMedia)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequete<Media>(REQUETE_OBTENIR_MEDIA, new MediaRowMapper(), false, pCodeMedia);
        }

        /// <summary>
        /// ObtenirListeExemplairesMedia
        /// </summary>
        /// <param name="codeMedia">codeMedia</param>
        /// <returns>List<Exemplaire></returns>
        public List<Exemplaire> ObtenirListeExemplairesMedia(Guid codeMedia)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_EXEMPLAIRES_MEDIA, new ExemplaireRowMapper(), false, codeMedia);
        }

        /// <summary>
        /// ObtenirExemplaire
        /// </summary>
        /// <param name="codeExemplaire">codeExemplaire</param>
        /// <returns>Exemplaire</returns>
        public Exemplaire ObtenirExemplaire(Guid codeExemplaire)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequete<Exemplaire>(REQUETE_OBTENIR_EXEMPLAIRE, new ExemplaireRowMapper(), false, codeExemplaire);
        }

        /// <summary>
        /// ObtenirSouhait
        /// </summary>
        /// <param name="codeSouhait">codeSouhait</param>
        /// <returns>Exemplaire</returns>
        public Exemplaire ObtenirSouhaitAchat(Guid codeSouhait)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequete<Exemplaire>(REQUETE_OBTENIR_SOUHAIT_ACHAT, new ExemplaireRowMapper(), false, codeSouhait);
        }

        /// <summary>
        /// ObtenirListeSouhaitsMedia
        /// </summary>
        /// <param name="codeMedia">codeMedia</param>
        /// <returns>List<Exemplaire></returns>
        public List<Exemplaire> ObtenirListeSouhaitsMedia(Guid codeMedia)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_SOUHAITS_MEDIA, new ExemplaireRowMapper(), false, codeMedia);
        }


        /// <summary>
        /// AjouterExemplaire
        /// </summary>
        /// <param name="pCodeJeu"></param>
        /// <param name="pCodeProprietaire"></param>
        public void AjouterExemplaire(Guid pCodeMedia, Guid pCodeProprietaire, int pEtat, string pCodeSupport, DateTime dateAcquisition)
        {

            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterExemplaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EXEMPLAIRE, true, pCodeProprietaire, pCodeMedia, pEtat, pCodeSupport, DateTime.Now, dateAcquisition);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin AjouterExemplaire");
            }
        }

        /// <summary>
        /// AjouterSouhaitAchat
        /// </summary>
        /// <param name="pCodeFilm">pCodeFilm</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        public void AjouterSouhaitAchat(Guid pCodeMedia, Guid pCodeProprietaire, string pCodeSupport)
        {

            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterSouhait");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SOUHAIT_ACHAT, true, pCodeProprietaire, pCodeMedia, pCodeSupport, DateTime.Now);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin AjouterSouhait");
            }
        }


        /// <summary>
        /// ListeSouhaitsFilmsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        /// <returns></returns>
        public List<Exemplaire> ListeSouhaitsAchatFilmsProprietaire(Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ListeSouhaitsFilmsProprietaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                List<Exemplaire> listeSouhaitsFilms = maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_SOUHAITS_FILMS_PROPRIETAIRE, new ExemplaireRowMapper(), false, pCodeProprietaire);

                maDataSource.CommitGlobalTransaction();

                return listeSouhaitsFilms;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ListeSouhaitsFilmsProprietaire");
            }
        }

        /// <summary>
        /// ListeSouhaitsFilmsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        /// <returns></returns>
        public List<Exemplaire> ListeSouhaitsAchatJeuxProprietaire(Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ListeSouhaitsFilmsProprietaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                List<Exemplaire> listeSouhaitsJeux = maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_SOUHAITS_JEUX_PROPRIETAIRE, new ExemplaireRowMapper(), false, pCodeProprietaire);

                maDataSource.CommitGlobalTransaction();

                return listeSouhaitsJeux;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ListeSouhaitsFilmsProprietaire");
            }
        }

        /// <summary>
        /// ListePretsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        /// <returns></returns>
        public List<Emprunt> ListePretsProprietaire(Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ListePretsProprietaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                List<Emprunt> listeEmprunts = maDataSource.ExecuterRequeteList<Emprunt>(REQUETE_OBTENIR_LISTE_PRETS_PROPRIETAIRE, new EmpruntRowMapper(), false, pCodeProprietaire);

                maDataSource.CommitGlobalTransaction();

                return listeEmprunts;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ListePretsProprietaire");
            }
        }

        /// <summary>
        /// ListeEmpruntsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        /// <returns>Liste emprunts</returns>
        public List<Emprunt> ListeEmpruntsProprietaire(Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ListeEmpruntsProprietaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                List<Emprunt> listeEmprunts = maDataSource.ExecuterRequeteList<Emprunt>(REQUETE_OBTENIR_LISTE_EMPRUNTS_PROPRIETAIRE, new EmpruntRowMapper(), false, pCodeProprietaire);

                maDataSource.CommitGlobalTransaction();

                return listeEmprunts;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ListeEmpruntsProprietaire");
            }
        }
        


        /// <summary>
        /// SupprimerMedia
        /// </summary>
        /// <param name="pCode">pCodeMedia</param>
        /// <returns>int</returns>
        public int SupprimerMedia(Guid pCodeMedia)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début SupprimerMedia");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);
            int result = -1;
            try
            {
                //Suppression en cascade
                result = maDataSource.ExecuterDML(REQUETE_SUPPRIMER_MEDIA, false, pCodeMedia);

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin SupprimerMedia");
            }

            return result;
        }


        /// <summary>
        /// SupprimerExemplaire
        /// </summary>
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pCodeSupport"></param>
        public void SupprimerExemplaire(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_SUPPRIMER_EXEMPLAIRE, false, pCodeFilm, pCodeProprietaire, pCodeSupport);
        }

        /// <summary>
        /// ModifierExemplaire
        /// </summary>
        /// <param name="pCodeExemplaire">pCodeExemplaire</param>
        /// <param name="pEtatMedia">pEtatMedia</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        /// <param name="dateAcquisition">dateAcquisition</param>
        public void ModifierExemplaire(Guid pCodeExemplaire, String pCodeSupport, int pEtatMedia, DateTime dateAcquisition)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ModifierExemplaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                int result = maDataSource.ExecuterDML(REQUETE_MODIFIER_EXEMPLAIRE, true, pEtatMedia, pCodeSupport, dateAcquisition, pCodeExemplaire);

                maDataSource.CommitGlobalTransaction();

                if (result == 1)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");
                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Pas de mise à jour effectuée");
                }
                
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ModifierExemplaire");
            }
        }

        /// <summary>
        /// SupprimerSouhait
        /// </summary>
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pCodeSupport"></param>
        public void SupprimerSouhait(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_SUPPRIMER_SOUHAIT_ACHAT, false, pCodeFilm, pCodeProprietaire, pCodeSupport);
        }

        /// <summary>
        /// AjouterEmprunt
        /// </summary>
        /// <param name="pCodeExemplaire"></param>
        /// <param name="pEmprunteur"></param>
        public void AjouterEmprunt(Guid pCodeExemplaire, Emprunteur pEmprunteur)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterEmprunt");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                Guid codeEmprunteur;

                if (pEmprunteur.Code == null || pEmprunteur.Code.Equals(Guid.Empty))
                {
                    codeEmprunteur = Guid.Empty;
                }
                else
                {
                    codeEmprunteur = pEmprunteur.Code;

                    ProprietaireDAO proprietaireDAO = new ProprietaireDAO();
                    Proprietaire p = proprietaireDAO.ObtenirListeProprietaires().Find(item => item.Code == codeEmprunteur);
                    pEmprunteur.Nom = p.Nom;
                    pEmprunteur.Prenom = p.Prenom;
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EMPRUNT, true, pCodeExemplaire, codeEmprunteur, pEmprunteur.Nom, pEmprunteur.Prenom, DateTime.Now);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'emprunt OK");

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin AjouterEmprunt");
            }
        }

        /// <summary>
        /// UpdateEmprunt
        /// </summary>
        /// <param name="pCodeEmprunt"></param>
        /// <returns></returns>
        public int UpdateEmprunt(Guid pCodeEmprunt)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_CLORE_EMPRUNT, false, DateTime.Now, pCodeEmprunt);
        }

        /// <summary>
        /// SupprimerExemplaire
        /// </summary>
        /// <param name="pCodeExemplaire">pCodeExemplaire</param>
        public void SupprimerExemplaire(Guid pCodeExemplaire)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_SUPPRIMER_EXEMPLAIRE, false, pCodeExemplaire);
        }


        /// <summary>
        /// SupprimerSouhait
        /// </summary>
        /// <param name="pCodeSouhait"></param>
        public void SupprimerSouhaitAchat(Guid pCodeSouhait)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_SUPPRIMER_SOUHAIT_ACHAT, false, pCodeSouhait);
        }


        /// <summary>
        /// AjouterSouhait
        /// </summary>
        /// <param name="pCodeFilm">pCodeMedia</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        public void AjouterSouhaitAchat(Guid pCodeMedia, string pCodeSupport, Guid pCodeProprietaire)
        {

            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterSouhait");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SOUHAIT_ACHAT, true, pCodeProprietaire, pCodeMedia, pCodeSupport);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin AjouterSouhait");
            }
        }
    }
}
