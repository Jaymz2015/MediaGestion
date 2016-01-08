using System;
using Utilitaires;


namespace MediaGestion.Metier
{
    public abstract class AGestionnaireMedias
    {

        /// <summary>
        /// Traitement des erreurs
        /// </summary>
        /// <param name="pNomFonction"></param>
        /// <param name="ex"></param>
        public void TraiterErreur(string pNomModule, string pNomFonction, Exception pException, bool pAfficherErreur) {

            string MessageErreur = String.Format("{0} : Erreur dans la fonction {1} : {2} ",pNomModule,pNomFonction, pException.Message);

            Log.MonitoringLogger().Info(MessageErreur);
            
                if (pAfficherErreur) {

                    //MessageBox.Show(MessageErreur);
                }
            

        }


    }
}
