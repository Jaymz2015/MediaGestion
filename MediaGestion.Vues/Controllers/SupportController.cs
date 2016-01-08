using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaGestion.Metier.Bl.Blo.Impl;
using MediaGestion.Modele.Dl.Dlo;
using System.IO;
using System.Drawing;
using MediaGestion.Vues.Helper;

namespace MediaGestion.Vues.Controllers
{
    public class SupportController : Controller
    {
        //
        // GET: /Support/
        public ActionResult Index()
        {
            Session.Clear();
            return View(DataManager.ListeSupports);
        }

        //
        // GET: /Support/Details/5
        public ActionResult Details(string pCode)
        {
            Support support = DataManager.ListeSupports.Find(item => item.Code == pCode);
            return View(support);
        }

        //
        // GET: /Support/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Support/Create
        [HttpPost]
        public ActionResult Create(Support pSupport)
        {
            try
            {
                GestionnaireSupports gestionnaireSupports = new GestionnaireSupports();
                DataManager.ListeSupports = gestionnaireSupports.AjouterSupport(pSupport);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Support", "Create");
                return View("Error", error);
            }
        }

        //
        // GET: /Support/Edit/5
        public ActionResult Edit(String pCode)
        {
            Support support = DataManager.ListeSupports.Find(item => item.Code == pCode);
            return View(support);
        }

        //
        // POST: /Support/Edit/5
        [HttpPost]
        public ActionResult Edit(Support pSupport)
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

                    pSupport.Icone = buffer;
                }

                if (Session["ContentStreamSupport"] != null)
                {
                    pSupport.Icone = (byte[])Session["ContentStreamSupport"];
                }

                GestionnaireSupports gestionnaireSupports = new GestionnaireSupports();
                DataManager.ListeSupports = gestionnaireSupports.MettreAJourSupport(pSupport);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Support", "Edit");
                return View("Error", error);
            }
        }

        //
        // GET: /Support/Delete/5
        public ActionResult Delete(String pCode)
        {
            Support support = DataManager.ListeSupports.Find(item => item.Code == pCode);
            return View(support);
        }

        //
        // POST: /Support/Delete/5
        [HttpPost]
        public ActionResult Delete(String pCode, FormCollection collection)
        {
            try
            {
                GestionnaireSupports gestionnaireSupports = new GestionnaireSupports();
                DataManager.ListeSupports = gestionnaireSupports.SupprimerSupport(pCode);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Support", "Delete");
                return View("Error", error);
            }
        }

        //Appuie sur le bouton upload : on stocke l'image dans la session
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, Support pSupport)
        {

            if (file != null && file.ContentLength > 0)
            {
                Session["ContentLengthSupport"] = file.ContentLength;
                Session["ContentTypeSupport"] = file.ContentType;
                byte[] b = new byte[file.ContentLength];
                file.InputStream.Read(b, 0, file.ContentLength);
                Session["ContentStreamSupport"] = b;

            }

            return RedirectToAction("Edit", new { pCode = pSupport.Code });
        }

        public ActionResult ThumbImage(string pCodeSupport)
        {
            Image img = null;
            ImageResult imageResult = null;

            try
            {
                Support support = DataManager.ListeSupports.Find(item => item.Code == pCodeSupport);

                if (support.Icone != null)
                {
                    MemoryStream ms = new MemoryStream(support.Icone);

                    using (Image tempImage = Image.FromStream(ms))
                    {
                        imageResult = new ImageResult(tempImage, 200, tempImage.Height);
                    }
                }

                return imageResult;
            }
            catch (Exception)
            {
                img = new Bitmap(1, 1);
                return new ImageResult(img, 1, 1);
            }
            finally
            {
                if (img != null) img.Dispose();
            }
        }

        /// <summary>
        /// On retourne la photo stockee dans la session suite chargement
        /// </summary>
        /// <param name="pCodeSupport">pCodeSupport</param>
        /// <returns>ActionResult</returns>
        public ActionResult ShowPhoto(string pCodeSupport)
        {
            if (Session["ContentStreamSupport"] != null)
            {
                byte[] b = (byte[])Session["ContentStreamSupport"];
                int length = (int)Session["ContentLengthSupport"];
                string type = (string)Session["ContentTypeSupport"];
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
            else if (pCodeSupport != null)
            {
                return ThumbImage(pCodeSupport);
            }
            else 

            return Content("");
        }

    }
}
