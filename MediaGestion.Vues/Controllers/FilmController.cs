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

namespace MediaGestion.Vues.Controllers
{
    public class FilmController : MediaController
    {
        //TODO : faire un trigger pour mettre à jour la valeur de dispo

        public Guid[] mSelectedProprios;
        private static int nbFilmsParPage = 20;
        private int numPage;

        //
        // GET: /Film/
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

                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();

                // On retourne les x premières fiches

                //numPage = 1;
                //Session["numeroPage"] = numPage;

                List<Film> listeFiltree = ObtenirListeFilmsFiltree();

                ListeMediaViewModel model = new ListeMediaViewModel();
                model.NbPages = listeFiltree.Count / nbFilmsParPage;
                model.NbResultats = listeFiltree.Count;

                if (model.NbResultats % nbFilmsParPage > 0)
                {
                    model.NbPages++;
                }

                model.ListeFilms = (listeFiltree.Skip((pNumeroPage - 1) * nbFilmsParPage).Take(nbFilmsParPage)).ToList<Film>();

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
        //// GET: /Film/

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

        //        //GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
        //        //List<Film> listeFilms = gestionnaireFilms.ObtenirFilms();

        //        List<Film> listeFilms = ObtenirListeFilmsFiltree();


        //        // On retourne les n premières fiches
        //        numPage = (int)Session["numeroPage"];

        //        int nbTotalPages = (int)Math.Ceiling((double)listeFilms.Count / nbFilmsParPage);

        //        if (numPage < nbTotalPages)
        //        {
        //            numPage++;
        //        }

        //        //Sauvegarde du numéro de page dans la session
        //        Session["numeroPage"] = numPage;

        //        return View("Index", listeFilms.Skip((numPage - 1) * nbFilmsParPage).Take(nbFilmsParPage));

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}

