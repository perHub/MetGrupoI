﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sprint_actual.aspx.cs" Inherits="ProyectoScrum.sprint_actual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<a href="/nueva_tarea.aspx" style="text-decoration: none;">
   <input type="button" value="Nueva tarea"/>
</a>
    <br />
    <br />
    <asp:GridView ID="gvTareas" runat="server" 
        onselectedindexchanged="gvTareas_SelectedIndexChanged" autogenerateselectbutton="True">
    </asp:GridView>
</asp:Content>
