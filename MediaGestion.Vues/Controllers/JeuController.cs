using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibAllocine;
using LibAllocine.Dl.Dto;
using LibAllocine.Helper;
using MediaGestion.Metier;
using MediaGestion.Metier.Bl.Blo.Impl;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.Vues.Helper;
using MediaGestion.Vues.Models;

namespace MediaGestion.Vues.Controllers
{
    public class JeuController : MediaController
    {
        //TODO : faire un trigger pour mettre à jour la valeur de dispo

        //TODO
        
        public string[] mSelectedMachines;
        public Guid[] mSelectedProprios;
        private static int nbJeuxParPage = 20;
        private int numPage;

        //
        // GET: /Jeu/
        public ActionResult Index(int pNumeroPage)
        {
            if (Request.IsAuthenticated)
            {
                Proprietaire proprio = null;

                HttpContextWrapper httpContextWrapper = new HttpContextWrapper(System.Web.HttpContext.Current);

                if (httpContextWrapper != null && httpContextWrapper.Session["proprietaire"] != null)
                {
                    proprio = (Proprietaire)httpContextWrapper.Session["proprietaire"];
                }

                //GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();

                List<Jeu> listeFiltree = ObtenirListeJeuxFiltree();

                ListeMediaViewModel model = new ListeMediaViewModel();
                model.NbPages = listeFiltree.Count / nbJeuxParPage;
                model.NbResultats = listeFiltree.Count;

                if (model.NbResultats % nbJeuxParPage > 0)
                {
                    model.NbPages++;
                }

                model.ListeJeux = (listeFiltree.Skip((pNumeroPage - 1) * nbJeuxParPage).Take(nbJeuxParPage)).ToList<Jeu>();

                model.NumeroPage = pNumeroPage;

                return View(model);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }


        ////TODO : à revoir
        ////
        //// GET: /Jeu/

        //public ActionResult Next()
        //{
        //    if (Request.IsAuthenticated)
        //    {
        //        Proprietaire proprio = null;

        //        HttpContextWrapper httpContextWrapper = new HttpContextWrapper(System.Web.HttpContext.Current);

        //        if (httpContextWrapper != null && httpContextWrapper.Session["proprietaire"] != null)
        //        {
        //            proprio = (Proprietaire)httpContextWrapper.Session["proprietaire"];
        //        }

        //        //GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
        //        //List<Jeu> listeJeux = gestionnaireJeux.ObtenirJeux();

        //        List<Jeu> listeJeux = ObtenirListeJeuxFiltree();


        //        // On retourne les n premières fiches
        //        numPage = (int)Session["numeroPage"];

        //        int nbTotalPages = (int)Math.Ceiling((double)listeJeux.Count / nbJeuxParPage);

        //        if (numPage < nbTotalPages)
        //        {
        //            numPage++;
        //        }

        //        //Sauvegarde du numéro de page dans la session
        //        Session["numeroPage"] = numPage;

        //        return View("Index", listeJeux.Skip((numPage - 1) * nbJeuxParPage).Take(nbJeuxParPage));

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}

        ////TODO : à revoir
        ////
        //// GET: /Jeu/
        [HttpGet]
        public ActionResult TrierParDateCreation()
        {
            if (Request.IsAuthenticated)
            {
                List<Jeu> listeFiltree = ObtenirListeJeuxFiltree();

                listeFiltree.Sort((Jeu f1, Jeu f2) => DateTime.Compare(f2.DateCreation, f1.DateCreation));

                ListeMediaViewModel model = new ListeMediaViewModel();
                model.NbPages = listeFiltree.Count / nbJeuxParPage;
                model.NbResultats = listeFiltree.Count;

                if (model.NbResultats % nbJeuxParPage > 0)
                {
                    model.NbPages++;
                }

                model.ListeJeux = (listeFiltree.Take(nbJeuxParPage)).ToList<Jeu>();

                return View("Index", model);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }


        //public ActionResult Previous()
        //{
        //    if (Request.IsAuthenticated)
        //    {
        //        Proprietaire proprio = null;

        //        HttpContextWrapper httpContextWrapper = new HttpContextWrapper(System.Web.HttpContext.Current);

        //        if (httpContextWrapper != null && httpContextWrapper.Session["proprietaire"] != null)
        //        {
        //            proprio = (Proprietaire)httpContextWrapper.Session["proprietaire"];
        //        }

        //        //GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();

        //        List<Jeu> listeJeux = ObtenirListeJeuxFiltree();


        //        // On retourne les n premières fiches

        //        numPage = (int)Session["numeroPage"];

        //        if (numPage > 1)
        //        {
        //            numPage--;
        //        }

        //        Session["numeroPage"] = numPage;

        //        return View("Index", listeJeux.Skip((numPage - 1) * nbJeuxParPage).Take(nbJeuxParPage));

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}


