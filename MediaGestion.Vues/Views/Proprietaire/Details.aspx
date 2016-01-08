<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Proprietaire>" %>

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
    
    
    <!-- LISTE DE PRETS EN COURS -->
    <% if (Model.ListePretsEnCours != null && Model.ListePretsEnCours.Count > 0)
       { %>
    
    <fieldset>
    
        <legend><%=Html.Encode("Prêts en cours")%></legend>
                                              
                <div class="display-field">
             
                <table>
            
                    <tr>
                        <th></th>
                        <th>
                            Titre
                        </th>
                        <th>
                            Support/Machine
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

                    <% foreach (var ex in Model.ListePretsEnCours)
                       { %>
         
                        <% string nomControlleur="";

                        if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM)
                        {
                            nomControlleur = "Film";  
                        }
                        else if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.JEU)
                        {
                            nomControlleur="Jeu";  
                        } 
                        %>

                        <tr> 
                            <td>
                                <% var imgurl = Url.Action("ThumbImage", nomControlleur,
                                                new { jaquette = ex.Lexemplaire.LeMedia.Photo, width = 100, height = 100 }); %>
                                    <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                            </td>
                            <td>
                                <%= Html.ActionLink(ex.Lexemplaire.LeMedia.Titre, "Details", nomControlleur, new { codeMedia = ex.Lexemplaire.LeMedia.Code }, null)%>                   
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
    <% if (Model.ListePretsClos != null && Model.ListePretsClos.Count > 0)
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
                            Support/Machine
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

                    <% foreach (var ex in Model.ListePretsClos)
                       { %>

                       <% string nomControlleur="";

                        if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM)
                        {
                            nomControlleur = "Film";  
                        }
                        else if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.JEU)
                        {
                            nomControlleur="Jeu";  
                        } 
                        %>
         
                        <tr> 
                            <td>
                                <% var imgurl = Url.Action("ThumbImage", nomControlleur,
                                                new { jaquette = ex.Lexemplaire.LeMedia.Photo, width = 100, height = 100 }); %>
                                    <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                            </td>
                            <td>
                                <%= Html.ActionLink(ex.Lexemplaire.LeMedia.Titre, "Details", nomControlleur, new { codeMedia = ex.Lexemplaire.LeMedia.Code }, null)%>                   
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

    <!-- LISTE D'EMPRUNTS EN COURS -->
    <% if (Model.ListeEmpruntsEnCours != null && Model.ListeEmpruntsEnCours.Count > 0)
       { %>
    
    <fieldset>
    
        <legend><%=Html.Encode("Emprunts en cours")%></legend>
                                              
                <div class="display-field">
             
                <table>
            
                    <tr>
                        <th></th>
                        <th>
                            Titre
                        </th>
                        <th>
                            Support/Machine
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

                    <% foreach (var ex in Model.ListeEmpruntsEnCours)
                       { %>

                       <% string nomControlleur="";

                        if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM)
                        {
                            nomControlleur = "Film";  
                        }
                        else if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.JEU)
                        {
                            nomControlleur="Jeu";  
                        } 
                        %>
         
                        <tr> 
                            <td>
                                <% var imgurl = Url.Action("ThumbImage", nomControlleur,
                                                new { jaquette = ex.Lexemplaire.LeMedia.Photo, width = 100, height = 100 }); %>
                                    <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                            </td>
                            <td>
                                <%= Html.ActionLink(ex.Lexemplaire.LeMedia.Titre, "Details", nomControlleur, new { codeMedia = ex.Lexemplaire.LeMedia.Code }, null)%>                   
                            </td> 
                            <td>
                                <% 
                                if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM)
                                {%> 
                                    <%= Html.Encode(ex.Lexemplaire.LeSupport.Libelle)%>  
                                <% }
                                else if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.JEU)
                                {%>  
                                     
                                <%} 
                                %>
 
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
    
        <legend>Emprunts clos</legend>
                                             
                <div class="display-field">
             
                <table>
            
                    <tr>
                        <th></th>
                        <th>
                            Titre
                        </th>
                        <th>
                            Support/Machine
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

                    <% foreach (var ex in Model.ListeEmpruntsClos)
                       { %>

                       <% string nomControlleur="";

                        if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM)
                        {
                            nomControlleur = "Film";  
                        }
                        else if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.JEU)
                        {
                            nomControlleur="Jeu";  
                        } 
                        %>
         
                        <tr> 
                            <td>
                                <% var imgurl = Url.Action("ThumbImage", nomControlleur,
                                                new { jaquette = ex.Lexemplaire.LeMedia.Photo, width = 100, height = 100 }); %>
                                    <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                            </td>
                            <td>
                                <%= Html.ActionLink(ex.Lexemplaire.LeMedia.Titre, "Details", nomControlleur, new { codeMedia = ex.Lexemplaire.LeMedia.Code }, null)%>                   
                            </td> 
                            <td>
                                <% 
                                if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.FILM)
                                {%> 
                                    <%= Html.Encode(ex.Lexemplaire.LeSupport.Libelle)%>  
                                <% }
                                else if (ex.Lexemplaire.LeMedia.TypeMedia == MediaGestion.Modele.Constantes.EnumTypeMedia.JEU)
                                {%>  
                                     
                                <%} 
                                %>
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
    
    <!-- LISTE DE SOUHAITS FILM -->
    <% if (Model.ListeSouhaitsFilms != null && Model.ListeSouhaitsFilms.Count > 0)
       { %>
    
    <fieldset>
    
        <legend>Souhaits films</legend>

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


         <% foreach (var ex in Model.ListeSouhaitsFilms) { %>
                <% string nomControlleur = "Film";  

                %>

                <tr> 
                    <td>
                        <% var imgurl = Url.Action("ThumbImage", nomControlleur,
                                        new { jaquette = ex.LeMedia.Photo, width = 100, height = 100 }); %>
                            <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                    </td>
                    <td>
                        <%= Html.ActionLink(ex.LeMedia.Titre, "Details", nomControlleur, new { codeMedia = ex.LeMedia.Code }, null)%>                  
                    </td> 
                    <td>
                        <%= Html.Encode(ex.LeMedia.LeGenre.Libelle)%>                     
                    </td> 
                    <td>
                        <%= Html.Encode(ex.LeSupport.Libelle)%>
                    </td>
                    <td>
                        <a href="<%= Url.Action("DeleteSouhait", "Film", new { pCodeMedia = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code, pCodeSupport = ex.LeSupport.Code } )  %>" class="lienEdition">
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
    

    <!-- LISTE DE SOUHAITS JEU -->
    <% if (Model.ListeSouhaitsJeux != null && Model.ListeSouhaitsJeux.Count > 0)
       { %>
    
    <fieldset>
    
        <legend>Souhaits jeux</legend>

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
                        Machine
                    </th>
                    <th></th>
                    <th></th>
                </tr>


         <% foreach (var ex in Model.ListeSouhaitsJeux) { %>
                <% string nomControlleur = "Jeu"; %>

                <tr> 
                    <td>
                        <% var imgurl = Url.Action("ThumbImage", nomControlleur,
                                        new { jaquette = ex.LeMedia.Photo, width = 100, height = 100 }); %>
                            <img src="<%=imgurl %>" alt="jaquette" style="padding-right:2px;"/>        
                    </td>
                    <td>
                        <%= Html.ActionLink(ex.LeMedia.Titre, "Details", nomControlleur, new { codeMedia = ex.LeMedia.Code }, null)%>                  
                    </td> 
                    <td>
                        <%= Html.Encode(ex.LeMedia.LeGenre.Libelle)%>                     
                    </td> 
                    <td>
                        <%= Html.Encode(ex.LaMachine.Nom)%>  
                    </td>
                    <td>
                        <a href="<%= Url.Action("DeleteSouhait", "Jeu", new { pCodeMedia = ex.LeMedia.Code, pCodeProprietaire = ex.LeProprietaire.Code } )  %>" class="lienEdition">
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
        <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
    </p>

</asp:Content>

