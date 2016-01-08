<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.FilmViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Créer exemplaire
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Html.Encode(Model.LeFilm.Titre) %></h2>

        <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        
             <% var imgurl = Url.Action("ThumbImage", "Film",
                            new { jaquette = Model.LeFilm.Jaquette, width = 100, height = 600 }); %>
            
    <fieldset>
        <!--<legend>Fields</legend>-->
        <!-- TODO : classe CSS non prise en compte -->
        <img src="<%=imgurl %>" alt="jaquette" style="float:left;padding-right:20px;"/>
        <div class="display-label">Date sortie</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.LeFilm.DateSortie))%></div>

        <div class="display-label">Réalisateur</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.Realisateur)%></div>
        
        <div class="display-label">Acteurs</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.Acteurs)%></div>
        
        <div class="display-label">Synopsys</div>
        <div class="display-field"><%= Html.Encode(Model.LeFilm.Synopsys)%></div>
        
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
            
            <!--Code Film champ caché-->
             <div class="editor-field">
                <%= Html.HiddenFor(model => model.LeFilm.Code)%>
                <%= Html.ValidationMessageFor(model => model.LeFilm.Code)%>
            </div>
            

        </fieldset>
        
        <p>
            <input type="submit" name="CreerExemplaire" value="Creer souhait" />
        </p>
            
  <% } %>

    <p>
        <%= Html.ActionLink("Editer", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%= Html.ActionLink("Retour à la liste", "Index") %>
    </p>

</asp:Content>



