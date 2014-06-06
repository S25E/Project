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
        <div class="col-md-4">
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
        <div class="col-md-4">
            <asp:RegularExpressionValidator ID="RegExp1" runat="server"
                ErrorMessage="Naam moet tussen de 2 en 50 tekens zijn (geen cijfers of speciale tekens)"
                ControlToValidate="TbNaam"
                Display="Dynamic"
                ForeColor="Red"
                ValidationGroup="validation2"
                ValidationExpression="^[a-zA-Z ]{2,50}$" />
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
        <div class="col-md-4">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Telefoonnummer" class="form-control" ID="TbTelefoonnummer" runat="server" />
            &nbsp;
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                  ControlToValidate="TbTelefoonnummer"
                  Display="Dynamic"
                  ErrorMessage="Vul het veld in."
                  ForeColor="Red"
                  ValidationGroup="validation1"
                  runat="server">
              </asp:RequiredFieldValidator>
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
        <div class="col-md-4">
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
        <div class="col-md-4">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                runat="server" ControlToValidate="TbPostcode"
                ErrorMessage="Vul een geldige postcode in zonder spatie."
                ForeColor="Red"
                ValidationGroup="validation2"
                Display="Dynamic"
                ValidationExpression="^[0-9]{4}[a-zA-Z]{2}$">
            </asp:RegularExpressionValidator>
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
        <div class="col-md-4">
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
        <div class="col-md-4">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                runat="server" ControlToValidate="TbWoonplaats"
                ErrorMessage="Vul alleen letters in."
                ForeColor="Red"
                ValidationGroup="validation2"
                Display="Dynamic"
                ValidationExpression="^[a-zA-Z '-]*$">
            </asp:RegularExpressionValidator>
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
        <div class="col-md-4">
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
        <div class="col-md-4">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                runat="server" ControlToValidate="TbStraat"
                ErrorMessage="Vul een geldig Adres in (alleen letters en cijfers)."
                ForeColor="Red"
                ValidationGroup="validation2"
                Display="Dynamic"
                ValidationExpression="^([a-zA-z]+) [0-9]{1,3}$">
            </asp:RegularExpressionValidator>
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
        <div class="col-md-4">
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
        <div class="col-md-4">
            <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator"
                runat="server"
                ControlToValidate="TbEmail"
                ErrorMessage="Vul een geldig emailadres in."
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="validation2"
                ValidationExpression="^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$">
            </asp:RegularExpressionValidator>
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
        <div class="col-md-4">
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
        <div class="col-md-4">
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
        <div class="col-md-4">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                runat="server"
                ControlToValidate="TbSofinummer"
                ErrorMessage="Voer Uw 9-cijferige sofinummer in."
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="validation2"
                ValidationExpression="^\d{9}$">
            </asp:RegularExpressionValidator>
            
        </div>
    </div>
    <%--Einde 8e row--%>
    <br />

    <div class="row class1">
        <div class="col-md-3">
            <asp:LinkButton runat="server" Style="font-size: 22px; margin-left: 325px;" CssClass="glyphicon glyphicon-arrow-right btn btn-large btn-primary" OnClick="ButtonNext_Click" />
        </div>
    </div>
</asp:Content>
