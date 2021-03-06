﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Machine>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ajout machine</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Code) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Code) %>
                <%= Html.ValidationMessageFor(model => model.Code) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Nom) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Nom) %>
                <%= Html.ValidationMessageFor(model => model.Nom) %>
            </div>
            <!-- DATE SORTIE -->
            <div class="editor-label">Date sortie france</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.DateSortie, new { @class = "datepicker", @Value = Model.DateSortie.ToString("dd/MM/yyyy") })%>               
                
                <%= Html.ValidationMessageFor(model => model.DateSortie)%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Historique)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Historique) %>
                <%= Html.ValidationMessageFor(model => model.Historique)%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Caracteristiques)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Caracteristiques)%>
                <%= Html.ValidationMessageFor(model => model.Caracteristiques)%>
            </div>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Retour à la liste", "Index", "Machine", null)%>
    </div>

</asp:Content>

