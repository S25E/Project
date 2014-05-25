<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Toelating.aspx.cs" Inherits="SME.Toelating" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Toelating</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="starter-template">
        <h1>Welkom op SME</h1>
        <div class="form-group">
            <asp:Label style=" text-align:center;" runat="server" class="alert-info" ID="InfoLabel" ForeColor="Red" BackColor="White"/>
              <asp:TextBox style="text-align:center; width: 200px; margin-left:auto; margin-right:auto;" placeholder="RFID-Code" class="form-control" id="RFIDCheck" runat="server"/>
                <br />  
                <asp:Button ID="ButtonCheck" runat="server" Text="Check" class="btn btn-success" OnClick="ButtonCheck_Click"/>
        </div>
      </div>
</asp:Content>