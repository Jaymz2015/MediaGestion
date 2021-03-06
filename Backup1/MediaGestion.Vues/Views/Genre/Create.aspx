﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Genre>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Création genre
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ajout Genre</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <!--<legend>Fields</legend>-->
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Code) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Code) %>
                <%= Html.ValidationMessageFor(model => model.Code) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Libelle) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Libelle) %>
                <%= Html.ValidationMessageFor(model => model.Libelle) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Retour à la liste", "Index") %>
    </div>

</asp:Content>

