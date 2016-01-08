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
   
            <!-- Support -->           
            <div class="editor-label">Support</div>
            <div class="editor-field">

                <%= Html.DropDownListFor(model => model.LeSupport.Code, 
                    new SelectList(Model.ListeSupports,"Code", "Libelle",
                                            Model.ListeSupports.First().Code))%>
                <%= Html.ValidationMessageFor(model => model.LeSupport.Code)%>
       
            </div>

            <!-- DATE ACQUISITION -->
             <div class="editor-label">Date acquisition</div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.DateAcquisition, new { @class = "datepicker", @Value = Model.DateAcquisition.ToString("dd/MM/yyyy") })%>                              
                <%= Html.ValidationMessageFor(model => model.DateAcquisition)%>
            </div>
            
            <!--Code Film champ caché-->
             <div class="editor-field">
                <%= Html.HiddenFor(model => model.LaSerie.Code)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Code)%>
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



