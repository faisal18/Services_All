<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DHCC_Clinician_Password_Recovery.aspx.cs" Inherits="Services_All.Utilities_UI.DhccClinician_Password_Recovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>DHCC CLINICIAN PASSWORD RECOVERY</h1>

    <div>
        <asp:Label runat="server" Text="Enter Password"></asp:Label>
    </div>
    <div>
        <asp:TextBox runat="server" ID="txt_password" TextMode="MultiLine" Style="resize: both; height: 200px; width: 900px; margin: 0px;"></asp:TextBox>
    </div>

    <div>
        <asp:Panel runat="server" ID="pnl_fileupload" Visible="false">
            <div>
                <asp:Label runat="server" Text="Upload File"></asp:Label>
            </div>
            <div>
                <asp:FileUpload runat="server" ID="file_upload_dhcc" AllowMultiple="true" />
            </div>
        </asp:Panel>
    </div>

    <asp:RadioButtonList runat="server" ID="rd_function" AutoPostBack="true" OnSelectedIndexChanged="rd_function_SelectedIndexChanged">
        <asp:ListItem Value="decryptbydhcc">Decrypt Password by DHCC Production</asp:ListItem>
        <asp:ListItem Value="encryptbylocalkey">Encrypt Password by Local Key</asp:ListItem>
        <asp:ListItem Value="decryptbylocalkey">Decrypt Password by Local Key</asp:ListItem>
        <asp:ListItem Value="getboth">Decrypt/Encrypt</asp:ListItem>
        <asp:ListItem Value="upload_file">Upload File</asp:ListItem>
    </asp:RadioButtonList>
    <div>
        <asp:Button runat="server" ID="txt_submit" Text="Submit" OnClick="txt_submit_Click" />
    </div>
    <div>
        <textarea runat="server" id="txt_rich_box" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>
</asp:Content>
