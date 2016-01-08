<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MediaGestion.Vues.Models.MediaViewModel>" %>

<h2><%= Html.Encode(Model.LeMedia.Titre)%></h2>
    <% var imgurl = Url.Action("ThumbImage", "Serie", new { jaquette = Model.LeMedia.Photo, width = 100, height = 600 }); %>
    
    <fieldset>
        <!-- TODO : classe CSS non prise en compte -->
        <img src="<%=imgurl %>" alt="jaquette" style="float: left; padding-right: 20px;" />
        <div class="display-label">Date sortie</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.LaSerie.DateSortie))%></div>
        <div class="display-label">Nombre de saisons</div>
        <div class="display-field"><%= Html.Encode(Model.LaSerie.NbSaisons)%></div>
        <div class="display-label">Genre</div>
        <div class="display-field"><%= Html.Encode(Model.LaSerie.LeGenre.Libelle)%></div>
        <div class="display-label">Réalisateur</div>
        <div class="display-field"><%= Html.Encode(Model.LaSerie.Realisateur)%></div>
        <div class="display-label">Acteurs</div>
        <div class="display-field"><%= Html.Encode(Model.LaSerie.Acteurs)%></div>
        <div class="display-label">Synopsys</div>
        <div class="display-field"><%= Html.Encode(Model.LaSerie.Synopsys)%></div>

        <% if (!String.IsNullOrEmpty(Model.LaSerie.UrlFiche))
           { %>
               
            <div class="display-field">
                <a href="<%= Html.Encode(Model.LaSerie.UrlFiche) %>" target="_blank">Lien Allociné</a>
            </div>

        <% } %>

    </fieldset>
