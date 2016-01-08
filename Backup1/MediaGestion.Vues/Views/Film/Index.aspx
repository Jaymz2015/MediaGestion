<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.ListeFilmViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Media Gestion : films</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste des films</h2>

   <%-- <p>
        <%= Html.ActionLink("Ajouter film", "Create", "Film") %>
        
    </p>--%>
           
        <fieldset class="fieldsetAllocine">
             <!--<legend>Recherche Allocine</legend>-->
             
            <form action="/Film/ListeAllocine" method="get">
                
                <div class="editor-field">
                    
                    <img src="../../Content/Images/allocine.png" alt="logo allocine"/>      
                    <br /><br />
                    
                    <input class="textSearch" name="nomFilm" type="text" value=""/>
                    
                    <button class="btnform" type="submit">
                        Rechercher
                    </button>     
                </div>
        
          </form>
         
        </fieldset>
        
        <div class="cadreRecherche">
             
          <form id="formSearch" action="/Film/Filtrer" method="get">

                    <input class="textSearch" type="text" name="nomFilm" value="<%=Session["critereNomFilm"]%>"/>
                        
                    <button class="btnform" type="submit">
                        Rechercher
                    </button> 
 
          </form>
        </div>

       <%-- <table class="nothing">
             <tr>      
                <td valign="top">--%>
        <div id="conteneur">
                <div id="cadreFiltres">
    
                        <h3>Filtres</h3>
                                                
                        <form id="formFiltres" action="/Film/Filtrer" method="get">
                        
                        <!--<input id="rechercherTxtBox" type="text" name="nomFilm" value="<%=Session["critereNomFilm"]%>"/>-->

                        <!-- Choix genre --> 
                         <% foreach (var item in MediaGestion.Vues.DataManager.ListeGenre) { %>
                        
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
               <div id="cadreListeFilms">

                         <% if(Model.ListeFilms.Count() > 0) { %>
                         
                             <h4><%= Model.NbResultats.ToString() %> films trouvés</h4>
                        
                             <div id="NumerosPages">
                                <!-- On affiche les numéros de page si au moins 2 pages -->
                                <% if(Model.NbPages > 1) { %>
                                     <% for(int i=1;i<=Model.NbPages;i++) { %>       
                                        <%= Html.ActionLink(i.ToString(), "Index", "Film", new { pNumeroPage = i }, null)%>
                                     <% } %>
                                 
                               <% } %>
                                 
                                &nbsp
                                &nbsp
                                &nbsp
                                &nbsp
                                <%= Html.ActionLink("Derniers ajouts", "TrierParDateCreation", "Film", null, null)%>
                        
                            </div>
                            
                           
                      
                            <table>
                                <tr>
                                    <th>
                                        
                                    </th>
                                    <th>
                                        Titre
                                    </th>
                                    <th>
                                        Genre
                                    </th>
                                    <th>
                                        Année
                                    </th>
                                    <th>
                                        Réalisateur
                                    </th>
                                    <th>
                                        Acteurs
                                    </th>
                                    <%--<th></th>--%>
                                </tr>

                            <% foreach (var item in Model.ListeFilms) { %>
                            
                                <tr>      
                                    <td>
                                        <% var imgurl = Url.Action("ThumbImage", "Film",
                                                    new { jaquette = item.Jaquette, width = 100, height = 100 }); %>
                                        <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                                    </td>                           
                                    <td>
                                        <%= Html.ActionLink(item.Titre, "Details", "Film", new { codeFilm = item.Code }, null)%>
                                    </td>
                                    <td>
                                        <%= Html.Encode(item.LeGenre.Libelle) %>
                                    </td>
                                    <td>
                                        <%= Html.Encode(String.Format("{0:yyyy}", item.DateSortie))%>
                                    </td>
                                    <td>
                                        <%= Html.Encode(item.Realisateur) %>
                                    </td>
                                    <td>
                                        <%= Html.Encode(item.Acteurs) %>
                                    </td>
                                    <%--<td>
                                        <%= Html.ActionLink("Editer", "Edit", "Film", new { pCodeFilm = item.Code },null)%> |
                                        <%= Html.ActionLink("Supprimer", "Delete", "Film", new { pCodeFilm = item.Code }, null)%>
                                    </td>--%>
                                    
                                </tr>
                            
                            <% } %>

                            </table>
                            
                               <%--  <%= Html.ActionLink("Page précédente", "Previous", "Film", null,null)%> | <%= Html.ActionLink("Page suivante", "Next", "Film", null,null)%>
                           <div class=navigation>
                                <a href="<%= Url.Action("Previous")  %>" class="lienEdition">
                                    <img src="../../Content/Images/previous-64.png" alt="Page précédente" title="Page précédente" class="boutonEdition"/>
                                </a>&nbsp
                                <a href="<%= Url.Action("Next")  %>" class="lienEdition">
                                    <img src="../../Content/Images/next-64.png" alt="Page suivante" title="Page suivante" class="boutonEdition"/>
                                </a>       
                            </div>--%>
                            
                            
                            <% if(Model.NbPages > 1) { %>
                                <% for(int i=1;i<=Model.NbPages;i++) { %>
          
                                    <%= Html.ActionLink(i.ToString(), "Index", "Film", new { pNumeroPage = i }, null)%>
                                <% } %>
                            <% } %>
                        
                        <% } else { %> Aucun film trouvé...  <% } %>
                            
                    </div>
      <%--          
                </td>
            </tr>      
                
        </table>
        --%>
        
     </div>
         
   
</asp:Content>

