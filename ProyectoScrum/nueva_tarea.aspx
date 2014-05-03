<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="nueva_tarea.aspx.cs" Inherits="ProyectoScrum.nueva_tarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
       
        <asp:Label ID="Label4" runat="server" Text="Seleccione historia"></asp:Label>
        <asp:DropDownList ID="historiaDropDown" runat="server" >
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <asp:Label ID="error" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
        Nombre:
        <asp:TextBox ID="txtNom" runat="server" Width="94px"></asp:TextBox>
    </p>
    <asp:Label ID="lb" runat="server" Text="Estimacion"></asp:Label>
        <asp:TextBox ID="EstimacionTXT" runat="server" Width="90px"></asp:TextBox>
    <table>
        <tr>
            <td>
                <asp:Label ID="lbInicio" runat="server" Text="Fecha inicio"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" 
                    onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
            </td>
            <td>
                <asp:Label ID="lbFin" runat="server" Text="Fecha Fin"></asp:Label>
                <asp:Calendar ID="Calendar2" runat="server" 
                    onselectionchanged="Calendar2_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
     </table>
    <p>
        Descripción:<br />
        <asp:TextBox ID="txtDesc" runat="server" Height="74px" style="margin-top: 0px" 
            TextMode="MultiLine" Width="219px"></asp:TextBox> 
    </p>

        <div style="text-indent: 282px; width: 282px;"><asp:Button ID="btnCrear" 
                runat="server" Text="Crear" onclick="btnCrear_Click" /> </div>


    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
</asp:Content>
