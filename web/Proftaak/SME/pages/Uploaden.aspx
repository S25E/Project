<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Uploaden.aspx.cs" Inherits="SME.pages.Uploaden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="row">
            <asp:Label runat="server">Locatie: </asp:Label><asp:FileUpload ID="Bladeren" CssClass="btn btn-sm" runat="server" />
        </div>
        <div class="row">
            <asp:Label runat="server">Categorie: </asp:Label><asp:DropDownList ID="Categorie" CssClass="dropdown" runat="server"/>
        </div>
        <div class="row">
            <asp:Label runat="server">Naam: </asp:Label><asp:TextBox ID="Naam" runat="server" />
        </div>
        <div class="row">
            <asp:Label runat="server">Beschrijving: </asp:Label><asp:TextBox ID="Beschrijving" Height="200px" runat="server" />
        </div>
        <div class="row">
            <asp:LinkButton runat="server" ID="UploadButton" Text="UploadenKnop" OnClick="Uploaden_Click" />
        </div>
    </div>
</asp:Content>
