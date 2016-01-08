<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%= Html.TextBox("", ViewData.TemplateInfo.FormattedModelValue, new { @class = "datepicker" })%>

<!--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateTime.ascx.cs" Inherits="MediaGestion.Vues.Views.Film.EditorTemplates.DateTime" %>-->

