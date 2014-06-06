<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="MateriaalToevoegen.aspx.cs" Inherits="SME.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" style="width=50%;">


        <div style="width: 50%;" class="form-horizontal">
            <h1>Voeg hier uw materiaal toe</h1>

                        <%--Begin 5e row--%>
            <div class="row class1">
                <div class="col-md-2">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="Label4">Barcode:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Barcode" class="form-control" ID="tbBarcode" runat="server" />
                </div>
            </div>
            <%--Einde 5e row--%>
            <br />

            <%--Begin 1e row--%>
            <div class="row class1">
                <div class="col-md-2" style="height: 34px; top: 0px; left: 0px;">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="LabelNaam">Naam:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Naam" class="form-control" ID="TbNaam" runat="server" />
                </div>
            </div>
            <%--Einde 1e row--%>
            <br />

            <%--Begin 2e row--%>
            <div class="row class1">
                <div class="col-md-2">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="LabelTelefoonnummer">Aantal:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Aantal" class="form-control" ID="tbAantal" runat="server" />
                </div>
            </div>
            <%--Einde 2e row--%>
            <br />

            <%--Begin 3e row--%>
            <div class="row class1">
                <div class="col-md-2">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="Label1">Verhuurprijs:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Verhuurprijs" class="form-control" ID="tbVerhuurprijs" runat="server" />
                </div>
            </div>
            <%--Einde 3e row--%>
            <br />
            <%--Begin 4e row--%>
            <div class="row class1">
                <div class="col-md-2">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="Label2">Omschrijving:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Omschrijving" class="form-control" ID="tbOmschrijving" runat="server" />
                </div>
            </div>
            <%--Einde 4e row--%>
            <br />
            <%--Begin 5e row--%>
            <div class="row class1">
                <div class="col-md-2">
                    <div class="control-group row-fluid form-inline">
                        <asp:Label runat="server" ID="Label3">Categorie:</asp:Label>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Categorie" class="form-control" ID="tbCategorie" runat="server" />
                </div>
            </div>
            <%--Einde 5e row--%>
            <br />


            <%--Begin 6e row--%>

            <asp:Button ID="Bevestigknop" runat="server" Text="Bevestig" Width="86px" CssClass="btn btn-primary" PostBackUrl="~/admin/Uitleen.aspx" OnClick="Bevestigknop_Click"  />


        </div>
</asp:Content>
