<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MediaGestion.Vues.Models.MediaViewModel>" %>

<fieldset>
        <legend>Exemplaires</legend>

         <% if (Model.LeMedia.ListeExemplaire != null && Model.LeMedia.ListeExemplaire.Count > 0)
           { %>

        <div class="display-field">
            <table>
                <tr>
                    <th>Propriétaire</th>
                    <% if ( Model.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM) { %>
                        <th>Support</th>
                    <% } %>
                    <th>Etat</th>
                    <th>Date acquisition</th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>

                <% foreach (var ex in Model.LeMedia.ListeExemplaire)
                   { %>
                <tr>
                    <td>
                        <%= Html.Encode(ex.LeProprietaire.Nom) + " "
                                         + Html.Encode(ex.LeProprietaire.Prenom)%>
                    </td>
                    <% if ( Model.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM) { %>
                    
                        <td>
                            <%= Html.Encode(ex.LeSupport.Libelle)%>
                        </td>
                    <% } %>
                    <td>
                        <%= Html.Encode(ex.Etat.Libelle)%>
                    </td>
                    <td>
                        
                         <% if (ex.DateAcquisition.Equals(new DateTime()))
                            { %>
                                INCONNUE
                        <%   } else {  %>
                                <%= Html.Encode(ex.DateAcquisition.ToShortDateString())%>

                        <%   }  %>   
                                 
                    </td>
                    <td>
                        <a href="<%= Url.Action("ModifierExemplaire", new { pCodeMedia = ex.LeMedia.Code, pCodeExemplaire = ex.Code, pCodeEtat = ex.Etat.Code} )  %>"
                            class="lienEdition">
                            <img src="../../Content/Images/edit_property-64.png" alt="Modifier" title="Modifier l'exemplaire"
                                class="boutonEdition" />
                        </a>
                    </td>
                    <td>
                        <a href="<%= Url.Action("DeleteExemplaire", "Media", new { pCodeMedia = ex.LeMedia.Code, pCodeExemplaire = ex.Code } )  %>"
                            class="lienEdition">
                            <img src="../../Content/Images/delete_property-64.png" alt="Supprimer" title="Supprimer l'exemplaire"
                                class="boutonEdition" />
                        </a>
                    </td>
                    <td>
                        <% if (ex.EstDispo)
                           { %>
                        <img src="../../Content/Images/ok-64.png" alt="Exemplaire disponible" title="Exemplaire disponible"
                            class="boutonEdition" />
                        <% }
                           else
                           { %>
                        <img src="../../Content/Images/cancel-64.png" alt="<%="Prêté à " + ex.NomEmprunteur + " le " + ex.DateEmprunt%>"
                            title="<%="Prêté à " + ex.NomEmprunteur + " le " + ex.DateEmprunt%>" class="boutonEdition" />
                        <% } %>
                    </td>
                    <td>
                        <% if (ex.EstDispo)
                           { %>
                        <%= Html.ActionLink("Enregistrer prêt", "CreerEmprunt", "Media", new { pCodeMedia = ex.LeMedia.Code, pCodeExemplaire = ex.Code, pTypeMedia = Model.TypeMedia }, null)%>
                        <% }
                           else
                           { %>
                        <%= Html.ActionLink("Cloturer prêt", "CloreEmprunt", "Media", new { pCodeMedia = ex.LeMedia.Code, pCodeEmprunt = ex.CodeEmprunt, pTypeMedia = Model.TypeMedia }, null)%>
                        <% } %>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
        
        <% } %>
        <p>
            <a href="<%= Url.Action("CreerExemplaire", new  { pCodeMedia = Model.LeMedia.Code } )  %>"
                class="lienEdition">
                <img src="../../Content/Images/add_property-64.png" alt="Supprimer" title="Ajouter un exemplaire"
                    class="boutonEdition" />
            </a>
        </p>
    </fieldset>