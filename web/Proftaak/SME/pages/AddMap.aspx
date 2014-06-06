<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="AddMap.aspx.cs" Inherits="SME.pages.AddMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal-content">
        <div class="row">
            <div class="row">
                Selecteer een parent map:
                <br />
                <br />
                <asp:DropDownList runat="server" ID="Mappicker" CssClass="dropdown" AutoPostBack="false">
                </asp:DropDownList>
            </div>
            <div class="col-xs-6">
                Geef een naam:
            <br />
                <br />
                <asp:TextBox runat="server" ID="Naam" PlaceHolder="Mapnaam" />
            </div>
            <div class="row">
                Geef een naam:
            <br />
                <br />
                <asp:LinkButton runat="server" ID="K" Text="Maak Map" OnClick="K_Click" />
            </div>
        </div>
    </div>
</asp:Content>
