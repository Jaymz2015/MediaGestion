using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibAllocine.Dl.Dto;
using Utilitaires;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;
namespace LibAllocine
{
    public class GestionnaireJVC
    {

        private static string KS_NOM_MODULE = "LibAllocine - GestionnaireJVC - ";
        private const string IdScreenShotFront = "100001";
        private const string IdScreenShotBack = "100002";

        /// <summary>
        /// Fonction qui retourne les films correspondant au critère de recherche
        /// </summary>
        /// <param name="critere"></param>
        public ListeFichesJeuxJVC RechercherJeu(string critere)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début RechercherJeu");

            try
            {
                string responseValue = String.Empty;

                // Construction de l'url de recherche
                string url = string.Format(Properties.Settings.Default.UrlRechercheJVC, critere);


                // Création de la requête
                HttpWebRequest request = CreateWebRequest(url);

                // Récupération de la réponse
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // Récupération du flux
                Stream responseStream = response.GetResponseStream();

                // Désérialisation
                return DeserialiserListeJeux(responseStream);

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                throw;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin RechercherJeu");
            }
        }

        /// <summary>
        /// Désérialisation d'une liste de jeux
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private ListeFichesJeuxJVC DeserialiserListeJeux(Stream stream)
        {
            string machine;
             string urlFiche;

            ListeFichesJeuxJVC listeFichesJeuxJVC = new ListeFichesJeuxJVC();

            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début DeserialiserListeJeux");


                StreamReader streamReader = new StreamReader(stream);
                string resultat = streamReader.ReadToEnd();

                int indexDebut = resultat.LastIndexOf("[")+1;
                int indexFin = resultat.IndexOf("]")-1;

                resultat = resultat.Substring(indexDebut, indexFin - indexDebut);

            
                indexDebut = resultat.IndexOf("ul>") + 3;

                resultat = resultat.Substring(indexDebut, resultat.Length - indexDebut);
                resultat = resultat.Replace("&", "and");

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(resultat);

                XPathNavigator xpathNavigator;
                xpathNavigator = xdoc.CreateNavigator();

                XPathNodeIterator xpathNodeIterator;
                xpathNodeIterator = xpathNavigator.Select("/div/h3");


                 // On parcourt les chunks
                while (xpathNodeIterator.MoveNext())
                {
                    // On recupère le nom de machine
                    machine = xpathNodeIterator.Current.Value;

                    //on va à ul
                    xpathNodeIterator.Current.MoveToNext();

                    // balises li
                    xpathNodeIterator.Current.MoveToChild("li", "");

                    do
                    {
                        // Chaque balise li correspond à une fiche
                        FicheJeuJVC ficheJeuJVC = new FicheJeuJVC();
                        ficheJeuJVC.Machine = xpathNodeIterator.Current.Value;


                        xpathNodeIterator.Current.MoveToChild("a", "");

                        ficheJeuJVC.Titre = xpathNodeIterator.Current.Value;

                        urlFiche = xpathNodeIterator.Current.GetAttribute("href", "");
                        urlFiche = urlFiche.Replace("jv:/", "http://ws.jeuxvideo.com");
                       
                        ficheJeuJVC.UrlSimple = urlFiche;
                        
 
                        xpathNodeIterator.Current.MoveToParent();


                        if (xpathNodeIterator.Current.MoveToChild("strong", ""))
                        {
                            ficheJeuJVC.Machine = xpathNodeIterator.Current.Value;
                            xpathNodeIterator.Current.MoveToParent();
                        }
                        else
                        {
                            ficheJeuJVC.Machine = machine;
                        }

                        FicheJeuJVC ficheComplementaire = ObtenirFicheSimpleJeu(urlFiche);

                        ficheJeuJVC.UrlVignette = ficheComplementaire.UrlVignette;
                        ficheJeuJVC.Editeur = ficheComplementaire.Editeur;
                        ficheJeuJVC.Developpeur = ficheComplementaire.Developpeur;
                        ficheJeuJVC.DateSortie = ficheComplementaire.DateSortie;
                        ficheJeuJVC.NomJaquette = ficheComplementaire.NomJaquette;
                        ficheJeuJVC.Genre = ficheComplementaire.Genre;

                        listeFichesJeuxJVC.AjouterFicheJeuJVC(ficheJeuJVC);


                    } while (xpathNodeIterator.Current.MoveToNext());

                    xpathNodeIterator.Current.MoveToParent();
                }


                foreach (FicheJeuJVC fiche in listeFichesJeuxJVC)
                {
                    Console.WriteLine(fiche.ToString());
                }


                return listeFichesJeuxJVC;
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                throw;

            }
            finally
            {

                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin DeserialiserListeJeux");
            }
        }


        /// <summary>
        /// Fonction qui retourne les films correspondant au critère de recherche
        /// </summary>
        /// <param name="critere"></param>
        public FicheJeuJVC ObtenirFicheSimpleJeu(string url)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ObtenirFicheSimpleJeu");

            try
            {
                string responseValue = String.Empty;

                // Création de la requête
                HttpWebRequest request = CreateWebRequest(url);

                // Récupération de la réponse
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // Récupération du flux
                Stream responseStream = response.GetResponseStream();

                // Désérialisation
                FicheJeuJVC ficheJeu = DeserialiserJeu(responseStream);

                //DownloadJaquette(ficheJeu);

                return ficheJeu;
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                throw;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ObtenirFicheSimpleJeu");
            }
        }

        /// <summary>
        /// Fonction qui retourne la fiche détaillée d'un jeu
        /// </summary>
        /// <param name="critere"></param>
        public FicheJeuJVC ObtenirFicheDetailleJeu(FicheJeuJVC ficheJeuSimple)
        {
            Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début ObtenirFicheDetailleJeu");

            try
            {
                string responseValue = String.Empty;

                // Construction de l'url de recherche
                string url = string.Format(Properties.Settings.Default.UrlObtenirFicheJVC, ficheJeuSimple.CodeJeu);

                // Création de la requête
                HttpWebRequest request = CreateWebRequest(url);

                // Récupération de la réponse
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // Récupération du flux
                Stream responseStream = response.GetResponseStream();

                StringBuilder resultat = new StringBuilder(Properties.Settings.Default.EnteteXML);

                StreamReader streamReader = new StreamReader(responseStream);
                resultat.Append(streamReader.ReadToEnd());

                resultat.Replace("<details_jeu>", "<jeu>");
                resultat.Replace("</details_jeu>", "</jeu>");
                resultat.Replace("<![CDATA[","");
                resultat.Replace("]]>", "");
                resultat.Replace("&", "");

                StringReader sr = new StringReader(resultat.ToString());
              
                // Désérialisation
                FicheJeuJVC ficheJeu = DeserialiserJeu(sr);

                ficheJeu.CodeJeu = ficheJeuSimple.CodeJeu;
                ficheJeu.DateSortie = ficheJeuSimple.DateSortie;
                ficheJeu.Developpeur = ficheJeuSimple.Developpeur;
                ficheJeu.Editeur = ficheJeuSimple.Editeur;
                ficheJeu.Genre = ficheJeuSimple.Genre;
                ficheJeu.Machine = ficheJeuSimple.Machine;
                ficheJeu.NomJaquette = ficheJeuSimple.NomJaquette;
                ficheJeu.Note = ficheJeuSimple.Note;
                ficheJeu.Titre = ficheJeuSimple.Titre;
                ficheJeu.UrlJaquette = ficheJeuSimple.UrlJaquette;
                ficheJeu.UrlVignette = ficheJeuSimple.UrlVignette;
                ficheJeu.UrlSimple = ficheJeuSimple.UrlSimple;
                ficheJeu.UrlDetaille = url;

 
                DownloadJaquette(ficheJeu);

                return ficheJeu;

            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                throw;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin ObtenirFicheFilm");
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
            request.ContentType = "text/xml";

            NetworkCredential cred = new NetworkCredential();

            cred.UserName = Properties.Settings.Default.LoginJVC;
            cred.Password = Properties.Settings.Default.PasswordJVC;

            request.Credentials = cred;

            request.PreAuthenticate = true;

            return request;
        }


        /// <summary>
        /// Téléchargement d'une jaquette
        /// </summary>
        /// <param name="pUrlFilm"></param>
        /// <param name="film"></param>
        private void DownloadJaquette(FicheJeuJVC ficheJeu)
        {
            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début DownloadJaquette");

                // Construction de l'url de recherche
                string url = string.Format(Properties.Settings.Default.UrlScreenshotsJVC, ficheJeu.CodeJeu);

                // Création de la requête
                HttpWebRequest request = CreateWebRequest(url);

                // Récupération de la réponse
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // Récupération du flux
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string resultat = streamReader.ReadToEnd();

                // Récupération de l'url de la jaquette
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(resultat);

                XPathNavigator xpathNavigator;
                xpathNavigator = xdoc.CreateNavigator();

                XPathNodeIterator xpathNodeIterator;
                xpathNodeIterator = xpathNavigator.Select("/screenshots/screenshot");

                //TODO : accéder directement au bon
                // On parcourt les item screenshot jusqu'à la jaquette
                while (xpathNodeIterator.MoveNext() && ficheJeu.UrlJaquette == null)
                {
                    // balises id
                    xpathNodeIterator.Current.MoveToChild("id", "");

                    // On recupère le nom de machine
                    string id = xpathNodeIterator.Current.Value;
                    Console.WriteLine(id);

                    // le screenshot correspond à la jaquette
                    if (id == IdScreenShotFront)
                    {
                        //on va à url_screenshot
                        xpathNodeIterator.Current.MoveToNext("url_screenshot", "");
                        ficheJeu.UrlJaquette = xpathNodeIterator.Current.Value;
                    }

                    xpathNodeIterator.Current.MoveToParent();
                }

                string nomJaquette = ficheJeu.Titre + ".jpg";

                if (nomJaquette.IndexOf(":") > 0)
                {
                    nomJaquette = nomJaquette.Remove(nomJaquette.IndexOf(":"), 1);
                }

                // Enregistrement dans Temp
                string cheminFichier = Properties.Settings.Default.RepertoireTemp + nomJaquette;

                //Création du controle client
                WebClient webClient = new WebClient();

                webClient.DownloadFile(ficheJeu.UrlJaquette, cheminFichier);

                ficheJeu.NomJaquette = nomJaquette;
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur", ex);
                throw ex;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin DownloadJaquette");
            }

        }

        /// <summary>
        /// Désérialisation d'un jeu
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private FicheJeuJVC DeserialiserJeu(Stream stream)
        {
            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début DeserialiserJeu");

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(FicheJeuJVC));
       

                return (FicheJeuJVC)xmlSerializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur", ex);
                throw ex;
            }
            finally
            {
                stream.Close();
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin DeserialiserJeu");
            }
        }

        /// <summary>
        /// Désérialisation d'un jeu
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private FicheJeuJVC DeserialiserJeu(StringReader sr)
        {
            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début DeserialiserJeu");

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(FicheJeuJVC));

                return (FicheJeuJVC)xmlSerializer.Deserialize(sr);
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur", ex);
                throw ex;
            }
            finally
            {
                sr.Close();
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin DeserialiserJeu");
            }
        }
    }
}
