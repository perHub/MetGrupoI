<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sprint_actual.aspx.cs" Inherits="ProyectoScrum.sprint_actual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<a href="/nueva_tarea.aspx" style="text-decoration: none;">
   <input type="button" value="Nueva tarea"/>
</a>
    <br />
    <br />
    <asp:GridView ID="gvTareas" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" Height="20px" Width="923px" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Tarea">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Label ID="lblTarea" runat="server" Text="Nombre tarea"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDesc" runat="server" Text="Descripción"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <asp:DropDownList ID="dropdownEstado" runat="server" Width="100">
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle Width="110px" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>
