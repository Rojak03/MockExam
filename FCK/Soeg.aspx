<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Soeg.aspx.cs" Inherits="Soeg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--////// SEARCH STUFFF--%>
    <div id="searched">
        <h1>Søgeresultat:</h1>
        <asp:Literal ID="litSoegord" runat="server" />
    </div>
    <div id="results">
        <asp:Literal ID="litResultat" runat="server" />
        <asp:Literal ID="litAntal" runat="server" />
    </div>
</asp:Content>

