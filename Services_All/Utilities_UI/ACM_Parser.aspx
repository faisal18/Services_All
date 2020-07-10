<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ACM_Parser.aspx.cs" Inherits="Services_All.Utilities_UI.ACM_Parser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <h1>ACM Log parser</h1>



    <div>
        <asp:Label runat="server" Text="TransactionID (Comma seperated/Newline)"></asp:Label>
    </div>

    <div> 
        <asp:TextBox runat="server" ID="txt_transID" TextMode ="MultiLine"></asp:TextBox>
    </div>

    <div>

        <asp:DropDownList runat="server" ID="ddl_client" AutoPostBack="true" OnSelectedIndexChanged="ddl_client_SelectedIndexChanged">

        </asp:DropDownList>
    </div>


    <div>
        <asp:DropDownList runat="server" ID="ddl_sections" AutoPostBack ="true" OnSelectedIndexChanged="ddl_sections_SelectedIndexChanged">

        </asp:DropDownList>
    </div>


    <div>
        <asp:Button runat="server" Text="Submit" ID="btn_Submit" OnClick="btn_Submit_Click" />
    </div>

     <div>
        <br />
        <textarea runat="server" id="lbl_message" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>


</asp:Content>
