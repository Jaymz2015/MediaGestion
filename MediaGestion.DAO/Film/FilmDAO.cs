using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using Utilitaires;
using MediaGestion.Modele;

namespace MediaGestion.DAO
{
    public class FilmDAO : MediaDAO
    {
        private static string KS_NOM_MODULE = "MediaGestion.DAO - FilmDAO - ";

        /// <summary>
        /// Requête de récupération de la liste des films
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_FILMS = "SELECT codeMedia, typeMedia, titre, dateSortie, photo, dateCreation, dateDerniereModification, " +
            " g.codeGenre, g.libelle, f.realisateur, f.acteurs FROM MEDIA m, GENRE g, FILM f WHERE m.codeGenre=g.codeGenre and f.codeFilm = m.codeMedia order by titre";

        /// <summary>
        /// Requête permettant de vérifier si un film n'existe pas déjà
        /// </summary>
        protected string REQUETE_EXISTE_FILM = "SELECT TOP 1 * from Media m, Film f, GENRE g " +
                                                                        " WHERE m.codeGenre=g.codeGenre and m.codeMedia = f.codeFilm" +
                                                                        " AND m.titre=@pTitre " +
                                                                        " AND f.realisateur=@pRealisateur";

        /// <summary>
        /// Requête de récupération de la liste des films
        /// </summary>
        private string REQUETE_OBTENIR_FILM = "SELECT codeMedia, typeMedia, titre, dateSortie, photo, url, PEGI, dateCreation, dateDerniereModification, " + 
            " duree, g.codeGenre, g.libelle, synopsys, realisateur,acteurs,notePublic " + 
            " FROM MEDIA m, FILM f, GENRE g " + 
            " WHERE m.codeMedia=f.codeFilm and m.codeGenre=g.codeGenre and f.codeFilm=@codeFilm order by titre";

        /// <summary>
        /// Requête de suppression d'un film (cascade)
        /// </summary>
        private string REQUETE_SUPPRIMER_FILM = "DELETE from FILM WHERE code=@codeFilm";

        /// <summary>
        /// Requête d'ajout d'un film
        /// </summary>
        private string REQUETE_AJOUTER_FILM = "INSERT INTO [CatalogueMedias].[dbo].[FILM] " + 
                                                       "([codeFilm]" + 
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
        /// Requête de modification d'un film
        /// </summary>
        private string REQUETE_MODIFICATION_FILM = "UPDATE FILM SET " +
                                                    "duree=@duree, " +
                                                    "synopsys=@synopsys, " + 
                                                    "realisateur=@pRealisateur, " +
                                                    "acteurs=@pActeurs " +
                                                    "where codeFilm=@pCodeFilm";


        /// <summary>
        /// Constructeur
        /// </summary>
        public FilmDAO() : base()
        {

        }

        /// <summary>
        /// ObtenirListeFilms
        /// </summary>
        /// <returns>Liste films</returns>
        public List<Film> ObtenirListeFilms()
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterRequeteList<Film>(REQUETE_OBTENIR_LISTE_FILMS, new FilmRowMapper(), false, null);
        }


        /// <summary>
        /// ObtenirFilm
        /// </summary>
        /// <param name="pCode">code film</param>
        /// <returns>Le film trouvé en base</returns>
        public Film ObtenirFilm(Guid pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            Film leFilm = maDataSource.ExecuterRequete<Film>(REQUETE_OBTENIR_FILM, new FilmRowMapper(), false, pCode);

            return leFilm;

        }


        /// <summary>
        /// ObtenirFilm
        /// </summary>
        /// <param name="pCode">code film</param>
        /// <returns>Le film trouvé en base</returns>
        public Film ObtenirFilmComplet(Guid pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            Film leFilm = maDataSource.ExecuterRequete<Film>(REQUETE_OBTENIR_FILM, new FilmRowMapper(), false, pCode);

            return leFilm;
        }

        ///// <summary>
        ///// AjouterExemplaire
        ///// </summary>
        ///// <param name="pCodeFilm"></param>
        ///// <param name="pCodeSupport"></param>
        ///// <param name="pCodeProprietaire"></param>
        //public void AjouterExemplaire(Guid pCodeFilm, string pCodeSupport, Guid pCodeProprietaire, DateTime pDateAcquisition)
        //{

        //    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterExemplaire");

        //    CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

        //    try
        //    {
        //        maDataSource.StartGlobalTransaction();

        //        maDataSource.ExecuterDML(REQUETE_AJOUTER_EXEMPLAIRE, true, pCodeProprietaire, pCodeFilm, pCodeSupport, DateTime.Now, pDateAcquisition);

        //        maDataSource.CommitGlobalTransaction();

        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
        //        maDataSource.RollBackGlobalTransaction();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin AjouterExemplaire");
        //    }
        //}

        

        /// <summary>
        /// ObtenirFilm
        /// </summary>
        /// <param name="pCode">code film</param>
        /// <returns>Le film trouvé en base</returns>
        public Film CreerFilmEtExemplaire(Film pFilm, string pCodeSupport, Guid pCodeProprietaire, DateTime pDateAcquisition, int pEtat)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début CreerFilmEtExemplaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                if (pFilm.Code.Equals(Guid.Empty)) {
                    pFilm.Code = Guid.NewGuid();
                }
 
                Film filmExistant = maDataSource.ExecuterRequete<Film>(REQUETE_EXISTE_FILM, new FilmRowMapper(), false, pFilm.Titre, pFilm.Realisateur);

