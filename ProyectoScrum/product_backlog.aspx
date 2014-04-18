<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="product_backlog.aspx.cs" Inherits="ProyectoScrum.product_backlog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
                        <asp:Label ID="L1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Historias.Descripcion")%>'></asp:Label>
						<asp:Label ID="L2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Historias.Estimacion")%>'></asp:Label>
						<asp:Label ID="L3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Historias.Prioridad")%>'></asp:Label>
        </ItemTemplate>

        </asp:ListView>
        
    </p>


</asp:Content>
