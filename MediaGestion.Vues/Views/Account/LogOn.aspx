<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Connexion
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Connexion</h2>
    <p>
        Veuillez saisir votre login et mot de passe. <%= Html.ActionLink("Register", "Register") %> <!-- if you don't have an account.-->
    </p>

    <% using (Html.BeginForm()) { %>
        <%= Html.ValidationSummary(true, "La connexion a échoué. Merci de corriger les erreurs et de réessayer.") %>
        <div>
            <fieldset>
                <legend>Informations de compte</legend>
                
                <div class="editor-label">
                    <%= Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(m => m.UserName) %>
                    <%= Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%= Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%= Html.PasswordFor(m => m.Password) %>
                    <%= Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%= Html.CheckBoxFor(m => m.RememberMe) %>
                    <%= Html.LabelFor(m => m.RememberMe) %>
                </div>
                
                <p>
                    <input type="submit" value="Connexion" />
                </p>
            </fieldset>
            
            <%= Html.ActionLink("Propriétaires", "LogOn", "Account")%>
        </div>
    <% } %>
    
</asp:Content>
