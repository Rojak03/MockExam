<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="RedSletNyhed.aspx.cs" Inherits="Admin_RedSletNyhed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    panel to show every nyhed with link to edit or delete nyhed

    <asp:Panel ID="pnlAllNyheder" runat="server" Visible="true">
        <h2>Nyhederen</h2>
        <br />
        <asp:Literal ID="litAlleNyheder" runat="server" />
    </asp:Panel>

    <asp:Panel ID="pnlRetNyheder" runat="server" Visible="false">
        <asp:TextBox ID="txtID" runat="server" Visible="false" />
        <table>
            <tr>
                <td>Nyhed Title:</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" /></td>
            </tr>
            <tr>
                <td>Nyhed:</td>
                <td>
                    <asp:TextBox ID="txtNyhed" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRet" runat="server" OnClick="btnRet_Click" Text="Ret" /></td>
                <td>
                    <asp:Button ID="btnSlet" runat="server" OnClick="btnSlet_Click" Text="Slet" /></td>
            </tr>
        </table>


    </asp:Panel>
    <%--panel that shows the editable parts of the nyhed selected--%>
</asp:Content>

