using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MediaGestion.Metier.Bl.Blo.Impl;

namespace MediaGestion.Vues
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.IgnoreRoute("image.axd");


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        /// <summary>
        /// Démarrage de l'appli
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            GestionnaireGenres gestionnaireGenres = new GestionnaireGenres();
            GestionnaireSupports gestionnaireSupports = new GestionnaireSupports();
            GestionnaireProprietaires gestionnaireProprietaires = new GestionnaireProprietaires();
            GestionnaireMachines gestionnaireMachines = new GestionnaireMachines();
            GestionnaireEtatsMedia gestionnaireEtatsMedia = new GestionnaireEtatsMedia();

            DataManager.ListeGenre = gestionnaireGenres.ObtenirGenres();
            DataManager.ListeSupports = gestionnaireSupports.ObtenirSupports();
            DataManager.ListeProprietaires = gestionnaireProprietaires.ObtenirProprietaires();
            DataManager.ListeMachines = gestionnaireMachines.ObtenirMachines();
            DataManager.ListeEtatsMedia = gestionnaireEtatsMedia.ObtenirEtatsMedia();
        }
    }
}