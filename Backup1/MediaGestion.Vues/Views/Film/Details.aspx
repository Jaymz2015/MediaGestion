<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Film>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fiche "<%= Html.Encode(Model.Titre) %>"
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(Model.Titre) %></h2>
    <!--<img src="image.axd?codeFilm=<%= Html.Encode(Model.Code) %>" alt="coucou"/>-->
    <% var imgurl = Url.Action("ThumbImage", "Film", new { jaquette = Model.Jaquette, width = 100, height = 600 }); %>
    
    <fieldset>
        <!--<legend>Fields</legend>-->
        <!-- TODO : classe CSS non prise en compte -->
        <img src="<%=imgurl %>" alt="jaquette" style="float: left; padding-right: 20px;" />
        <div class="display-label">
            Date sortie</div>
        <div class="display-field">
            <%= Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.DateSortie))%></div>
        <div class="display-label">
            Durée</div>
        <div class="display-field">
            <%= Html.Encode(Model.Duree / 60 + "h" + Model.Duree%60 + "mn")%></div>
        <div class="display-label">
            Genre</div>
        <div class="display-field">
            <%= Html.Encode(Model.LeGenre.Libelle)%></div>
        <div class="display-label">
            Réalisateur</div>
        <div class="display-field">
            <%= Html.Encode(Model.Realisateur) %></div>
        <div class="display-label">
            Acteurs</div>
        <div class="display-field">
            <%= Html.Encode(Model.Acteurs) %></div>
        <div class="display-label">
            Synopsys</div>
        <div class="display-field">
            <%= Html.Encode(Model.Synopsys) %></div>
    </fieldset>
    <fieldset>
        <legend>Exemplaires</legend>
        <%--<div class="display-label">Exemplaires</div>--%>
        <div class="display-field">
            <table>
                <% foreach (var ex in Model.ListeExemplaire)
                   { %>
                <tr>
                    <td>
                        <%= Html.Encode(ex.LeProprietaire.Nom) + " "
                                         + Html.Encode(ex.LeProprietaire.Prenom)%>
                    </td>
                    <td>
                        <%= Html.Encode(ex.LeSupport.Libelle)%>
                    </td>
                    <td>
                        <%--<%= Html.ActionLink("Supprimer", "DeleteExemplaire", "Film", new { pCodeFilm = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code, pCodeSupport = ex.LeSupport.Code }, null)%>
                    --%>
                        <a href="<%= Url.Action("DeleteExemplaire", new  { pCodeFilm = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code, pCodeSupport = ex.LeSupport.Code } )  %>"
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
                        <%= Html.ActionLink("Enregistrer prêt", "CreerEmprunt", "Film", new { pCodeFilm = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code, pCodeSupport = ex.LeSupport.Code }, null)%>
                        <% }
                           else
                           { %>
                        <%= Html.ActionLink("Cloturer prêt", "CloreEmprunt", "Film", new { pCodeFilm = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code, pCodeSupport = ex.LeSupport.Code }, null)%>
                        <% } %>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
        <p>
            <%--<%= Html.ActionLink("Ajouter exemplaire", "CreerExemplaire", "Film", new { pCodeFilm = Model.Code}, null)%>--%>
            <a href="<%= Url.Action("CreerExemplaire", new  { pCodeFilm = Model.Code } )  %>"
                class="lienEdition">
                <img src="../../Content/Images/add_property-64.png" alt="Supprimer" title="Ajouter un exemplaire"
                    class="boutonEdition" />
            </a>
        </p>
    </fieldset>
    <fieldset>
        <legend>Souhaits</legend>
        <%--<div class="display-label">Exemplaires</div>--%>
        <div class="display-field">
            <table>
                <% foreach (var ex in Model.ListeSouhaits)
                   { %>
                <tr>
                    <td>
                        <%= Html.Encode(ex.LeProprietaire.Nom) + " " + Html.Encode(ex.LeProprietaire.Prenom)%>
                    </td>
                    <td>
                        <%= Html.Encode(ex.LeSupport.Libelle)%>
                    </td>
                    <td>
                        <a href="<%= Url.Action("DeleteSouhait", new  { pCodeFilm = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code, pCodeSupport = ex.LeSupport.Code } )  %>"
                            class="lienEdition">
                            <img src="../../Content/Images/delete_property-64.png" alt="Supprimer" title="Supprimer le souhait"
                                class="boutonEdition" />
                        </a>
                    </td>
                </tr>
                <% } %>
            </table>
        </div>
        <p>
            <a href="<%= Url.Action("CreerSouhait", new  { pCodeFilm = Model.Code } )  %>" class="lienEdition">
                <img src="../../Content/Images/add_property-64.png" alt="Creer" title="Ajouter ce film à la liste de souhaits"
                    class="boutonEdition" />
            </a>
        </p>
    </fieldset>
    <p>
        <%= Html.ActionLink("Editer", "Edit", "Film", new { pCodeFilm = Model.Code }, null)%>
        |
        <%= Html.ActionLink("Supprimer", "Delete", "Film", new { pCodeFilm = Model.Code }, null)%>
        |
        <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
    </p>
</asp:Content>
