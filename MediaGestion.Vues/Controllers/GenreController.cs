using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaGestion.Metier.Bl.Blo.Impl;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.Vues.Models;
using System.IO;

namespace MediaGestion.Vues.Controllers
{
    public class GenreController : Controller
    {
        //
        // GET: /Genre/

        public ActionResult Index()
        {
            return View(DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.TOUT));
        }

        //
        // GET: /Genre/Details/5

        public ActionResult Details(string pCode)
        {
            Genre genre = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.TOUT).Find(item => item.Code == pCode);
            return View(genre);
        }

        //
        // GET: /Genre/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Genre/Create

        [HttpPost]
        public ActionResult Create(Genre pGenre)
        {
            try
            {
                GestionnaireGenres gestionnaireGenres = new GestionnaireGenres();
                
                //Mise à jour de la liste en mémoire
                DataManager.ListeGenre = gestionnaireGenres.AjouterGenre(pGenre);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Genre", "Create");
                return View("Error", error);
            }
        }
        
        //
        // GET: /Genre/Edit/5

        public ActionResult Edit(String pCode)
        {
            Genre genre = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.TOUT).Find(item => item.Code == pCode);
            return View(new GenreViewModel(genre));
        }

        //
        // POST: /Genre/Edit/5

        [HttpPost]
        public ActionResult Edit(GenreViewModel pGenreViewModel)
        {
            try
            {
                Genre g = new Genre();
                g.Code = pGenreViewModel.Code;
                g.Libelle = pGenreViewModel.Libelle;

                GestionnaireGenres gestionnaireGenres = new GestionnaireGenres();
                //Mise à jour de la liste en mémoire
                DataManager.ListeGenre = gestionnaireGenres.MettreAJourGenre(g, pGenreViewModel.OldCode);
 
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Genre", "Edit");
                return View("Error", error);
            }
        }


        [HttpPost]
        public ActionResult Upload()
        {
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength > 0)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads")
                            , Path.GetFileName(file.FileName));
                    file.SaveAs(filePath);
                }
            }

            //return RedirectToAction("Edit","Edit", new { pCode = item.Code });
            return RedirectToAction("Edit");
        }

        //
        // GET: /Genre/Delete/5

        public ActionResult Delete(String pCode)
        {
            Genre genre = DataManager.ObtenirListeGenre(Modele.Constantes.EnumTypeMedia.TOUT).Find(item => item.Code == pCode);
            return View(genre);
        }

        //
        // POST: /Genre/Delete/5

        [HttpPost]
        public ActionResult Delete(String pCode, FormCollection collection)
        {
            try
            {
                GestionnaireGenres gestionnaireGenres = new GestionnaireGenres();

                //Mise à jour de la liste en mémoire
                DataManager.ListeGenre = gestionnaireGenres.SupprimerGenre(pCode);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Genre", "Delete");
                return View("Error", error);
            }
        }
    }
}
