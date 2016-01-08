using System.Web.Mvc;
using System.Web.UI;


namespace MediaGestion.Vues.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //NOTE : LA VUE DOIT PORTER LE MEME NOM QUE LA METHODE QUI DOIT ETRE APPELEE LA PREMIERE FOIS
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Film", new { pNumeroPage = 1 });
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

    }
}
