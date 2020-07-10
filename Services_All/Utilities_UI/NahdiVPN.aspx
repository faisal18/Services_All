<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest ="false" CodeBehind="NahdiVPN.aspx.cs" Inherits="Services_All.Utilities_UI.NahdiVPN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="title">
        <h1>Nahdi VPN Service</h1>
    </div>
    <div>
        <div>
            <textarea runat="server" id="input_richbox" style="resize: none; height: 500px; width: 921px; margin: 0px;" ></textarea>
        </div>
        <div>
            <asp:FileUpload runat="server" ID="file_upload" /></div>
        <div>
            <asp:RadioButton runat="server" ID="rd_bupa" Text="BUPA Eligibility" AutoPostBack="true" OnCheckedChanged="rd_bupa_CheckedChanged" Checked="true" /></div>
        <div>
            <asp:RadioButton runat="server" ID="rd_waseel" Text="WASEEL Eligibility" AutoPostBack="true" OnCheckedChanged="rd_waseel_CheckedChanged" /></div>
       <div>
           <asp:RadioButton runat="server" ID="rd_waseel_submission" Text="WASEEL Submission" AutoPostBack ="true" OnCheckedChanged="rd_waseel_submission_CheckedChanged" />
       </div>
        <div>
            <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" /></div>
        
         <div id="ResultBox">
                <textarea runat="server" id="txt_rich_box" style="resize: none; height: 500px; width: 921px; margin: 0px;" readonly="readonly"></textarea>
            </div>
        
    </div>
</asp:Content>
