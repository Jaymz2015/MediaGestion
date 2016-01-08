using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaGestion.Metier.Bl.Blo.Impl;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.Metier;
using System.Web.UI;
using MediaGestion.Vues.Models;

namespace MediaGestion.Vues.Controllers
{
    public class ProprietaireController : Controller
    {
        //
        // GET: /Proprietaire/

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(DataManager.ListeProprietaires);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
            
        }

        //
        // GET: /Proprietaire/Details/5

        public ActionResult Details(Guid pCode)
        {

            if (Request.IsAuthenticated)
            {

                Proprietaire proprietaire = DataManager.ListeProprietaires.Find(item => item.Code == pCode);

                GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();

                proprietaire.ListeSouhaits = gestionnaireFilms.ObtenirSouhaitsProprietaire(proprietaire.Code);

                List<Emprunt> listeEmprunts = gestionnaireFilms.ObtenirEmpruntsProprietaire(proprietaire.Code);

                proprietaire.ListeEmpruntsEnCours = listeEmprunts.Where<Emprunt>(item => item.DateRendu.Year <= 1900).ToList<Emprunt>();
                proprietaire.ListeEmpruntsClos = listeEmprunts.Where<Emprunt>(item => item.DateRendu.Year > 1900).ToList<Emprunt>();

                return View(proprietaire);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }


        }


        //
        // GET: /Proprietaire/Create

        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                //TODO
                return View();
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }

            
        } 

        //
        // POST: /Proprietaire/Create

        [HttpPost]
        public ActionResult Create(Proprietaire pProprietaire)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();

                    //Mise à jour de la liste en mémoire
                    DataManager.ListeProprietaires = gestionnaireProprietaires.AjouterProprietaire(pProprietaire);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Proprietaire", "Create");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }


            
        }
        
        //
        // GET: /Proprietaire/Edit/5
 
        public ActionResult Edit(Guid pCode, String pLogin)
        {
            if (Request.IsAuthenticated)
            {
                if (User.Identity.Name.Equals(pLogin))
                {
                    //Seul le propriétaire peut se modifier

                    Proprietaire proprietaire = DataManager.ListeProprietaires.Find(item => item.Code == pCode);

                    ProprietaireViewModel proprietaireViewModel = new ProprietaireViewModel(proprietaire);


                    return View(proprietaireViewModel);

                }
                else
                {
                    HandleErrorInfo error = new HandleErrorInfo(new Exception("Vous n'avez pas le droit de modifier un autre profil"), "Proprietaire", "Edit");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }    
        }





        //
        // POST: /Proprietaire/Edit/5

        [HttpPost]
        public ActionResult Edit(ProprietaireViewModel pProprietaire)
        {
            if (Request.IsAuthenticated)
            {

                try
                {
                    GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();

                    Proprietaire p = new Proprietaire();
                    p.Code = pProprietaire.Code;
                    p.Adresse = pProprietaire.Adresse;
                    p.CP = pProprietaire.CP;
                    
                    p.Login = pProprietaire.Login;
                    p.Nom = pProprietaire.Nom;
                    p.Prenom = pProprietaire.Prenom;
                    p.Ville = pProprietaire.Ville;
                    p.PasswordHash = pProprietaire.PasswordHash;

                    if (!String.IsNullOrEmpty(pProprietaire.NewPassword)) {
                        
                        if (!p.VerifyHash(pProprietaire.OldPassword)) {

                            throw new Exception("L'ancien mot de passe est erroné");
                        }

                        if (String.IsNullOrEmpty(pProprietaire.ConfirmPassword) || !pProprietaire.ConfirmPassword.Equals(pProprietaire.NewPassword)) {
                        
                            throw new Exception("Le mot de passe de confirmation n'est pas identique au nouveau mot de passe");
                        }
                    }


                    //Mise à jour de la liste en mémoire
                    DataManager.ListeProprietaires = gestionnaireProprietaires.ModifierProprietaire(p, p.CalculateHash(pProprietaire.NewPassword));

                    return RedirectToAction("Details", new { pCode = pProprietaire.Code });

                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Proprietaire", "Edit");
                    return View("Error", error);
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }


        }

        //
        // GET: /Proprietaire/Delete/5
 
        public ActionResult Delete(Guid pCode)
        {
            if (Request.IsAuthenticated)
            {
                //Proprietaire proprio = null;

                //HttpContextWrapper httpContextWrapper = new HttpContextWrapper(System.Web.HttpContext.Current);

                //if (httpContextWrapper != null && httpContextWrapper.Session["proprietaire"] != null)
                //{
                //    proprio = (Proprietaire)httpContextWrapper.Session["proprietaire"];
                //}
                
               
                GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();
                Proprietaire proprio = gestionnaireProprietaires.ObtenirProprietaire(System.Web.HttpContext.Current.User.Identity.Name);

                //Si le user connecté souhaite supprimer sa fiche OK, sinon KO
                if (pCode.Equals(proprio.Code))
                {
                    Proprietaire proprietaire = DataManager.ListeProprietaires.Find(item => item.Code == pCode);
                    return View(proprietaire);
                } else {
                    Exception ex = new Exception("Vous n'êtes pas autorisé à effectuer cette action !");
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Proprietaire", "Delete");
                    return View("Error", error); 
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }    
        }

        //
        // POST: /Proprietaire/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid pCode, FormCollection collection)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();

                    //Mise à jour de la liste en mémoire
                    DataManager.ListeProprietaires = gestionnaireProprietaires.SupprimerProprietaire(pCode);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    HandleErrorInfo error = new HandleErrorInfo(ex, "Proprietaire", "Delete");
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
