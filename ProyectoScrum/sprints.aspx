<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sprints.aspx.cs" Inherits="ProyectoScrum.sprints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnNuSprint" runat="server" Text="Nuevo sprint" Width="91px" OnClick="~/nuevo_sprint.aspx"  />
    <br />
    <br /><b>Sprints actuales</b>
    <br />&nbsp;&nbsp;&nbsp;
        *lista de sprints actuales 
    <br />
    <br /><b>Sprints futuros</b>
    <br />&nbsp;&nbsp;&nbsp;
        *lista de sprints futuros<br />
    <br />
    <b>Sprints pasados</b>
    <br />&nbsp;&nbsp;&nbsp; *lista de sprints pasados
</asp:Content>
