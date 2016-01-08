<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MediaGestion.Modele.Dl.Dlo.Proprietaire>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Media Gestion : propriétaires
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste des propriétaires</h2>

    <table>
        <tr>
            <th>
                Nom
            </th>
            <th>
                Prenom
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            
            <td>
                <%= Html.Encode(item.Nom) %>
            </td>
            <td>
                <%= Html.Encode(item.Prenom) %>
            </td>
            <td>
                               
                <a href="<%= Url.Action("Details", new  { pCode = item.Login } )  %>" class="lienEdition">
                  <img src="../../Content/Images/show_property-64.png" alt="Editer" title="Visualiser le propriétaire" class="boutonEdition"/>
                </a>
                &nbsp
             
                <a href="<%= Url.Action("Edit", new  { pCode = item.Code, pLogin = item.Login } )  %>" class="lienEdition">
                  <img src="../../Content/Images/edit_property-64.png" alt="Détails" title="Modifier le propriétaire" class="boutonEdition"/>
                </a> 
                &nbsp
                <!--<%= Html.ActionLink("Supprimer", "Delete", new { pCode=item.Code })%>-->
                <a href="<%= Url.Action("Delete", new  { pCode = item.Code } )  %>" class="lienEdition">
                  <img src="../../Content/Images/delete_property-64.png" alt="Supprimer" title="Supprimer le propriétaire" class="boutonEdition"/>
                </a> 
            </td>
        </tr>
    
    <% } %>

    </table>
<!--
    <p>
        <%= Html.ActionLink("Ajouter", "Create") %>
    </p>
    
    -->

</asp:Content>

