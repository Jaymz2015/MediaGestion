<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Création film
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ajout film</h2>


        <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

             <% 
                 var imgurl = "";
               
                 if (!String.IsNullOrEmpty(this.Model.LeFilm.Photo))
                 {
                     imgurl = Url.Action("ThumbImage", "Film",
                                                 new { jaquette = this.Model.LeFilm.Photo, width = 100, height = 600 });

                 }
                 else
                 {
                     imgurl = "../../Content/Images/fichiervide.png";
                 }
               
               %>
            
        <fieldset>

            <img src="<%=imgurl %>" alt="jaquette" style="float:left;padding-right:20px;"/>
        
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
                <!--<%= Html.TextBoxFor(model => model.LeFilm.Duree, new { Value = "" })%>-->
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

            <% if (!String.IsNullOrEmpty(Model.LeFilm.UrlFiche))
                { %>
                <div class="display-field"><a href="<%= Html.Encode(Model.LeFilm.UrlFiche) %>" target="_blank">Lien Allociné</a>
            <% } %>

        </fieldset>
      
        <fieldset>
            
            <!-- PROPRIETAIRE -->
            <div class="editor-label">Propriétaire</div>
            <div class="editor-field">

                <%= Html.DropDownListFor(model => model.LeProprietaire.Code, 
                    new SelectList(Model.ListeProprietaire,"Code", "Value", 
                        Model.ListeProprietaire.First().Code))%>
                <%= Html.ValidationMessageFor(model => model.LeProprietaire.Code)%>
       
            </div>

            <!-- Support -->
            <div class="editor-label">Support</div>
            <div class="editor-field">

                <%= Html.DropDownListFor(model => model.LeSupport.Code, 
                    new SelectList(Model.ListeSupports,"Code", "Libelle",
                                            Model.ListeSupports.First().Code))%>
                <%= Html.ValidationMessageFor(model => model.LeSupport.Code)%>
       
            </div>
            

            <%--<!-- SOUHAIT ? -->
            <div class="editor-label">Propriétaire</div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.EstSouhait)%>
                <%= Html.ValidationMessageFor(model => model.EstSouhait)%>
            </div>
--%>
            
        </fieldset>
        
        <p>
           <input type="submit" name="creerExemplaire" value="Créer exemplaire" />   <input type="submit" name="creerSouhait" value="Ajouter à la liste de souhaits"  />
        </p>
        
        
        <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeFilm.Photo)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Photo)%>
        
        </div>
        <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeFilm.UrlFiche)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.UrlFiche)%>
        
        </div>     

    <% } %>
    

    <div>          
        <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
    </div>

</asp:Content>

