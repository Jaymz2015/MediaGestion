<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Proprietaire>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Suppression film
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Suppression propriétaire</h2>

    <h3>Voulez-vous vraiment supprimer <%= Html.Encode(Model.Prenom) %>&nbsp<%= Html.Encode(Model.Nom) %> ?</h3>

    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Retour à la liste", "Index") %>
        </p>
    <% } %>

</asp:Content>

