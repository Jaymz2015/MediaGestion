<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Création jeu
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ajout jeu</h2>


        <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

             <% 
                 var imgurl = "";
               
                 if (!String.IsNullOrEmpty(this.Model.LeJeu.Photo))
                 {
                     imgurl = Url.Action("ThumbImage", "Jeu",
                                                 new { jaquette = this.Model.LeJeu.Photo, width = 100, height = 600 });

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
                <%= Html.LabelFor(model => model.LeJeu.Titre) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeJeu.Titre)%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.Titre)%>
            </div>
                                    
            <!-- MACHINE -->
            <div class="editor-label">Machine</div>
            <div class="editor-field">

                <%= Html.DropDownListFor(model => model.LeJeu.LaMachine.Code, 
                    new SelectList(Model.ListeMachines,"Code", "Nom",
                                                           Model.ListeMachines.First().Code))%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.LaMachine.Code)%>
       
            </div>
            
            <!-- DATE SORTIE -->
             <div class="editor-label">Date Sortie</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LeJeu.DateSortie, new { @class = "datepicker", @Value = Model.LeJeu.DateSortie.ToString("dd/MM/yyyy") })%>                              
                <%= Html.ValidationMessageFor(model => model.LeJeu.DateSortie)%>
            </div>
     
            <!-- GENRE -->
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LeJeu.LeGenre) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.LeJeu.LeGenre.Code,
                           new SelectList(this.Model.ListeGenres, "Code", "Libelle",
                                  this.Model.LeJeu.LeGenre))%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.LeGenre.Code)%>
            </div>

            <!-- Developpeur -->
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Developpeur)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Developpeur)%>
                <%= Html.ValidationMessageFor(model => model.Developpeur)%>
            </div>
            
            <!-- Editeur -->
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Editeur)%>
            </div>
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

            <!-- ETAT -->
            <div class="editor-label">Etat</div>
            <div class="editor-field">
        
                <%= Html.DropDownListFor(model => model.Etat.Code, 
                    new SelectList(Model.ListeEtatsMedia,"Code", "Libelle",
                                       Model.ListeEtatsMedia.Last().Code))%>
     
                <%= Html.ValidationMessageFor(model => model.Etat.Code)%>
       
            </div>

            <!-- DATE ACQUISITION -->
             <div class="editor-label">Date acquisition</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.DateAcquisition, new { @class = "datepicker", @Value = Model.DateAcquisition.ToString("dd/MM/yyyy") })%>                              
                <%= Html.ValidationMessageFor(model => model.DateAcquisition)%>
            </div>
                 
        </fieldset>
        
        <p>
           <input type="submit" name="creerExemplaire" value="Créer exemplaire" />   
           <input type="submit" name="creerSouhait" value="Ajouter à la liste de souhaits"  />
        </p>
        
        
        <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeJeu.Photo)%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.Photo)%>
        </div>
            

    <% } %>
    

    <div>          
        <%= Html.ActionLink("Retour à la liste", "Index", "Jeu", new { pNumeroPage = 1 }, null)%>
    </div>

</asp:Content>

