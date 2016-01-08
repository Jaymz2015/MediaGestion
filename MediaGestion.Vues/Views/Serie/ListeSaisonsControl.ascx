<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MediaGestion.Vues.Models.MediaViewModel>" %>

<fieldset>
        <legend>Saisons</legend>

         <% if (Model.LaSerie.ListeSaisons != null && Model.LaSerie.ListeSaisons.Count > 0)
           { %>


            <% foreach (MediaGestion.Modele.Dl.Dlo.Series.Saison saison in Model.LaSerie.ListeSaisons)
            { %>
                <div class="display-field">
                <h1>
                Saison <%=Html.Encode(saison.Numero)%> sortie en <%=Html.Encode(saison.AnneeSortie)%> : <%=Html.Encode(saison.NbEpisodes)%> épisodes
                </h1>
                </div>
            <% } %>

        <% } %>

        <% Html.RenderPartial("ListeExemplairesControl"); %>
        <% Html.RenderPartial("ListeSouhaitsControl"); %>   


        <p>
            <a href="<%= Url.Action("CreerSaisons", new  { pCodeMedia = Model.LeMedia.Code } )  %>"
                class="lienEdition">
                <img src="../../Content/Images/add_property-64.png" alt="Supprimer" title="Ajouter une saison"
                    class="boutonEdition" />
            </a>
        </p>
    </fieldset>