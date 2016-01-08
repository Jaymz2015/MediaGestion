<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Créer emprunt
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <% Html.RenderPartial(Model.NomControlDetail); %>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <% Html.RenderPartial("EmpruntControl"); %>
    
        <p>
            <input type="submit" name="CreerEmprunt" value="Enregistrer emprunt" />
        </p>
            
  <% } %>

    <p>
       <%= Html.ActionLink("Retour", "Details", Model.NomControlleur, new { codeMedia = Model.LeMedia.Code}, null)%>
    </p>

</asp:Content>



