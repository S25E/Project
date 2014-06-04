<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Uitleen.aspx.cs" Inherits="SME.Uitleen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uitleen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="content">
    <div class="form-horizontal">
        <h1>Leen hier uw artiekelen</h1>
        <asp:DropDownList ID="CategorieList" runat="server" Height="56px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="156px" DataTextField="Categorie">
        </asp:DropDownList>
        <asp:DropDownList ID="ArtiekelList" runat="server" Width="114px">
        </asp:DropDownList>
        <br />

        <%--Begin 1e row--%>
        <div class="row class1">
            <div class="col-md-2" style="height:34px; top: 0px; left: 0px;">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelNaam">Aantal:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;"  placeholder="Aantal" class="form-control" id="TbAantal" runat="server"/>
            </div>
        </div>
        <%--Einde 1e row--%>
        <br />
        
        <%--Begin 2e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelTelefoonnummer">RFID:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="RFID" class="form-control" id="TbRFID" runat="server"/>
            </div>
        </div>
        <%--Einde 2e row--%>
        <br />

        <%--Begin 3e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    Tot uiterste datum:</div>
            </div>
            <div class="col-md-2">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </div>
        </div>
        <%--Einde 3e row--%>
        <br />


        <asp:Button ID="Bevestigknop" runat="server" Text="Bevestig" OnClick="Bevestigknop_Click" />


    </div>
    </div>
</asp:Content>

