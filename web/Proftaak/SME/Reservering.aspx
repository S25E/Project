<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reservering.aspx.cs" Inherits="SME.Reservering1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reservering</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <h1>Maak hier uw reservering</h1>
        <br />
        <%--Begin 1e row--%>
        <div class="row class1">
            <div class="col-md-2" style="height:34px;">
                <div class="control-group row-fluid form-inline">
                    Naam:
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
                    Straat:  
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Straat" class="form-control" id="TbStraat" runat="server"/>
            </div>
        </div>
        <%--Einde 2e row--%>
        <br />

        <%--Begin 3e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    Postcode:  
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
                     Woonplaats:
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
                    Telefoonnummer:  
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox style="text-align:left; width: 200px; margin-left:auto; margin-right:auto;" placeholder="Telefoonnummer" class="form-control" id="TbTelefoonnummer" runat="server"/>
            </div>
        </div>
        <%--Einde 5e row--%>
        <br />
        
        <%--Begin 6e row--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    Emailadres:  
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
                    Rekeningnummer:
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
                    Sofinummer:  
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
                <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-arrow-left btn btn-success" OnClick="ButtonBack_Click"/>
            </div>
        
            <div class="col-md-2 text-right">
                <asp:LinkButton runat="server" CssClass="glyphicon glyphicon-arrow-right btn btn-success" OnClick="ButtonNext_Click"/>
            </div>

            
        </div>
    </div>
</asp:Content>
