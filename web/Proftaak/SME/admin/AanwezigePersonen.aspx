<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="AanwezigePersonen.aspx.cs" Inherits="SME.admin.AanwezigePersonen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="scrollbar-3dlight-color:aqua; overflow-y:auto;">
    <asp:GridView Id="PersonenView" runat="server">
        <Columns>
            <asp:BoundField DataField="RFID" HeaderText="RFID"/>
            <asp:BoundField DataField="TYPE" HeaderText="Type"/>
            <asp:BoundField DataField="AANWEZIG" HeaderText="Aanwezig"/>
            <asp:BoundField DataField="NAAM" HeaderText="Naam"/>
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
