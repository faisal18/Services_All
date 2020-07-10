<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IDAM_Integration.aspx.cs" Inherits="Services_All.Utilities_UI.IDAM_Integration" %>
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
            $("[id$=txt_StartDate]").datepicker({
                //showOn: 'button',
                buttonImageOnly: true,
                changeMonth: true,
                dateFormat: "dd-mm-yy",
                //buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
    </script>


    <h1>IDAM Integration</h1>
    <div>
    <asp:Label runat="server" Text="Start Date"></asp:Label>
        </div>

    <div>
        <asp:TextBox runat="server" ID="txt_StartDate"></asp:TextBox>
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
        <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
    </div>

    <div>
        <asp:Label runat="server" ID="lbl_result"></asp:Label>
    </div>



</asp:Content>
