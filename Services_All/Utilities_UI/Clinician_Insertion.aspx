<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clinician_Insertion.aspx.cs" Inherits="Services_All.Utilities_UI.Clinician_Insertion" %>

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
            $("[id$=txt_pnl6_transFromDate]").datepicker({
                //showOn: 'button',
                buttonImageOnly: true,
                changeMonth: true,
                dateFormat: "yy-mm-dd 00:00",
                //buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
        $(function () {
            $("[id$=txt_pnl6_transToDate]").datepicker({
                //showOn: 'button',
                buttonImageOnly: true,
                changeMonth: true,
                dateFormat: "yy-mm-dd 00:00",
                //buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        })

    </script>


    <h1>Add clinician fatafut</h1>


    <div>


        <div>
            <asp:Label runat="server" Text="License"></asp:Label>
        </div>

        <div>
            <asp:TextBox runat="server" ID="txt_License"></asp:TextBox>
        </div>

        <div>
            <asp:Label runat="server" Text="Username"></asp:Label>
        </div>

        <div>
            <asp:TextBox runat="server" ID="txt_username"></asp:TextBox>
        </div>

        <div>
            <asp:Label runat="server" Text="Password"></asp:Label>
        </div>

        <div>
            <asp:TextBox runat="server" ID="txt_password"></asp:TextBox>
        </div>

        <div>
            <asp:Label runat="server" ID="lbl_pnl6_transFromDate" Text="Transaction From Date"></asp:Label>
        </div>
        <div>

            <asp:TextBox runat="server" ID="txt_pnl6_transFromDate"></asp:TextBox>
        </div>

        <div>
            <asp:Label runat="server" ID="lbl_pnl6_transToDate" Text="Transaction To Date"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_pnl6_transToDate"></asp:TextBox>
        </div>

        <div>
            <asp:Button runat="server" Text="Submit" ID="btn_submit" OnClick="btn_submit_Click" />
        </div>

        <div>
            <br />
            <textarea runat="server" id="lbl_message" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
        </div>



    </div>


</asp:Content>
