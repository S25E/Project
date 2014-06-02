<%@ Page Title="" Language="C#" MasterPageFile="~/Standaard.Master" AutoEventWireup="true" CodeBehind="Reservering.aspx.cs" Inherits="SME.Reservering1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reservering</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
    <div class="form-horizontal">
        <h1>Maak hier uw reservering</h1>
        <br />

        <%--dropdown row--%>
        <div class="row class1">
            <div class="col-md-2" style="height:34px;">
                <div class="btn-group">
                  <asp:Button ID="combobox" runat="server" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" text="Type Boeker... ▼"/>
                  <ul class="dropdown-menu" role="menu">
                        <li><asp:LinkButton runat="server" OnClick="DropDownHoofdboeker_Click">Hoofdboeker</asp:LinkButton></li>
                        <li><asp:LinkButton runat="server" OnClick="DropDownBijboeker_Click">Bijboeker</asp:LinkButton></li>
                  </ul>
                </div>
            </div>
        </div>
        <%--einde dropdown row--%>
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
                    <asp:label runat="server" id="LabelTelefoonnummer">Telefoonnummer:</asp:label>
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
        <%--Einde 4e row--%>
        <br />

        <%--Begin 5e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelStraat">Straat:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Straat" class="form-control" id="TbStraat" runat="server"/>
            </div>
        </div>
        <%--Einde 5e row--%>
        <br />
        
        <%--Begin 6e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelEmail">Emailadres:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Emailadres" class="form-control" id="TbEmail" runat="server"/>
            </div>
        </div>
        <%--Einde 6e row--%>
        <br />

        <%--Begin 7e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelRekeningnummer">Rekeningnummer:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Rekeningnummer" class="form-control" id="TbRekeningnummer" runat="server"/>
            </div>
        </div>
        <%--Einde 7e row--%>
        <br />

        <%--Begin 8e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:label runat="server" id="LabelSofinummer">Sofinummer:</asp:label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Sofinummer" class="form-control" id="TbSofinummer" runat="server"/>
            </div>
        </div>
        <%--Einde 8e row--%>
        <br />

        <div class="row class1">
            <div class="col-md-2">
                <asp:LinkButton runat="server" style="font-size:22px;" CssClass="glyphicon glyphicon-arrow-left btn btn-large btn-primary" OnClick="ButtonBack_Click"/>
            </div>
        
            <div class="col-md-3">
                <asp:LinkButton runat="server" style="font-size:22px; margin-left:152px;" CssClass="glyphicon glyphicon-arrow-right btn btn-large btn-primary" OnClick="ButtonNext_Click"/>
            </div>

            
        </div>
    </div>
    </div>
</asp:Content>
