<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
        <table>
            <tr>
                <td>Brugernavn: </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

