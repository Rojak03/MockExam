<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MinSide.aspx.cs" Inherits="MinSide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:literal ID="litOplysing" runat="server" />
    
     <asp:Panel ID="pnlOplysing" runat="server" >
    <h1>Mine fremtidige aktiviteter</h1>    
        
    </asp:Panel>
    <asp:Panel ID="pnlDog" runat="server" >
        <h1>Mine Hunde</h1>
        <asp:Literal ID="litDogs" runat="server" />
    </asp:Panel>
</asp:Content>

