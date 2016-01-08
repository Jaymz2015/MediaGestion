<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.ListeMediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Media Gestion : jeux</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste des jeux</h2>

        <fieldset class="fieldsetJVC">
      
            <form action="/Jeu/ListeJVC" method="get">
                
                <div class="editor-field">
                    
                    <img src="../../Content/Images/logoJVC.png" alt="logo JVC"/>      
                    <br /><br />
                    
                    <input class="textSearch" name="nomjeu" type="text" value=""/>
                    
                    <button class="btnform" type="submit">
                        Rechercher
                    </button>     
                </div>
        
          </form>
         
        </fieldset>
        
        <div class="cadreRecherche">
             
          <form id="formSearch" action="/Jeu/Filtrer" method="get">

                    <input class="textSearch" type="text" name="nomjeu" value="<%=Session["critereNomjeu"]%>"/>
                        
                    <button class="btnform" type="submit">
                        Rechercher
                    </button> 
 
          </form>
        </div>

        <div id="conteneur">
                <div id="cadreFiltres">
    
                        <h3>Filtres</h3>
                                                
                        <form id="formFiltres" action="/Jeu/Filtrer" method="get">
                        
                        <!--<input id="rechercherTxtBox" type="text" name="nomjeu" value="<%=Session["critereNomjeu"]%>"/>-->

                        <!-- Choix genre --> 
                         <% foreach (var item in MediaGestion.Vues.DataManager.ObtenirListeGenre(MediaGestion.Modele.Constantes.EnumTypeMedia.JEU)) { %>
                        
                            <% 
                                bool test=false;

                                if (Session["critereSelectedGenres"] != null && ((string[])(Session["critereSelectedGenres"])).Length > 0)
                                {
                                    foreach (string g in (string[])Session["critereSelectedGenres"])
                                    {
                                        if (g.ToUpper().Equals(item.Code.ToUpper()))
                                        {
                                            test = true;
                                            break;
                                        }
                                    }
                                }

                            %>
                                
                                <% if (test)
                                   {  %>
                                
                                     <input type="checkbox" name="selectedGenres" value="<%=item.Code%>" checked=checked/>
                                    <%= item.Libelle%>
                                
                                <% } 
                                   else
                                   {  %>
                                
                                    <input type="checkbox" name="selectedGenres" value="<%=item.Code%>">
                                    <%= item.Libelle%>
                             
                                <% }  %>
                             <br />

                        <% } %>
                        <br />

                        <!-- Choix machine --> 
                         <% foreach (var item in MediaGestion.Vues.DataManager.ListeMachines) { %>
                        
                            <% 
                                bool test=false;

                                if (Session["critereSelectedMachines"] != null && ((string[])(Session["critereSelectedMachines"])).Length > 0)
                                {
                                    foreach (string m in (string[])Session["critereSelectedMachines"])
                                    {
                                        if (m.ToUpper().Equals(item.Code.ToUpper()))
                                        {
                                            test = true;
                                            break;
                                        }
                                    }
                                }

                            %>
                                
                                <% if (test)
                                   {  %>
                                
                                     <input type="checkbox" name="selectedMachines" value="<%=item.Code%>" checked=checked/>
                                    <%= item.Nom%>
                                
                                <% } 
                                   else
                                   {  %>
                                
                                    <input type="checkbox" name="selectedMachines" value="<%=item.Code%>">
                                    <%= item.Nom%>
                             
                                <% }  %>
                             <br />

                        <% } %>
                        <br />

                        <!-- Choix propriétaire --> 
                         <% foreach (var item in MediaGestion.Vues.DataManager.ListeProprietaires) { %>
                        
                                <% 
                                bool test=false;

                                //On recoche les éléments déjà sélectionnés précédemment par rapport à la sauvegarde faite
                                if (Session["critereSelectedProprietaires"] != null && ((Guid[])(Session["critereSelectedProprietaires"])).Length > 0)
                                {
                                    foreach (Guid g in (Guid[])Session["critereSelectedProprietaires"])
                                    {
                                        if (g.Equals(item.Code))
                                        {                                       
                                            test = true;
                                            break;
                                        }
                                    }
                                }

                                %>

                                <% if (test)
                                   {  %>
                                
                                     <input type="checkbox" name="selectedProprietaires" value="<%=item.Code%>" checked=checked>
                                    <%= item.ToString()%>
                                
                                <% } 
                                   else
                                   {  %>
                                
                                    <input type="checkbox" name="selectedProprietaires" value="<%=item.Code%>">
                                    <%= item.ToString()%>
                             
                                <% }  %>

                                <br />
                        
                        <% } %>
                        <br />
                                               
                        <br />                        
                            <input type="submit" value="Filtrer" /> 
                        </form>
                        
               </div>
                
               <%-- </td>
                <td valign="top">--%>
               <div id="cadreListeMedia">

                         <% if(Model.ListeJeux.Count() > 0) { %>
                         
                             <h4><%= Model.NbResultats.ToString() %> jeux trouvés</h4>
                        
                             <div id="NumerosPages">
                                <!-- On affiche les numéros de page si au moins 2 pages -->
                                <% if(Model.NbPages > 1) { %>
                                     <% for(int i=1;i<=Model.NbPages;i++) { %>       
                                        <%= Html.ActionLink(i.ToString(), "Index", "Jeu", new { pNumeroPage = i }, null)%>
                                     <% } %>
                                 
                               <% } %>
                                 
                                &nbsp
                                &nbsp
                                &nbsp
                                &nbsp
                                <%= Html.ActionLink("Derniers ajouts", "TrierParDateCreation", "Jeu", null, null)%>
                        
                            </div>

                            <table>
                                <tr>
                                    <th>
                                        
                                    </th>
                                    <th>
                                        Titre
                                    </th>
                                    <th>
                                        Machine
                                    </th>
                                    <th>
                                        Genre
                                    </th>
                                    <th>
                                        Année
                                    </th>
                                    <th>
                                        Developpeur
                                    </th>
                                    <th>
                                        Editeur
                                    </th>
                                </tr>

                            <% foreach (var item in Model.ListeJeux) { %>
                            
                                <tr>      
                                    <td>
                                        <% var imgurl = Url.Action("ThumbImage", "Jeu",
                                                    new { jaquette = item.Photo, width = 100, height = 100 }); %>
                                        <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                                    </td>                           
                                    <td>
                                        <%= Html.ActionLink(item.Titre, "Details", "Jeu", new { codeMedia = item.Code }, null)%>
                                    </td>
                                    <td>
                                        <%= Html.Encode(item.LaMachine.Nom) %>
                                    </td>
                                    <td>
                                        <%= Html.Encode(item.LeGenre.Libelle) %>
                                    </td>
                                    <td>
                                        <%= Html.Encode(String.Format("{0:yyyy}", item.DateSortie))%>
                                    </td>
                                    <td>
                                        <%= Html.Encode(item.Developpeur.Nom) %>
                                    </td>
                                    <td>
                                        <%= Html.Encode(item.Editeur.Nom) %>
                                    </td>
                                </tr>
                            
                            <% } %>

                            </table>

                            <% if(Model.NbPages > 1) { %>
                                <% for(int i=1;i<=Model.NbPages;i++) { %>
          
                                    <%= Html.ActionLink(i.ToString(), "Index", "Jeu", new { pNumeroPage = i }, null)%>
                                <% } %>
                            <% } %>
                        
                        <% } else { %> Aucun jeu trouvé...  <% } %>
                            
                    </div>
        
     </div>

</asp:Content>

