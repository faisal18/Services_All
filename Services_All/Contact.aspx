<%@  Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Services_All.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<h1>
    Contact Us
</h1>
    <div>
        <asp:Label runat="server" Text="Name"></asp:Label>
        <asp:TextBox runat="server" ID="txt_name"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" Text="Comments"></asp:Label>
        <asp:TextBox runat="server" ID="txt_text"></asp:TextBox>
    </div>

    <div>
        <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
    </div>
    <div>
        <asp:Label runat="server" ID="lbl_response"></asp:Label>
    </div>
</asp:Content>
