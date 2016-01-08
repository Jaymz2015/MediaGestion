<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MediaGestion.Vues.Models.MediaViewModel>" %>

<h2><%= Html.Encode(Model.LeMedia.Titre)%></h2>
    <!--<img src="image.axd?codeFilm=<%= Html.Encode(Model.LeMedia.Code) %>" alt="coucou"/>-->
    <% var imgurl = Url.Action("ThumbImage", "Film", new { jaquette = Model.LeMedia.Photo, width = 100, height = 600 }); %>
    
    <fieldset>
        <!-- TODO : classe CSS non prise en compte -->
        <img src="<%=imgurl %>" alt="jaquette" style="float: left; padding-right: 20px;" />
        <div class="display-label">Date sortie</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.LeFilm.DateSortie))%></div>
        <div class="display-label">Durée</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.Duree / 60 + "h" + Model.LeFilm.Duree % 60 + "mn")%></div>
        <div class="display-label">Genre</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.LeGenre.Libelle)%></div>
        <div class="display-label">Réalisateur</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.Realisateur) %></div>
        <div class="display-label">Acteurs</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.Acteurs) %></div>
        <div class="display-label">Synopsys</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.Synopsys) %></div>

        <% if(! String.IsNullOrEmpty(Model.LeFilm.UrlFiche)) { %>
               
            <div class="display-field"><a href="<%= Html.Encode(Model.LeFilm.UrlFiche) %>" target="_blank">Lien Allociné</a>

        <% } %>

    </fieldset>
