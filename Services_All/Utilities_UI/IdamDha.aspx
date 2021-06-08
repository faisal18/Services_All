<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IdamDha.aspx.cs" Inherits="Services_All.Utilities_UI.IdamDha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <h1>DHPO Transaction Cancellation in DHPO</h1>



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
        <asp:Button runat="server" Text="Submit" ID="btn_Submit" OnClick="btn_Submit_Click" />
    </div>

    <div>
        <br />
        <textarea runat="server" id="lbl_message" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>

</asp:Content>
