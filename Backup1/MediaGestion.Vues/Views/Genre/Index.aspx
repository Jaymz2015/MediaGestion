<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MediaGestion.Modele.Dl.Dlo.Genre>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Liste des genres
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste des Genres</h2>

    <table>
        <tr>           
            <th>
                Code
            </th>
            <th>
                Libelle
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>            
            <td>
                <%= Html.Encode(item.Code) %>
            </td>
            <td>
                <%= Html.Encode(item.Libelle) %>
            </td>
            <td>
                <!--<%= Html.ActionLink("Edit", "Edit", new { pCode = item.Code })%> -->
                
                <a href="<%= Url.Action("Details", new  { pCode = item.Code } )  %>" class="lienEdition">
                  <img src="../../Content/Images/show_property-64.png" alt="Editer" title="Visualiser le genre" class="boutonEdition"/>
                </a>
                &nbsp
                <!--<%= Html.ActionLink("Détails", "Details", new { pCode = item.Code })%>-->
                <a href="<%= Url.Action("Edit", new  { pCode = item.Code } )  %>" class="lienEdition">
                  <img src="../../Content/Images/edit_property-64.png" alt="Détails" title="Modifier le genre" class="boutonEdition"/>
                </a> 
                &nbsp
                <!--<%= Html.ActionLink("Supprimer", "Delete", new { pCode=item.Code })%>-->
                <a href="<%= Url.Action("Delete", new  { pCode = item.Code } )  %>" class="lienEdition">
                  <img src="../../Content/Images/delete_property-64.png" alt="Supprimer" title="Supprimer le genre" class="boutonEdition"/>
                </a> 
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <!--<%= Html.ActionLink("Créer un nouveau support", "Create") %>-->
        
        <a href="<%= Url.Action("Create")%>" class="lienEdition">
           <img src="../../Content/Images/add_property-64.png" alt="Ajouter" class="boutonEdition"/>
        </a>
    </p>

</asp:Content>

