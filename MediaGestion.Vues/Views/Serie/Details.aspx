<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fiche "<%= Html.Encode(Model.LeMedia.Titre) %>"
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% Html.RenderPartial("DetailSerieControl"); %>

    <% Html.RenderPartial("ListeSaisonsControl"); %>

    <p>
        <%= Html.ActionLink("Editer", "Edit", Model.NomControlleur, new { pCodeMedia = Model.LeMedia.Code }, null)%>
        |
        <%= Html.ActionLink("Supprimer", "Delete", "Media", new { pCodeMedia = Model.LeMedia.Code }, null)%>
        |
        <%= Html.ActionLink("Retour à la liste", "Index", Model.NomControlleur, new { pNumeroPage = 1 }, null)%>
    </p>
</asp:Content>
