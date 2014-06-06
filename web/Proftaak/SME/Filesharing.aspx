<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Filesharing.aspx.cs" Inherits="SME.pages.Filesharing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Filesharing</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="row">
            <div class="col-xs-6">
                <asp:DropDownList ID="Categorie" runat="server" CssClass="form-control" OnSelectedIndexChanged="Categorie_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:DropDownList ID="Bestanden" runat="server" CssClass="form-control" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="Bestanden_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-xs-6">
                Rechts
            </div>
        </div>
    </div>
</asp:Content>
