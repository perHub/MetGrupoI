<%@ Page Title="" Language="C#" MasterPageFile="~/gvHU.master" AutoEventWireup="true" CodeBehind="product_backlog.aspx.cs" Inherits="ProyectoScrum.product_backlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="PBC" ContentPlaceHolderID="CPHU" runat="server">
<a href="/nueva_historia.aspx" style="text-decoration: none;">
   <input type="button" value="Nueva historia" style="width: 101px"/><br />
&nbsp;</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Footer" runat="server">
    <br />
Enviar a sprint:
<asp:DropDownList ID="DDSprs" runat="server" DataValueField="Id" DataTextField="Nombre">
</asp:DropDownList>
&nbsp;
<asp:Button ID="btnEnviar" runat="server" Text="Enviar al sprint" 
    onclick="btnEnviar_Click" Width="95px" />
</asp:Content>