        /// <summary>
        /// Application d'un filtre sur la liste des jeux
        /// </summary>
        /// <param name="selectedGenres">selectedGenres</param>
        /// <param name="selectedProprietaires">selectedProprietaires</param>
        /// <returns></returns>
        public ActionResult Filtrer(string[] selectedGenres, string[] selectedMachines, Guid[] selectedProprietaires, string nomJeu)
        {
            Session["critereNomJeu"] = nomJeu;
            Session["critereSelectedGenres"] = selectedGenres;
            Session["critereSelectedMachines"] = selectedMachines;
            Session["critereSelectedProprietaires"] = selectedProprietaires;

            List<Jeu> listeFiltree = ObtenirListeJeuxFiltree();

            ListeMediaViewModel model = new ListeMediaViewModel();
            model.NbPages = listeFiltree.Count / nbJeuxParPage;
            model.NbResultats = listeFiltree.Count;

            if (model.NbResultats % nbJeuxParPage > 0)
            {
                model.NbPages++;
            }

            model.ListeJeux = (listeFiltree.Take(nbJeuxParPage)).ToList<Jeu>();

            return View("Index", model);

        }

        /// <summary>
        /// ObtenirListeJeuxFiltree
        /// </summary>
        /// <returns></returns>
        private List<Jeu> ObtenirListeJeuxFiltree()
        {
            mSelectedName = (String)Session["critereNomJeu"];
            mSelectedGenres = (string[])Session["critereSelectedGenres"];
            mSelectedMachines = (string[])Session["critereSelectedMachines"];
            mSelectedProprios = (Guid[])Session["critereSelectedProprietaires"];

            GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
            List<Jeu> liste = gestionnaireJeux.ObtenirJeux();

            if (!String.IsNullOrEmpty(mSelectedName))
            {
                liste = liste.FindAll(findName);
            }

            liste = liste.FindAll(findGenre);
            liste = liste.FindAll(findMachine);
            liste = liste.FindAll(findProprio);

            return liste;

        }




