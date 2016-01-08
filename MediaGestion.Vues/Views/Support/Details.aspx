<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Support>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.Code)%></h2>

    <fieldset>

        <% var imgurl = Url.Action("ThumbImage", "Support",
                            new { pCodeSupport = Model.Code }); %>
        <img src="<%=imgurl %>" alt="logo" style="padding-right:2px;"/>        
                
        <div class="display-label">Libelle</div>
        <div class="display-field"><%= Html.Encode(Model.Libelle) %></div>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { pCode=Model.Code}) %> |
        <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
    </p>

</asp:Content>

