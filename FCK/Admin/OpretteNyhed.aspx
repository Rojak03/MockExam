<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OpretteNyhed.aspx.cs" Inherits="Admin_OpretteNyhed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Opret nyhed</h1>
    <h2>Her kan du oprette nyheder til siden.</h2>
    <table>
        <tr>
            <td>Title:</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" /></td>
        </tr>
        <tr>
            <td>Nyhed:</td>
            <td>
                <asp:TextBox ID="txtNyhed" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Opret" /></td>
        </tr>
    </table>
</asp:Content>

