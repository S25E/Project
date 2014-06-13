<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Filesharing.aspx.cs" Inherits="SME.pages.Filesharing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Filesharing</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    function PostToNewWindow() {
        originalTarget = document.forms[0].target;
        document.forms[0].target = '_blank';
        window.setTimeout("document.forms[0].target=originalTarget;", 300);
        return true;
    }
</script>
    <div class="row">
        <div class="col-xs-8 col-xs-offset-2">
            <div id="content">
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Panel ID="PanelZoeken" CssClass="form-group row" runat="server">
                            <label class="col-sm-4 control-label">
                                <asp:Label runat="server" ID="Label3">Zoek:</asp:Label>
                            </label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <asp:TextBox ID="Zoekterm" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button Text="Zoek!" runat="server" ID="ZoekKnop" OnClick="ZoekKnop_Click" CssClass="btn btn-success" />
                                    </span>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PanelMap" CssClass="form-group row" runat="server">
                            <label class="col-sm-4 control-label">
                                <asp:Label runat="server" ID="LabelMap">Selecteer map:</asp:Label>
                            </label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <asp:DropDownList ID="Categorie" runat="server" CssClass="form-control" OnSelectedIndexChanged="Categorie_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:Button Text="+" runat="server" ID="KnopNieuweMap" OnClick="KnopNieuweMap_Click" CssClass="btn btn-primary" />
                                    </span>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PanelBestand" CssClass="form-group row" runat="server">
                            <label class="col-sm-4 control-label">
                                <asp:Label runat="server" ID="LabelBestand">Selecteer Bestand:</asp:Label>
                            </label>
                            <div class="col-sm-8">
                                <div class="input-group">
                                    <asp:DropDownList ID="Bestanden" runat="server" CssClass="form-control" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="Bestanden_SelectedIndexChanged"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:Button Text="+" runat="server" ID="KnopNieuwBestand" OnClick="KnopNieuwBestand_Click" CssClass="btn btn-primary" />
                                    </span>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="PanelInfo" runat="server" Visible="false">
                            <h2 runat="server" id="Bestandnaam"></h2>
                            <asp:LinkButton ID="VerwijderKnop" OnClick="VerwijderKnop_Click" runat="server">Verwijder dit bestand<br /></asp:LinkButton>
                            <b>Bestandsnaam:</b> <asp:Label ID="Naam" runat="server" Text="Label"></asp:Label><br />
                            <b>Beschrijving:</b> <asp:Label ID="Beschrijving" runat="server" Text="Label"></asp:Label><br />
                            <b>Grootte:</b> <asp:Label ID="Grootte" runat="server" Text="Label"></asp:Label><br />
                            <b>Geupload op:</b> <asp:Label ID="Datum" runat="server" Text="Label"></asp:Label><br />
                            <b>Geupload door:</b> <asp:Label ID="Uploader" runat="server" Text="Label"></asp:Label><br />
                            <b>Aantal downloads:</b> <asp:Label ID="Downloads" runat="server" Text="Label"></asp:Label><br />
                            <br />
                            <asp:LinkButton ID="DownloadKnop" OnClick="DownloadKnop_Click" runat="server" OnClientClick="return PostToNewWindow();"  >Klik hier om het bestand te downloaden!</asp:LinkButton><br />
                            <br />
                            <asp:Button ID="Like" runat="server" Text="+1" CssClass="btn btn-lg btn-success" OnClick="Like_Click" /> &nbsp;&nbsp;&nbsp; <span class="badge"><asp:Label ID="Score" runat="server" Text="Label" Font-Size="Large"></asp:Label></span> &nbsp;&nbsp;&nbsp; <asp:Button ID="Dislike" runat="server" Text="-1" CssClass="btn btn-lg btn-danger" OnClick="Dislike_Click" /> &nbsp;&nbsp;&nbsp; <asp:Button ID="Report" runat="server" Text="Report" CssClass="btn btn-lg btn-primary" OnClick="Report_Click" /><br />
                            <br />
                            <asp:ListView ID="Reacties" runat="server">
                                <ItemTemplate>
                                    <div class="panel panel-default">
                                      <div class="panel-heading"><b><%#Eval("Persoon.Naam").ToString() %></b> - <%#Eval("Datum").ToString() %></div>
                                      <div class="panel-body">
                                            <%#Eval("Opmerking").ToString() %>
                                      </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                            <h3>Reactie plaatsen</h3>
                            <asp:TextBox ID="Reactie" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:Button Text="Plaats reactie!" runat="server" ID="PlaatsReactie" OnClick="PlaatsReactie_Click" CssClass="btn btn-success btn-block" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
