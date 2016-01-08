<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Suppression exemplaire
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Suppression</h2>

    <h3>Etes vous sûr de vouloir supprimer l'exemplaire du média <b><%= Html.Encode(Model.LeMedia.Titre)%></b> appartenant à <b><%= Html.Encode(Model.Lexemplaire.LeProprietaire.Prenom)%> <%= Html.Encode(Model.Lexemplaire.LeProprietaire.Nom)%></b>?</h3>
  
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeMedia.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeMedia.Code)%>
            </div>
            
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.Lexemplaire.Code)%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.Code)%>
            </div>

            
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Supprimer" /> | 
            <%= Html.ActionLink("Retour", "Details", Model.NomControlleur, new { codeMedia = Model.LeMedia.Code }, null)%>
           
        </p>
    <% } %>

</asp:Content>

