<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Modifier exemplaire
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.LaSerie.Titre) %></h2>

        <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

             <% var imgurl = Url.Action("ThumbImage", "Serie",
                            new { jaquette = Model.LaSerie.Photo, width = 100, height = 600 }); %>
            
        <fieldset>

            <img src="<%=imgurl %>" alt="jaquette" style="float: left; padding-right: 20px;" />
            <div class="display-label">Date sortie</div>
            <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.LaSerie.DateSortie))%></div>
            <div class="display-label">Durée</div>
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
               
                <div class="display-field"><a href="<%= Html.Encode(Model.LaSerie.UrlFiche) %>" target="_blank">Lien Allociné</a>

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
      
            <!--Code serie champ caché-->
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.LaSerie.Code)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Code)%>
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
        <%= Html.ActionLink("Retour", "Details", "Serie", new { codeMedia = Model.LaSerie.Code }, null)%>
    </p>

</asp:Content>



