<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DHPO_Cancellation.aspx.cs" Inherits="Services_All.Utilities_UI.DHPO_Cancellation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <h1>DHPO Transaction Cancellation in DHPO</h1>



    <div>
        <asp:Label runat="server" Text="TransactionID (Comma seperated/Newline)"></asp:Label>
    </div>

    <div> 
        <asp:TextBox runat="server" ID="txt_transID" TextMode ="MultiLine"></asp:TextBox>
    </div>

    <div>
        <asp:Button runat="server" Text="Submit" ID="btn_Submit" OnClick="btn_Submit_Click" />
    </div>

     <div>
        <br />
        <textarea runat="server" id="lbl_message" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>


    <%--<asp:Label runat="server" ID="lbl_message"></asp:Label>--%>

</asp:Content>
