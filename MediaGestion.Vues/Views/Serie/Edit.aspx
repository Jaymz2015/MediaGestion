<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edition serie
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Modification serie</h2>

            <% using (Html.BeginForm("Upload", "serie", FormMethod.Post, new { enctype = "multipart/form-data" }))
               {%>
                <%= Html.ValidationSummary(true) %>

                        <%= Html.HiddenFor(model => model.LaSerie.Code) %>
                        <%= Html.ValidationMessageFor(model => model.LaSerie.Code)%>
      
                    <% var imgurl = Url.Action("ShowPhoto", "serie", new { pPhoto = Model.LaSerie.Photo }); %>

                  <!--<img src="/Support/ShowPhoto/1" alt="logo" width="200" />-->
                  
                    <img src="<%=imgurl %>" alt="logo" style="padding-right:2px;"/>        
                   
                    <br />
                    <label for="file">Photo :</label>
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
                <%= Html.LabelFor(model => model.LaSerie.Titre) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LaSerie.Titre)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Titre)%>
            </div>
            
            <!-- DATE SORTIE -->
            <div class="editor-label">Date sortie</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LaSerie.DateSortie, new { @class = "datepicker", @Value = Model.LaSerie.DateSortie.ToString("dd/MM/yyyy")})%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.DateSortie)%>
            </div>
     
            <!-- GENRE -->          
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LaSerie.LeGenre) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.LaSerie.LeGenre.Code,
                           new SelectList(this.Model.ListeGenres, "Code", "Libelle",
                                  this.Model.LaSerie.LeGenre))%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.LeGenre.Code)%>
            </div>
            
            <!-- NB SAISONS -->
             <div class="editor-label">
                <%= Html.LabelFor(model => model.LaSerie.NbSaisons) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LaSerie.NbSaisons)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.NbSaisons)%>
            </div>
            
            <!-- REALISATEUR -->
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LaSerie.Realisateur)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LaSerie.Realisateur)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Realisateur)%>
            </div>
            
            <!-- ACTEURS -->
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LaSerie.Acteurs)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LaSerie.Acteurs)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Acteurs)%>
            </div>
            
            <!-- SYNOPSIS -->
            <div class="editor-label">Synopsys</div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.LaSerie.Synopsys, new { style = "width:600px;height:200px" })%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Synopsys)%>
            </div>
            
            <%= Html.HiddenFor(model => model.LaSerie.Code) %>
            <%= Html.ValidationMessageFor(model => model.LaSerie.Code)%>
            
            <%= Html.HiddenFor(model => model.LaSerie.Photo) %>
            <%= Html.ValidationMessageFor(model => model.LaSerie.Photo)%>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <p>
        <%= Html.ActionLink("Retour", "Details", "serie", new { codeMedia = Model.LaSerie.Code }, null)%>
    </p>

</asp:Content>

