
namespace MediaGestion.Modele.Dl.Dlo
{
    public class Support
    {
        public string Code { get; set; }
        public string Libelle { get; set; }

        public byte[] Icone { get; set; }
   

        public Support()
        {
		
        }

        public Support(string pCode, string pLibelle, byte[] pIcone)
        {
            Code = pCode;
            Libelle = pLibelle;
            Icone = pIcone;
        }
    }

}
