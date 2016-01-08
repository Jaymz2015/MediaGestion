using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using System.IO;
using LibAllocine.Helper;

namespace LibAllocine.Dl.Dto
{
    [XmlRoot(ElementName = "jeu")]
    [Serializable]
    public class FicheJeuJVC
    {
        private string dateSortie;
        private string codeJeu;

        public string CodeJeu
        {
            get
            {
                if (UrlSimple != "")
                {
                    codeJeu = UrlSimple;
                    codeJeu = codeJeu.Replace("http://ws.jeuxvideo.com/01.jeux/", "");
                    codeJeu = codeJeu.Replace(".xml", "");
                }
                
                return codeJeu;
            }
            set
            {
                codeJeu = value;
            }
        }

        [XmlElement("titre")]
        public string Titre {get; set;}

        [XmlElement("date_sortie")]
        public string DateSortie
        {
            get
            {
                if (dateSortie.Contains("communiquée"))
                {
                    return "-";
                }
                else if (dateSortie.Length > 4)
                {
                    return dateSortie.Substring(dateSortie.Length - 4, 4);
                }
                else
                {
                    return dateSortie;
                }
            }
            set
            {
                dateSortie = value;
            }
        }

        public string Machine { get; set; }

        [XmlElement("editeur")]
        public string Editeur { get; set; }

        [XmlElement("developpeur")]
        public string Developpeur { get; set; }

        [XmlElement("type")]
        public string Genre { get; set; }

        [XmlElement("resume")]
        public string Description { get; set; }

        public string UrlSimple { get; set; }
        public string UrlDetaille { get; set; }

        [XmlElement("vignette")]     
        public string UrlVignette { get; set; }

        public string UrlJaquette { get; set; }

        public int Note { get; set; }

        public string NomJaquette { get; set; }

        public override string ToString()
        {
            return Titre + " | " + Machine + " | " + DateSortie;
        }

        /// <summary>
        /// Récupération de l'imagette
        /// </summary>
        /// <returns></returns>
        public Image ObtenirThumbnail()
        {

            Image img = null;
            Image thumb = null;
            MemoryStream stream = null;

            try
            {
                // Téléchargement de l'image
                stream = UtilsAllocine.DownloadData(UrlVignette);

                // On limite la durée de vie de img
                using (img = Image.FromStream(stream))
                {
                    Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(UtilsAllocine.ThumbnailCallback);

                    int newWidth = (int)img.Width / 10;
                    int newHeight = (int)img.Height / 10;

                    thumb = img.GetThumbnailImage(Constantes.LargeurThumbnails, Constantes.HauteurThumbnails, myCallback, IntPtr.Zero);
                }

                return thumb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

    }
}
