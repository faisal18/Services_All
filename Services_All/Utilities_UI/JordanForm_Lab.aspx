<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest ="false" CodeBehind="JordanForm_Lab.aspx.cs" Inherits="Services_All.Utilities_UI.JordanForm_Lab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent"  runat="server">
     <div id="title">
        <h1>JORDAN LAB WS</h1>
    </div>
    <div>
        <div>
            <asp:Label runat="server" ID="lbl_facilitylogin" Text ="Facility login"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_facilitylogin"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="lbl_facilitypassword" Text ="Facility Password"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_facilitypassword"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="lbl_clinicianlogin" Text ="Clinician login"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_clinicianlogin"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="lbl_clinicianpassword" Text ="Facility password"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_clinicianpassword"></asp:TextBox>
        </div>
        <div style="float:none">
            <div style="float:left">
            <textarea runat="server" id="input_richbox" style="resize: none; height: 500px; width: 700px; margin: 0px;"></textarea>
            </div>
            <div style="float:right">
            <textarea runat="server" id="txt_rich_box" style="resize: none; height: 200px; width: 300px; margin: 0px;" readonly="readonly"></textarea>
            </div>
        </div>

        <div style="float:initial">
            <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
        </div>

    </div>
</asp:Content>
