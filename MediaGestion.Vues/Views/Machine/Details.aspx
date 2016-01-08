<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Machine>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Details</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.Nom)%></h2>

    <fieldset>

        <% var imgurl = Url.Action("ThumbImage", "Machine",
                            new { pCodeMachine = Model.Code, pTaille = 300 }); %>
        <img src="<%=imgurl %>" alt="logo" style="padding-right:2px;"/>        
         
         <br />
         <% var imgurlPhoto = Url.Action("ThumbPhoto", "Machine",
                            new { pCodeMachine = Model.Code, pTaille = 300 }); %>
        <img src="<%=imgurlPhoto %>" alt="photo" style="padding-right:2px;"/>   


         <% if (!"PC".Equals(Model.Code)) { %>

            <div class="display-label">Date sortie</div>     
            <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.DateSortie))%></div>

            <div class="display-label">Historique</div>
            <div class="display-field-pre"><%= Html.Encode(Model.Historique)%></div>
        
            <div class="display-label">Caracteristiques</div>
            <div class="display-field-pre"><%= Html.Encode(Model.Caracteristiques)%></div>

        <% } %>

    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { pCode=Model.Code}) %> |
        <%= Html.ActionLink("Retour à la liste", "Index", "Machine", null)%>
    </p>

</asp:Content>

