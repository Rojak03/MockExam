<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BlivMedlem.aspx.cs" Inherits="BlivMedlem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 class="title">Bliv medlem</h1>
    <h4>Jeg ønsker ab blive oprettet som medlem af Fyen Cocker Klub:</h4>
    <br />
    <asp:Panel ID="pnlPersonal" runat="server">

        <h2>Personlige oplysninger</h2>

        <asp:Label ID="lblNavn" runat="server" Text="Navn: " />
        <asp:TextBox ID="txtNavn" runat="server" /><br />

        <asp:Label ID="lblEmail" runat="server" Text="Email: " />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="email" />
        <asp:Label ID="lblMobil" runat="server" Text="Mobil: " />
        <asp:TextBox ID="txtMobil" runat="server" /><br />

        <asp:Label ID="lblAdresse" runat="server" Text="Adresse: " />
        <asp:TextBox ID="txtAdresse" runat="server" />
        <asp:Label ID="lblPost" runat="server" Text="Postnr: " />
        <asp:TextBox ID="txtPost" runat="server" /><br />

        <asp:Label ID="lblPassword" runat="server" Text="Password: " />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />

    </asp:Panel>
    <asp:Panel ID="pnlDog" runat="server">

        <h2>Oplysninger om min(e) hunde</h2>

        <asp:Label ID="lblDogName" runat="server" Text="Hundens navn: " />
        <asp:TextBox ID="txtDogName" runat="server" />
        <br />
        <asp:Label ID="lblDogSex" runat="server" Text="Hundens Køn: " />
        <asp:DropDownList ID="ddlSex" runat="server" />
        <br />
        <asp:Label ID="lblDogBirth" runat="server" Text="Hundens fødselsdag: " />
        <asp:TextBox ID="txtBirthday" TextMode="Date" runat="server" />
        <br />
        <asp:CheckBox ID="chbVaccine" runat="server" Text="Hunden er vaccineret" />
    </asp:Panel>
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Tilmeld" />
</asp:Content>

