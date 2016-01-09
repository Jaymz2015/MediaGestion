using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using Utilitaires;
using MediaGestion.Modele;
using MediaGestion.Modele.Dl.Dlo.Series;

namespace MediaGestion.DAO
{
    public class SerieDAO : MediaDAO
    {
        private static string KS_NOM_MODULE = "MediaGestion.DAO - SerieDAO - ";

        /// <summary>
        /// Requête de récupération de la liste des SERIEs
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_SERIES = "SELECT codeMedia, typeMedia, titre, dateSortie, photo, dateCreation, dateDerniereModification, " +
            " g.codeGenre, g.libelle, se.realisateur, se.acteurs, se.nbSaisons FROM MEDIA m, GENRE g, SERIE se WHERE m.codeGenre=g.codeGenre and se.codeSerie = m.codeMedia " + 
            " order by titre";

        /// <summary>
        /// Requête de récupération de la liste des saisons
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_SAISONS = "SELECT codeSaison, numeroSaison, codeSerie, annee, nbEpisodes from Saison where codeSerie=@pCodeSerie order by numeroSaison asc";

        /// <summary>
        /// Requête de récupération de la liste des SERIEs
        /// </summary>
        private string REQUETE_OBTENIR_SERIE = "SELECT codeMedia, typeMedia, titre, dateSortie, photo, url, PEGI, dateCreation, dateDerniereModification, " + 
            " g.codeGenre, g.libelle, se.synopsys, realisateur,acteurs, notePublic, se.format, se.nbSaisons, se.anneeDebut " + 
            " FROM MEDIA m, SERIE se, SAISON sa, GENRE g " + 
            " WHERE m.codeMedia=se.codeSerie and m.codeGenre=g.codeGenre and se.codeSerie=@codeSerie" +
            " order by titre";

        /// <summary>
        /// Requête de suppression d'un SERIE (cascade)
        /// </summary>
        private string REQUETE_SUPPRIMER_SERIE = "DELETE from SERIE WHERE code=@codeSerie";

        /// <summary>
        /// Requête d'ajout d'un SERIE
        /// </summary>
        private string REQUETE_AJOUTER_SERIE = "INSERT INTO [CatalogueMedias].[dbo].[SERIE] " + 
                                                       "([codeSerie]" + 
                                                       ",[duree]" + 
                                                       ",[synopsys]" + 
                                                       ",[realisateur]" + 
                                                       ",[acteurs])" +
                                                   "VALUES" + 
                                                       "(@code" + 
                                                       ",@duree" +
                                                       ",@synopsys" +
                                                       ",@realisateur" +
                                                       ",@acteurs)";


        /// <summary>
        /// Requête de modification d'un SERIE
        /// </summary>
        private string REQUETE_MODIFICATION_SERIE = "UPDATE SERIE SET " +
                                                    "nbSaisons=@nbSaisons, " +
                                                    "synopsys=@synopsys, " + 
                                                    "realisateur=@pRealisateur, " +
                                                    "acteurs=@pActeurs, " +
                                                    "anneeDebut=@pAnneeDebut, " +
                                                    "format=@pFormat " +
                                                    "where codeSerie=@pcodeSerie";


        /// <summary>
        /// Requête permettant de vérifier si une serie n'existe pas déjà
        /// </summary>
        private const string REQUETE_EXISTE_SERIE = "SELECT TOP 1 * from Media m, Serie se, GENRE g " +
                                                                        " WHERE m.codeGenre=g.codeGenre and m.codeMedia = se.codeSerie" +
                                                                        " AND m.titre=@pTitre " +
                                                                        " AND se.realisateur=@pRealisateur";


        /// <summary>
        /// Ajout d'une saison
        /// </summary>
        private const string REQUETE_AJOUTER_SAISON = "INSERT INTO [dbo].[SAISON] " +
                                                         "  ([codeSaison] " + 
                                                         "  ,[numeroSaison] " + 
                                                         "  ,[codeSerie] " + 
                                                         "  ,[annee] " + 
                                                         "  ,[nbEpisodes]) " + 
                                                   "  VALUES " + 
                                                    "       (@codeSaison " + 
                                                    "       ,@numeroSaison " + 
                                                    "       ,@codeSerie " +
                                                    "       ,@anneeSortie " + 
                                                    "       ,@nbEpisodes)";
                                



        /// <summary>
        /// Constructeur
        /// </summary>
        public SerieDAO() : base()
        {

        }

        /// <summary>
        /// ObtenirListeSeries
        /// </summary>
        /// <returns>Liste series</returns>
        public List<Serie> ObtenirListeSeries()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Serie>(REQUETE_OBTENIR_LISTE_SERIES, new SerieRowMapper(), false, null);
        }


        ///// <summary>
        ///// ObtenirSERIE
        ///// </summary>
        ///// <param name="pCode">code SERIE</param>
        ///// <returns>La serie trouvé en base</returns>
        //public Serie ObtenirSerie(Guid pCode)
        //{
        //    CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

        //    Serie laSerie = maDataSource.ExecuterRequete<Serie>(REQUETE_OBTENIR_SERIE, new SerieRowMapper(), false, pCode);

        //    return laSerie;

        //}


