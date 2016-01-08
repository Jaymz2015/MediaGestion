<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<LibAllocine.Dl.Dto.FicheFilmAllocine>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Allocine
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ListeAllocine</h2>
    
    
     <% if(Model.Count() > 0) { %>
                         
    <table>
        <tr>
            <th>
            </th>
            <th>
                <div class="display-header">Titre</div>
            </th>
            <th>
                <div class="display-header">Année</div>
            </th>
            <th>
                <div class="display-header">Note presse</div>
            </th>
            <th>
                <div class="display-header">Note public</div>
            </th>
            <th>
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <% var imgurl = ""; if (item.LaJaquette != null) { imgurl = Url.Action("ThumbImage2", "Film", new { url = item.LaJaquette.Url }); } %>               
                <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>  
            </td>
            <td>
                <div class="display-field">
                   <%-- <a href="<%= Html.Encode(item.ListeURLs.Lien.Url) %>"><%= Html.Encode(item.Titre) %></a>--%>
                    <%= Html.Encode(item.Titre) %>
                </div>
            </td>
            <td>
                <div class="display-field">
                    <%= Html.Encode(item.InfosSortie==null?"":String.Format("{0:yyyy}", item.InfosSortie.DateSortie))%>
                </div>
            </td>
            <td>
                <div class="display-field">
                    <%= Html.Encode(item.Statistiques == null ? "-" : item.Statistiques.NotePresse == 0f ? "-" : Math.Round(item.Statistiques.NotePresse, 1).ToString())%>
                </div>
            </td>
            <td>
                <div class="display-field">
                    <%= Html.Encode(item.Statistiques == null ? "-" : Math.Round(item.Statistiques.NotePublic, 1).ToString())%>
                </div>
            </td>
            <td>
                <div class="display-field">
                    <%= Html.ActionLink("Créer fiche", "Create", new {codeFilmAllocine=item.Code}) %>
                </div>
            </td>
        </tr>
    
    <% } %>

    </table>
    
     <% } else { %> Aucun film trouvé...  <% } %>

</asp:Content>

