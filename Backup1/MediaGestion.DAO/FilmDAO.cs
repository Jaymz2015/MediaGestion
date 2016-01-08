using System.Collections.Generic;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;
using Utilitaires;

namespace MediaGestion.DAO
{
    public class FilmDAO
    {
        private static string KS_NOM_MODULE = "MediaGestion.DAO - FilmDAO - ";

        /// <summary>
        /// Requête de récupération de la liste des films
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_FILMS = "SELECT f.code, titre, duree, f.codeGenre, g.libelle, dateSortie, resume, " +
            "jaquette, realisateur,acteurs,support, dispo, note, codeProprietaire, dateCreation FROM FILM f, GENRE g WHERE f.codeGenre=g.codeGenre order by titre";


        /// <summary>
        /// Requête permettant de vérifier si un film n'existe pas déjà
        /// </summary>
        private string REQUETE_EXISTE_FILM = "SELECT TOP 1 * from FILM f, GENRE g " +
                                                                        " WHERE f.codeGenre=g.codeGenre " +
                                                                        " AND f.titre=@pTitre " +
                                                                        " AND f.realisateur=@pRealisateur";

        /// <summary>
        /// Requête de récupération de la liste des films
        /// </summary>
        private string REQUETE_OBTENIR_FILM = "SELECT f.code, titre, duree, f.codeGenre, g.libelle, dateSortie, resume, " +
            "jaquette, realisateur,acteurs,support, dispo, note, codeProprietaire, dateCreation FROM FILM f, GENRE g WHERE f.code=@codeFilm and f.codeGenre=g.codeGenre order by titre";

        /// <summary>
        /// Requête de suppression d'un film (cascade)
        /// </summary>
        private string REQUETE_SUPPRIMER_FILM = "DELETE from FILM WHERE code=@codeFilm";

        /// <summary>
        /// Requête de suppression d'un exemplaire
        /// </summary>
        private string REQUETE_SUPPRIMER_EXEMPLAIRE = "DELETE from EXEMPLAIRE_FILM WHERE codeFilm=@codeFilm and codeProprietaire=@codeProprietaire and codeSupport=@codeSupport";

        /// <summary>
        /// Requête de suppression d'un souhait
        /// </summary>
        private string REQUETE_SUPPRIMER_SOUHAIT = "DELETE from SOUHAIT_FILM WHERE codeFilm=@codeFilm and codeProprietaire=@codeProprietaire and codeSupport=@codeSupport";

        /// <summary>
        /// Requête de récupération de la liste des exemplaires d'un film
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_EXEMPLAIRES_FILM = "select f.code codeFilm, f.titre titreFilm, f.codeGenre codeGenre, g.libelle libelleGenre, f.jaquette jaquette, f.dateCreation, p.code codeProprio, p.nom nom, p.prenom prenom, s.code codeSupport, s.libelle libelleSupport, " +
                                                                " emp.codeEmprunteur codeEmprunteur, emp.nom nomEmprunteur, emp.prenom prenomEmprunteur, emp.datePrete, case when emp.datePrete is not null and emp.dateRendu is null then 0 else 1 end as dispo " +
                                                                "from EXEMPLAIRE_FILM ex left outer join EMPRUNT_FILM emp " +
                                                                "on emp.codeFilm = ex.codeFilm " +  
                                                                "and emp.codeProprietaire = ex.codeProprietaire " + 
                                                                "and emp.codeSupport = ex.codeSupport " +
                                                                "and emp.dateRendu is null " +
                                                                ",PROPRIETAIRE p, FILM f, SUPPORT s, GENRE g " +
                                                                "where ex.codeFilm = f.code " +
                                                                "and ex.codeProprietaire = p.code " +
                                                                "and ex.codeSupport = s.code " +
                                                                "and f.codeGenre= g.codeGenre " +                                                                
                                                                "and f.code = @codeFilm  " +
                                                                " order by titreFilm";

        /// <summary>
        /// Requête de récupération de la liste des souhaits pour un film
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_SOUHAITS_FILM = "select f.code codeFilm, f.titre titreFilm, f.codeGenre codeGenre, g.libelle libelleGenre, f.jaquette jaquette, p.code codeProprio, p.nom nom, p.prenom prenom, s.code codeSupport, s.libelle libelleSupport " +
                                                                "from SOUHAIT_FILM ex, PROPRIETAIRE p, FILM f, SUPPORT s, GENRE g " +
                                                                "where ex.codeFilm = f.code " +
                                                                "and ex.codeProprietaire = p.code " +
                                                                "and ex.codeSupport = s.code " +
                                                                "and f.codeGenre= g.codeGenre " +
                                                                "and f.code = @codeFilm  order by titreFilm";


