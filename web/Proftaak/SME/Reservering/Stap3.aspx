<%@ Page Title="" Language="C#" MasterPageFile="~/Reservering/Reservering.master" AutoEventWireup="true" CodeBehind="Stap3.aspx.cs" Inherits="SME.Stap3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3>3. Selecteer kampeerplaats.</h3>
    <div class="row class1">
        <div class="col-xs-6">
            <img src="../img/plattegrond camping zonder nummers.png" />
        </div>
        <div class="col-xs-6" style="padding-left:50px; margin-bottom:10px">
            <asp:DropDownList runat="server" ID="dropdown" OnTextChanged="LaadOpmerking" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="col-xs-6" style="padding-left:50px; margin-bottom:10px">
            <asp:TextBox runat="server" ID="TbOpmerking"></asp:TextBox>
            <asp:LinkButton runat="server" ID="ButtonSelecteer" OnClick="ButtonSelecteer_Click" CssClass="btn btn-primary glyphicon glyphicon-plus"></asp:LinkButton>
        </div>
        <div class="col-xs-3" style="margin-left:35px;">
            <ul class="list-group">
                <asp:Repeater runat="server" ID="repeaterPlaatsen">
                    <ItemTemplate>
                        <li class="list-group-item">Kampeerplaats nummer: <%#Container.DataItem%></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <br />
    <asp:LinkButton runat="server" OnClick="ButtonNext_Click" CssClass="btn btn-primary glyphicon glyphicon-arrow-right" ></asp:LinkButton>
</asp:Content>
