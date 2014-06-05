<%@ Page Title="" Language="C#" MasterPageFile="~/Reservering/Reservering.master" AutoEventWireup="true" CodeBehind="Stap5.aspx.cs" Inherits="SME.Stap5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3>5. Bevestigen</h3>
    <div class="row">
        <div class="col-xs-6">
            <asp:Label runat="server">Hoofdboeker</asp:Label>
            <br />
            <asp:Label runat="server">Naam: </asp:Label>
            <asp:Label runat="server" ID="LabelNaam"></asp:Label>
            <br />
            <asp:Label runat="server">Telefoonnummer: </asp:Label>
            <asp:Label runat="server" ID="LabelTelefoonnummer"></asp:Label>
            <br />
            <asp:Label runat="server">Postcode: </asp:Label>
            <asp:Label runat="server" ID="LabelPostocde"></asp:Label>
            <br />
            <asp:Label runat="server">Woonplaats: </asp:Label>
            <asp:Label runat="server" ID="LabelWoonplaats"></asp:Label>
            <br />
            <asp:Label runat="server">Straat: </asp:Label>
            <asp:Label runat="server" ID="LabelStraat"></asp:Label>
            <br />
            <asp:Label runat="server">Emailadres: </asp:Label>
            <asp:Label runat="server" ID="LabelEmailadres"></asp:Label>
            <br />
            <asp:Label runat="server">Rekeningnummer: </asp:Label>
            <asp:Label runat="server" ID="LabelRekeningnummer"></asp:Label>
            <br />
            <asp:Label runat="server">Sofinummer: </asp:Label>
            <asp:Label runat="server" ID="LabelSofinummer"></asp:Label>
            <br />
        </div>
        <div class="col-xs-6">
            <asp:Label runat="server">Bijboeker(s)</asp:Label>
            <br />
            <asp:ListBox runat="server" Style="width: 400px;" ID="ListboxBijboekers"></asp:ListBox>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-xs-6">
            <asp:Label runat="server">Kampeerplaats(en)</asp:Label>
            <br />
            <asp:ListBox runat="server" Style="width: 400px;" ID="ListboxKampeerplaats"></asp:ListBox>
        </div>
        <div class="col-xs-6">
            <asp:Label runat="server">Materialen</asp:Label>
            <br />
            <asp:ListBox runat="server" Style="width: 400px;" ID="Listboxmaterialen"></asp:ListBox>
            <br />
        </div>
    </div>
    <br />
    <asp:LinkButton runat="server" CssClass="btn btn-primary glyphicon glyphicon-ok" OnClick="Bevestig_Click"></asp:LinkButton>

</asp:Content>
