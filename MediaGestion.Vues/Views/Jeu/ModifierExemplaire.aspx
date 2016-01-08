<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Modifier exemplaire
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.LeJeu.Titre) %></h2>

        <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

             <% var imgurl = Url.Action("ThumbImage", "Jeu",
                            new { jaquette = Model.LeJeu.Photo, width = 100, height = 600 }); %>
            
        <fieldset>
            <img src="<%=imgurl %>" alt="jaquette" style="float: left; padding-right: 20px;" />
            <div class="display-label">Date sortie</div>
            <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.AnneeSortie))%></div>
            <div class="display-label">Machine</div>
            <div class="display-field"><%= Html.ActionLink(Model.LeJeu.LaMachine.Nom, "Details", "Machine", new { pCode = Model.LeJeu.LaMachine.Code }, null)%>  
            <div class="display-label">Genre</div>
            <div class="display-field"><%= Html.Encode(Model.LeJeu.LeGenre.Libelle)%></div>
            <div class="display-label">Développeur</div>
            <div class="display-field"><%= Html.Encode(Model.LeJeu.Developpeur.Nom)%></div>
            <div class="display-label">Editeur</div>
            <div class="display-field"><%= Html.Encode(Model.LeJeu.Editeur.Nom)%></div>
            <div class="display-label">Synopsys</div>
            <div class="display-field"><%= Html.Encode(Model.LeJeu.Synopsys) %></div>

            <% if (!String.IsNullOrEmpty(Model.LeJeu.UrlFiche))
            { %>
               
                <div class="display-field"><a href="<%= Html.Encode(Model.LeJeu.UrlFiche) %>" target="_blank">Lien jeuxvideo.com</a>

            <% } %>

        </fieldset>
    
        <fieldset>
            
            <!-- ETAT -->
            <div class="editor-label">Etat</div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Lexemplaire.Etat.Code, new SelectList(Model.ListeEtatsMedia, "Code", "Libelle", Model.ListeEtatsMedia.Last().Code))%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.Etat.Code)%>
            </div>

            <!-- DATE ACQUISITION -->
             <div class="editor-label">Date acquisition</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.DateAcquisition, new { @class = "datepicker", @Value = Model.DateAcquisition.ToString("dd/MM/yyyy") })%>                              
                <%= Html.ValidationMessageFor(model => model.DateAcquisition)%>
            </div>
      
            <!--Code Jeu champ caché-->
             <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeJeu.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.Code)%>
            </div>

            <div class="editor-field">
                <%= Html.HiddenFor(model => model.Lexemplaire.Code)%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.Code)%>
            </div>

            <div class="editor-field">
                <%= Html.HiddenFor(model => model.Lexemplaire.Etat.Code)%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.Etat.Code)%>
            </div>

        </fieldset>
        
        <p>
            <input type="submit" name="ModifierExemplaire" value="Modifier exemplaire" />
        </p>
            
  <% } %>

    <p>
        <%= Html.ActionLink("Retour", "Details", "Jeu", new { codeMedia = Model.LeJeu.Code }, null)%>
    </p>

</asp:Content>



