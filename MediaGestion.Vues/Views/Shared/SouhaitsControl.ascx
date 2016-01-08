<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <%--Bienvenue <b><%= Html.Encode(Page.User.Identity.Name) %></b>!--%>



         Bienvenue <b><%= Html.ActionLink(Html.Encode(Page.User.Identity.Name), "Details", "Proprietaire", new { pCode = Page.User.Identity.Name }, null)%></b>!

        [ <%= Html.ActionLink("Déconnexion", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Connexion", "LogOn", "Account") %> ]
<%
    }
%>