        /// <summary>
        /// Requête de récupération de la liste des souhaits d'un propriétaire
        /// </summary>
        //private string REQUETE_OBTENIR_LISTE_SOUHAITS_PROPRIETAIRE = "select f.code codeFilm, f.titre titreFilm, f.codeGenre codeGenre, g.libelle libelleGenre, f.jaquette jaquette, p.code codeProprio, p.nom nom, p.prenom prenom, s.code codeSupport, s.libelle libelleSupport " +
        //                                                        "from SOUHAIT_FILM ex, PROPRIETAIRE p, FILM f, SUPPORT s, GENRE g " +
        //                                                        "where ex.codeFilm = f.code " +
        //                                                        "and ex.codeProprietaire = p.code " +
        //                                                        "and ex.codeSupport = s.code " +
        //                                                        "and f.codeGenre= g.codeGenre " +
        //                                                        "and p.code = @codeProprietaire order by titreFilm";

        /// <summary>
        /// Requête de récupération de la liste des souhaits d'un propriétaire
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_SOUHAITS_PROPRIETAIRE = "select f.code codeFilm, f.titre titreFilm, f.codeGenre codeGenre, g.libelle libelleGenre, f.jaquette jaquette, p.code codeProprio, p.nom nom,  " +
                                                                        "p.prenom prenom, s.code codeSupport, s.libelle libelleSupport, p2.nom + ' ' + p2.prenom + ' ' + s2.libelle as exemplaire_existant " +
                                                                        "from SOUHAIT_FILM souhait, PROPRIETAIRE p, SUPPORT s, GENRE g,  " +
                                                                        "FILM f left outer join EXEMPLAIRE_FILM ex on " +
                                                                        "f.code = ex.codeFilm  " +
                                                                        "left outer join PROPRIETAIRE p2 on  " +
                                                                        "ex.codeProprietaire = p2.code " +
                                                                        "left outer join SUPPORT s2 on " +
                                                                        "ex.codeSupport = s2.code " +
                                                                        "where souhait.codeFilm = f.code  " +
                                                                        "and souhait.codeProprietaire = p.code  " +
                                                                        "and souhait.codeSupport = s.code  " +
                                                                        "and f.codeGenre= g.codeGenre  " +
                                                                        "and p.code = @codeProprietaire order by titreFilm";


        /// <summary>
        /// Requête de récupération de la liste des emprunts d'un propriétaire
        /// </summary>
        private string REQUETE_OBTENIR_LISTE_EMPRUNTS_PROPRIETAIRE = "select emp.nom nomEmprunteur, emp.prenom prenomEmprunteur, emp.datePrete datePrete, emp.dateRendu dateRendu, f.code codeFilm, f.titre titreFilm, f.jaquette jaquette, p.code codeProprio, p.nom nom, p.prenom prenom, s.code codeSupport, s.libelle libelleSupport " +
                                                                "from EMPRUNT_FILM emp, PROPRIETAIRE p, FILM f, SUPPORT s " +
                                                                "where emp.codeFilm = f.code " +
                                                                "and emp.codeProprietaire = p.code " +
                                                                "and emp.codeSupport = s.code " +
                                                                "and p.code = @codeProprietaire order by titreFilm";

        /// <summary>
        /// Requête d'ajout d'un film
        /// </summary>
        private string REQUETE_AJOUTER_FILM = "INSERT INTO [CatalogueMedias].[dbo].[FILM] " + 
                                                       "([code]" + 
                                                       ",[titre]" + 
                                                       ",[duree]" + 
                                                       ",[codeGenre]" + 
                                                       ",[dateSortie]" + 
                                                       ",[resume]" + 
                                                       ",[jaquette]" + 
                                                       ",[realisateur]" + 
                                                       ",[acteurs]" +
                                                       ",[dispo]" +
                                                       ",[note]" +
                                                       ",[dateCreation])" + 
                                                   "VALUES" + 
                                                       "(@code" + 
                                                       ",@titre" +
                                                       ",@duree" +
                                                       ",@codeGenre" +
                                                       ",@dateSortie" +
                                                       ",@resume" +
                                                       ",@jaquette" +
                                                       ",@realisateur" +
                                                       ",@acteurs" +
                                                       ",@dispo" +
                                                       ",@note" +
                                                       ",GETDATE())";
  
