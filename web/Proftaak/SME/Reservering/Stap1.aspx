<%@ Page Title="" Language="C#" MasterPageFile="~/Reservering/Reservering.master" AutoEventWireup="true" CodeBehind="Stap1.aspx.cs" Inherits="SME.Stap1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3>1. Voeg de Hoofdboeker toe.</h3>
    <br />

    <%--Begin 1e row--%>
    <div class="row class1">
        <div class="col-md-2" style="height: 34px;">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelNaam">Naam:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Naam" class="form-control" ID="TbNaam" runat="server" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                ControlToValidate="TbNaam"
                Display="Dynamic"
                ErrorMessage="Vul het veld in."
                ForeColor="Red"
                ValidationGroup="validation1"
                runat="server" />
        </div>
    </div>
    <%--Einde 1e row--%>
    <br />

    <%--Begin 2e row--%>
    <div class="row class1">
        <div class="col-md-2">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelTelefoonnummer">Telefoonnummer:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Telefoonnummer" class="form-control" ID="TbTelefoonnummer" runat="server" />
            &nbsp;
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                  ControlToValidate="TbTelefoonnummer"
                  Display="Dynamic"
                  ErrorMessage="Vul het veld in."
                  ForeColor="Red"
                  ValidationGroup="validation1"
                  runat="server" />
        </div>
    </div>
    <%--Einde 2e row--%>
    <br />

    <%--Begin 3e row--%>
    <div class="row class1">
        <div class="col-md-2">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelPostcode">Postcode:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Postcode" class="form-control" ID="TbPostcode" runat="server" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                ControlToValidate="TbPostcode"
                Display="Dynamic"
                ErrorMessage="Vul het veld in."
                ForeColor="Red"
                ValidationGroup="validation1"
                runat="server" />
        </div>
    </div>
    <%--Einde 3e row--%>
    <br />

    <%--Begin 4e row--%>
    <div class="row class1">
        <div class="col-md-2">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelWoonplaats">Woonplaats:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Woonplaats" class="form-control" ID="TbWoonplaats" runat="server" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                ControlToValidate="TbWoonplaats"
                Display="Dynamic"
                ErrorMessage="Vul het veld in."
                ForeColor="Red"
                ValidationGroup="validation1"
                runat="server" />
        </div>
    </div>
    <%--Einde 4e row--%>
    <br />

    <%--Begin 5e row--%>
    <div class="row class1">
        <div class="col-md-2">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelStraat">Straat:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Straat" class="form-control" ID="TbStraat" runat="server" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                ControlToValidate="TbStraat"
                Display="Dynamic"
                ErrorMessage="Vul het veld in."
                ForeColor="Red"
                ValidationGroup="validation1"
                runat="server" />
        </div>
    </div>
    <%--Einde 5e row--%>
    <br />

    <%--Begin 6e row--%>
    <div class="row class1">
        <div class="col-md-2">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelEmail">Emailadres:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Emailadres" class="form-control" ID="TbEmail" runat="server" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                ControlToValidate="TbEmail"
                Display="Dynamic"
                ErrorMessage="Vul het veld in."
                ForeColor="Red"
                ValidationGroup="validation1"
                runat="server" />
        </div>
    </div>
    <%--Einde 6e row--%>
    <br />

    <%--Begin 7e row--%>
    <div class="row class1">
        <div class="col-md-2">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelRekeningnummer">Rekeningnummer:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Rekeningnummer" class="form-control" ID="TbRekeningnummer" runat="server" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                ControlToValidate="TbRekeningnummer"
                Display="Dynamic"
                ErrorMessage="Vul het veld in."
                ForeColor="Red"
                ValidationGroup="validation1"
                runat="server" />
        </div>
    </div>
    <%--Einde 7e row--%>
    <br />

    <%--Begin 8e row--%>
    <div class="row class1">
        <div class="col-md-2">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelSofinummer">Sofinummer:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Sofinummer" class="form-control" ID="TbSofinummer" runat="server" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                ControlToValidate="TbSofinummer"
                Display="Dynamic"
                ErrorMessage="Vul het veld in."
                ForeColor="Red"
                ValidationGroup="validation1"
                runat="server" />
        </div>
    </div>
    <%--Einde 8e row--%>
    <br />

    <div class="row class1">
        <div class="col-md-3">
            <asp:LinkButton runat="server" Style="font-size: 22px;" CssClass="glyphicon glyphicon-arrow-left btn btn-large btn-primary" OnClick="ButtonBack_Click" />
        </div>

        <div class="col-md-3">
            <asp:LinkButton runat="server" Style="font-size: 22px; margin-left: 60px;" CssClass="glyphicon glyphicon-arrow-right btn btn-large btn-primary" OnClick="ButtonNext_Click" />
        </div>
    </div>
</asp:Content>
