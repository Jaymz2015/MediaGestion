<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LibAllocine.Dl.Dto.ListeFichesJeuxJVC>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Allocine
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste JeuxVideo.com</h2>
    
    
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
                <div class="display-header">Machine</div>
            </th>
            <th>
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <% var imgurl = ""; if (item.UrlVignette != null) { imgurl = Url.Action("ThumbImage2", "Jeu", new { url = item.UrlVignette }); } %>               
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
                    <%= Html.Encode(item.DateSortie == null ? "" : String.Format("{0:yyyy}", item.DateSortie))%>
                </div>
            </td>
             <td>
                <div class="display-field">
                    <%= Html.Encode(item.Machine)%>
                </div>
            </td>
            <td>
                <div class="display-field">
                    <%= Html.ActionLink("Créer fiche", "Create", new { codeJeuJVC = item.CodeJeu })%>
                </div>
            </td>
        </tr>
    
    <% } %>

    </table>
    
     <% } else { %> Aucun film trouvé...  <% } %>

</asp:Content>

