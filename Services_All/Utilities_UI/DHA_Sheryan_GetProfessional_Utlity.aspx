<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DHA_Sheryan_GetProfessional_Utlity.aspx.cs" Inherits="Services_All.Utilities_UI.DHA_Sheryan_GetProfessional_Utlity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Get Professional</h2>


    <div>
        <asp:Label runat="server"  Text="License"></asp:Label>
    </div>

    <div>
        <asp:TextBox runat="server" ID="txt_license" TextMode="MultiLine"></asp:TextBox>
    </div>

    <div>
        <asp:RadioButton runat="server" ID="rdbtn_detailed" Text="Short ?" />
    </div>

    <div>
        <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
    </div>

    <div>
        <textarea runat="server" id="txt_rich_box" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>



</asp:Content>
