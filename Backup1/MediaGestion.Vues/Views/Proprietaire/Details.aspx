<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Proprietaire>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Fiche "<%= Html.Encode(Model.Login) %>"
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>

        <div class="display-label">Login</div>
        <div class="display-field"><%= Html.Encode(Model.Login) %></div>
        
        <div class="display-label">Nom</div>
        <div class="display-field"><%= Html.Encode(Model.Nom) %>&nbsp<%= Html.Encode(Model.Prenom) %></div>
              
        <div class="display-label">Adresse</div>
        <div class="display-field"><%= Html.Encode(Model.Adresse) %>&nbsp<%= Html.Encode(Model.CP) %>&nbsp<%= Html.Encode(Model.Ville) %></div>

    </fieldset>
    
    
    <!-- LISTE D'EMPRUNTS EN COURS -->
    <% if (Model.ListeEmpruntsEnCours != null && Model.ListeEmpruntsEnCours.Count > 0)
       { %>
    
    <fieldset>
    
        <legend>Prêts en cours</legend>
                                             
                <div class="display-field">
             
                <table>
            
                    <tr>
                                    <th></th>
                                    <th>
                                        Titre
                                    </th>
                                    <th>
                                        Support
                                    </th>
                                    <th>
                                        Nom emprunteur
                                    </th>
                                    <th>
                                        Prêté le :
                                    </th>
                                    <th>
                                        Rendu le :
                                    </th>
                                   
                    </tr>

                    <% foreach (var ex in Model.ListeEmpruntsEnCours) { %>
         
                        <tr> 
                            <td>
                                   <% var imgurl = Url.Action("ThumbImage", "Film",
                                                    new { jaquette = ex.Lexemplaire.LeMedia.Jaquette, width = 100, height = 100 }); %>
                                        <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                            </td>
                            <td>
                                <%= Html.ActionLink(ex.Lexemplaire.LeMedia.Titre, "Details", "Film", new { codeFilm = ex.Lexemplaire.LeMedia.Code }, null)%>                   
                            </td> 
                            <td>
                                <%= Html.Encode(ex.Lexemplaire.LeSupport.Libelle)%>  
                            </td>
                            <td>
                                <%= Html.Encode(ex.Lemprunteur.Prenom + " " + ex.Lemprunteur.Nom)%>  
                            </td> 
                            <td>
                                <%= Html.Encode(ex.DatePrete.ToShortDateString())%>  
                            </td>  
                            <td>
                            
                                <% if (ex.DateRendu.Equals(DateTime.MinValue))
                                   { %>
                                        Prêt en cours !
                                <% }
                                   else
                                   { %>
                                   
                                        <%= Html.Encode(ex.DateRendu.ToShortDateString())%>  
                                
                                <% } %>
                                
                                
                            </td>
                        </tr> 

                    <% } %>
         
                </table>     
                </div>
    </fieldset>
    
    <% } %>
    
    <!-- LISTE D'EMPRUNTS CLOS -->
    <% if (Model.ListeEmpruntsClos != null && Model.ListeEmpruntsClos.Count > 0)
       { %>
    
    <fieldset>
    
        <legend>Prêts clos</legend>
                                             
                <div class="display-field">
             
                <table>
            
                    <tr>
                                    <th></th>
                                    <th>
                                        Titre
                                    </th>
                                    <th>
                                        Support
                                    </th>
                                    <th>
                                        Nom emprunteur
                                    </th>
                                    <th>
                                        Prêté le :
                                    </th>
                                    <th>
                                        Rendu le :
                                    </th>
                                   
                    </tr>

                    <% foreach (var ex in Model.ListeEmpruntsClos) { %>
         
                        <tr> 
                            <td>
                                   <% var imgurl = Url.Action("ThumbImage", "Film",
                                                    new { jaquette = ex.Lexemplaire.LeMedia.Jaquette, width = 100, height = 100 }); %>
                                        <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                            </td>
                            <td>
                                <%= Html.ActionLink(ex.Lexemplaire.LeMedia.Titre, "Details", "Film", new { codeFilm = ex.Lexemplaire.LeMedia.Code }, null)%>                   
                            </td> 
                            <td>
                                <%= Html.Encode(ex.Lexemplaire.LeSupport.Libelle)%>  
                            </td>
                            <td>
                                <%= Html.Encode(ex.Lemprunteur.Prenom + " " + ex.Lemprunteur.Nom)%>  
                            </td> 
                            <td>
                                <%= Html.Encode(ex.DatePrete.ToShortDateString())%>  
                            </td>  
                            <td>
                            
                                <% if (ex.DateRendu.Equals(DateTime.MinValue))
                                   { %>
                                        Prêt en cours !
                                <% }
                                   else
                                   { %>
                                   
                                        <%= Html.Encode(ex.DateRendu.ToShortDateString())%>  
                                
                                <% } %>
                                
                                
                            </td>
                        </tr> 

                    <% } %>
         
                </table>     
                </div>
    </fieldset>
    
    <% } %>
    
    <!-- LISTE DE SOUHAITS -->
    <% if (Model.ListeSouhaits != null && Model.ListeSouhaits.Count > 0)
       { %>
    
    <fieldset>
    
        <legend>Souhaits</legend>

          <div class="display-field">
             
            <table>
            
                    <tr>
                                    <th></th>
                                    <th>
                                        Titre
                                    </th>
                                    <th>
                                        Genre
                                    </th>
                                    <th>
                                        Support
                                    </th>
                                    <th></th>
                                    <th></th>
                    </tr>


         <% foreach (var ex in Model.ListeSouhaits) { %>
         
                        <tr> 
                            <td>
                                   <% var imgurl = Url.Action("ThumbImage", "Film",
                                                    new { jaquette = ex.LeMedia.Jaquette, width = 100, height = 100 }); %>
                                        <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                            </td>
                            <td>
                                <%= Html.ActionLink(ex.LeMedia.Titre, "Details", "Film", new { codeFilm = ex.LeMedia.Code }, null)%>                   
                            </td> 
                            <td>
                                <%= Html.Encode(ex.LeMedia.LeGenre.Libelle)%>                     
                            </td> 
                            <td>
                                <%= Html.Encode(ex.LeSupport.Libelle)%>  
                            </td>
                            <td>
                                <a href="<%= Url.Action("DeleteSouhait", "Film", new { pCodeFilm = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code, pCodeSupport = ex.LeSupport.Code } )  %>" class="lienEdition">
                                    <img src="../../Content/Images/delete_property-64.png" alt="Supprimer" title="Supprimer le souhait" class="boutonEdition"/>
                                </a>  
                            </td>  
                            <td>
                                <% if (!String.IsNullOrEmpty(ex.ExemplaireExistant)) { %>
                                    <img src="../../Content/Images/error-64.png" alt="<%=ex.ExemplaireExistant %>" title="<%=ex.ExemplaireExistant %>" class="boutonEdition"/>                                                                       
                                <% } %>
                            </td>
                        </tr> 

         <% } %>

         </table>     
          </div>
     
    </fieldset>
    
    <% } %>
    
    
    <p>
        <%= Html.ActionLink("Modifier", "Edit", new { pCode = Model.Code, pLogin = Model.Login })%> |
        <%= Html.ActionLink("Retour à la liste", "Index") %>
    </p>

</asp:Content>

