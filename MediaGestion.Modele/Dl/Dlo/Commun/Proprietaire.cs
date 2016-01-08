using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MediaGestion.Modele.Dl.Dlo
{
    /// <summary>
    /// Proprietaire
    /// </summary>
    public class Proprietaire
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

        public List<Exemplaire> ListeSouhaitsFilms { get; set; }
        public List<Exemplaire> ListeSouhaitsJeux { get; set; }

        public List<Emprunt> ListePretsEnCours { get; set; }
        public List<Emprunt> ListePretsClos { get; set; }

        public List<Emprunt> ListeEmpruntsEnCours { get; set; }
        public List<Emprunt> ListeEmpruntsClos { get; set; }


        public enmHabilitation Habilitation { get; set; }

        public enum enmHabilitation : int
        {
            DEFAULT=0,
            ADMINISTRATEUR = 1,
            AUTRE=2
        }

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

        /// <summary>
        /// VerifyHash
        /// </summary>
        /// <param name="password">password</param>
        /// <returns>bool</returns>
        public bool VerifyHash(string password) {

            return CalculateHash(password).Equals(PasswordHash);

        }

        /// <summary>
        /// CalculateHash
        /// </summary>
        /// <param name="password">password</param>
        /// <returns>string</returns>
        public string CalculateHash(string password)
        {
            SHA1 sha = SHA1.Create();
            byte[] data = sha.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
