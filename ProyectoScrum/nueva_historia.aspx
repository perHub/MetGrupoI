<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="nueva_historia.aspx.cs" Inherits="ProyectoScrum.nueva_historia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        Descripción:<br />
        <asp:TextBox ID="txtDescripcion" runat="server" Height="74px" style="margin-top: 0px" 
            TextMode="MultiLine" Width="219px"></asp:TextBox> </p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescripcion" 
            runat="server" Text="La Descripción es Obligatoria." ErrorMessage="Nombre"></asp:RequiredFieldValidator>
        <br />
        Estimación:&nbsp;
        <asp:TextBox ID="txtEstimacion" runat="server" Height="22px" style="margin-top: 0px" Width="50px">
        </asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtEstimacion" Text="Ingrese el valor de Prioridad en Números"
            Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>    
        <br />
        Prioridad:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrioridad" runat="server" Height="22px" style="margin-top: 0px" Width="50px">
        </asp:TextBox>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtPrioridad" Text="Ingrese el valor de Prioridad en Números"
            Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>    
        <br />
        Número:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtNumero" runat="server" Height="22px" 
        style="margin-top: 0px; margin-left: 0px;" Width="50px">
        </asp:TextBox>
        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtNumero" Text="Ingrese el Número en forma correcta"
            Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>    
        <br />
        <div style="text-indent: 282px; width: 282px;"><asp:Button ID="btnCrear" 
                runat="server" Text="Crear" onclick="btnCrear_Click" /> </div>


    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
</asp:Content>
