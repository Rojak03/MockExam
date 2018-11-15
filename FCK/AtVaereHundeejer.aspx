<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AtVaereHundeejer.aspx.cs" Inherits="AtVaereHundeejer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>At Være Hundeejer</h1>
    <br />
    <div class="infoBox">
        <asp:Literal ID="litIntro" runat="server" />
    </div>
    <div id="description">
        <p>Hunden skal være vaccineret mod hundesyge og parvovirus, hvis den skal deltage i træning, og du skal huske at have attesten med til udstillingen. Hunden skal selvfølgelig også være mentalt og fysisk sund. Hvalpe, der er under 3 måneder gamle, må ikke tages med til aktiviteter.</p>
        <br />
        <p>Hunden skal have en ansvarsforsikring.</p>
        <br />
        <p>Hundene skal føres i line og hundeejeren skal til enhver tid sikre hundens velfærd, fx fjerne hunden fra varme biler og sikre drikkevand.</p>
        <br />
        <p>Hvis en hund opfører sig aggressivt eller på anden vis er til gene, kan den bortvises præmiering kan inddrages. En hund, som 2 gange diskvalificeres på grund af temperamentet, kan fratages retten til avl og til at deltage i udstillinger, prøver, konkurrencer mv. Afstraffelse af hund medfører øjeblikkelig bortvisning og inddragelse af evt. opnået præmiering.</p>
    </div>
    <br />
    <br />
    <h1>Tidligere nyheder</h1>
    <br />
    <div class="infoBox">
        <asp:Literal ID="litTidligereNyheder" runat="server" />
    </div>
</asp:Content>

