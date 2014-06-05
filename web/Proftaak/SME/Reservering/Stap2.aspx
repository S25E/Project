<%@ Page Title="" Language="C#" MasterPageFile="~/Reservering/Reservering.master" AutoEventWireup="true" CodeBehind="Stap2.aspx.cs" Inherits="SME.Stap2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3>2. Voeg de bijboekers toe.</h3>

    <div class="row class1">
        <div class="col-md-2" style="height: 34px;">
            <div class="control-group row-fluid form-inline">
                <asp:Label runat="server" ID="LabelNaam">Naam:</asp:Label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:TextBox Style="text-align: left; width: 200px; margin-left: auto; margin-right: auto;" placeholder="Naam" class="form-control" ID="TbBijboekersNaam" runat="server" />
        </div>
        <div class="col-xs-5" style="margin-left: 200px;">
            <ul class="list-group">
                <asp:Repeater runat="server" ID="repeaterBijboekersNaam">
                    <ItemTemplate>
                        <li class="list-group-item"><%#Eval("Naam")%></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-3">
            <asp:LinkButton runat="server" Style="font-size: 22px;" CssClass="glyphicon glyphicon-plus btn btn-primary" OnClick="ButtonVoegToe_Click" />
        </div>
        <div class="col-md-3">
            <asp:LinkButton runat="server" Style="font-size: 22px; margin-left: 60px;" CssClass="glyphicon glyphicon-arrow-right btn btn-large btn-primary" OnClick="ButtonNext_Click" />
        </div>
    </div>
</asp:Content>
