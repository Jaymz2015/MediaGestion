<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Exemplaire>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Suppression exemplaire
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Suppression</h2>

    <h3>Etes vous sûr de vouloir supprimer l'exemplaire du film <b><%= Html.Encode(Model.LeMedia.Titre)%></b> appartenant à <b><%= Html.Encode(Model.LeProprietaire.Prenom)%> <%= Html.Encode(Model.LeProprietaire.Nom)%></b>?</h3>
  
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeMedia.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeMedia.Code)%>
            </div>
            
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeProprietaire.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeProprietaire.Code)%>
            </div>

             <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeSupport.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeSupport.Code)%>
            </div>
            
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Supprimer" /> |
		    <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
        </p>
    <% } %>

</asp:Content>

