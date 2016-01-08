<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Modele.Dl.Dlo.Support>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Modification support</h2>

        <fieldset>
        
            <% using (Html.BeginForm("Upload", "Support", FormMethod.Post, new { enctype = "multipart/form-data" }))
               {%>
                <%= Html.ValidationSummary(true) %>
                                
                        <%= Html.HiddenFor(model => model.Code) %>
                        <%= Html.ValidationMessageFor(model => model.Code) %>
                    

                    <% var imgurl = Url.Action("ShowPhoto", "Support", new { pCodeSupport = Model.Code }); %>

                  <!--<img src="/Support/ShowPhoto/1" alt="logo" width="200" />-->
                  
                    <img src="<%=imgurl %>" alt="logo" style="padding-right:2px;"/>        
                   
                    <br />
                    <label for="file">Logo support :</label>
                    <input type="file" name="file" id="file1"  />
                    <p>
                        <input type="submit" />
                    </p>
             
              <% } %>
              
            <% using (Html.BeginForm("Edit", "Support", FormMethod.Post, new { enctype = "multipart/form-data" }))
               {%>
                <%= Html.ValidationSummary(true) %>
        
            <!--<legend>Fields</legend>-->
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Code) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Code) %>
                <%= Html.ValidationMessageFor(model => model.Code) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Libelle) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Libelle) %>
                <%= Html.ValidationMessageFor(model => model.Libelle) %>
            </div>
            <%--<input type="file" name="files" id="file2" size="25" />
            --%>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        
        <% } %>

      </fieldset>

     
   <%--<form action="Upload" method="post" enctype="multipart/form-data">

      <img src="/Support/ShowPhoto/1" alt="" />
      <label for="file">Filename:</label>
      <input type="file" name="file" id="file" />

      <input type="submit" />
    </form>--%>
   
            

    <div>
        <%= Html.ActionLink("Retour à la liste", "Index", "Film", new { pNumeroPage = 1 }, null)%>
    </div>

</asp:Content>

