<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Uitleen.aspx.cs" Inherits="SME.Uitleen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uitleen</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="position: fixed; left: 50%; top: 21%; width: 50%;">

        <h1>Lever hier uw artikelen in</h1>

        <br />
        <br />
        <div class="row class1">
            <div class="col-md-2" style="height: 34px; top: 0px; left: 0px;">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="Label1">Aantal:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Aantal" class="form-control" ID="AantalInleverBox" runat="server" />
            </div>
        </div>
        <%--Einde 1e row--%>
        <br />

        <%--Begin 2e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="Label2">Reservering nummer:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" AutoPostBack="true" placeholder="Reservering Nummer" class="form-control" ID="ReserveringNRinleverBox" runat="server" OnTextChanged="RFIDinleverBox_TextChanged" />
            </div>
        </div>
        <%--Einde 2e row--%>
        <br />

        <%--Begin 3e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <asp:ListBox Width="340px" Height="160px" ID="ListBox1" runat="server"></asp:ListBox>
            </div>
        </div>
        <br />
        <asp:Button ID="btnTerugBreng" runat="server" Width="150px" CssClass="btn btn-primary" Text="Breng terug" OnClick="Button1_Click" />
        <asp:Button ID="btnOmzetten" runat="server" Width="200px" CssClass="btn btn-primary" Text="Reservering -> Uitlening" OnClick="btnOmzetten_Click" />

    </div>
    <%--Einde 3e row--%>
    <br />


    <div id="content" style="width=50%;">


        <div style="width: 50%;" class="form-horizontal">
            <h1>Leen hier uw artiekelen</h1>

            <asp:DropDownList ID="CategorieList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="80px" DataTextField="Categorie" CssClass="dropdown">
            </asp:DropDownList>
            <asp:DropDownList ID="ArtiekelList" runat="server" Width="180px" Style="margin-left: 25px;">
            </asp:DropDownList>
            <br />
            <br />

            <%--Begin 1e row--%>
            <div class="row class1">
                <div class="col-md-2" style="height: 34px; top: 0px; left: 0px;">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="LabelNaam">Aantal:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Aantal" class="form-control" ID="TbAantal" runat="server" />
                </div>
            </div>
            <%--Einde 1e row--%>
            <br />

            <%--Begin 2e row--%>
            <div class="row class1">
                <div class="col-md-2">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="LabelTelefoonnummer">RFID:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="RFID" class="form-control" ID="TbRFID" runat="server" />
                </div>
            </div>
            <%--Einde 2e row--%>
            <br />

            <%--Begin 3e row--%>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />



            <asp:Button ID="Bevestigknop" runat="server" Text="Bevestig" OnClick="Bevestigknop_Click" Width="86px" CssClass="btn btn-primary" />
            <asp:Button ID="MateriaalToevoegen" runat="server" Text="Materiaal Toevoegen"  Width="160px" CssClass="btn btn-primary" PostBackUrl="~/admin/MateriaalToevoegen.aspx" />


        </div>
    </div>
</asp:Content>

