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
using System.Globalization;

namespace MediaGestion.Vues.Controllers
{
    public class MediaController : Controller
    {
        protected string mSelectedName;
        protected string[] mSelectedGenres;

        /// <summary>
        /// Filtre par nom 
        /// </summary>
        /// <param name="pFilm">pMedia</param>
        /// <returns></returns>
        protected bool findName(Media pMedia)
        {
            if (!String.IsNullOrEmpty(mSelectedName))
            {
                if (pMedia.Titre.ToUpperInvariant().Replace(" ", "").Contains(mSelectedName.ToUpperInvariant().Replace(" ", "")))
                {
                    return true;
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
        /// Filtre par genre 
        /// </summary>
        /// <param name="pJeu">pJeu</param>
        /// <returns></returns>
        protected bool findGenre(Media pMedia)
        {
            if (mSelectedGenres != null)
            {
                foreach (string g in mSelectedGenres)
                {
                    if (g.ToUpper().Equals(pMedia.LeGenre.Code.ToUpper()))
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

        //
        // GET: /Media/DeleteExemplaire/5

        public ActionResult DeleteExemplaire(Guid pCodeMedia, Guid pCodeExemplaire)
        {
            if (Request.IsAuthenticated)
            {
                GestionnaireMedias gestionnaireMedias = new GestionnaireMedias();

                Media media = gestionnaireMedias.ObtenirMedia(pCodeMedia);

                Exemplaire expl = gestionnaireMedias.ObtenirExemplaire(pCodeExemplaire);

                MediaViewModel model = new MediaViewModel(media.TypeMedia);
                model.LeMedia = media;

                expl.LeMedia = media;

                model.Lexemplaire = expl;

                return View(model);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Media/DeleteExemplaire/5

        [HttpPost]
        public ActionResult DeleteExemplaire(Guid pCodeMedia, Guid pCodeExemplaire, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireMedias gestionnaireMedias = new GestionnaireFilms();
                    gestionnaireMedias.SupprimerExemplaire(pCodeExemplaire);

                    Media m = gestionnaireMedias.ObtenirMedia(pCodeMedia);

                    switch (m.TypeMedia)
                    {
                        case MediaGestion.Modele.Constantes.EnumTypeMedia.TOUT:
                            throw new Exception("Cas non géré");
                        case MediaGestion.Modele.Constantes.EnumTypeMedia.FILM:
                            return RedirectToAction("Details", "Film", new { codeMedia = pCodeMedia });
                        case MediaGestion.Modele.Constantes.EnumTypeMedia.JEU:
                            return RedirectToAction("Details", "Jeu", new { codeMedia = pCodeMedia });
                        default:
                            throw new Exception("Cas non géré");
                    }
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "DeleteExemplaire");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // GET: /Media/DeleteSouhait/5
        public ActionResult DeleteSouhait(Guid pCodeMedia, Guid pCodeSouhait)
        {
            if (Request.IsAuthenticated)
            {
                GestionnaireMedias gestionnaireMedias = new GestionnaireMedias();

                Media media = gestionnaireMedias.ObtenirMedia(pCodeMedia);

                Exemplaire expl = gestionnaireMedias.ObtenirSouhaitAchat(pCodeSouhait);

                MediaViewModel model = new MediaViewModel(media.TypeMedia);

                model.LeMedia = media;

                expl.LeMedia = media;
                
                model.Lexemplaire = expl;

                return View(model);

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Media/DeleteSouhait/5
        [HttpPost]
        public ActionResult DeleteSouhait(Guid pCodeMedia, Guid pCodeSouhait, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireMedias gestionnaireMedias = new GestionnaireFilms();
                    gestionnaireMedias.SupprimerSouhaitAchat(pCodeSouhait);

                    Media m = gestionnaireMedias.ObtenirMedia(pCodeMedia);

                    switch (m.TypeMedia)
                    {
                        case MediaGestion.Modele.Constantes.EnumTypeMedia.TOUT:
                            throw new Exception("Cas non géré");
                        case MediaGestion.Modele.Constantes.EnumTypeMedia.FILM:
                            return RedirectToAction("Details", "Film", new { codeMedia = pCodeMedia });
                        case MediaGestion.Modele.Constantes.EnumTypeMedia.JEU:
                            return RedirectToAction("Details", "Jeu", new { codeMedia = pCodeMedia });
                        default:
                            throw new Exception("Cas non géré");
                    }

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Film", "DeleteSouhait");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }


        //Create Emprunt
        //
        // GET: /Home/CreerEmprunt
        public ActionResult CreerEmprunt(Guid pCodeMedia, Guid pCodeExemplaire, MediaGestion.Modele.Constantes.EnumTypeMedia pTypeMedia)
        {
            if (Request.IsAuthenticated)
            {

                GestionnaireMedias gestionnaireMedias = new GestionnaireMedias();
   
                MediaViewModel mediaViewModel = null;

                switch (pTypeMedia)
                {
                    case MediaGestion.Modele.Constantes.EnumTypeMedia.TOUT:
                        break;
                    case MediaGestion.Modele.Constantes.EnumTypeMedia.FILM:
                        mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.FILM);

                        GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
                        mediaViewModel.LeFilm = gestionnaireFilms.ObtenirLeFilmComplet(pCodeMedia);


                        break;
                    case MediaGestion.Modele.Constantes.EnumTypeMedia.JEU:
                        mediaViewModel = new MediaViewModel(Modele.Constantes.EnumTypeMedia.JEU);

                        GestionnaireJeux gestionnaireJeux = new GestionnaireJeux();
                        mediaViewModel.LeJeu = gestionnaireJeux.ObtenirLeJeuComplet(pCodeMedia);

                        break;
                    default:
                        break;
                }

                mediaViewModel.ListeProprietaire = DataManager.ListeProprietaires;

                mediaViewModel.Lexemplaire = mediaViewModel.LeMedia.ListeExemplaire.Find(item => item.Code == pCodeExemplaire);

                mediaViewModel.LeProprietaire = mediaViewModel.Lexemplaire.LeProprietaire;
                mediaViewModel.LeSupport = mediaViewModel.Lexemplaire.LeSupport;

                return View(mediaViewModel);
          
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Home/CreerEmprunt

        [HttpPost]
        public ActionResult CreerEmprunt(MediaViewModel pMediaViewModel)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireMedias gestionnaireMedias = new GestionnaireMedias();

                    gestionnaireMedias.AjouterEmprunt(
                        pMediaViewModel.Lexemplaire.Code,
                        pMediaViewModel.Lemprunteur);

                    //On affiche la page du film
                    return RedirectToAction("Details", pMediaViewModel.NomControlleur, new { codeMedia = pMediaViewModel.LeMedia.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, pMediaViewModel.NomControlleur, "CreerExemplaire");
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
        // GET: /Home/CreerEmprunt
        public ActionResult CloreEmprunt(Guid pCodeMedia, Guid pCodeEmprunt, MediaGestion.Modele.Constantes.EnumTypeMedia pTypeMedia)
        {
            if (Request.IsAuthenticated)
            {

                GestionnaireMedias gestionnaireMedias = new GestionnaireMedias();

                string nomControlleur = String.Empty;

                switch (pTypeMedia)
                {
                    case MediaGestion.Modele.Constantes.EnumTypeMedia.TOUT:
                        break;
                    case MediaGestion.Modele.Constantes.EnumTypeMedia.FILM:
                        nomControlleur = "Film";
                        break;
                    case MediaGestion.Modele.Constantes.EnumTypeMedia.JEU:
                        nomControlleur = "Jeu";
                        break;
                    default:
                        break;
                }

                if (gestionnaireMedias.CloreEmprunt(pCodeEmprunt))
                {
                    return RedirectToAction("Details", nomControlleur, new { codeMedia = pCodeMedia });

                }
                else
                {
                    HandleErrorInfo error = new HandleErrorInfo(new Exception("Erreur lors de la cloture de l'emprunt"), nomControlleur, "CloreEmprunt");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }


        //
        // GET: /Film/Delete/5

        public ActionResult Delete(Guid pCodeMedia)
        {
            if (Request.IsAuthenticated)
            {
                Proprietaire proprio = new GestionnaireProprietaires().ObtenirProprietaire(System.Web.HttpContext.Current.User.Identity.Name);

                if (proprio.Habilitation == Proprietaire.enmHabilitation.ADMINISTRATEUR)
                {
                    GestionnaireMedias gestionnaireMedias = new GestionnaireMedias();
                    Media m = gestionnaireMedias.ObtenirMedia(pCodeMedia);

                    MediaViewModel modele = new MediaViewModel(m.TypeMedia);

                    modele.LeMedia = m;

                    return View(modele);

                }
                else
                {
                    Exception ex = new Exception("Vous n'êtes pas autorisé à effectuer cette action !");
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Media", "Delete");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        //
        // POST: /Film/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid pCodeMedia, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {

                try
                {
                    GestionnaireMedias gestionnaireMedias = new GestionnaireFilms();
                    gestionnaireMedias.SupprimerMedia(pCodeMedia);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Media", "Delete");
                    return View("Error", error);
                }

            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }



    }
}
