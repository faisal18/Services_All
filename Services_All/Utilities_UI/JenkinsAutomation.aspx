<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JenkinsAutomation.aspx.cs" Inherits="Services_All.Utilities_UI.JenkinsAutomation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <h1>JENKINS AUTOMATION</h1>
    </div>
    
    <div>
        <div>
            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
        </div>
        <br>
          <div>
            <textarea runat="server" id="txt_richbox" style="resize: none; height: 196px; width: 921px; margin: 0px;" readonly="readonly"></textarea>
        </div>
    </div>

</asp:Content>