                if (filmExistant == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le film n'existe pas, on l'ajoute");

                    maDataSource.ExecuterDML(
                        REQUETE_AJOUTER_MEDIA, true,
                        pFilm.Code, Constantes.EnumTypeMedia.FILM, pFilm.Titre, pFilm.DateSortie, pFilm.Photo, pFilm.UrlFiche, pFilm.PEGI, pFilm.LeGenre.Code, pFilm.Note);


                    maDataSource.ExecuterDML(
                        REQUETE_AJOUTER_FILM, true, pFilm.Code, pFilm.Duree, pFilm.Synopsys, pFilm.Realisateur, pFilm.Acteurs);

                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le film existe déjà");

                    pFilm.Code = filmExistant.Code;                   
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EXEMPLAIRE, true, pCodeProprietaire, pFilm.Code, pEtat, pCodeSupport, DateTime.Now, pDateAcquisition);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement de l'exemplaire OK");


                return pFilm;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin CreerFilmEtExemplaire");
            }
        }

        ///// <summary>
        ///// ListeSouhaitsProprietaire
        ///// </summary>
        ///// <param name="pCodeProprietaire">Le proprio</param>
        ///// <returns></returns>
        //public List<Exemplaire> ListeSouhaitsProprietaire(Guid pCodeProprietaire)
        //{
        //    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ListeSouhaitsProprietaire");

        //    CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

        //    try
        //    {
        //        maDataSource.StartGlobalTransaction();

        //        List<Exemplaire> listeSouhaits = maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_SOUHAITS_PROPRIETAIRE, new ExemplaireFilmRowMapper(), false, pCodeProprietaire);
                
        //        maDataSource.CommitGlobalTransaction();

        //        return listeSouhaits;

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
        //        maDataSource.RollBackGlobalTransaction();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ListeSouhaitsProprietaire");
        //    }
        //}

        ///// <summary>
        ///// ListeSouhaitsProprietaire
        ///// </summary>
        ///// <param name="pCodeProprietaire">Le proprio</param>
        ///// <returns></returns>
        //public List<Emprunt> ListeEmpruntsProprietaire(Guid pCodeProprietaire)
        //{
        //    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ListeEmpruntsProprietaire");

        //    CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

        //    try
        //    {
        //        maDataSource.StartGlobalTransaction();

        //        List<Emprunt> listeEmprunts = maDataSource.ExecuterRequeteList<Emprunt>(REQUETE_OBTENIR_LISTE_EMPRUNTS_PROPRIETAIRE, new EmpruntFilmRowMapper(), false, pCodeProprietaire);

        //        maDataSource.CommitGlobalTransaction();

        //        return listeEmprunts;

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
        //        maDataSource.RollBackGlobalTransaction();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ListeEmpruntsProprietaire");
        //    }
        //}

        /// <summary>
        /// CreerFilmEtSouhait
        /// </summary>
        /// <param name="pFilm">pFilm</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <returns></returns>
        public Film CreerFilmEtSouhait(Film pFilm, string pCodeSupport, Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début CreerFilmEtSouhait");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                pFilm.Code = Guid.NewGuid();

                Film filmExistant = maDataSource.ExecuterRequete<Film>(REQUETE_EXISTE_FILM, new FilmRowMapper(), false, pFilm.Titre, pFilm.Realisateur);

                if (filmExistant == null)
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le film n'existe pas, on l'ajoute");

                    maDataSource.ExecuterDML(REQUETE_AJOUTER_FILM, true, pFilm.Code, pFilm.Titre, pFilm.Duree,
                    pFilm.LeGenre.Code, pFilm.DateSortie, pFilm.Synopsys, pFilm.Photo, pFilm.Realisateur,
                    pFilm.Acteurs, 1, pFilm.Note, pFilm.UrlFiche);

                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le film existe déjà");

                    pFilm.Code = filmExistant.Code;
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SOUHAIT_ACHAT, true, pCodeProprietaire, pFilm.Code, pCodeSupport, DateTime.Now);

                maDataSource.CommitGlobalTransaction();

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement du souhait OK");

                return pFilm;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin CreerFilmEtSouhait");
            }
        }

        ///// <summary>
        ///// SupprimerFilm (et exemplaires associés)
        ///// </summary>
        ///// <param name="pCode">pCode</param>
        //public int SupprimerFilm(Guid pCode)
        //{
        //    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début SupprimerFilm");

        //    CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);
        //    int result = -1;
        //    try
        //    {
        //        maDataSource.StartGlobalTransaction();

        //        result = maDataSource.ExecuterDML(REQUETE_SUPPRIMER_FILM, false, pCode);

        //        result = maDataSource.ExecuterDML(REQUETE_SUPPRIMER_EXEMPLAIRE, false, pCode);

        //        if (result.Equals(1))
        //        {
        //            result = maDataSource.ExecuterDML(REQUETE_SUPPRIMER_MEDIA, false, pCode);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
        //        maDataSource.RollBackGlobalTransaction();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin SupprimerFilm");
        //    }

        //    return result;
        //}

     

        /// <summary>
        /// UpdateFilm
        /// </summary>
        /// <param name="f">Film</param>
        /// <returns></returns>
        public int UpdateFilm(Film f)
        {
            int result = -1;
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {               
                maDataSource.StartGlobalTransaction();

                result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_FILM, false, f.Duree,
                   f.Synopsys, f.Realisateur, f.Acteurs, f.Code);

                if (result == 1)
                {
                    result = maDataSource.ExecuterDML(REQUETE_MODIFICATION_MEDIA, false, f.Titre,
                        f.LeGenre.Code, f.DateSortie, f.Photo, f.UrlFiche, f.PEGI, f.Note, f.Code);
                }

                if (result == 1)
                {
                    maDataSource.CommitGlobalTransaction();
                }
                else
                {
                    maDataSource.RollBackGlobalTransaction();
                }

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Enregistrement du film OK");

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin UpdateFilm");
            }

            return result;
        }

        

    }
}
