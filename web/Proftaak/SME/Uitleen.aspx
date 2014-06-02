<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Uitleen.aspx.cs" Inherits="SME.Uitleen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uitleen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="content">
    <div class="form-horizontal">
        <h1>Maak hier uw reservering</h1>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />

        <%--Begin 1e row--%>
        <div class="row class1">
            <div class="col-md-2" style="height:34px;">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelNaam">Naam:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;"  placeholder="Naam" class="form-control" id="TbNaam" runat="server"/>
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
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Telefoonnummer" class="form-control" id="TbTelefoonnummer" runat="server"/>
            </div>
        </div>
        <%--Einde 2e row--%>
        <br />

        <%--Begin 3e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelPostcode">Postcode:</asp:label>  
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Postcode" class="form-control" id="TbPostcode" runat="server"/>
            </div>
        </div>
        <%--Einde 3e row--%>
        <br />

        <%--Begin 4e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                     <asp:label runat="server" id="LabelWoonplaats">Woonplaats:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Woonplaats" class="form-control" id="TbWoonplaats" runat="server"/>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

