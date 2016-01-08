using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Net;
using LibAllocine.Helper;

namespace LibAllocine.Dl.Dto
{
    //12/03/2013 : prise en compte du format JSON, le format XML n'étant plus retourné
    //[XmlRoot(ElementName="movie", Namespace="http://www.allocine.net/v6/ns/")]
    [XmlRoot(ElementName = "movie")]
    [Serializable]
    public class FicheFilmAllocine
    {
        public static string KS_NOM_MODULE = "LibAllocine - FicheFilmAllocine - ";

        [XmlElement("code")]
        public string Code;

        [XmlElement("originalTitle")]
        public string TitreOriginal { get; set; }

        private string mTitre;

        [XmlElement("title")]
        public string Titre
        {
            get
            {
                if (mTitre == null)
                {
                    return TitreOriginal;
                }
                else
                {
                    return mTitre;
                }

            }

            set
            {
                mTitre = value;
            }

        }


        [XmlElement("productionYear")]
        public int AnneeProduction { get; set; }

        [XmlElement("runtime")]
        public int Duree { get; set; }
       
        [XmlElement("synopsis")]
        public string LeSynopsis;

        //[XmlElement("linkList")]
        //public LinkList ListeURLs;

        [XmlElement("link")]
        public Link UrlFiche;

        [XmlElement("statistics")]
        public Statistics Statistiques;

        [XmlElement("castingShort")]
        public CastingShort Casting;

        [XmlElement("release")]
        public Release InfosSortie;

        [XmlElement("poster")]
        public Poster LaPhoto;

        //[XmlElement("genreList")]
        //public GenreList ListeGenres;

        [XmlElement("genre")]
        public Genre LeGenre;

        public string NomPhoto { get; set; }

        /// <summary>
        /// Récupération de l'imagette
        /// </summary>
        /// <returns></returns>
        public Image ObtenirThumbnail(){

            Image img = null;
            Image thumb = null;
            MemoryStream stream = null;

            try
            {
                // Téléchargement de l'image
                stream = UtilsAllocine.DownloadData(LaPhoto.Url);

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

     
       
        #region Classes internes

        [XmlRoot("linkList")]
        [Serializable]
        public class LinkList
        {
            [XmlElement("link")]
            public Link Lien;

            [XmlRoot("link")]
            [Serializable]
            public class Link
            {
                [XmlElement("href")]
                public string Url;
            }
        }

        [XmlRoot("link")]
        [Serializable]
        public class Link
        {
            [XmlElement("href")]
            public string Url;
        }

        [XmlRoot("statistics")]
        [Serializable]
        public class Statistics
        {
            [XmlElement("pressRating")]
            public float NotePresse;

            [XmlElement("userRating")]
            public float NotePublic;
        }

        [XmlRoot("castingShort")]
        [Serializable]
        public class CastingShort
        {
            [XmlElement("directors")]
            public string Realisateur;

            [XmlElement("actors")]
            public string Acteurs;
        }

        [XmlRoot("release")]
        [Serializable]
        public class Release
        {
            [XmlElement("releaseDate")]
            public DateTime DateSortie;
        }

        [XmlRoot("poster")]
        [Serializable]
        public class Poster
        {
            [XmlElement("href")]
            public string Url;
        }

        [XmlRoot("genreList")]
        [Serializable]
        public class GenreList
        {
            [XmlElement("genre")]
            public string LeGenre;

        }

        [XmlRoot("genre")]
        [Serializable]
        public class Genre
        {
            [XmlElement("code")]
            public string LeCode;
            [XmlElement("X")]
            public string Libelle;

        }

        

      
        #endregion
    }
}
