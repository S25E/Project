<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reservering.aspx.cs" Inherits="SME.Reservering1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reservering</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <h1>Maak hier uw reservering</h1>
        <br />
        <div class="control-group row-fluid form-inline">
            Naam:  <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Naam" class="form-control" id="TbNaam" runat="server"/>
         </div>
        <br />
        <div class="control-group row-fluid form-inline">
            Adres:  <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Adres" class="form-control" id="TbAdres" runat="server"/>
         </div>
    </div>
</asp:Content>