        /// <summary>
        /// ObtenirSERIE
        /// </summary>
        /// <param name="pCode">code SERIE</param>
        /// <returns>La serie trouvé en base</returns>
        public Serie ObtenirSerieComplete(Guid pCode)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ObtenirSerieComplete : pCode=" + pCode.ToString());

            Serie laSerie = null;
            try
            {
                CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

                laSerie = maDataSource.ExecuterRequete<Serie>(REQUETE_OBTENIR_SERIE, new SerieRowMapper(), false, pCode);

                List<Saison> listeSaisons = maDataSource.ExecuterRequeteList<Saison>(REQUETE_OBTENIR_LISTE_SAISONS, new SaisonRowMapper(), false, pCode);

                laSerie.ListeSaisons = listeSaisons;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                
                throw ex;
            }

            return laSerie;
        }

       

        /// <summary>
        /// ObtenirSERIE
        /// </summary>
        /// <param name="pCode">code SERIE</param>
        /// <returns>La serie trouvé en base</returns>
        public Serie CreerSerieEtExemplaire(Serie pSerie, string pCodeSupport, Guid pCodeProprietaire, DateTime pDateAcquisition, int pEtat)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début CreerSerieEtExemplaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                if (pSerie.Code.Equals(Guid.Empty)) {
                    pSerie.Code = Guid.NewGuid();
                }

                Serie SerieExistantee = maDataSource.ExecuterRequete<Serie>(REQUETE_EXISTE_SERIE, new SerieRowMapper(), false, pSerie.Titre, pSerie.Realisateur);

                if (SerieExistantee == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "La serie n'existe pas, on l'ajoute");

                    maDataSource.ExecuterDML(
                        REQUETE_AJOUTER_MEDIA, true,
                        pSerie.Code, Constantes.EnumTypeMedia.SERIE, pSerie.Titre, pSerie.DateSortie, pSerie.Photo, pSerie.UrlFiche, pSerie.PEGI, pSerie.LeGenre.Code, pSerie.Note);


                    maDataSource.ExecuterDML(
                        REQUETE_AJOUTER_SERIE, true, pSerie.Code, pSerie.NbSaisons, pSerie.Synopsys, pSerie.Realisateur, pSerie.Acteurs);

                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "La serie existe déjà");

                    pSerie.Code = SerieExistantee.Code;                   
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EXEMPLAIRE, true, pCodeProprietaire, pSerie.Code, pEtat, pCodeSupport, DateTime.Now, pDateAcquisition);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");


                return pSerie;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin CreerSerieEtExemplaire");
            }
        }

        /// <summary>
        /// CreerSerieEtSouhait
        /// </summary>
        /// <param name="pSerie">pSerie</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <returns></returns>
        public Serie CreerSerieEtSouhait(Serie pSerie, string pCodeSupport, Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début CreerSerieEtSouhait");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                pSerie.Code = Guid.NewGuid();

                Serie SerieExistante = maDataSource.ExecuterRequete<Serie>(REQUETE_EXISTE_SERIE, new SerieRowMapper(), false, pSerie.Titre, pSerie.Realisateur);

                if (SerieExistante == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "La serie n'existe pas, on l'ajoute");

                    maDataSource.ExecuterDML(REQUETE_AJOUTER_SERIE, true, pSerie.Code, pSerie.Titre, pSerie.NbSaisons,
                    pSerie.LeGenre.Code, pSerie.DateSortie, pSerie.Synopsys, pSerie.Photo, pSerie.Realisateur,
                    pSerie.Acteurs, 1, pSerie.Note, pSerie.UrlFiche);

                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "La serie existe déjà");

                    pSerie.Code = SerieExistante.Code;
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SOUHAIT_ACHAT, true, pCodeProprietaire, pSerie.Code, pCodeSupport);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement du souhait OK");

                return pSerie;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin CreerSerieEtSouhait");
            }
        }

        /// <summary>
        /// UpdateSerie
        /// </summary>
        /// <param name="f">Serie</param>
        /// <returns></returns>
        public int UpdateSerie(Serie se)
        {
            int result = -1;
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {               
                maDataSource.StartGlobalTransaction();

                result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_SERIE, false, se.NbSaisons,
                   se.Synopsys, se.Realisateur, se.Acteurs, se.AnneeDebut, se.Format, se.Code);

                if (result == 1)
                {
                    result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_MEDIA, false, se.Titre,
                        se.LeGenre.Code, se.DateSortie, se.Photo, se.UrlFiche, se.PEGI, se.Note, se.Code);
                }

                if (result == 1)
                {
                    maDataSource.CommitGlobalTransaction();
                }
                else
                {
                    maDataSource.RollBackGlobalTransaction();
                }

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de la SERIE OK");

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin UpdateSerie");
            }

            return result;
        }


        /// <summary>
        /// AjouterSaison
        /// </summary>
        /// <param name="pCodeSerie"></param>
        /// <param name="pSaison"></param>
        /// <returns></returns>
        public bool AjouterSaison(Guid pCodeSerie, Saison pSaison)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterSaison");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SAISON, true, pSaison.CodeSaison, pSaison.Numero, pCodeSerie, pSaison.AnneeSortie, pSaison.NbEpisodes);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");

                return true;


            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin AjouterSaison");
            }


        }

        
    }
}
