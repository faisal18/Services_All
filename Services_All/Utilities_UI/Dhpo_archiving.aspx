<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dhpo_archiving.aspx.cs" Inherits="Services_All.Utilities_UI.Dhpo_archiving" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>
            DHPO Archiviing Service
        </h1>
    </div>
    <div>
        <div>
            <asp:Label runat="server" ID="lbl_data" Text="Enter Transaction IDs" ></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_transactionids" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div>
            <asp:RadioButtonList ID="rd_list" runat="server">
                <asp:ListItem Value="PR">Prior Request</asp:ListItem>
                <asp:ListItem Value="PA">Prior Authourization</asp:ListItem>
                <asp:ListItem Value="CS">Claim Submissions</asp:ListItem>
                <asp:ListItem Value="RA">Remiitance Advise</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <textarea runat="server" id="txt_richbox" style="resize: none; height: 196px; width: 921px; margin: 0px;" readonly="readonly"></textarea>
        </div>
        <div>
            <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
        </div>
    </div>
</asp:Content>
