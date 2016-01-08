<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site2.Master" Inherits="System.Web.Mvc.ViewPage<MediaGestion.Vues.Models.MachineViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">Modification machine</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Modification machine</h2>

        <fieldset>
        
            <% using (Html.BeginForm("UploadLogo", "Machine", FormMethod.Post, new { enctype = "multipart/form-data" }))
               {%>
                <%= Html.ValidationSummary(true) %>
                                
                    <%= Html.HiddenFor(model => model.LaMachine.Code) %>
                    <%= Html.ValidationMessageFor(model => model.LaMachine.Code)%>
                    
                    <% var imgurl = Url.Action("ShowLogo", "Machine", new { pCodeMachine = Model.LaMachine.Code, pTaille = 300 }); %>

                  <!--<img src="/Machine/ShowPhoto/1" alt="logo" width="200" />-->
                  
                    <img src="<%=imgurl %>" alt="logo" style="padding-right:2px;"/>        
                   
                    <br />
                    <label for="file">Logo machine :</label>
                    <input type="file" name="file" id="file1"  />
                    <p>
                        <input type="submit" />
                    </p>
             
              <% } %>
              
            <% using (Html.BeginForm("Upload", "Machine", FormMethod.Post, new { enctype = "multipart/form-data" }))
               {%>
                <%= Html.ValidationSummary(true) %>
                                
                    <%= Html.HiddenFor(model => model.LaMachine.Code) %>
                    <%= Html.ValidationMessageFor(model => model.LaMachine.Code)%>
                    
                    <% var imgurl = Url.Action("ShowPhoto", "Machine", new { pCodeMachine = Model.LaMachine.Code, pTaille = 300 }); %>

                  <!--<img src="/Machine/ShowPhoto/1" alt="logo" width="200" />-->
                  
                    <img src="<%=imgurl %>" alt="photo" style="padding-right:2px;"/>        
                   
                    <br />
                    <label for="file">Photo machine :</label>
                    <input type="file" name="file" id="file2"  />
                    <p>
                        <input type="submit" />
                    </p>
             
              <% } %>


            <% using (Html.BeginForm("Edit", "Machine", FormMethod.Post, new { enctype = "multipart/form-data" })) {%>
                <%= Html.ValidationSummary(true) %>

                <div class="editor-label">
                    <%= Html.LabelFor(model => model.LaMachine.Code)%>
                </div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.LaMachine.Code)%>
                    <%= Html.ValidationMessageFor(model => model.LaMachine.Code)%>
                </div>
            
                <div class="editor-label">
                    <%= Html.LabelFor(model => model.LaMachine.Nom)%>
                </div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.LaMachine.Nom)%>
                    <%= Html.ValidationMessageFor(model => model.LaMachine.Nom)%>
                </div>

                <!-- DATE SORTIE -->
                <div class="editor-label">Date sortie france</div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(model => model.LaMachine.DateSortie, new { @class = "datepicker", @Value = Model.LaMachine.DateSortie.ToString("dd/MM/yyyy") })%>               
                
                    <%= Html.ValidationMessageFor(model => model.LaMachine.DateSortie)%>
                </div>
                <div class="editor-label">
                    <%= Html.LabelFor(model => model.LaMachine.Historique)%>
                </div>
                <div class="editor-field">
                    <%= Html.TextAreaFor(model => model.LaMachine.Historique, new { style = "width:600px;height:200px" })%>
                    <%= Html.ValidationMessageFor(model => model.LaMachine.Historique)%>
                </div>
                <div class="editor-label">
                    <%= Html.LabelFor(model => model.LaMachine.Caracteristiques)%>
                </div>
                <div class="editor-field">
                    <%= Html.TextAreaFor(model => model.LaMachine.Caracteristiques, new { style = "width:600px;height:200px" })%>
                    <%= Html.ValidationMessageFor(model => model.LaMachine.Caracteristiques)%>
                </div>

                <div class="editor-field">
                    <%= Html.HiddenFor(model => model.OldCode)%>
                    <%= Html.ValidationMessageFor(model => model.OldCode)%>
                </div>

                <div class="editor-field">
                    <%= Html.HiddenFor(model => model.LaMachine.LeConstructeur.Code)%>
                    <%= Html.ValidationMessageFor(model => model.LaMachine.LeConstructeur.Code)%>
                </div>
       
                <p>
                    <input type="submit" value="Save" />
                </p>
        
            <% } %>

      </fieldset>

    <div>
        <%= Html.ActionLink("Retour à la liste", "Index", "Machine", null)%>
    </div>

</asp:Content>

