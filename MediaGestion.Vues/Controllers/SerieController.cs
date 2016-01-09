using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaGestion.Metier;
using MediaGestion.Metier.Bl.Blo.Impl;
using MediaGestion.Vues.Models;
using LibAllocine;
using LibAllocine.Dl.Dto;
using MediaGestion.Modele.Dl.Dlo;
using System.IO;
using System.Drawing;
using MediaGestion.Vues.Helper;
using LibAllocine.Helper;
using System.Drawing.Imaging;
using MediaGestion.Modele.Dl.Dlo.Series;

namespace MediaGestion.Vues.Controllers
{
    public class SerieController : MediaController
    {
        //TODO : faire un trigger pour mettre à jour la valeur de dispo

        public Guid[] mSelectedProprios;
        private static int nbSeriesParPage = 20;
        private int numPage;

        //
        // GET: /Serie/
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

                GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();

                // On retourne les x premières fiches

                //numPage = 1;
                //Session["numeroPage"] = numPage;

                List<Serie> listeFiltree = ObtenirListeSeriesFiltree();

                ListeMediaViewModel model = new ListeMediaViewModel();
                model.NbPages = listeFiltree.Count / nbSeriesParPage;
                model.NbResultats = listeFiltree.Count;

                if (model.NbResultats % nbSeriesParPage > 0)
                {
                    model.NbPages++;
                }

                model.ListeSeries = (listeFiltree.Skip((pNumeroPage - 1) * nbSeriesParPage).Take(nbSeriesParPage)).ToList<Serie>();

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
        //// GET: /Serie/

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

        //        //GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
        //        //List<Serie> listeSeries = gestionnaireSeries.ObtenirSeries();

        //        List<Serie> listeSeries = ObtenirListeSeriesFiltree();


        //        // On retourne les n premières fiches
        //        numPage = (int)Session["numeroPage"];

        //        int nbTotalPages = (int)Math.Ceiling((double)listeSeries.Count / nbSeriesParPage);

        //        if (numPage < nbTotalPages)
        //        {
        //            numPage++;
        //        }

        //        //Sauvegarde du numéro de page dans la session
        //        Session["numeroPage"] = numPage;

        //        return View("Index", listeSeries.Skip((numPage - 1) * nbSeriesParPage).Take(nbSeriesParPage));

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}