        ////TODO : à revoir
        ////
        //// GET: /Film/
        [HttpGet]
        public ActionResult TrierParDateCreation()
        {
            if (Request.IsAuthenticated)
            {

                List<Film> listeFiltree = ObtenirListeFilmsFiltree();

                listeFiltree.Sort((Film f1, Film f2) => DateTime.Compare(f2.DateCreation, f1.DateCreation));

                ListeMediaViewModel model = new ListeMediaViewModel();
                model.NbPages = listeFiltree.Count / nbFilmsParPage;
                model.NbResultats = listeFiltree.Count;

                if (model.NbResultats % nbFilmsParPage > 0)
                {
                    model.NbPages++;
                }

                model.ListeFilms = (listeFiltree.Take(nbFilmsParPage)).ToList<Film>();

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

        //        //GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();

        //        List<Film> listeFilms = ObtenirListeFilmsFiltree();


        //        // On retourne les n premières fiches

        //        numPage = (int)Session["numeroPage"];

        //        if (numPage > 1)
        //        {
        //            numPage--;
        //        }

        //        Session["numeroPage"] = numPage;

        //        return View("Index", listeFilms.Skip((numPage - 1) * nbFilmsParPage).Take(nbFilmsParPage));

        //    }
        //    else
        //    {
        //        return RedirectToAction("LogOn", "Account");
        //    }
        //}


        /// <summary>
        /// Application d'un filtre sur la liste des films
        /// </summary>
        /// <param name="selectedGenres">selectedGenres</param>
        /// <param name="selectedProprietaires">selectedProprietaires</param>
        /// <returns></returns>
        public ActionResult Filtrer(string[] selectedGenres, Guid[] selectedProprietaires, string nomFilm)
        {
            Session["critereNomFilm"] = nomFilm;
            Session["critereSelectedGenres"] = selectedGenres;
            Session["critereSelectedProprietaires"] = selectedProprietaires;

            List<Film> listeFiltree = ObtenirListeFilmsFiltree();

            ListeMediaViewModel model = new ListeMediaViewModel();
            model.NbPages = listeFiltree.Count / nbFilmsParPage;
            model.NbResultats = listeFiltree.Count;

            if (model.NbResultats % nbFilmsParPage > 0)
            {
                model.NbPages++;
            }

            model.ListeFilms = (listeFiltree.Take(nbFilmsParPage)).ToList<Film>();

            return View("Index", model);

        }

        /// <summary>
        /// ObtenirListeFilmsFiltree
        /// </summary>
        /// <returns></returns>
        private List<Film> ObtenirListeFilmsFiltree()
        {
            mSelectedName = (String)Session["critereNomFilm"];
            mSelectedGenres = (string[])Session["critereSelectedGenres"];
            mSelectedProprios = (Guid[])Session["critereSelectedProprietaires"];

            GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
            List<Film> liste = gestionnaireFilms.ObtenirFilms();

            if (!String.IsNullOrEmpty(mSelectedName))
            {
                liste = liste.FindAll(findName);
            }

            liste = liste.FindAll(findGenre);
            liste = liste.FindAll(findProprio);

            return liste;

        }

        /// <summary>
        /// GET: /Film/Details/5
        /// </summary>
        /// <param name="codeFilm">codeFilm</param>
        /// <returns></returns>
        public ActionResult Details(Guid codeMedia)
        {
            if (Request.IsAuthenticated)
            {
                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                Film f = gestionnaireFilms.ObtenirLeFilmComplet(codeMedia);

                MediaViewModel model = new MediaViewModel(Modele.Constantes.EnumTypeMedia.FILM);
                model.LeFilm = f;

                return View(model);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        /// <summary>
        /// GET: /Film/ListeAllocine/
        /// </summary>
        /// <param name="nomFilm">nomFilm</param>
        /// <returns></returns>
        public ActionResult ListeAllocine(string nomFilm)
        {
            if (Request.IsAuthenticated)
            {
                if (nomFilm == null || String.Empty.Equals(nomFilm))
                {
                    return RedirectToAction("Index", "Film");
                }
                else
                {
                    GestionnaireAllocine gestionnaireAllocine = new GestionnaireAllocine();

                    List<FicheFilmAllocine> liste = gestionnaireAllocine.RechercherMedia(nomFilm, Constantes.EnumTypeMediaAllocine.FILM).ObtenirListeFilms();

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
        /// <param name="codeFilmAllocine">codeFilmAllocine</param>
        /// <returns></returns>
        public ActionResult Create(string codeFilmAllocine)
        {
            if (Request.IsAuthenticated)
            {

                try
                {

                    MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.FILM);

                    mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                    mediaViewModel.ListeSupports = DataManager.ListeSupports;
                    mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.FILM);
   

                    if (String.IsNullOrEmpty(codeFilmAllocine))
                    {

                    }
                    else
                    {

                        //Ajout via Allocine

                        GestionnaireAllocine gestionnaireAllocine = new GestionnaireAllocine();


                        FicheFilmAllocine ficheAllocine = gestionnaireAllocine.ObtenirFicheFilm(codeFilmAllocine, Constantes.EnumTypeMediaAllocine.FILM);

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

                        mediaViewModel.LeFilm = new Film(ficheAllocine, genre);
                    }

                    //Sélection du propriétaire par défaut pour la création de l'exemplaire
                    mediaViewModel.LeProprietaire.Code = mediaViewModel.ListeProprietaire.Find(
                        item => item.Login.Equals(System.Web.HttpContext.Current.User.Identity.Name)).Code;


                    return View(mediaViewModel);

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "Create");
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
                    GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                    Film f = null;

                    if (Request.Form["creerExemplaire"] != null)
                    {
                        //TODO : gérer l'état
                        f = gestionnaireFilms.CreerFilmEtExemplaire(pMediaViewModel.LeFilm, pMediaViewModel.LeSupport.Code, pMediaViewModel.LeProprietaire.Code, pMediaViewModel.DateAcquisition, 0);

                        //On affiche la page du film
                        return RedirectToAction("Details", "Film", new { codeMedia = f.Code });
                    }
                    else if (Request.Form["creerSouhait"] != null)
                    {

                        f = gestionnaireFilms.CreerFilmEtSouhait(pMediaViewModel.LeFilm, pMediaViewModel.LeSupport.Code, pMediaViewModel.LeProprietaire.Code);

                    }

                    //On affiche la page du film
                    return RedirectToAction("Details", "Film", new { codeMedia = f.Code });
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "CreerFilm");
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
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.FILM);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.FILM);

                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                mediaViewModel.LeFilm = gestionnaireFilms.ObtenirLeFilmComplet(pCodeMedia);

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
                    GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();

                    gestionnaireFilms.AjouterExemplaire(
                        pMediaViewModel.LeFilm.Code,
                        pMediaViewModel.LeProprietaire.Code,
                        pMediaViewModel.Etat.Code,
                        pMediaViewModel.LeSupport.Code,
                        pMediaViewModel.DateAcquisition);

                    //On affiche la page du film
                    return RedirectToAction("Details", "Film", new { codeMedia = pMediaViewModel.LeFilm.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "CreerExemplaire");
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
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.FILM);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.FILM);

                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                mediaViewModel.LeFilm = gestionnaireFilms.ObtenirLeFilmComplet(pCodeMedia);

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
                    GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();

                    gestionnaireFilms.AjouterSouhaitAchat(
                        pMediaViewModel.LeFilm.Code,
                        pMediaViewModel.LeProprietaire.Code,
                        pMediaViewModel.LeSupport.Code);

                    //On affiche la page du film
                    return RedirectToAction("Details", "Film", new { codeMedia = pMediaViewModel.LeFilm.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "CreerSouhait");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // GET: /Film/Edit/5

        public ActionResult Edit(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.FILM);
                //GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;
                mediaViewModel.ListeGenres = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.FILM);

                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();

                mediaViewModel.LeFilm = gestionnaireFilms.ObtenirLeFilmComplet(pCodeMedia);

                return View(mediaViewModel);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Film/Edit/5

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

                        //pFilm.Icone = buffer;
                    }

                    if (Session["ContentStreamFilm"] != null)
                    {
                        int length = (int)Session["ContentLengthFilm"];
                        string type = (string)Session["ContentTypeFilm"];
                        byte[] img = (byte[])Session["ContentStreamFilm"];

                        string fichierPhoto = @"D:\Jaymz\Images\Pochettes\DVD\" + pMediaViewModel.LeFilm.Titre + ".jpg";

                        pMediaViewModel.LeFilm.Photo = pMediaViewModel.LeFilm.Titre + ".jpg";

                        FileInfo fichierImage = new FileInfo(fichierPhoto);

                        if (fichierImage.Exists)
                        {
                            fichierImage.Delete();
                        }

                        using (Image image = Image.FromStream(new MemoryStream(img)))
                        {
                            image.Save(fichierPhoto, ImageFormat.Jpeg);  // Or Png
                        }

                        Session.Remove("ContentStreamFilm");
                        Session.Remove("ContentLengthFilm");
                        Session.Remove("ContentTypeFilm");
                    }


                    //if (Session["FileName"] != null)
                    //{
                    //    //TODO : sauvegarde de l'image chargée dans un fichier ContentStreamFilm
                    //    pMediaViewModel.LeFilm.Photo = (String)Session["FileName"];
                    //}

                    GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                    gestionnaireFilms.MettreAJourFilm(pMediaViewModel.LeFilm);

                    Session.Clear();

                    return RedirectToAction("Details", "Film", new { codeMedia = pMediaViewModel.LeFilm.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "Edit");
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
                MediaViewModel mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.FILM);

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;
                mediaViewModel.ListeSupports = DataManager.ListeSupports;

                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                mediaViewModel.LeFilm = gestionnaireFilms.ObtenirLeFilmComplet(pCodeMedia);

                 mediaViewModel.Lexemplaire = mediaViewModel.LeFilm.ListeExemplaire.Find(item => item.Code == pCodeExemplaire);

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
                    GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();

                    gestionnaireFilms.ModifierExemplaire(
                        pMediaViewModel.Lexemplaire.Code,
                        pMediaViewModel.Lexemplaire.LeSupport.Code, 
                        pMediaViewModel.Lexemplaire.Etat.Code,
                        pMediaViewModel.DateAcquisition);

                    //On affiche la page du jeu
                    return RedirectToAction("Details", "Film", new { codeMedia = pMediaViewModel.LeFilm.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "ModifierExemplaire");
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
        /// <param name="pFilm">pFilm</param>
        /// <returns></returns>
        private bool findProprio(Film pFilm)
        {
            if (mSelectedProprios != null)
            {
                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                Film f = gestionnaireFilms.ObtenirLeFilmComplet(pFilm.Code);

                foreach (Guid p in mSelectedProprios)
                {
                    //Parcourt des exemplaires de ce film
                    foreach (Exemplaire el in f.ListeExemplaire)
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
            if (Session["ContentStreamFilm"] != null)
            {
                byte[] b = (byte[])Session["ContentStreamFilm"];
                int length = (int)Session["ContentLengthFilm"];
                string type = (string)Session["ContentTypeFilm"];
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
        public ActionResult Upload(HttpPostedFileBase file, MediaViewModel pFilm)
        {

            if (file != null && file.ContentLength > 0)
            {
                Session["ContentLengthFilm"] = file.ContentLength;
                Session["FileName"] = file.FileName;
                Session["ContentTypeFilm"] = file.ContentType;
                byte[] b = new byte[file.ContentLength];
                file.InputStream.Read(b, 0, file.ContentLength);
                Session["ContentStreamFilm"] = b;

            }

            return RedirectToAction("Edit", new { pCodeMedia = pFilm.LeFilm.Code });
        }


    }
}
