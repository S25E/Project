<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Toelating.aspx.cs" Inherits="SME.Toelating" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Toelating</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.8); border-radius:25px; overflow:visible; margin-top:17.5%;" class="col-lg-4 col-lg-offset-4">
		<div class="starter-template">
			<h1>Welkom op SME</h1>
			<div class="form-group">
				<asp:Label style=" text-align:center;" runat="server" class="alert-info" ID="InfoLabel" ForeColor="Red" BackColor="Transparent"/>
				<asp:TextBox style="text-align:center; width: 200px; margin-left:auto; margin-right:auto;" placeholder="RFID-Code" class="form-control" id="RFIDCheck" onFocus="this.select()" runat="server"/>
                <br />  
                <asp:Button ID="ButtonCheck" runat="server" Text="Check" class="btn btn-success" OnClick="ButtonCheck_Click"/>
			</div>
		</div>
	</div>
</asp:Content>