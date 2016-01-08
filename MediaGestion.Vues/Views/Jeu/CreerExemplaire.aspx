<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Créer exemplaire
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

    <% Html.RenderPartial(Model.NomControlDetail); %>

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
      
            <!--Code Jeu champ caché-->
             <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeJeu.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeJeu.Code)%>
            </div>

        </fieldset>
        
        <p>
            <input type="submit" name="CreerExemplaire" value="Creer exemplaire" />
        </p>
            
  <% } %>

    <p>
        <%= Html.ActionLink("Retour", "Details", Model.NomControlleur, new { codeMedia = Model.LeMedia.Code }, null)%>
    </p>
    

</asp:Content>



