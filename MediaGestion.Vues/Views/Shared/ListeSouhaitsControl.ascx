<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MediaGestion.Vues.Models.MediaViewModel>" %>

<fieldset>
        <legend>Souhaits</legend>
        
        <% if (Model.LeMedia.ListeSouhaits != null && Model.LeMedia.ListeSouhaits.Count > 0)
           { %>
        <div class="display-field">
            <table>
                <% foreach (var ex in Model.LeMedia.ListeSouhaits)
                   { %>
                <tr>
                    <td>
                        <%= Html.Encode(ex.LeProprietaire.Nom) + " " + Html.Encode(ex.LeProprietaire.Prenom)%>
                    </td>
                    <% if(Model.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM) { %>
                        <td>
                            <%= Html.Encode(ex.LeSupport.Libelle)%>
                        </td>
                    <% } %>
                    <td>
                        <a href="<%= Url.Action("DeleteSouhait", "Media", new { pCodeMedia = ex.LeMedia.Code, pCodeSouhait = ex.Code } )  %>"
                            class="lienEdition">
                            <img src="../../Content/Images/delete_property-64.png" alt="Supprimer" title="Supprimer le souhait"
                                class="boutonEdition" />
                        </a>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
        <% } %>
        <p>
            <a href="<%= Url.Action("CreerSouhait", new  { pCodeMedia = Model.LeMedia.Code } )  %>" class="lienEdition">
                <img src="../../Content/Images/add_property-64.png" alt="Creer" title="Ajouter à la liste de souhaits"
                    class="boutonEdition" />
            </a>
        </p>
    </fieldset>