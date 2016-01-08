<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Suppression <%=Model.NomControlleur%></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Suppression</h2>

    <h3>Etes vous sûr de vouloir supprimer la fiche du film <b><%= Html.Encode(Model.LeMedia.Titre)%></b> et les exemplaires associés ?</h3>
  
      <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeMedia.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeMedia.Code)%>
            </div>
            
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Supprimer" /> | 
           <%= Html.ActionLink("Retour à la liste", "Index", Model.NomControlleur, new { pNumeroPage = 1 }, null)%>

        </p>
    <% } %>

</asp:Content>

