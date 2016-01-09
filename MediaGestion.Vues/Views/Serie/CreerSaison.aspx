<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MediaViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Créer exemplaire
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

    <% Html.RenderPartial(Model.NomControlDetail); %>
    
    <fieldset>
            
            <!-- Numero de saison -->
            <div class="editor-label">Numero de saison</div>
            <div class="editor-field">

                <%= Html.TextBoxFor(model => model.LaSaison.Numero)%>
                <%= Html.ValidationMessageFor(model => model.LaSaison.Numero)%>
       
            </div>
   
            <!-- Année de sortie -->
            <div class="editor-label">Année de sortie</div>
            <div class="editor-field">

                <%= Html.TextBoxFor(model => model.LaSaison.AnneeSortie)%>
                <%= Html.ValidationMessageFor(model => model.LaSaison.AnneeSortie)%>
       
            </div>

            <!-- Nb épisodes -->
            <div class="editor-label">Nombre d'épisodes</div>
            <div class="editor-field">

                <%= Html.TextBoxFor(model => model.LaSaison.NbEpisodes)%>
                <%= Html.ValidationMessageFor(model => model.LaSaison.NbEpisodes)%>
       
            </div>
            
            <!--Code Serie champ caché-->
             <div class="editor-field">
                <%= Html.HiddenFor(model => model.LaSerie.Code)%>
                <%= Html.ValidationMessageFor(model => model.LaSerie.Code)%>
            </div>
            

        </fieldset>
        
        <p>
            <input type="submit" name="CreerExemplaire" value="Creer saison" />
        </p>
            
  <% } %>

    <p>
        <%= Html.ActionLink("Retour", "Details", Model.NomControlleur, new { codeMedia = Model.LeMedia.Code }, null)%>
    </p>

</asp:Content>



