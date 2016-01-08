using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaGestion.Modele
{
    public static class Constantes
    {

        public const string NOM_REPERTOIRE_IMAGES = "D:/Jaymz/Images/";

        public const string NOM_REPERTOIRE_DOCUMENTS = "D:/Jaymz/Documents/";
   
        public const string KS_SUPPORT_DIVX = "divx";
        public const string KS_SUPPORT_DVD = "dvd";
        public const string KS_SUPPORT_BLURAY = "bray";
        public const string KS_SUPPORT_TNT = "tnt";
        public const string KS_SUPPORT_TNT_HD = "tnth";

        public enum EnumTypeSupport {
            DVD = 0,
            DIVX = 1,
            BLURAY = 2,
            TNT = 3,
            TNT_HD = 4
        }
       
    
    }
}
