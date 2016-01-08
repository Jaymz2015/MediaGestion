<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Film>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Suppression film</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Suppression</h2>

    <h3>Etes vous sûr de vouloir supprimer la fiche du film <b><%= Html.Encode(Model.Titre) %></b> et les exemplaires associés ?</h3>
  
      <div class="editor-field">
                <%= Html.HiddenFor(model => model.Code)%>
                <%= Html.ValidationMessageFor(model => model.Code)%>
            </div>
            
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Supprimer" /> |
		    <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
        </p>
    <% } %>

</asp:Content>