        /// <summary>
        /// GET: /Jeu/Details/5
        /// </summary>
        /// <param name="codeMedia">codeMedia</param>
        /// <returns></returns>
        public ActionResult Details(Guid codeMedia)
        {
            if (Request.IsAuthenticated)
            {
                GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
                Jeu j = gestionnaireJeux.ObtenirLeJeuComplet(codeMedia);

                MediaViewModel model = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);
                model.LeJeu = j;

                return View(model);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        /// <summary>
        /// GET: /Jeu/ListeJVC/
        /// </summary>
        /// <param name="nomJeu">nomJeu</param>
        /// <returns></returns>
        public ActionResult ListeJVC(string nomJeu)
        {
            if (Request.IsAuthenticated)
            {
                if (nomJeu == null || String.Empty.Equals(nomJeu))
                {
                    return RedirectToAction("Index", "Jeu");
                }
                else
                {
                    GestionnaireJVC gestionnaireJVC = new GestionnaireJVC();

                    ListeFichesJeuxJVC liste = gestionnaireJVC.RechercherJeu(nomJeu);
                 
                    return View(liste);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        /// <summary>
        /// Create depuis la liste des fiches trouvées dans Allocine
        /// GET: /Home/Create
        /// </summary>
        /// <param name="codeJeuAllocine">codeJeuAllocine</param>
        /// <returns></returns>
        public ActionResult Create(string codeJeuJVC)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);

                    mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                    mediaViewModel.ListeMachines = DataManager.ListeMachines;
                    mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.JEU);
                    mediaViewModel.ListeEtatsMedia = DataManager.ListeEtatsMedia;

                    if (String.IsNullOrEmpty(codeJeuJVC))
                    {

                    }
                    else
                    {
                        //Ajout via JVC
                        GestionnaireJVC gestionnaireJVC = new GestionnaireJVC();

                        //FicheJeuJVC ficheJeuJVC = gestionnaireJVC.ObtenirFicheSimpleJeu(codeJeuJVC);
                        FicheJeuJVC ficheJeuJVC = new FicheJeuJVC();
                        ficheJeuJVC.CodeJeu = codeJeuJVC;
                        ficheJeuJVC = gestionnaireJVC.ObtenirFicheDetailleJeu(ficheJeuJVC);

                        Genre genre = mediaViewModel.ListeGenres.Find(
                        item => item.Libelle.ToLower().Replace(" ", "").Replace("-", "").Contains(
                            ficheJeuJVC.Genre.ToLower().Replace(" ", "").Replace("-", "")));

                        Machine machine = mediaViewModel.ListeMachines.Find(item => item.Nom.ToLower().Equals(ficheJeuJVC.Machine.ToLower()));

                        FileInfo sourceFile = new FileInfo("C:\\Temp\\" + ficheJeuJVC.NomPhoto);
                        if (sourceFile.Exists)
                        {
                            FileInfo destFile = new FileInfo("D:\\Jaymz\\Images\\Pochettes\\Jeux\\" + ficheJeuJVC.NomPhoto);

                            if (destFile.Exists)
                            {
                                destFile.Delete();
                            }

                            sourceFile.MoveTo(destFile.FullName);
                        }

                        mediaViewModel.LeJeu = new Jeu(ficheJeuJVC, genre, machine);
                        mediaViewModel.Developpeur = ficheJeuJVC.Developpeur;
                        mediaViewModel.Editeur = ficheJeuJVC.Editeur;
                        mediaViewModel.AnneeSortie = ficheJeuJVC.DateSortie;
                 
                    }

                    //Sélection du propriétaire par défaut pour la création de l'exemplaire
                    mediaViewModel.LeProprietaire.Code = mediaViewModel.ListeProprietaire.Find(
                        item => item.Login.Equals(System.Web.HttpContext.Current.User.Identity.Name)).Code;


                    return View(mediaViewModel);

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Jeu", "Create");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        /// <summary>
        /// POST: /Home/Create
        /// </summary>
        /// <param name="pMediaViewModel">pMediaViewModel</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(MediaViewModel pMediaViewModel)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
                    Jeu f = null;

                    if (Request.Form["creerExemplaire"] != null)
                    {
                        pMediaViewModel.LeJeu.Developpeur.Nom = pMediaViewModel.Developpeur;
                        pMediaViewModel.LeJeu.Editeur.Nom = pMediaViewModel.Editeur;

                        f = gestionnaireJeux.CreerJeuEtExemplaire(pMediaViewModel.LeJeu, pMediaViewModel.LeProprietaire.Code, pMediaViewModel.Etat, pMediaViewModel.DateAcquisition);

                        //On affiche la page du jeu
                        return RedirectToAction("Details", "Jeu", new { codeMedia = f.Code });
                    }
                    else if (Request.Form["creerSouhait"] != null)
                    {
                        f = gestionnaireJeux.CreerJeuEtSouhait(pMediaViewModel.LeJeu, pMediaViewModel.LeProprietaire.Code);
                    }

                    //On affiche la page du jeu
                    return RedirectToAction("Details", "Jeu", new { codeMedia = f.Code });
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Jeu", "CreerJeu");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //Create depuis la liste des fiches trouvées dans Allocine
        //
        // GET: /Home/CreerExemplaire
        public ActionResult CreerExemplaire(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.JEU);
                mediaViewModel.ListeEtatsMedia = DataManager.ListeEtatsMedia;

                GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
                mediaViewModel.LeJeu = gestionnaireJeux.ObtenirLeJeuComplet(pCodeMedia);

                //Sélection du propriétaire par défaut pour la création de l'exemplaire
                mediaViewModel.LeProprietaire.Code = mediaViewModel.ListeProprietaire.Find(
                    item => item.Login.Equals(System.Web.HttpContext.Current.User.Identity.Name)).Code;

                return View(mediaViewModel);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Home/CreerExemplaire

        [HttpPost]
        public ActionResult CreerExemplaire(MediaViewModel pMediaViewModel)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();

                    gestionnaireJeux.AjouterExemplaire(
                        pMediaViewModel.LeJeu.Code,
                        pMediaViewModel.LeProprietaire.Code,
                        pMediaViewModel.Etat.Code,
                        pMediaViewModel.DateAcquisition);

                    //On affiche la page du jeu
                    return RedirectToAction("Details", "Jeu", new { codeMedia = pMediaViewModel.LeJeu.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Jeu", "CreerExemplaire");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //Edit
        //
        // GET: /Home/ModifierExemplaire
        public ActionResult ModifierExemplaire(Guid pCodeMedia, Guid pCodeExemplaire, int pCodeEtat)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeEtatsMedia = DataManager.ListeEtatsMedia;

                GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
                mediaViewModel.LeJeu = gestionnaireJeux.ObtenirLeJeuComplet(pCodeMedia);

                mediaViewModel.Lexemplaire = mediaViewModel.LeJeu.ListeExemplaire.Find(item => item.Code == pCodeExemplaire);

                //Sélection du propriétaire par défaut pour la création de l'exemplaire
                //mediaViewModel.LeProprietaire.Code = mediaViewModel.Lexemplaire.LeProprietaire.Code;
                //mediaViewModel.Etat.Code = pCodeEtat;

                if (mediaViewModel.Lexemplaire.DateAcquisition.Equals(new DateTime()))
                {
                    mediaViewModel.DateAcquisition = DateTime.Now;
                } else {
                    mediaViewModel.DateAcquisition = mediaViewModel.Lexemplaire.DateAcquisition;
                }

                return View(mediaViewModel);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Home/ModifierExemplaire

        [HttpPost]
        public ActionResult ModifierExemplaire(MediaViewModel pMediaViewModel)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
                   
                    gestionnaireJeux.ModifierExemplaire(
                        pMediaViewModel.Lexemplaire.Code,
                        pMediaViewModel.Lexemplaire.Etat.Code, 
                        pMediaViewModel.DateAcquisition);

                    //On affiche la page du jeu
                    return RedirectToAction("Details", "Jeu", new { codeMedia = pMediaViewModel.LeJeu.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Jeu", "ModifierExemplaire");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }


        ////Create depuis la liste des fiches trouvées dans Allocine
        ////
        //// GET: /Home/CreerEmprunt
        //public ActionResult CreerEmprunt(Guid pCodeMedia, Guid pCodeExemplaire)
        //{
        //    if (Request.IsAuthenticated)
        //    {
        //        MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);

        //        mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
        //        //mediaViewModel.ListeSupports = DataManager.ListeSupports;
        //        //mediaViewModel.ListeGenres = DataManager.ListeGenre;

        //        GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
        //        mediaViewModel.LeJeu = gestionnaireJeux.ObtenirLeJeuComplet(pCodeMedia);

        //        mediaViewModel.Lexemplaire = mediaViewModel.LeJeu.ListeExemplaire.Find(item => item.Code == pCodeExemplaire);

        //        mediaViewModel.LeProprietaire = mediaViewModel.Lexemplaire.LeProprietaire;
      
        //        return View(mediaViewModel);

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}

        ////
        //// POST: /Home/CreerExemplaire

        //[HttpPost]
        //public ActionResult CreerEmprunt(MediaViewModel pMediaViewModel)
        //{
        //    if (Request.IsAuthenticated)
        //    {
        //        try
        //        {
        //            GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();

        //            gestionnaireJeux.AjouterEmprunt(
        //                pMediaViewModel.Lexemplaire.Code, 
        //                pMediaViewModel.Lemprunteur);

        //            //On affiche la page du jeu
        //            return RedirectToAction("Details", "Jeu", new { codeJeu = pMediaViewModel.LeJeu.Code });

        //        }
        //        catch (Exception ex)
        //        {
        //            HandleErrorInfo error = new HandleErrorInfo(ex, "Jeu", "CreerExemplaire");
        //            return View("Error", error);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}

        ////Create depuis la liste des fiches trouvées dans Allocine
        ////
        //// GET: /Home/CreerEmprunt
        //public ActionResult CloreEmprunt(Guid pCodeMedia, Guid pCodeEmprunt)
        //{
        //    if (Request.IsAuthenticated)
        //    {
        //        ///MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);

        //        //mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
        //        //mediaViewModel.ListeSupports = DataManager.ListeSupports;
        //        //mediaViewModel.ListeGenres = DataManager.ListeGenre;

        //        GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
        //        if (gestionnaireJeux.CloreEmprunt(pCodeEmprunt))
        //        {
        //            //return View("Details", pCodeMedia);
        //            return RedirectToAction("Details", "Jeu", new { codeJeu = pCodeMedia });

        //        }
        //        else
        //        {
        //            //Message d'erreur ?
        //            return RedirectToAction("Details", "Jeu", new { codeJeu = pCodeMedia });
        //        }

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}

        //Create souhait
        //
        // GET: /Home/CreerExemplaire
        public ActionResult CreerSouhait(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.JEU);
                mediaViewModel.ListeEtatsMedia = DataManager.ListeEtatsMedia;

                GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
                mediaViewModel.LeJeu = gestionnaireJeux.ObtenirLeJeuComplet(pCodeMedia);

                //Sélection du propriétaire par défaut pour la création du souhait
                mediaViewModel.LeProprietaire.Code = mediaViewModel.ListeProprietaire.Find(
                    item => item.Login.Equals(System.Web.HttpContext.Current.User.Identity.Name)).Code;

                return View(mediaViewModel);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }

        }

        //
        // POST: /Home/CreerSouhait
        [HttpPost]
        public ActionResult CreerSouhait(MediaViewModel pMediaViewModel)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                   
                    GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();

                    gestionnaireJeux.AjouterSouhaitAchat(pMediaViewModel.LeJeu.Code, pMediaViewModel.LeProprietaire.Code);

                    //On affiche la page du jeu
                    return RedirectToAction("Details", "Jeu", new { codeMedia = pMediaViewModel.LeJeu.Code });
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Jeu", "CreerSouhait");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // GET: /Jeu/Edit/5

        public ActionResult Edit(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);
                //GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.JEU);
                mediaViewModel.ListeEtatsMedia = DataManager.ListeEtatsMedia;

                GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();

                mediaViewModel.LeJeu = gestionnaireJeux.ObtenirLeJeuComplet(pCodeMedia);
                mediaViewModel.Developpeur = mediaViewModel.LeJeu.Developpeur.Nom;
                mediaViewModel.Editeur = mediaViewModel.LeJeu.Editeur.Nom;

                return View(mediaViewModel);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Jeu/Edit/5

        [HttpPost]
        public ActionResult Edit(MediaViewModel pMediaViewModel)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    foreach (string inputTagName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[inputTagName];

                        byte[] buffer = new byte[file.ContentLength];
                        file.InputStream.Read(buffer, 0, file.ContentLength);
                    }

                    if (Session["ContentStreamJeu"] != null)
                    {
                        int length = (int)Session["ContentLengthJeu"];
                        string type = (string)Session["ContentTypeJeu"];
                        byte[] img = (byte[])Session["ContentStreamJeu"];

                        string fichierPhoto = @"D:\Jaymz\Images\Pochettes\DVD\" + pMediaViewModel.LeJeu.Titre + ".jpg";

                        pMediaViewModel.LeJeu.Photo = pMediaViewModel.LeJeu.Titre + ".jpg";

                        FileInfo fichierImage = new FileInfo(fichierPhoto);

                        if (fichierImage.Exists)
                        {
                            fichierImage.Delete();
                        }

                        using (Image image = Image.FromStream(new MemoryStream(img)))
                        {
                            image.Save(fichierPhoto, ImageFormat.Jpeg);  // Or Png
                        }

                        Session.Remove("ContentStreamJeu");
                        Session.Remove("ContentLengthJeu");
                        Session.Remove("ContentTypeJeu");
                    }

                    GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();

                    pMediaViewModel.LeJeu.Developpeur.Nom = pMediaViewModel.Developpeur;
                    pMediaViewModel.LeJeu.Editeur.Nom = pMediaViewModel.Editeur;
                    Machine machine = DataManager.ListeMachines.Find(item => item.Nom.ToLower().Equals(pMediaViewModel.LeJeu.LaMachine.Nom.ToLower()));

                    pMediaViewModel.LeJeu.LaMachine = machine;

                    gestionnaireJeux.MettreAJourJeu(pMediaViewModel.LeJeu);

                    Session.Clear();

                    return RedirectToAction("Details", "Jeu", new { codeMedia = pMediaViewModel.LeJeu.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Jeu", "Edit");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        

        //TODO

        public ActionResult ThumbImage2(string url)
        {
            Image img = ObtenirThumbnail(url);
            ImageResult imageResult = new ImageResult(img);

            return imageResult;

        }

        /// <summary>
        /// Récupération de l'imagette
        /// </summary>
        /// <returns></returns>
        private Image ObtenirThumbnail(string url)
        {
            Image thumb = null;

            try
            {
                // Téléchargement de l'image
                using (MemoryStream stream = UtilsAllocine.DownloadData(url))
                {
                    // On limite la durée de vie de img
                    using (Image img = Image.FromStream(stream))
                    {
                        Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(UtilsAllocine.ThumbnailCallback);

                        int newWidth = (int)img.Width / 10;
                        int newHeight = (int)img.Height / 10;

                        thumb = img.GetThumbnailImage(Constantes.LargeurThumbnails, Constantes.HauteurThumbnails, myCallback, IntPtr.Zero);
                    }
                }

                return thumb;
            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }

        }

        public ActionResult ThumbImage(string jaquette, int width, int height)
        {
            ImageResult imageResult = null;
            Image img = null;

            try
            {
                if (String.IsNullOrEmpty(jaquette))
                {
                    //TODO : revoir l'accès au fichier
                    //using (img = Image.FromFile(@"D:\Jaymz\Documents\Boulot\Mes projets Visual Studio\MediaGestion\MediaGestion.Vues\Content\Images\fichiervide.png"))
                    //{
                    //    imageResult = new ImageResult(img, width/2, height/2);
                    //}

                    img = new Bitmap(1, 1);
                    imageResult = new ImageResult(img, width / 2, height / 2);
                }
                else
                {
                    using (img = Image.FromFile(@"D:\Jaymz\Images\Pochettes\Jeux\" + jaquette))
                    {

                        imageResult = new ImageResult(img, width, height);
                       
                    }
                }

                return imageResult;
            }
            catch (Exception ex)
            {
                img = new Bitmap(1, 1);
                return new ImageResult(img, width / 2, height / 2);
            }

        }


        /// <summary>
        /// Filtre par machine 
        /// </summary>
        /// <param name="pJeu">pMachine</param>
        /// <returns></returns>
        private bool findMachine(Jeu pJeu)
        {
            if (mSelectedMachines != null)
            {
                foreach (string m in mSelectedMachines)
                {
                    if (m.ToUpper().Equals(pJeu.LaMachine.Code.ToUpper()))
                    {
                        return true;
                    }
                }
            }
            else
            {
                //Si rien de coché on retourne VRAI
                return true;
            }

            return false;
        }

        /// <summary>
        /// Filtre par propriétaire 
        /// </summary>
        /// <param name="pFilm">pFilm</param>
        /// <returns></returns>
        private bool findProprio(Media pMedia)
        {
            if (mSelectedProprios != null)
            {
                GestionnaireJeux gestionnaire = new GestionnaireJeux();
                Media m = gestionnaire.ObtenirLeJeuComplet(pMedia.Code);

                foreach (Guid p in mSelectedProprios)
                {
                    //Parcourt des exemplaires de ce film
                    foreach (Exemplaire el in m.ListeExemplaire)
                    {
                        if (p.Equals(el.LeProprietaire.Code))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                //Si rien de coché on retourne VRAI
                return true;
            }

            return false;
        }


        ///// <summary>
        ///// Filtre par nom 
        ///// </summary>
        ///// <param name="pJeu">pJeu</param>
        ///// <returns></returns>
        //private bool findName(Jeu pJeu)
        //{
        //    if (!String.IsNullOrEmpty(mSelectedName))
        //    {

        //        //if (String.Compare(pJeu.Titre.ToUpperInvariant().Replace(" ", ""), mSelectedName.ToUpperInvariant().Replace(" ", ""), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace)==0)
        //        if (pJeu.Titre.ToUpperInvariant().Replace(" ", "").Contains(mSelectedName.ToUpperInvariant().Replace(" ", "")))
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        //Si rien de coché on retourne VRAI
        //        return true;
        //    }

        //    return false;
        //}


        ///// <summary>
        ///// Filtre par propriétaire 
        ///// </summary>
        ///// <param name="pJeu">pJeu</param>
        ///// <returns></returns>
        //private bool findProprio(Guid pCodeMedia)
        //{
        //    if (mSelectedProprios != null)
        //    {

        //        GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
        //        Jeu f = gestionnaireJeux.ObtenirLeJeuComplet(pCodeMedia);

        //        foreach (Guid p in mSelectedProprios)
        //        {
        //            //Parcourt des exemplaires de ce jeu
        //            foreach (Exemplaire el in f.ListeExemplaire)
        //            {

        //                if (p.Equals(el.LeProprietaire.Code))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //Si rien de coché on retourne VRAI
        //        return true;
        //    }

        //    return false;
        //}

        //On retourne la photo stockee dans la session suite chargement
        public ActionResult ShowPhoto(string pPhoto)
        {
            if (Session["ContentStreamJeu"] != null)
            {
                byte[] b = (byte[])Session["ContentStreamJeu"];
                int length = (int)Session["ContentLengthJeu"];
                string type = (string)Session["ContentTypeJeu"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = type;
                Response.BinaryWrite(b);
                Response.Flush();

                //Session.Clear();
                Response.End();

                return Content("");
            }
            else if (pPhoto != null)
            {
                return ThumbImage(pPhoto, 600, 600);
            }
            else
            {
                return ThumbImage(null, 600, 600);
            }
        }


        //Appuie sur le bouton upload : on stocke l'image dans la session
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, MediaViewModel pJeu)
        {

            if (file != null && file.ContentLength > 0)
            {
                Session["ContentLengthJeu"] = file.ContentLength;
                Session["FileName"] = file.FileName;
                Session["ContentTypeJeu"] = file.ContentType;
                byte[] b = new byte[file.ContentLength];
                file.InputStream.Read(b, 0, file.ContentLength);
                Session["ContentStreamJeu"] = b;

            }

            return RedirectToAction("Edit", new { pCodeMedia = pJeu.LeJeu.Code });
        }


    }
}
