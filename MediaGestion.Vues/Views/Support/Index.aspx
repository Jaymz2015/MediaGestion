<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MediaGestion.Modele.Dl.Dlo.Support>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste des supports</h2>

    <table>
        <tr>    
            <th>
                Logo
            </th>       
            <th>
                Code
            </th>
            <th>
                Libelle
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <% var imgurl = Url.Action("ThumbImage", "Support", new { pCodeSupport = item.Code }); %>

        <tr>    
            <td>
                <img src="<%=imgurl %>" alt="logo" style="padding-right:2px;width:50px" />        
            </td>        
            <td>
                <%= Html.Encode(item.Code) %>
            </td>
            <td>
                <%= Html.Encode(item.Libelle) %>
            </td>
            <td>
                 <!--<%= Html.ActionLink("Edit", "Edit", new { pCode = item.Code })%> -->
                
                <a href="<%= Url.Action("Details", new  { pCode = item.Code } )  %>" class="lienEdition">
                  <img src="../../Content/Images/show_property-64.png" alt="Editer" title="Visualiser le support" class="boutonEdition"/>
                </a>
                &nbsp
                <!--<%= Html.ActionLink("Détails", "Details", new { pCode = item.Code })%>-->
                <a href="<%= Url.Action("Edit", new  { pCode = item.Code } )  %>" class="lienEdition">
                  <img src="../../Content/Images/edit_property-64.png" alt="Détails" title="Modifier le support" class="boutonEdition"/>
                </a> 
                &nbsp
                <!--<%= Html.ActionLink("Supprimer", "Delete", new { pCode=item.Code })%>-->
                <a href="<%= Url.Action("Delete", new  { pCode = item.Code } )  %>" class="lienEdition">
                  <img src="../../Content/Images/delete_property-64.png" alt="Supprimer" title="Supprimer le support" class="boutonEdition"/>
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