        /// <summary>
        /// Requête d'ajout d'un exemplaire
        /// </summary>
        private string REQUETE_AJOUTER_EXEMPLAIRE = "INSERT INTO [CatalogueMedias].[dbo].[EXEMPLAIRE_FILM]" +
                                                               "([codeProprietaire]" +
                                                               ",[codeFilm]" +
                                                               ",[codeSupport]" +
                                                               ",[dateAcquisition])" +
                                                         "VALUES" +
                                                               "(@codeProprietaire" +
                                                               ",@codeFilm" +
                                                               ",@codeSupport" +
                                                               ",@dateAcquisition)";

        /// <summary>
        /// Requête d'ajout d'un exemplaire
        /// </summary>
        private string REQUETE_AJOUTER_SOUHAIT = "INSERT INTO [CatalogueMedias].[dbo].[SOUHAIT_FILM]" +
                                                               "([codeProprietaire]" +
                                                               ",[codeFilm]" +
                                                               ",[codeSupport])" +
                                                         "VALUES" +
                                                               "(@codeProprietaire" +
                                                               ",@codeFilm" +
                                                               ",@codeSupport)";


        /// <summary>
        /// Requête de modification d'un support
        /// </summary>
        private string REQUETE_MODIFICATION_FILM = "UPDATE FILM SET " +
                                                    "titre=@pTitre, " +
                                                    "duree=@pDuree, " + 
                                                    "codeGenre=@pCodeGenre, " + 
                                                    "dateSortie=@pDateSortie, " + 
                                                    "resume=@pResume, " + 
                                                    "jaquette=@pJaquette, " + 
                                                    "realisateur=@pRealisateur, " +
                                                    "acteurs=@pActeurs, " +
                                                    "note=@pNote, " +
                                                    "dateDerniereModification=GETDATE() " +
                                                    "where code=@pCode";

        // <summary>
        /// Requête d'ajout d'un emprunt
        /// </summary>
        private string REQUETE_AJOUTER_EMPRUNT = "INSERT INTO [CatalogueMedias].[dbo].[EMPRUNT_FILM]" +
                                                               "([codeProprietaire]" +
                                                               ",[codeFilm]" +
                                                               ",[codeSupport]" +
                                                               ",[codeEmprunteur]" +
                                                               ",[nom]" +
                                                               ",[prenom]" +
                                                               ",[datePrete])" +
                                                         "VALUES" +
                                                               "(@pCodeProprietaire" +
                                                               ",@pCodeFilm" +
                                                               ",@pCodeSupport" +
                                                               ",@pCodeEmprunteur" +
                                                               ",@pNom" +
                                                               ",@pPrenom" +
                                                               ",@pDatePrete)";

        /// <summary>
        /// Requête de modification d'un emprunt
        /// </summary>
        private string REQUETE_CLORE_EMPRUNT = "UPDATE [CatalogueMedias].[dbo].[EMPRUNT_FILM] SET " +
                                                    "dateRendu=@pDateRendu " +
                                                    "where codeFilm=@pCodeFilm " + 
                                                    "and codeProprietaire=@pCodeProprietaire " + 
                                                    "and codeSupport=@pCodeSupport " +
                                                    "and dateRendu is null";


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

