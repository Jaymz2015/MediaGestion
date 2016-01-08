using System;
using System.Web;
using MediaGestion.Metier;
using MediaGestion.Modele.Dl.Dlo;
using System.Drawing;
using System.Web.Mvc;
using System.Web.Routing;

namespace MediaGestion.Vues.Handler
{
    public class ImageHandler : MvcHandler
    {

        public ImageHandler(RequestContext requestContext) : base(requestContext)
        {
            GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
        }

        #region IHttpHandler Members

        protected override bool IsReusable
        {
            get { return true; }
        }

        //protected override void ProcessRequest(HttpContext context)
        //{
        //    //Récupération du site internet
        //    Guid codeFilm = new Guid(context.Request.QueryString["codeFilm"]);
        //    GestionnaireFilms gestionnaireFilms = new GestionnaireFilms();
        //    gestionnaireFilms.ObtenirFilms();


    
        //    Film leFilm = gestionnaireFilms.ObtenirLeFilm(codeFilm);

        //    // Chargement de l'image
        //    Image img = Image.FromFile(@"D:\Jaymz\Images\Pochettes\DVD\" + leFilm.Photo);
        //    // Resalisation de la miniature en 100x100
        //    img = img.GetThumbnailImage(100, 100, null, IntPtr.Zero);
        //    // Envoie de l'image au client
        //    img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    // Liberer les ressources
        //    img.Dispose();
        //}

        #endregion


    }
}
