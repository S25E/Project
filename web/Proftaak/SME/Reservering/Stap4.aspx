<%@ Page Title="" Language="C#" MasterPageFile="~/Reservering/Reservering.master" AutoEventWireup="true" CodeBehind="Stap4.aspx.cs" Inherits="SME.Stap4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3>4. Voeg meterialen toe.</h3>
    <br />
    <div class="row">
        <div class="col-xs-6">
            Selecteer een Categorie:
            <br />
            <br />
            <asp:DropDownList runat="server" ID="DropdownCategorieen" OnTextChanged="LaadMaterialen" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="col-xs-6">
            Selecteer een Product:
            <br />
            <br />
            <asp:ListBox runat="server" style="width:400px;" ID="ListBoxMaterialen" AutoPostBack="true" OnSelectedIndexChanged="SelecteerMateriaal"></asp:ListBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-6">
            Geselecteerde producten:
            <br />
            <br />
            <asp:ListBox runat="server" style="width:400px;" ID="ListboxGeselecteerd" AutoPostBack="true"></asp:ListBox>
        </div>
    </div>
    <asp:LinkButton runat="server"  CssClass="btn btn-primary glyphicon glyphicon-ok" OnClick="Volgende_Click"></asp:LinkButton>
</asp:Content>
