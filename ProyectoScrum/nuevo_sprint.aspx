<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="nuevo_sprint.aspx.cs" Inherits="ProyectoScrum.nuevo_sprint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Nombre del sprint:&nbsp;
        <asp:TextBox ID="txtNomSprint" runat="server"></asp:TextBox>
    </p>
    <p>
        Fecha de inicio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtInicSprint" runat="server"></asp:TextBox>
    </p>
    <p>
        Fecha de fin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFinSprint" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;<asp:Button ID="btnCrearSprint" runat="server" Text="Crear sprint" />
    </p>
</asp:Content>
