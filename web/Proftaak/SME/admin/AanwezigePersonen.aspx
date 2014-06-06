<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="AanwezigePersonen.aspx.cs" Inherits="SME.admin.AanwezigePersonen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" style="overflow-y: auto;">
        <script type="text/javascript">window.print();</script>
        <center><asp:GridView Id="PersonenView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="RFID" HeaderText="RFID" ItemStyle-Width="100px"/>
            <asp:BoundField DataField="TYPE" HeaderText="Type" ItemStyle-Width="150px"/>
            <asp:BoundField DataField="AANWEZIG" HeaderText="Aanwezig" ItemStyle-Width="70px"/>
            <asp:BoundField DataField="NAAM" HeaderText="Naam" ItemStyle-Width="150px"/>
        </Columns>
    </asp:GridView>
        </center>
    </div>
</asp:Content>
