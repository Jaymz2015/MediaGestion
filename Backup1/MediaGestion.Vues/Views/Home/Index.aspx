<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MediaGestion.Modele.Dl.Dlo.Film>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Media Gestion : Films
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste des films</h2>

    <p>
        <%= Html.ActionLink("Ajouter film", "Create", "Film") %>
        
    </p>

          <form action="/Film/ListeAllocine" method="get">
                <div class="editor-label">
                    <label for="recherche">Recherche Allocine</label>
                </div>
                <div class="editor-field">
                    <input id="rechercherAllocine" name="nomFilm" type="text" value="" />&nbsp<input type="submit" value="Rechercher" />               
                </div>
        
          </form>
 
    <div style="float:left">
        <form action="/Film/Filtre" method="get">
        
         <% foreach (var item in MediaGestion.Vues.DataManager.ListeGenre) { %>
        
              <input type="checkbox" name="selectedObjects" value="<%=item.Code%>">
                <%= item.Libelle%>
                
                <br />
                
        
        <% } %>
        
            <input type="submit" value="Filtrer" /> 
        </form>
    </div>
    
    <div>
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

    <% foreach (var item in Model) { %>
    
        <tr>      
            <td>
                <% var imgurl = Url.Action("ThumbImage", "Home",
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

</div>
</asp:Content>

