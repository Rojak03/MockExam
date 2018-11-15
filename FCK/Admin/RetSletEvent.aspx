<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="RetSletEvent.aspx.cs" Inherits="Admin_RetSletEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:panel id="pnlAlleEvents" runat="server" CssClass="content" visible="true">
        <h1>Artiviteter, Træning og Prøver</h1>
        <br />
        <asp:Literal ID="litAlleEvents" runat="server" />

    </asp:panel>

    <asp:panel id="pnlEnEvent" runat="server" visible="false">
        <asp:TextBox ID="txtID" runat="server" Visible="false" />
        <table>
            <tr>
                <td>Typer: </td>
                <td>
                    <asp:DropDownList ID="ddlTyper" runat="server" /></td>
            </tr>
            <tr>
                <td>Kategori: </td>
                <td>
                    <asp:DropDownList ID="ddlKat" runat="server" /></td>
            </tr>
            <tr>
                <td>Ansvarligt:</td>
                <td>
                    <asp:DropDownList ID="ddlInstructor" runat="server" /></td>
                <td>Role: </td>
                <td>
                    <asp:DropDownList ID="ddlRoles" runat="server" /></td>
            </tr>
            <tr>
                <td>Sted: </td>
                <td>
                    <asp:TextBox ID="txtSted" runat="server" /></td>
            </tr>
            <tr>
                <td>Dato:</td>
                <td>
                    <asp:TextBox ID="txtDato" runat="server" /></td>
            </tr>
            <tr>
                <td>Beskrivelse: </td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server" /></td>
            </tr>
            <tr>
                <td>Rules:</td>
                <td>
                    <asp:TextBox ID="txtRules" runat="server" /></td>
            </tr>
            <tr>
            <tr>
                <td>Billede: </td>
                <td>
                    <asp:Literal ID="litImage" runat="server" /></td>
                <td>
                    <asp:FileUpload ID="fuImage" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnRet" runat="server" Text="Ret" OnClick="btnRet_Click" /></td>
                <td><asp:Button ID="btnSlet" runat="server" Text="Slet" OnClick="btnSlet_Click" /></td>
            </tr>
        </table>

    </asp:panel>
</asp:Content>

