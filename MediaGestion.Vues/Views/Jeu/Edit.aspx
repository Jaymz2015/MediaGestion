<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edition film
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Modification film</h2>

            <% using (Html.BeginForm("Upload", "Jeu", FormMethod.Post, new { enctype = "multipart/form-data" }))
               {%>
                <%= Html.ValidationSummary(true) %>

                        <%= Html.HiddenFor(model => model.LeJeu.Code) %>
                        <%= Html.ValidationMessageFor(model => model.LeJeu.Code)%>
      
                    <% var imgurl = Url.Action("ShowPhoto", "Jeu", new { pPhoto = Model.LeJeu.Photo }); %>

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
            <div class="editor-label"><%= Html.LabelFor(model => model.LeJeu.Titre) %></div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeJeu.Titre)%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.Titre)%>
            </div>

            <!-- MACHINE -->
            <div class="editor-label"><%= Html.LabelFor(model => model.LeJeu.LaMachine.Nom) %></div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeJeu.LaMachine.Nom)%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.LaMachine.Nom)%>
            </div>
            
            <!-- DATE SORTIE -->
            <div class="editor-label">Date sortie</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeJeu.DateSortie, new { @class = "datepicker", @Value = Model.LeJeu.DateSortie.ToString("dd/MM/yyyy")})%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.DateSortie)%>
            </div>
     
            <!-- GENRE -->          
            <div class="editor-label"><%= Html.LabelFor(model => model.LeJeu.LeGenre) %></div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.LeJeu.LeGenre.Code,
                           new SelectList(this.Model.ListeGenres, "Code", "Libelle",
                                  this.Model.LeJeu.LeGenre))%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.LeGenre.Code)%>
            </div>

            <!-- Developpeur -->
            <div class="editor-label"><%= Html.LabelFor(model => model.Developpeur)%></div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Developpeur)%>
                <%= Html.ValidationMessageFor(model => model.Developpeur)%>
            </div>
            
            <!-- Editeur -->
            <div class="editor-label"><%= Html.LabelFor(model => model.Editeur)%></div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Editeur)%>
                <%= Html.ValidationMessageFor(model => model.Editeur)%>
            </div>
            
            <!-- SYNOPSIS -->
            <div class="editor-label">Synopsys</div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.LeJeu.Synopsys, new { style = "width:600px;height:200px" })%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.Synopsys)%>
            </div>
            
            <%= Html.HiddenFor(model => model.LeJeu.Code) %>
            <%= Html.ValidationMessageFor(model => model.LeJeu.Code)%>
            
            <%= Html.HiddenFor(model => model.LeJeu.Photo) %>
            <%= Html.ValidationMessageFor(model => model.LeJeu.Photo)%>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <p>
        <%= Html.ActionLink("Retour", "Details", "Jeu", new { codeJeu = Model.LeJeu.Code }, null)%>
    </p>

</asp:Content>