        ////TODO : à revoir
        ////
        //// GET: /Serie/
        [HttpGet]
        public ActionResult TrierParDateCreation()
        {
            if (Request.IsAuthenticated)
            {

                List<Serie> listeFiltree = ObtenirListeSeriesFiltree();

                listeFiltree.Sort((Serie f1, Serie f2) => DateTime.Compare(f2.DateCreation, f1.DateCreation));

                ListeMediaViewModel model = new ListeMediaViewModel();
                model.NbPages = listeFiltree.Count / nbSeriesParPage;
                model.NbResultats = listeFiltree.Count;

                if (model.NbResultats % nbSeriesParPage > 0)
                {
                    model.NbPages++;
                }

                model.ListeSeries = (listeFiltree.Take(nbSeriesParPage)).ToList<Serie>();

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

        //        //GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();

        //        List<Serie> listeSeries = ObtenirListeSeriesFiltree();


        //        // On retourne les n premières fiches

        //        numPage = (int)Session["numeroPage"];

        //        if (numPage > 1)
        //        {
        //            numPage--;
        //        }

        //        Session["numeroPage"] = numPage;

        //        return View("Index", listeSeries.Skip((numPage - 1) * nbSeriesParPage).Take(nbSeriesParPage));

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}


        /// <summary>
        /// Application d'un filtre sur la liste des Series
        /// </summary>
        /// <param name="selectedGenres">selectedGenres</param>
        /// <param name="selectedProprietaires">selectedProprietaires</param>
        /// <returns></returns>
        public ActionResult Filtrer(string[] selectedGenres, Guid[] selectedProprietaires, string nomSerie)
        {
            Session["critereNomSerie"] = nomSerie;
            Session["critereSelectedGenres"] = selectedGenres;
            Session["critereSelectedProprietaires"] = selectedProprietaires;

            List<Serie> listeFiltree = ObtenirListeSeriesFiltree();

            ListeMediaViewModel model = new ListeMediaViewModel();
            model.NbPages = listeFiltree.Count / nbSeriesParPage;
            model.NbResultats = listeFiltree.Count;

            if (model.NbResultats % nbSeriesParPage > 0)
            {
                model.NbPages++;
            }

            model.ListeSeries = (listeFiltree.Take(nbSeriesParPage)).ToList<Serie>();

            return View("Index", model);

        }

        /// <summary>
        /// ObtenirListeSeriesFiltree
        /// </summary>
        /// <returns></returns>
        private List<Serie> ObtenirListeSeriesFiltree()
        {
            mSelectedName = (String)Session["critereNomSerie"];
            mSelectedGenres = (string[])Session["critereSelectedGenres"];
            mSelectedProprios = (Guid[])Session["critereSelectedProprietaires"];

            GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
            List<Serie> liste = gestionnaireSeries.ObtenirSeries();

            if (!String.IsNullOrEmpty(mSelectedName))
            {
                liste = liste.FindAll(findName);
            }

            liste = liste.FindAll(findGenre);
            liste = liste.FindAll(findProprio);

            return liste;

        }

        /// <summary>
        /// GET: /Serie/Details/5
        /// </summary>
        /// <param name="codeSerie">codeSerie</param>
        /// <returns></returns>
        public ActionResult Details(Guid codeMedia)
        {
            if (Request.IsAuthenticated)
            {
                GestionnaireSeries gestionnaire = new GestionnaireSeries();
                Serie se = gestionnaire.ObtenirLaSerieComplete(codeMedia);

                MediaViewModel model = new MediaViewModel(Modele.Constantes.EnumTypeMedia.SERIE);
                model.LaSerie = se;

                return View(model);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        /// <summary>
        /// GET: /Serie/ListeAllocine/
        /// </summary>
        /// <param name="nomSerie">nomSerie</param>
        /// <returns></returns>
        public ActionResult ListeAllocine(string nomSerie)
        {
            if (Request.IsAuthenticated)
            {
                if (nomSerie == null || String.Empty.Equals(nomSerie))
                {
                    return RedirectToAction("Index", "Serie");
                }
                else
                {
                    GestionnaireAllocine gestionnaireAllocine = new GestionnaireAllocine();

                    List<FicheFilmAllocine> liste = gestionnaireAllocine.RechercherMedia(nomSerie, Constantes.EnumTypeMediaAllocine.SERIE).ObtenirListeSeries();

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
        /// <param name="codeSerieAllocine">codeSerieAllocine</param>
        /// <returns></returns>
        public ActionResult Create(string codeSerieAllocine)
        {
            if (Request.IsAuthenticated)
            {

                try
                {

                    MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.SERIE);

                    mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                    mediaViewModel.ListeSupports = DataManager.ListeSupports;
                    mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.SERIE);
   

                    if (String.IsNullOrEmpty(codeSerieAllocine))
                    {

                    }
                    else
                    {
                        //Ajout via Allocine

                        GestionnaireAllocine gestionnaireAllocine = new GestionnaireAllocine();

                        FicheFilmAllocine ficheAllocine = gestionnaireAllocine.ObtenirFicheFilm(codeSerieAllocine, Constantes.EnumTypeMediaAllocine.SERIE);

                        Genre genre = mediaViewModel.ListeGenres.Find(
                        item => item.Libelle.ToLower().Replace(" ", "").Replace("-", "").Contains(
                            ficheAllocine.LeGenre.Libelle.ToLower().Replace(" ", "").Replace("-", "")));

                        FileInfo sourceFile = new FileInfo("C:\\Temp\\" + ficheAllocine.NomPhoto);
                        if (sourceFile.Exists)
                        {
                            FileInfo destFile = new FileInfo("D:\\Jaymz\\Images\\Pochettes\\DVD\\" + ficheAllocine.NomPhoto);

                            if (destFile.Exists)
                            {
                                destFile.Delete();
                            }

                            sourceFile.MoveTo(destFile.FullName);
                        }

                        mediaViewModel.LaSerie = new Serie(ficheAllocine, genre);
                    }

                    //Sélection du propriétaire par défaut pour la création de l'exemplaire
                    mediaViewModel.LeProprietaire.Code = mediaViewModel.ListeProprietaire.Find(
                        item => item.Login.Equals(System.Web.HttpContext.Current.User.Identity.Name)).Code;


                    return View(mediaViewModel);

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Serie", "Create");
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
                    GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
                    Serie f = null;

                    if (Request.Form["creerExemplaire"] != null)
                    {
                        //TODO : gérer l'état
                        f = gestionnaireSeries.CreerSerieEtExemplaire(pMediaViewModel.LaSerie, pMediaViewModel.LeSupport.Code, pMediaViewModel.LeProprietaire.Code, pMediaViewModel.DateAcquisition, 0);

                        //On affiche la page du Serie
                        return RedirectToAction("Details", "Serie", new { codeMedia = f.Code });
                    }
                    else if (Request.Form["creerSouhait"] != null)
                    {

                        f = gestionnaireSeries.CreerSerieEtSouhait(pMediaViewModel.LaSerie, pMediaViewModel.LeSupport.Code, pMediaViewModel.LeProprietaire.Code);

                    }

                    //On affiche la page du Serie
                    return RedirectToAction("Details", "Serie", new { codeMedia = f.Code });
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Serie", "CreerSerie");
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
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.SERIE);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.SERIE);

                GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
                mediaViewModel.LaSerie = gestionnaireSeries.ObtenirLaSerieComplete(pCodeMedia);

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
                    GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();

                    gestionnaireSeries.AjouterExemplaire(
                        pMediaViewModel.LaSerie.Code,
                        pMediaViewModel.LeProprietaire.Code,
                        pMediaViewModel.Etat.Code,
                        pMediaViewModel.LeSupport.Code,
                        pMediaViewModel.DateAcquisition);

                    //On affiche la page du Serie
                    return RedirectToAction("Details", "Serie", new { codeMedia = pMediaViewModel.LaSerie.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Serie", "CreerExemplaire");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }


        //Create souhait
        //
        // GET: /Home/CreerExemplaire
        public ActionResult CreerSouhait(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.SERIE);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.SERIE);

                GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
                mediaViewModel.LaSerie = gestionnaireSeries.ObtenirLaSerieComplete(pCodeMedia);

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
                    GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();

                    gestionnaireSeries.AjouterSouhaitAchat(
                        pMediaViewModel.LaSerie.Code,
                        pMediaViewModel.LeProprietaire.Code,
                        pMediaViewModel.LeSupport.Code);

                    //On affiche la page du Serie
                    return RedirectToAction("Details", "Serie", new { codeMedia = pMediaViewModel.LaSerie.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Serie", "CreerSouhait");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //Create saison
        //
        // GET: /Home/CreerSaison
        public ActionResult CreerSaison(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.SERIE);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.SERIE);

                GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
                mediaViewModel.LaSerie = gestionnaireSeries.ObtenirLaSerieComplete(pCodeMedia);
                mediaViewModel.LaSaison = new Saison();

                mediaViewModel.LaSaison.Numero = mediaViewModel.LaSerie.ListeSaisons.Last<Saison>().Numero + 1;
                mediaViewModel.LaSaison.AnneeSortie = mediaViewModel.LaSerie.ListeSaisons.Last<Saison>().AnneeSortie + 1;
                mediaViewModel.LaSaison.NbEpisodes = mediaViewModel.LaSerie.ListeSaisons.Last<Saison>().NbEpisodes;

                return View(mediaViewModel);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }

        }

        //
        // POST: /Home/CreerSaison
        [HttpPost]
        public ActionResult CreerSaison(MediaViewModel pMediaViewModel)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();

                    gestionnaireSeries.AjouterSaison(
                        pMediaViewModel.LaSerie.Code,
                        pMediaViewModel.LaSaison);

                    //On affiche la page du Serie
                    return RedirectToAction("Details", "Serie", new { codeMedia = pMediaViewModel.LaSerie.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Serie", "CreerSaison");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }
        

        //
        // GET: /Serie/Edit/5

        public ActionResult Edit(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.SERIE);
                //GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.SERIE);

                GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();

                mediaViewModel.LaSerie = gestionnaireSeries.ObtenirLaSerieComplete(pCodeMedia);

                return View(mediaViewModel);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Serie/Edit/5

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
                        //if (file.ContentLength > 0)
                        //{
                        //    string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads")
                        //            , Path.GetFileName(file.FileName));
                        //    file.SaveAs(filePath);
                        //}

                        byte[] buffer = new byte[file.ContentLength];
                        file.InputStream.Read(buffer, 0, file.ContentLength);

                        //ImageElement image = ImageElement.FromBinary(byteArray);

                        //pSerie.Icone = buffer;
                    }

                    if (Session["ContentStreamSerie"] != null)
                    {
                        int length = (int)Session["ContentLengthSerie"];
                        string type = (string)Session["ContentTypeSerie"];
                        byte[] img = (byte[])Session["ContentStreamSerie"];

                        string fichierPhoto = @"D:\Jaymz\Images\Pochettes\DVD\" + pMediaViewModel.LaSerie.Titre + ".jpg";

                        pMediaViewModel.LaSerie.Photo = pMediaViewModel.LaSerie.Titre + ".jpg";

                        FileInfo fichierImage = new FileInfo(fichierPhoto);

                        if (fichierImage.Exists)
                        {
                            fichierImage.Delete();
                        }

                        using (Image image = Image.FromStream(new MemoryStream(img)))
                        {
                            image.Save(fichierPhoto, ImageFormat.Jpeg);  // Or Png
                        }

                        Session.Remove("ContentStreamSerie");
                        Session.Remove("ContentLengthSerie");
                        Session.Remove("ContentTypeSerie");
                    }


                    //if (Session["FileName"] != null)
                    //{
                    //    //TODO : sauvegarde de l'image chargée dans un fichier ContentStreamSerie
                    //    pMediaViewModel.LaSerie.Photo = (String)Session["FileName"];
                    //}

                    GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
                    gestionnaireSeries.MettreAJourSerie(pMediaViewModel.LaSerie);

                    Session.Clear();

                    return RedirectToAction("Details", "Serie", new { codeMedia = pMediaViewModel.LaSerie.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Serie", "Edit");
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
        public ActionResult ModifierExemplaire(Guid pCodeMedia, Guid pCodeExemplaire)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.SERIE);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;

                GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
                mediaViewModel.LaSerie = gestionnaireSeries.ObtenirLaSerieComplete(pCodeMedia);

                 mediaViewModel.Lexemplaire = mediaViewModel.LaSerie.ListeExemplaire.Find(item => item.Code == pCodeExemplaire);

                //Sélection du propriétaire par défaut pour la création de l'exemplaire
                 //mediaViewModel.LeProprietaire.Code = mediaViewModel.Lexemplaire.LeProprietaire.Code;
                 //mediaViewModel.LeSupport.Code = mediaViewModel.Lexemplaire.LeSupport.Code;
               
                //mediaViewModel.OldSupport.Code = expl.LeSupport.Code;

                 if (mediaViewModel.Lexemplaire.DateAcquisition.Equals(new DateTime()))
                {
                    mediaViewModel.DateAcquisition = DateTime.Now;
                }
                else
                {
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
                    GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();

                    gestionnaireSeries.ModifierExemplaire(
                        pMediaViewModel.Lexemplaire.Code,
                        pMediaViewModel.Lexemplaire.LeSupport.Code, 
                        pMediaViewModel.Lexemplaire.Etat.Code,
                        pMediaViewModel.DateAcquisition);

                    //On affiche la page du jeu
                    return RedirectToAction("Details", "Serie", new { codeMedia = pMediaViewModel.LaSerie.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Serie", "ModifierExemplaire");
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
                throw ex;
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
                    using (img = Image.FromFile(@"D:\Jaymz\Images\Pochettes\DVD\" + jaquette))
                    {

                        imageResult = new ImageResult(img, width, height);
                    }
                }

                return imageResult;
            }
            catch (Exception)
            {
                img = new Bitmap(1, 1);
                return new ImageResult(img, width / 2, height / 2);
            }

        }


        //TODO : peu performant : à revoir
        /// <summary>
        /// Filtre par propriétaire 
        /// </summary>
        /// <param name="pSerie">pSerie</param>
        /// <returns></returns>
        private bool findProprio(Serie pSerie)
        {
            if (mSelectedProprios != null)
            {
                GestionnaireSeries gestionnaireSeries = new GestionnaireSeries();
                Serie se = gestionnaireSeries.ObtenirLaSerieComplete(pSerie.Code);

                foreach (Guid p in mSelectedProprios)
                {
                    //Parcourt des exemplaires de ce Serie
                    foreach (Exemplaire el in se.ListeExemplaire)
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

        //On retourne la photo stockee dans la session suite chargement
        public ActionResult ShowPhoto(string pPhoto)
        {
            if (Session["ContentStreamSerie"] != null)
            {
                byte[] b = (byte[])Session["ContentStreamSerie"];
                int length = (int)Session["ContentLengthSerie"];
                string type = (string)Session["ContentTypeSerie"];
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
                return ThumbImage(pPhoto, 100, 600);
            }
            else
            {
                return ThumbImage(null, 100, 600);
            }
        }


        //Appuie sur le bouton upload : on stocke l'image dans la session
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, MediaViewModel pSerie)
        {

            if (file != null && file.ContentLength > 0)
            {
                Session["ContentLengthSerie"] = file.ContentLength;
                Session["FileName"] = file.FileName;
                Session["ContentTypeSerie"] = file.ContentType;
                byte[] b = new byte[file.ContentLength];
                file.InputStream.Read(b, 0, file.ContentLength);
                Session["ContentStreamSerie"] = b;

            }

            return RedirectToAction("Edit", new { pCodeMedia = pSerie.LaSerie.Code });
        }


    }
}
