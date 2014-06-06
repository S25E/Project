<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Uploaden.aspx.cs" Inherits="SME.pages.Uploaden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="form-group row">
            <label class="col-sm-2 control-label">
                <asp:Label runat="server" ID="LabelFileUpload">Locatie:</asp:Label></label>
            <div class="col-sm-4">
                <asp:FileUpload ID="FileUpload" CssClass="btn btn-sm" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFileUpload" ControlToValidate="FileUpload" Text="Bestand uploaden is verplicht!" runat="Server" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-2 control-label">
                <asp:Label runat="server" ID="Label1">Categorie:</asp:Label></label>
            <div class="col-sm-5">
                <asp:DropDownList ID="Categorie" CssClass="dropdown form-control" runat="server"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Categorie" Text="Categorie is verplicht!" runat="Server" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-2 control-label">
                <asp:Label runat="server" ID="LabelBestandNaam">Naam:</asp:Label></label>
            <div class="col-sm-5">
                <asp:TextBox CssClass="form-control" ID="BestandNaam" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorBestandNaam" ControlToValidate="BestandNaam" Text="Naam is verplicht!" runat="Server" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-2 control-label">
                <asp:Label runat="server" ID="Label2">Beschrijving:</asp:Label></label>
            <div class="col-sm-5">
                <asp:TextBox ID="Beschrijving" Height="200px" runat="server" CssClass="form-control" TextMode="MultiLine"  />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Beschrijving" Text="Beschrijving is verplicht!" runat="Server" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5 col-xs-offset-2">
                <asp:Button Text="Uploaden!" runat="server" ID="UploadKnop" OnClick="UploadKnop_Click" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</asp:Content>
