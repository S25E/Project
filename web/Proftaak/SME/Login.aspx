<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SME.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inloggen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div style="background-color: rgba(255, 255, 255, 0.8); border-radius: 25px; margin-top: 40px; padding: 30px 0" class="col-lg-4 col-lg-offset-4">
            <asp:Panel CssClass="alert alert-danger" style="margin: 0 10px 20px 10px" Visible="false" ID="Error" runat="server">Het is niet gelukt om in te loggen. Controleer de gebruikersnaam/wachtwoord!</asp:Panel>
            <div class="form-group">
                <label class="col-sm-5 control-label">
                    <asp:Label runat="server" ID="LabelGebruikersnaam">Gebruikersnaam:</asp:Label></label>
                <div class="col-sm-7">
                    <asp:TextBox CssClass="form-control" ID="TextBoxGebruikersnaam" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGebruikersnaam" ControlToValidate="TextBoxGebruikersnaam" Text="Gebruikersnaam is verplicht!" runat="Server" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-5 control-label">
                    <asp:Label runat="server" ID="LabelWachtwoord">Wachtwoord:</asp:Label></label>
                <div class="col-sm-7">
                    <asp:TextBox CssClass="form-control" TextMode="Password" ID="TextBoxWachtwoord" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorWahhtwoord" ControlToValidate="TextBoxWachtwoord" Text="Wachtwoord is verplicht!" runat="Server" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-5 col-sm-4">
                    <asp:Button ID="Inloggen" runat="server" OnClick="Inloggen_Click" Text="Inloggen!" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
