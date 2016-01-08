using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MediaGestion.Modele.Dl.Dlo;
using System.Collections.Generic;
using System.ComponentModel;

namespace MediaGestion.Vues.Models
{
    public class ProprietaireViewModel
    {
        public Guid Code { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Adresse { get; set; }
        public int CP { get; set; }
        public String Ville { get; set; }
        public bool EstProprietairePrincipal { get; set; }


        public string Login { get; set; }

        public string PasswordHash { get; set; }

        //public List<Exemplaire> ListeSouhaits { get; set; }

        //public List<Emprunt> ListeEmprunts { get; set; }


        public string Value
        {
            get
            {
                return Nom + " " + Prenom;
            }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }

        [DisplayName("Ancien mot de passe")]
        public string OldPassword { get; set; }

        [DisplayName("Nouveau mot de passe")]
        public string NewPassword { get; set; }

        [DisplayName("Confirmation du nouveau mot de passe")]
        public string ConfirmPassword { get; set; }

        public ProprietaireViewModel()
        {

        }

        public ProprietaireViewModel(Proprietaire p)
        {
            Code = p.Code;
            Nom = p.Nom;
            Prenom = p.Prenom;
            Adresse = p.Adresse;
            CP = p.CP;
            Ville = p.Ville;
            Login = p.Login;
            PasswordHash = p.PasswordHash;
            
        }

    }
}
