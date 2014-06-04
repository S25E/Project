<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Toelating.aspx.cs" Inherits="SME.Toelating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Toelating</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.8); border-radius: 25px; overflow: visible; margin-top: 17.5%;" class="col-lg-4 col-lg-offset-4">
        <div class="starter-template">
            <h1>Welkom op SME</h1>
            <div class="form-group">
                <asp:Label Style="text-align: center;" runat="server" class="alert-info" ID="InfoLabel" ForeColor="Red" BackColor="Transparent" />
                <asp:TextBox Style="text-align: center; width: 250px; margin-left: auto; margin-right: auto;" placeholder="RFID-Code" class="form-control" ID="RFIDCheck" onFocus="this.select()" runat="server" />
                <br />
                <asp:Button ID="ButtonCheck" runat="server" Text="Check" class="btn btn-success" OnClick="ButtonCheck_Click" />
            </div>
        </div>
    </div>
    <div class="right" style="position: fixed; left: 90%; top: 5%; width: 10%;">
        <asp:ListView runat="server" ID="AanwezigenList" class="list-group">
            <ItemTemplate>
                <asp:Label class="list-group-item dropdown" runat="server">
                    <a data-toggle="dropdown" class="dropdown-toggle" href="#"><%#Eval("RFID") %> <b class="caret"></b></a>
                    <div style="padding: 10px 15px 15px 15px" class="navbar-right dropdown-menu dropdown-yellow dropdown-caret">
                        <asp:Label runat="server" > <%#Persoonstring(Eval("RFID").ToString()) %> </asp:Label>
                        
                        <button type="button" class="btn btn-success" style="width: 100%">Ok</button>
                    </div>
                </asp:Label>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
