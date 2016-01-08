<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MediaGestion.Vues.Models.MediaViewModel>" %>

<fieldset>
            
        <!-- Emprunteur -->
        <div class="editor-label">Choix emprunteur</div>
        <div class="editor-field">
            <%= Html.DropDownListFor(model => model.Lemprunteur.Code, 
                new SelectList(Model.ListeProprietaire,"Code", "Value", 
                    Model.ListeProprietaire.First().Code))%>
            <%= Html.ValidationMessageFor(model => model.Lemprunteur.Code)%>
        </div>
   
        <br />
        <div class="display-label">ou saisir le nom de l'emprunteur</div>
        <br />
            
        <!-- Emprunteur -->
        <div class="editor-label">Nom</div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Lemprunteur.Nom)%>
            <%= Html.ValidationMessageFor(model => model.Lemprunteur.Nom)%>
        </div>

        <div class="editor-label">Prénom</div>
        <div class="editor-field">
            <%= Html.TextBoxFor(model => model.Lemprunteur.Prenom)%>
            <%= Html.ValidationMessageFor(model => model.Lemprunteur.Prenom)%>
        </div>

        <!--Code TypeMedia champ caché-->
        <div class="editor-field">
            <%= Html.HiddenFor(model => model.TypeMedia)%>
            <%= Html.ValidationMessageFor(model => model.TypeMedia)%>
        </div>

        <!--Code media champ caché-->
        <div class="editor-field">
            <%= Html.HiddenFor(model => model.LeMedia.TypeMedia)%>
            <%= Html.ValidationMessageFor(model => model.LeMedia.TypeMedia)%>
        </div>

        <!--Code media champ caché-->
        <div class="editor-field">
            <%= Html.HiddenFor(model => model.LeMedia.Code)%>
            <%= Html.ValidationMessageFor(model => model.LeMedia.Code)%>
        </div>

        <!--Code Exemplaire champ caché-->
        <div class="editor-field">
            <%= Html.HiddenFor(model => model.Lexemplaire.Code)%>
            <%= Html.ValidationMessageFor(model => model.Lexemplaire.Code)%>
        </div>


</fieldset>