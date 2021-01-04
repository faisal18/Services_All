<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eclaim_Add_MissingDrug.aspx.cs" Inherits="Services_All.Utilities_UI.Eclaim_Add_MissingDrug" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Eclaimlink add missing drug</h1>



    <div>
        <asp:Label runat="server" Text="ScientificCode (Comma seperated/Newline)"></asp:Label>
    </div>

    <div> 
        <asp:TextBox runat="server" ID="txt_ScientificCode" TextMode ="MultiLine"></asp:TextBox>
    </div>

    <div>
        <asp:Button runat="server" Text="Submit" ID="btn_Submit" OnClick="btn_Submit_Click" />
    </div>

     <div>
        <br />
        <textarea runat="server" id="lbl_message" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>

</asp:Content>
