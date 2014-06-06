<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Filesharing.aspx.cs" Inherits="SME.pages.Filesharing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Filesharing</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-8 col-xs-offset-2">
            <div id="content">
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Panel ID="PanelMap" CssClass="form-group row" runat="server">
                            <label class="col-sm-4 control-label">
                                <asp:Label runat="server" ID="Label1">Selecteer map:</asp:Label>
                            </label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="Categorie" runat="server" CssClass="form-control" OnSelectedIndexChanged="Categorie_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PanelBestand" CssClass="form-group row" runat="server">
                            <label class="col-sm-4 control-label">
                                <asp:Label runat="server" ID="Label2">Selecteer Bestand:</asp:Label>
                            </label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="Bestanden" runat="server" CssClass="form-control" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="Bestanden_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PanelInfo" runat="server" Visible="false">
                            <h2 runat="server" id="Bestandnaam"></h2>
                            <b>Bestandsnaam:</b> <asp:Label ID="Naam" runat="server" Text="Label"></asp:Label><br />
                            <b>Beschrijving:</b> <asp:Label ID="Beschrijving" runat="server" Text="Label"></asp:Label><br />
                            <b>Grootte:</b> <asp:Label ID="Grootte" runat="server" Text="Label"></asp:Label><br />
                            <b>Geupload op:</b> <asp:Label ID="Datum" runat="server" Text="Label"></asp:Label><br />
                            <b>Geupload door:</b> <asp:Label ID="Uploader" runat="server" Text="Label"></asp:Label><br />
                            <br />
                            <asp:LinkButton ID="DownloadKnop" OnClick="DownloadKnop_Click" runat="server">Klik hier om het bestand te downloaden!</asp:LinkButton><br />
                            <br />
                            <asp:Button ID="Like" runat="server" Text="+1" CssClass="btn btn-lg btn-success" OnClick="Like_Click" /> &nbsp;&nbsp;&nbsp; <span class="badge"><asp:Label ID="Score" runat="server" Text="Label" Font-Size="Large"></asp:Label></span> &nbsp;&nbsp;&nbsp; <asp:Button ID="Dislike" runat="server" Text="-1" CssClass="btn btn-lg btn-danger" OnClick="Dislike_Click" /> &nbsp;&nbsp;&nbsp; <asp:Button ID="Report" runat="server" Text="Report" CssClass="btn btn-lg btn-primary" OnClick="Report_Click" />
                            
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
