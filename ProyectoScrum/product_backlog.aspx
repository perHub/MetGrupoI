<%@ Page Title="" Language="C#" MasterPageFile="~/gvHU.master" AutoEventWireup="true" CodeBehind="product_backlog.aspx.cs" Inherits="ProyectoScrum.product_backlog" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Footer" runat="server">
    <br />
Enviar a sprint:
<asp:Button ID="btnNuevaHistoria" runat="server" Text="Crear Historia de Usuario" 
    onclick="btnCrearHistoria_Click" Width="200px" />
<asp:DropDownList ID="DDSprs" runat="server" DataValueField="Id" DataTextField="Nombre">
</asp:DropDownList>
&nbsp;
<asp:Button ID="btnEnviar" runat="server" Text="Enviar al sprint" 
    onclick="btnEnviar_Click" Width="95px" />
</asp:Content>
