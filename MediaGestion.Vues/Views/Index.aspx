<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MediaGestion.Modele.Dl.Dlo.Genre>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste des Genres</h2>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
    
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
                <%= Html.ActionLink("Edit", "Edit", new { pCode = item.Code })%> |
                <%= Html.ActionLink("Details", "Details", new { pCode = item.Code })%> |
                <%= Html.ActionLink("Delete", "Delete", new { pCode=item.Code })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    

</asp:Content>

