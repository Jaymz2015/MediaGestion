<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Genre>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Suppression genre
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Suppression Genre</h2>

    <h3>Etes vous sûr de vouloir supprimer ce Genre ?</h3>
    <fieldset>
        <!--<legend>Fields</legend>-->
        
        <div class="display-label">Code</div>
        <div class="display-field"><%= Html.Encode(Model.Code) %></div>
        
        <div class="display-label">Libelle</div>
        <div class="display-field"><%= Html.Encode(Model.Libelle) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

