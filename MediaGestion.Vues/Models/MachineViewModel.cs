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
    public class MachineViewModel
    {
        public Machine LaMachine { get; set; }
        public String OldCode { get; set; }

        

    }
}
