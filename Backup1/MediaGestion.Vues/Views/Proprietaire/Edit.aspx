<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.ProprietaireViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Edition propriétaire</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edition</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
 
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.Code) %>
                <%= Html.ValidationMessageFor(model => model.Code) %>
            </div>
            
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.PasswordHash) %>
                <%= Html.ValidationMessageFor(model => model.PasswordHash)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Login) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Login) %>
                <%= Html.ValidationMessageFor(model => model.Login) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(m => m.OldPassword) %>
            </div>
            <div class="editor-field">
                <%= Html.PasswordFor(m => m.OldPassword) %>
                <%= Html.ValidationMessageFor(m => m.OldPassword) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(m => m.NewPassword) %>
            </div>
            <div class="editor-field">
                <%= Html.PasswordFor(m => m.NewPassword) %>
                <%= Html.ValidationMessageFor(m => m.NewPassword) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(m => m.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%= Html.PasswordFor(m => m.ConfirmPassword) %>
                <%= Html.ValidationMessageFor(m => m.ConfirmPassword) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Nom) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Nom) %>
                <%= Html.ValidationMessageFor(model => model.Nom) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Prenom) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Prenom) %>
                <%= Html.ValidationMessageFor(model => model.Prenom) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Adresse) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Adresse) %>
                <%= Html.ValidationMessageFor(model => model.Adresse) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.CP) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.CP) %>
                <%= Html.ValidationMessageFor(model => model.CP) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Ville) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Ville) %>
                <%= Html.ValidationMessageFor(model => model.Ville) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Retour à la liste", "Index") %>
    </div>

</asp:Content>

