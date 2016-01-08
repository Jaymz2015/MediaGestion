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
                return dateSortie;
            }
            set
            {
                dateSortie = value;
            }
        }

        public Constantes.EnumTypeMachine TypeMachine { get; set; }

        [XmlElement("id_machine")]
        public string id_machine { get; set; }

        /// <summary>
        /// Machine
        /// </summary>
        public string Machine {

            get
            {
                TypeMachine = (Constantes.EnumTypeMachine)(Int32.Parse(id_machine));

                switch(TypeMachine) {

                    case Constantes.EnumTypeMachine.PC:
                        return "PC";
                    case Constantes.EnumTypeMachine.DREAMCAST:
                        return "Dreamcast";
                    case Constantes.EnumTypeMachine.WII:
                        return "Wii";
                    case Constantes.EnumTypeMachine.MEGADRIVE:
                        return "Megadrive";
                    case Constantes.EnumTypeMachine.MASTERSYSTEM:
                        return "Master System";
                    case Constantes.EnumTypeMachine.GAMECUBE:
                        return "Game Cube";
                    case Constantes.EnumTypeMachine.GAMEGEAR:
                        return "Game Gear";
                    case Constantes.EnumTypeMachine.INCONNU:
                        return "";
                    default:
                        return "";

                }

            }
            
        }


        [XmlElement("editeur")]
        public string Editeur { get; set; }

        [XmlElement("developpeur")]
        public string Developpeur { get; set; }

        [XmlElement("type")]
        public string Genre { get; set; }

        [XmlElement("synopsys")]
        public string Description { get; set; }

        //public string UrlSimple { get; set; }
        //public string UrlDetaille { get; set; }

        [XmlElement("url_jv")]
        public string UrlJVC { get; set; }
        
        [XmlElement("vignette")]     
        public string UrlVignette { get; set; }

        [XmlElement("vignette_grande")]
        public string UrlVignetteGrande
        {
            get
            {
                return UrlVignette.Replace("-xs", "");
            }

        }

        public string UrlPhoto { get; set; }

        public int Note { get; set; }

        public string NomPhoto { get; set; }

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
