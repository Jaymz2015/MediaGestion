﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :2.0.50727.4247
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibAllocine.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://api.allocine.fr/rest/v3/search")]
        public string UrlRechercheAllocine {
            get {
                return ((string)(this["UrlRechercheAllocine"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://api.allocine.fr/rest/v3/movie?partner=YW5kcm9pZC12M3M&code={0}&profile=med" +
            "ium&format=json&filter=movie&striptags=synopsis,synopsisshort")]
        public string UrlInfosFilmAllocine {
            get {
                return ((string)(this["UrlInfosFilmAllocine"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:/Temp/")]
        public string RepertoireTemp {
            get {
                return ((string)(this["RepertoireTemp"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ws.jeuxvideo.com/search/{0}")]
        public string UrlRechercheJVC {
            get {
                return ((string)(this["UrlRechercheJVC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ws.jeuxvideo.com/01.jeux/details/{0}.xml")]
        public string UrlInfosJeuJVC {
            get {
                return ((string)(this["UrlInfosJeuJVC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("appandr")]
        public string LoginJVC {
            get {
                return ((string)(this["LoginJVC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("e32!cdf")]
        public string PasswordJVC {
            get {
                return ((string)(this["PasswordJVC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ws.jeuxvideo.com/01.jeux/details/{0}.xml")]
        public string UrlObtenirFicheJVC {
            get {
                return ((string)(this["UrlObtenirFicheJVC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>")]
        public string EnteteXML {
            get {
                return ((string)(this["EnteteXML"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ws.jeuxvideo.com/01.jeux/screen/{0}.xml")]
        public string UrlScreenshotsJVC {
            get {
                return ((string)(this["UrlScreenshotsJVC"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("json")]
        public string FormatRecherche {
            get {
                return ((string)(this["FormatRecherche"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("partner=100043982026&q={0}&format=json&filter=movie&sed={1}&count=10&page=1")]
        public string ParamsRechercheAllocine {
            get {
                return ((string)(this["ParamsRechercheAllocine"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("29d185d98c984a359e6e6f26a0474269")]
        public string SecretKeyAllocine {
            get {
                return ((string)(this["SecretKeyAllocine"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("partner=100043982026&code={0}&profile=medium&format=json&filter=movie&sed={1}&str" +
            "iptags=synopsis,synopsisshort")]
        public string ParamsInfosFilmAllocine {
            get {
                return ((string)(this["ParamsInfosFilmAllocine"]));
            }
        }
    }
}
