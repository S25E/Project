<%@ Page Title="" Language="C#" MasterPageFile="~/Reservering/Reservering.master" AutoEventWireup="true" CodeBehind="Stap3.aspx.cs" Inherits="SME.Stap3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3>3. Selecteer kampeerplaats.</h3>
    <div class="row class1">
        <style type="text/css">
            .selected {
                background-color: yellow;
            }
            .gekozen {
                background-color: blue;
            }
        </style>
        <div class="col-xs-6">
            <div style="width: 542px; height: 520px; background: url('../img/plattegrond camping zonder nummers.png');">
                <asp:ListView runat="server" ID="KampeerplaatsenLijst">
                    <ItemTemplate>
                        <div style="left: <%#Eval("X") %>px; top: <%#Eval("Y") %>px;position: absolute;background-color: <%# string.Format("{0}", (bool)Eval("IsBeschikbaar") ? "none" : "red") %>; font-size: 10px; padding: 3px; border-radius: 10px;" class="kampeerplaats<%# string.Format("{0}", (bool)Eval("IsBeschikbaar") ? " beschikbaar" : "") %>" data-id="<%#Eval("Nummer") %>" id="kampeerplaats<%#Eval("Nummer") %>"><%#Eval("Nummer") %></div>
                    </ItemTemplate>
                </asp:ListView>
        </div>
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
            <ul class="list-group" id="geselecteerdeplaatsen">
                <asp:Repeater runat="server" ID="repeaterPlaatsen">
                    <ItemTemplate>
                        <li class="list-group-item" data-id="<%#Container.DataItem%>">Kampeerplaats nummer: <%#Container.DataItem%></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <asp:Label runat="server" ID="Labelfoutmelding" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <br />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#kampeerplaats" + $("#ContentPlaceHolder1_ContentPlaceHolder3_dropdown").val()).addClass("selected");
            $(".kampeerplaats.beschikbaar:not(.gekozen)").click(function () {
                $('#ContentPlaceHolder1_ContentPlaceHolder3_dropdown option[value=' + $(this).data('id') + ']').attr('selected', 'selected');
                $('#ContentPlaceHolder1_ContentPlaceHolder3_dropdown').trigger('change');
            });
            $("#geselecteerdeplaatsen li").each(function () {
                $("#kampeerplaats" + $(this).data('id')).addClass('gekozen');
            });
        });
    </script>
    <asp:LinkButton runat="server" OnClick="ButtonNext_Click" CssClass="btn btn-primary glyphicon glyphicon-arrow-right" ></asp:LinkButton>
</asp:Content>
