<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Suppression souhait
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Suppression</h2>

    <h3>Etes vous sûr de vouloir supprimer ce film de la liste des souhaits de <b><%= Html.Encode(Model.Lexemplaire.LeProprietaire.Prenom)%> <%= Html.Encode(Model.Lexemplaire.LeProprietaire.Nom)%></b> : <b><%= Html.Encode(Model.LeMedia.Titre)%></b> ?</h3>
  
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeMedia.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeMedia.Code)%>
            </div>
            
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.Lexemplaire.LeProprietaire.Code)%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.LeProprietaire.Code)%>
            </div>

             <div class="editor-field">
                <%= Html.HiddenFor(model => model.Lexemplaire.LeSupport.Code)%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.LeSupport.Code)%>
            </div>
            
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Supprimer" /> | 
            <%= Html.ActionLink("Retour", "Details", Model.NomControlleur, new { codeMedia = Model.LeMedia.Code }, null)%>

        </p>
    <% } %>

</asp:Content>

