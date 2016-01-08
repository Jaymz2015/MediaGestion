<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.FilmViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edition film
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Modification film</h2>

            <% using (Html.BeginForm("Upload", "Film", FormMethod.Post, new { enctype = "multipart/form-data" }))
               {%>
                <%= Html.ValidationSummary(true) %>

                        <%= Html.HiddenFor(model => model.LeFilm.Code) %>
                        <%= Html.ValidationMessageFor(model => model.LeFilm.Code)%>
      
                    <% var imgurl = Url.Action("ShowPhoto", "Film", new { pJaquette = Model.LeFilm.Jaquette }); %>

                  <!--<img src="/Support/ShowPhoto/1" alt="logo" width="200" />-->
                  
                    <img src="<%=imgurl %>" alt="logo" style="padding-right:2px;"/>        
                   
                    <br />
                    <label for="file">Jaquette :</label>
                    <input type="file" name="file" id="file1"  />
                    <p>
                        <input type="submit" />
                    </p>
             
              <% } %>
              
    <fieldset>
        <% using (Html.BeginForm()) {%>
            <%= Html.ValidationSummary(true) %>

            <!-- TITRE -->
             <div class="editor-label">
                <%= Html.LabelFor(model => model.LeFilm.Titre) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeFilm.Titre)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Titre)%>
            </div>
            
            <!-- DATE SORTIE -->
            <div class="editor-label">Date sortie</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeFilm.DateSortie, new { @class = "datepicker", @Value = Model.LeFilm.DateSortie.ToString("dd/MM/yyyy")})%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.DateSortie)%>
            </div>
     
            <!-- GENRE -->          
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LeFilm.LeGenre) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.LeFilm.LeGenre.Code,
                           new SelectList(this.Model.ListeGenres, "Code", "Libelle",
                                  this.Model.LeFilm.LeGenre))%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.LeGenre.Code)%>
            </div>
            
            <!-- DUREE -->
             <div class="editor-label">
                <%= Html.LabelFor(model => model.LeFilm.Duree) %>
            </div>
            <div class="editor-field">
                <%--<%= Html.TextBoxFor(model => model.LeFilm.Duree, new { Value = "" })%>--%>
 
                <%= Html.TextBoxFor(model => model.LeFilm.Duree)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Duree)%>
            </div>
            
            <!-- REALISATEUR -->
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LeFilm.Realisateur)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeFilm.Realisateur)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Realisateur)%>
            </div>
            
            <!-- ACTEURS -->
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LeFilm.Acteurs)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeFilm.Acteurs)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Acteurs)%>
            </div>
            
            <!-- SYNOPSIS -->
            <div class="editor-label">Synopsys</div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.LeFilm.Synopsys, new { style = "width:600px;height:200px" })%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Synopsys)%>
            </div>
            
            <%= Html.HiddenFor(model => model.LeFilm.Code) %>
            <%= Html.ValidationMessageFor(model => model.LeFilm.Code)%>
            
            <%= Html.HiddenFor(model => model.LeFilm.Jaquette) %>
            <%= Html.ValidationMessageFor(model => model.LeFilm.Jaquette)%>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>          
        <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
    </div>

</asp:Content>

