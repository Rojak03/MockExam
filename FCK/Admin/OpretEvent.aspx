<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OpretEvent.aspx.cs" Inherits="Admin_OpretEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Opret Aktivitet</h1>
    <h2>Her kan du oprette en aktivitet</h2>
    <table>
        <tr>
            <td>Beskrivelse:</td>
            <td>
                <asp:TextBox ID="txtBeskrivelse" runat="server" /></td>
        </tr>
        <tr>
            <td>Rules:</td>
            <td>
                <asp:TextBox ID="txtRules" runat="server" /></td>
        </tr>
        <tr>
            <td>Sted:</td>
            <td>
                <asp:TextBox ID="txtSted" runat="server" /></td>
        </tr>
        <%-- <tr>
            <td>Postnr:</td>
            <td>
                <asp:TextBox ID="txtPost" runat="server" /></td>
        </tr>--%>
        <tr>
            <td>Dato:</td>
            <td>
                <asp:TextBox ID="txtDato" runat="server" /></td>
        </tr>
        <tr>
            <td>Forudsættinger:</td>
            <td>
                <asp:TextBox ID="txtForud" runat="server" /></td>
        </tr>
        <tr>
            <td>Billede:</td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" /></td>
        </tr>
        <tr>
            <td>Type: </td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server" /></td>
            <td>Kategori: </td>
            <td>
                <asp:DropDownList ID="ddlKategori" runat="server" /></td>
        </tr>
        <tr>
            <td>Ansvarligt: </td>
            <td>
                <asp:DropDownList ID="ddlPersons" runat="server" /></td>
            <td>Role: </td>
            <td>
                <asp:DropDownList ID="ddlRoles" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Opret" /></td>
        </tr>
    </table>
</asp:Content>

