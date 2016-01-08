using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using LibAllocine.Dl.Dto;
using Newtonsoft.Json;
using System.Diagnostics;
using Utilitaires;
using LibAllocine.Helper;
using System.Security.Cryptography;
using System.Web;


namespace LibAllocine
{
    public class GestionnaireAllocine
    {
        private static string KS_NOM_MODULE = "LibAllocine - GestionnaireAllocine - ";


        /// <summary>
        /// Fonction qui retourne les films correspondant au critère de recherche
        /// </summary>
        /// <param name="critere"></param>
        public ListeFichesFilmsAllocine RechercherMedia(string critere, Constantes.EnumTypeMediaAllocine typeMedia)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début RechercherFilm");
           
            try
            {
                string filter = String.Empty;

                switch (typeMedia)
                {
                    case Constantes.EnumTypeMediaAllocine.FILM:
                        filter = "movie";
                        break;
                    case Constantes.EnumTypeMediaAllocine.SERIE:
                        filter = "tvseries";
                        break;
                    default:
                        break;
                }


                if (critere == null || String.Empty.Equals(critere)) {
                    return null;
                }

                critere = critere.Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ê', 'e').Replace('ô', 'o').Replace('&', ' ');

                string responseValue = String.Empty;
                SHA1 sha1 = SHA1CryptoServiceProvider.Create();
                
                // Construction de l'url de recherche
                string url = Properties.Settings.Default.UrlRechercheAllocine;

                string sed = String.Format("{0:yyyyMMdd}", DateTime.Now);
                string param = String.Format(Properties.Settings.Default.ParamsRechercheAllocine, critere.Replace(" ", "+"), sed, filter);

                string encode = Properties.Settings.Default.SecretKeyAllocine + param;
                string sig = HttpUtility.UrlEncode(System.Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(encode))));

                url = url + "?" + param + "&sig=" + sig;

                // Création de la requête
                HttpWebRequest request = CreateWebRequest(url);

                // Récupération de la réponse
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                //13/03/2013 - prise en compte format JSON
                // Récupération du flux
                Stream responseStream = UtilsAllocine.ConvertToXML(response.GetResponseStream());
               
                //responseStream.Position = 0;
                //StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                //url = reader.ReadToEnd();
                
                //responseStream.Position = 0;

                // Désérialisation
                return DeserialiserListeFilms(responseStream);
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                throw;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin RechercherFilm");
            }           
        }




        /// <summary>
        /// Fonction qui retourne les films correspondant au critère de recherche
        /// </summary>
        /// <param name="critere"></param>
        public FicheFilmAllocine ObtenirFicheFilm(string codeFilm, Constantes.EnumTypeMediaAllocine typeMedia)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ObtenirFicheFilm");

            try
            {
                string filter = String.Empty;

                switch (typeMedia)
                {
                    case Constantes.EnumTypeMediaAllocine.FILM:
                        filter = "movie";
                        break;
                    case Constantes.EnumTypeMediaAllocine.SERIE:
                        filter = "tvseries";
                        break;
                    default:
                        break;
                }

                string responseValue = String.Empty;
                SHA1 sha1 = SHA1CryptoServiceProvider.Create();

                string sed = String.Format("{0:yyyyMMdd}", DateTime.Now);
                string param = String.Format(Properties.Settings.Default.ParamsInfosFilmAllocine, codeFilm, sed, filter);

                string encode = Properties.Settings.Default.SecretKeyAllocine + param;
                string sig = HttpUtility.UrlEncode(System.Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(encode))));

                // Construction de l'url de recherche
                string url = string.Format(Properties.Settings.Default.UrlInfosFilmAllocine, filter, param, sig);

                //url = url + "?" + param + "&sig=" + sig;

                // Création de la requête
                HttpWebRequest request = CreateWebRequest(url);

                // Récupération de la réponse
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                //13/03/2013 - prise en compte format JSON
                // Récupération du flux
                Stream responseStream = UtilsAllocine.ConvertToXML(response.GetResponseStream());

                // Désérialisation
                FicheFilmAllocine film = DeserialiserFilm(responseStream);

                ControlerDonnees(film);

                DownloadPhoto(film);

                return film;
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                return null;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ObtenirFicheFilm");
            }
        }

        /// <summary>
        /// Désérialisation d'une liste de films
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private ListeFichesFilmsAllocine DeserialiserListeFilms(Stream pStream)
        {
            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début DeserialiserListeFilms");

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListeFichesFilmsAllocine));
                return (ListeFichesFilmsAllocine)xmlSerializer.Deserialize(pStream);
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                throw;

            } finally {

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin DeserialiserListeFilms");
            }
        }


        /// <summary>
        /// Contrôle des données d'une fiche Film
        /// </summary>
        /// <param name="pFilm"></param>
        private void ControlerDonnees(FicheFilmAllocine pFilm)
        {
            if (pFilm.InfosSortie == null)
            {
                pFilm.InfosSortie = new FicheFilmAllocine.Release();
                pFilm.InfosSortie.DateSortie = new DateTime(1900, 1, 1);
            }

        }


        /// <summary>
        /// Désérialisation d'un film
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private FicheFilmAllocine DeserialiserFilm(Stream stream)
        {
            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début DeserialiserFilm");

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(FicheFilmAllocine));

                return (FicheFilmAllocine)xmlSerializer.Deserialize(stream);

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur", ex);
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin DeserialiserFilm");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        private HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.ContentLength = 0;
            //request.ContentType = "application/x-www-form-urlencoded";
            request.ContentType = "text/html";

            //request.UserAgent = "Dalvik/1.6.0 (Linux; U; Android 4.2.2; Nexus 4 Build/JDQ39E)";
            //request.UserAgent = "Mozilla/5.0 (Linux; U; Android 2.3.3; ja-jp; 001HT Build/GRI40) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1";
            //request.UserAgent = "Dalvik/1.2.0 (Linux; U; Android 2.2; 003Z Build/FRF91)";
            //request.UserAgent = "Dalvik/1.4.0 (Linux; U; Android 2.3.3; 001HT Build/GRI40)";
            request.UserAgent = "Dalvik/1.2.0 (Linux; U; Android 2.2.2; Huawei U8800-51 Build/HWU8800B635)";

            request.Timeout = 10000;

            return request;
        }  


        /// <summary>
        /// Téléchargement d'une jaquette
        /// </summary>
        /// <param name="pUrlFilm"></param>
        /// <param name="film"></param>
        private void DownloadPhoto(FicheFilmAllocine film) {

            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début DownloadPhoto");

                string nomPhoto = film.Titre + ".jpg";

                nomPhoto = nomPhoto.Replace(":", "");
                nomPhoto = nomPhoto.Replace("?", "");
                nomPhoto = nomPhoto.Replace("/", "");

                string cheminFichier = Properties.Settings.Default.RepertoireTemp + nomPhoto;

                //Creation du répertoire temporaire s'il n'existe pas
                DirectoryInfo repTemp = new DirectoryInfo(Properties.Settings.Default.RepertoireTemp);

                if (!repTemp.Exists)
                {
                    repTemp.Create();
                }

                //Création du controle client
                WebClient webClient = new WebClient();

                if (film.LaPhoto != null)
                {
                    Uri adress = new Uri(film.LaPhoto.Url);

                    webClient.DownloadFile(adress, cheminFichier);
                    film.NomPhoto = nomPhoto;
                }
                else
                {
                    Log.MonitoringLogger().Info(KS_NOM_MODULE + "Pas de jaquette à télécharger");
                }
 
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur", ex);
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin DownloadPhoto");
            }
            
        }
    }
}
