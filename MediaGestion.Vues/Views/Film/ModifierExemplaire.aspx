<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Modifier exemplaire
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.LeFilm.Titre) %></h2>

        <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

             <% var imgurl = Url.Action("ThumbImage", "Film",
                            new { jaquette = Model.LeFilm.Photo, width = 100, height = 600 }); %>
            
        <fieldset>
            <!--<legend>Fields</legend>-->
            <!-- TODO : classe CSS non prise en compte -->
            <img src="<%=imgurl %>" alt="jaquette" style="float: left; padding-right: 20px;" />
            <div class="display-label">Date sortie</div>
            <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.LeFilm.DateSortie))%></div>
            <div class="display-label">Durée</div>
            <div class="display-field"><%= Html.Encode(Model.LeFilm.Duree / 60 + "h" + Model.LeFilm.Duree % 60 + "mn")%></div>
            <div class="display-label">Genre</div>
            <div class="display-field"><%= Html.Encode(Model.LeFilm.LeGenre.Libelle)%></div>
            <div class="display-label">Réalisateur</div>
            <div class="display-field"><%= Html.Encode(Model.LeFilm.Realisateur)%></div>
            <div class="display-label">Acteurs</div>
            <div class="display-field"><%= Html.Encode(Model.LeFilm.Acteurs)%></div>
            <div class="display-label">Synopsys</div>
            <div class="display-field"><%= Html.Encode(Model.LeFilm.Synopsys)%></div>

            <% if (!String.IsNullOrEmpty(Model.LeFilm.UrlFiche))
           { %>
               
                <div class="display-field"><a href="<%= Html.Encode(Model.LeFilm.UrlFiche) %>" target="_blank">Lien Allociné</a>

            <% } %>

        </fieldset>
    
        <fieldset>
            
            <!-- SUPPORT -->
            <div class="editor-label">Support</div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Lexemplaire.LeSupport.Code, new SelectList(Model.ListeSupports, "Code", "Libelle", Model.ListeSupports.Last().Code))%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.LeSupport.Code)%>
            </div>

            <!-- DATE ACQUISITION -->
             <div class="editor-label">Date acquisition</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.DateAcquisition, new { @class = "datepicker", @Value = Model.DateAcquisition.ToString("dd/MM/yyyy") })%>                              
                <%= Html.ValidationMessageFor(model => model.DateAcquisition)%>
            </div>
      
            <!--Code Film champ caché-->
             <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeFilm.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Code)%>
            </div>

             <div class="editor-field">
                <%= Html.HiddenFor(model => model.Lexemplaire.Code)%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.Code)%>
            </div>

            <div class="editor-field">
                <%= Html.HiddenFor(model => model.Lexemplaire.Etat.Code)%>
                <%= Html.ValidationMessageFor(model => model.Lexemplaire.Etat.Code)%>
            </div>

           <%--  <div class="editor-field">
                <%= Html.HiddenFor(model => model.OldSupport.Code)%>
                <%= Html.ValidationMessageFor(model => model.OldSupport.Code)%>
            </div>--%>


        </fieldset>
        
        <p>
            <input type="submit" name="ModifierExemplaire" value="Modifier exemplaire" />
        </p>
            
  <% } %>

    <p>
        <%= Html.ActionLink("Retour", "Details", "Film", new { codeMedia = Model.LeFilm.Code }, null)%>
    </p>

</asp:Content>



