<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MediaGestion.Vues.Models.MediaViewModel>" %>

<h2><%= Html.Encode(Model.LeMedia.Titre)%></h2>
    <!--<img src="image.axd?codeFilm=<%= Html.Encode(Model.LeMedia.Code) %>" alt="coucou"/>-->
    <% var imgurl = Url.Action("ThumbImage", "Jeu", new { jaquette = Model.LeMedia.Photo, width = 600, height = 600 }); %>
   
    <fieldset>

        <img src="<%=imgurl %>" alt="jaquette" style="float: left; padding-right: 20px;" />
        <div class="display-label">Date sortie</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.LeJeu.DateSortie))%></div>
        <div class="display-label">Machine</div>
        <div class="display-field"><%= Html.ActionLink(Model.LeJeu.LaMachine.Nom, "Details", "Machine", new { pCode = Model.LeJeu.LaMachine.Code }, null)%>  
        <div class="display-label">Genre</div>
        <div class="display-field"><%= Html.Encode(Model.LeJeu.LeGenre.Libelle)%></div>
        <div class="display-label">Développeur</div>
        <div class="display-field"><%= Html.Encode(Model.LeJeu.Developpeur.Nom)%></div>
        <div class="display-label">Editeur</div>
        <div class="display-field"><%= Html.Encode(Model.LeJeu.Editeur.Nom)%></div>
        <div class="display-label">Synopsys</div>
        <div class="display-field"><%= Html.Encode(Model.LeJeu.Synopsys)%></div>

        <% if(! String.IsNullOrEmpty(Model.LeJeu.UrlFiche)) { %>
               
            <div class="display-field"><a href="<%= Html.Encode(Model.LeJeu.UrlFiche) %>" target="_blank">Lien jeuxvideo.com</a>

        <% } %>
    </fieldset>