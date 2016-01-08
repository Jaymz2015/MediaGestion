using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Utilitaires;
using System.Xml.Serialization;
using System.Diagnostics;

namespace LibAllocine.Helper
{
    public class UtilsAllocine
    {
        private static string KS_NOM_MODULE = "LibAllocine - Helper - ";

        /// <summary>
        /// Téléchargement de données
        /// </summary>
        /// <param name="pURL"></param>
        /// <returns></returns>
        public static MemoryStream DownloadData(string pURL)
        {
            WebRequest req = WebRequest.Create(pURL);
            WebResponse response = req.GetResponse();
            Stream stream = response.GetResponseStream();

            MemoryStream memStream = new MemoryStream();

            //Download in chuncks
            byte[] buffer = new byte[1024];

            //Get Total Size
            int dataLength = (int)response.ContentLength;

            while (true)
            {
                //Try to read the data
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }
                else
                {
                    //Write the downloaded data
                    memStream.Write(buffer, 0, bytesRead);
                }
            }

            return memStream;
        }


        public static bool ThumbnailCallback()
        {
            return false;
        }

        /// <summary>
        /// Conversion JSON -> XML
        /// </summary>
        /// <param name="streamJSON"></param>
        /// <returns></returns>
        public static Stream ConvertToXML(Stream streamJSON)
        {
            try
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Début streamJSON");

                //12/03/2013 : prise en compte du format JSON, le format XML n'étant plus retourné
                //Conversion JSON en XML
                StreamReader streamReader = new StreamReader(streamJSON);
                string json = streamReader.ReadToEnd();
                json = json.Replace('$', 'X');

                XmlDocument xmlDocument = (XmlDocument)JsonConvert.DeserializeXmlNode(json);

                Stream stream = new MemoryStream();
                xmlDocument.Save(stream);
                stream.Position = 0;

                //streamReader = new StreamReader(stream);
                //string fluxXML = streamReader.ReadToEnd();
                //Trace.WriteLine(fluxXML);

                //stream.Position = 0;

                return stream;
            }
            catch (Exception ex)
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Erreur = " + ex.Message);
                throw;
            }
            finally
            {
                Log.MonitoringLogger().Info(KS_NOM_MODULE + "Fin streamJSON");
            }
            
            
        }
        


    }
}
