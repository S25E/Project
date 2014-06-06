<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="AddMap.aspx.cs" Inherits="SME.pages.AddMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="form-group row">
            <label class="col-sm-2 control-label">
                <asp:Label runat="server" ID="Label1">Parentmap:</asp:Label></label>
            <div class="col-sm-5">
                <asp:DropDownList ID="Mappicker" CssClass="dropdown form-control" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Categorie" Text="Categorie is verplicht!" runat="Server" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-2 control-label">
                <asp:Label runat="server" ID="Naam">Naam:</asp:Label></label>
            <div class="col-sm-5">
                <asp:TextBox CssClass="form-control" ID="BestandNaam" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorBestandNaam" ControlToValidate="BestandNaam" Text="Naam is verplicht!" runat="Server" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5 col-xs-offset-2">
                <asp:Button Text="Maak Map" runat="server" ID="K" OnClick="K_Click" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</asp:Content>
