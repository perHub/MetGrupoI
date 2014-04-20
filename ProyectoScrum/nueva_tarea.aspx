<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="nueva_tarea.aspx.cs" Inherits="ProyectoScrum.nueva_tarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        Nombre:
        <asp:TextBox ID="txtNom" runat="server" Width="94px"></asp:TextBox>
    </p>
    <p>
        Descripción:<br />
        <asp:TextBox ID="txtDesc" runat="server" Height="74px" style="margin-top: 0px" 
            TextMode="MultiLine" Width="219px"></asp:TextBox> </p>

        Estado:
        <asp:DropDownList ID="dropdEst" runat="server">
        </asp:DropDownList>
        <div style="text-indent: 282px; width: 282px;"><asp:Button ID="btnCrear" 
                runat="server" Text="Crear" onclick="btnCrear_Click" /> </div>


    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
</asp:Content>
