<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%= Page.ResolveUrl("./CSS/Style.css")%>" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="omText">
        <asp:Literal ID="litOm" runat="server" />
    </div>
    <div id="kommendeAktiviteter">
        <h2>Kommende aktiviteter</h2>
        <h3>Find mere om kommendeog tidligere aktiviteter, træning og prøver fra menuen ovenfor.</h3>
        <asp:Literal ID="litAktiviteter" runat="server" />
    </div>
</asp:Content>

