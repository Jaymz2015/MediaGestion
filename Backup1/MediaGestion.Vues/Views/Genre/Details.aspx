<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Genre>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Genre "<%= Html.Encode(Model.Libelle) %>"
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.Code)%></h2>

    <fieldset>
        <!--<legend>Fields</legend>-->
                
        <div class="display-label">Libelle</div>
        <div class="display-field"><%= Html.Encode(Model.Libelle) %></div>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { pCode=Model.Code}) %> |
        <%= Html.ActionLink("Retour à la liste", "Index") %>
    </p>

</asp:Content>