            List<Exemplaire> listeExpl = maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_EXEMPLAIRES_FILM, new ExemplaireRowMapper(), false, pCode);
            List<Exemplaire> listeSouhaits = maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_SOUHAITS_FILM, new ExemplaireRowMapper(), false, pCode);

            //On associe le film à chaque exemplaire
            foreach (Exemplaire expl in listeExpl) {
                expl.LeMedia = leFilm;
            }

            //On associe le film à chaque exemplaire
            foreach (Exemplaire expl in listeSouhaits)
            {
                expl.LeMedia = leFilm;
            }

            leFilm.ListeExemplaire = listeExpl;
            leFilm.ListeSouhaits = listeSouhaits;

            return leFilm;
        }

        /// <summary>
        /// AjouterExemplaire
        /// </summary>
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        public void AjouterExemplaire(Guid pCodeFilm, string pCodeSupport, Guid pCodeProprietaire)
        {

            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterExemplaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EXEMPLAIRE, true, pCodeProprietaire, pCodeFilm, pCodeSupport, new DateTime());

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
        /// AjouterSouhait
        /// </summary>
        /// <param name="pCodeFilm">pCodeFilm</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        public void AjouterSouhait(Guid pCodeFilm, string pCodeSupport, Guid pCodeProprietaire)
        {

            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterSouhait");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SOUHAIT, true, pCodeProprietaire, pCodeFilm, pCodeSupport);

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
        /// ObtenirFilm
        /// </summary>
        /// <param name="pCode">code film</param>
        /// <returns>Le film trouvé en base</returns>
        public Film CreerFilmEtExemplaire(Film pFilm, string pCodeSupport, Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début CreerFilmEtExemplaire");

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
                    pFilm.LeGenre.Code, pFilm.DateSortie, pFilm.Synopsys, pFilm.Jaquette, pFilm.Realisateur,
                    pFilm.Acteurs, 1, pFilm.Note);

                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le film existe déjà");

                    pFilm.Code = filmExistant.Code;                   
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EXEMPLAIRE, true, pCodeProprietaire, pFilm.Code, pCodeSupport, new DateTime());

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

        /// <summary>
        /// ListeSouhaitsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        /// <returns></returns>
        public List<Exemplaire> ListeSouhaitsProprietaire(Guid pCodeProprietaire)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ListeSouhaitsProprietaire");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                List<Exemplaire> listeSouhaits = maDataSource.ExecuterRequeteList<Exemplaire>(REQUETE_OBTENIR_LISTE_SOUHAITS_PROPRIETAIRE, new ExemplaireRowMapper(), false, pCodeProprietaire);
                
                maDataSource.CommitGlobalTransaction();

                return listeSouhaits;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                maDataSource.RollBackGlobalTransaction();
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ListeSouhaitsProprietaire");
            }
        }

        /// <summary>
        /// ListeSouhaitsProprietaire
        /// </summary>
        /// <param name="pCodeProprietaire">Le proprio</param>
        /// <returns></returns>
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
                    pFilm.LeGenre.Code, pFilm.DateSortie, pFilm.Synopsys, pFilm.Jaquette, pFilm.Realisateur,
                    pFilm.Acteurs, 1, pFilm.Note);

                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Le film existe déjà");

                    pFilm.Code = filmExistant.Code;
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_SOUHAIT, true, pCodeProprietaire, pFilm.Code, pCodeSupport);

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

        /// <summary>
        /// SupprimerFilm (et exemplaires associés)
        /// </summary>
        /// <param name="pCode">pCode</param>
        public void SupprimerFilm(Guid pCode)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_SUPPRIMER_FILM, false, pCode);
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
        /// SupprimerSouhait
        /// </summary>
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pCodeSupport"></param>
        public void SupprimerSouhait(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            maDataSource.ExecuterDML(REQUETE_SUPPRIMER_SOUHAIT, false, pCodeFilm, pCodeProprietaire, pCodeSupport);
        }


        /// <summary>
        /// UpdateFilm
        /// </summary>
        /// <returns>Liste films</returns>
        public int UpdateFilm(Film f)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_MODIFICATION_FILM, false, f.Titre, f.Duree, 
                f.LeGenre.Code, f.DateSortie, f.Synopsys, f.Jaquette, f.Realisateur, f.Acteurs, f.Note, f.Code);
        }

        /// <summary>
        /// AjouterEmprunt
        /// </summary>
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pNom"></param>
        /// <param name="pPrenom"></param>
        public void AjouterEmprunt(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport, Emprunteur pEmprunteur)
        {

            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début AjouterEmprunt");

            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            try
            {
                maDataSource.StartGlobalTransaction();

                Guid codeEmprunteur;

                if (!String.IsNullOrEmpty(pEmprunteur.Nom))
                {
                    codeEmprunteur = Guid.Empty;
                }
                else
                {
                    codeEmprunteur = pEmprunteur.Code;

                    ProprietaireDAO proprietaireDAO = new ProprietaireDAO();
                    Proprietaire p = proprietaireDAO.ObtenirListeProprietaires().Find(item=>item.Code==codeEmprunteur);
                    pEmprunteur.Nom = p.Nom;
                    pEmprunteur.Prenom = p.Prenom;
                }

                maDataSource.ExecuterDML(REQUETE_AJOUTER_EMPRUNT, true, pCodeProprietaire, pCodeFilm, pCodeSupport, codeEmprunteur, pEmprunteur.Nom, pEmprunteur.Prenom, DateTime.Now);

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
        /// <param name="pCodeFilm"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <param name="pCodeSupport"></param>
        /// <returns></returns>
        public int UpdateEmprunt(Guid pCodeFilm, Guid pCodeProprietaire, String pCodeSupport)
        {
            CustomDataSource maDataSource = new CustomDataSource(Properties.Settings.Default.CHAINE_CONNEXION);

            return maDataSource.ExecuterDML(REQUETE_CLORE_EMPRUNT, false, DateTime.Now, pCodeFilm, pCodeProprietaire, pCodeSupport);
        }

    }
}
