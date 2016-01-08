<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Création série
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ajout série</h2>


        <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

             <% 
                 var imgurl = "";
               
                 if (!String.IsNullOrEmpty(this.Model.LaSerie.Photo))
                 {
                     imgurl = Url.Action("ThumbImage", "serie",
                                                 new { jaquette = this.Model.LaSerie.Photo, width = 100, height = 600 });

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
            
            <!-- DUREE -->
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

            <% if (!String.IsNullOrEmpty(Model.LaSerie.UrlFiche))
                { %>
                <div class="display-field"><a href="<%= Html.Encode(Model.LaSerie.UrlFiche) %>" target="_blank">Lien Allociné</a>
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
                <%= Html.HiddenFor(model => model.LaSerie.Photo)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Photo)%>
        
        </div>
        <div class="editor-field">
                <%= Html.HiddenFor(model => model.LaSerie.UrlFiche)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.UrlFiche)%>
        
        </div>     

    <% } %>
    

    <div>          
        <%= Html.ActionLink("Retour à la liste", "Index", "serie", new { pNumeroPage = 1 }, null)%>
    </div>

</asp:Content>

