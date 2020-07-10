<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DHCC_Client.aspx.cs" Inherits="Services_All.Utilities_UI.DHCC_Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


    <script type="text/javascript">
        $(function () {
            $("[id$=txt_FromDate]").datepicker({
                //showOn: 'button',
                buttonImageOnly: true,
                changeMonth: true,
                dateFormat: "dd-mm-yy",
                //buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
        $(function () {
            $("[id$=txt_EndDate]").datepicker({
                //showOn: 'button',
                buttonImageOnly: true,
                changeMonth: true,
                dateFormat: "dd-mm-yy",
                //buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
    </script>

    <h1>DHCC Client</h1>

    <div>
        <asp:Label runat="server" Text="Transaction From Date"></asp:Label>
    </div>
    <div>
        <asp:TextBox runat="server" ID="txt_FromDate"></asp:TextBox>
    </div>

    <asp:Panel runat="server" ID="pnl_toDate">
        <div>
            <asp:Label runat="server" Text="Transaction To Date"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_EndDate"></asp:TextBox>
        </div>
    </asp:Panel>

    <div>
        <asp:RadioButtonList runat="server" ID="rd_list_enviorment">
            <asp:ListItem Value="QA" Selected="True">DHCC QA</asp:ListItem>
            <asp:ListItem Value="Production" >DHCC Production</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:CheckBox runat="server" ID="chk_iterate" Text="Iterate Dates" OnCheckedChanged="chk_iterate_CheckedChanged" AutoPostBack="true" />
        <asp:Panel runat="server" ID="pnl_interval" Visible="false">
            <div>
                <asp:Label runat="server" Text="Days Interval from start date"></asp:Label>
                <asp:TextBox runat="server" ID="txt_daysinterval"></asp:TextBox>
            </div>
        </asp:Panel>
    </div>

    <div>
        <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
    </div>
    <div>
        <textarea runat="server" id="txt_rich_box" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>
</asp:Content>
