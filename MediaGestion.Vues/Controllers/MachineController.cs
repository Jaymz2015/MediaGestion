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
using MediaGestion.Vues.Models;

namespace MediaGestion.Vues.Controllers
{
    public class MachineController : Controller
    {
        //
        // GET: /Machine/
        public ActionResult Index()
        {
            Session.Clear();
            return View(DataManager.ListeMachines);
        }

        //
        // GET: /Machine/Details/5
        public ActionResult Details(string pCode)
        {
            Machine machine = DataManager.ListeMachines.Find(item => item.Code == pCode);
            return View(machine);
        }

        //
        // GET: /Machine/Create
        public ActionResult Create()
        {
            return View(new Machine());
        }

        //
        // POST: /Machine/Create
        [HttpPost]
        public ActionResult Create(Machine pMachine)
        {
            try
            {
                GestionnaireMachines gestionnaireMachines = new GestionnaireMachines();
                DataManager.ListeMachines = gestionnaireMachines.AjouterMachine(pMachine);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Machine", "Create");
                return View("Error", error);
            }
        }

        //
        // GET: /Machine/Edit/5
        public ActionResult Edit(String pCode)
        {
            Machine machine = DataManager.ListeMachines.Find(item => item.Code == pCode);

            MachineViewModel model = new MachineViewModel();
            model.LaMachine = machine;
            model.OldCode = machine.Code;
            return View(model);
        }

        //
        // POST: /Machine/Edit/5
        [HttpPost]
        public ActionResult Edit(MachineViewModel model)
        {
            try
            {
                string test = "test";


                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];

                    byte[] buffer = new byte[file.ContentLength];
                    file.InputStream.Read(buffer, 0, file.ContentLength);

                    model.LaMachine.Logo = buffer;
                }

                if (Session["ContentStreamLogo"] != null)
                {
                    model.LaMachine.Logo = (byte[])Session["ContentStreamLogo"];
                }

                if (Session["ContentStreamMachine"] != null)
                {
                    model.LaMachine.Photo = (byte[])Session["ContentStreamMachine"];
                }

                GestionnaireMachines gestionnaireMachines = new GestionnaireMachines();
                DataManager.ListeMachines = gestionnaireMachines.MettreAJourMachine(model.LaMachine, model.OldCode);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Machine", "Edit");
                return View("Error", error);
            }
        }

        //
        // GET: /Machine/Delete/5
        public ActionResult Delete(String pCode)
        {
            Machine support = DataManager.ListeMachines.Find(item => item.Code == pCode);
            return View(support);
        }

        //
        // POST: /Machine/Delete/5
        [HttpPost]
        public ActionResult Delete(String pCode, FormCollection collection)
        {
            try
            {
                GestionnaireMachines gestionnaireMachines = new GestionnaireMachines();
                DataManager.ListeMachines = gestionnaireMachines.SupprimerMachine(pCode);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "Machine", "Delete");
                return View("Error", error);
            }
        }

        //Appuie sur le bouton upload : on stocke l'image dans la session
        [HttpPost]
        public ActionResult UploadLogo(HttpPostedFileBase file, MachineViewModel model)
        {

            if (file != null && file.ContentLength > 0)
            {
                Session["ContentLengthLogo"] = file.ContentLength;
                Session["ContentTypeLogo"] = file.ContentType;
                byte[] b = new byte[file.ContentLength];
                file.InputStream.Read(b, 0, file.ContentLength);
                Session["ContentStreamLogo"] = b;

            }

            return RedirectToAction("Edit", new { pCode = model.LaMachine.Code });
        }

        //Appuie sur le bouton upload : on stocke l'image dans la session
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, MachineViewModel model)
        {

            if (file != null && file.ContentLength > 0)
            {
                Session["ContentLengthMachine"] = file.ContentLength;
                Session["ContentTypeMachine"] = file.ContentType;
                byte[] b = new byte[file.ContentLength];
                file.InputStream.Read(b, 0, file.ContentLength);
                Session["ContentStreamMachine"] = b;

            }

            return RedirectToAction("Edit", new { pCode = model.LaMachine.Code });
        }

        /// <summary>
        /// On retourne la photo stockee dans la session suite chargement
        /// </summary>
        /// <param name="pCodeMachine">pCodeMachine</param>
        /// <returns>ActionResult</returns>
        public ActionResult ShowLogo(string pCodeMachine, int pTaille)
        {
            if (Session["ContentStreamLogo"] != null)
            {
                byte[] b = (byte[])Session["ContentStreamLogo"];
                int length = (int)Session["ContentLengthLogo"];
                string type = (string)Session["ContentTypeLogo"];
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
            else if (pCodeMachine != null)
            {
                return ThumbImage(pCodeMachine, pTaille);
            }
            else 

            return Content("");
        }

        /// <summary>
        /// On retourne la photo stockee dans la session suite chargement
        /// </summary>
        /// <param name="pCodeMachine">pCodeMachine</param>
        /// <returns>ActionResult</returns>
        public ActionResult ShowPhoto(string pCodeMachine, int pTaille)
        {
            if (Session["ContentStreamMachine"] != null)
            {
                byte[] b = (byte[])Session["ContentStreamMachine"];
                int length = (int)Session["ContentLengthMachine"];
                string type = (string)Session["ContentTypeMachine"];
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
            else if (pCodeMachine != null)
            {
                return ThumbPhoto(pCodeMachine, pTaille);
            }
            else

                return Content("");
        }

        /// <summary>
        /// ThumbImage
        /// </summary>
        /// <param name="pCodeMachine">pCodeMachine</param>
        /// <returns>ActionResult</returns>
        public ActionResult ThumbImage(string pCodeMachine, int pTaille)
        {
            Image img = null;
            ImageResult imageResult = null;

            try
            {
                Machine machine = DataManager.ListeMachines.Find(item => item.Code == pCodeMachine);

                if (machine.Logo != null)
                {
                    MemoryStream ms = new MemoryStream(machine.Logo);

                    using (Image tempImage = Image.FromStream(ms))
                    {
                        imageResult = new ImageResult(tempImage, pTaille, tempImage.Height);
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
        /// ThumbImage
        /// </summary>
        /// <param name="pCodeMachine">pCodeMachine</param>
        /// <returns>ActionResult</returns>
        public ActionResult ThumbPhoto(string pCodeMachine, int pTaille)
        {
            Image img = null;
            ImageResult imageResult = null;

            try
            {
                Machine machine = DataManager.ListeMachines.Find(item => item.Code == pCodeMachine);

                if (machine.Logo != null)
                {
                    MemoryStream ms = new MemoryStream(machine.Photo);

                    using (Image tempImage = Image.FromStream(ms))
                    {
                        imageResult = new ImageResult(tempImage, pTaille, tempImage.Height);
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

    }
}
