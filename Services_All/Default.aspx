<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Services_All._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="title">
        <h1>Utilities - Technical Support Team - Praise the Developer</h1>
    </div>
    <div id="content">
        <fieldset>
            <legend>Miscellaneous</legend>
            <ul>
                <li><a runat="server" href="~/Utilities_UI/Validate_Services.aspx">Services Check</a></li>
                <li><a runat="server" href="~/Utilities_UI/NahdiVPN.aspx">Nahdi VPN</a></li>
                <li><a runat="server" href="~/Utilities_UI/Greenrain.aspx">Greenrain</a></li>
                <li><a runat="server" href="~/Utilities_UI/JenkinsAutomation.aspx">Jenkins Automation</a></li>
                <li><a runat="server" href="~/Utilities_UI/Provider_Registration.aspx">Provider Registration</a></li>
                <li><a runat="server" href="~/Utilities_UI/JordanForm_Lab.aspx">Jordan LAB WS</a></li>
                <li><a runat="server" href="~/Utilities_UI/JordanForm_Rad.aspx">Jordan RAD WS</a></li>
                <li><a runat="server" href="~/Utilities_UI/Aims_Execution.aspx">AIMS EXECUTION</a></li>
                <li><a runat="server" href="~/Utilities_UI/TPO_API.aspx">TPO API</a></li>
                <li><a runat="server" href="~/Utilities_UI/Dashboard.aspx">Dashboard</a></li>
                <li><a runat="server" href="~/Utilities_UI/AIMSDeployment.aspx">AIMS Deployment</a></li>
                <li><a runat="server" href="~/Utilities_UI/DHCC_Client.aspx">DHCC Client</a></li>
                <li><a runat="server" href="~/Utilities_UI/DHCC_Clinician_Password_Recovery.aspx">DHCC Clinician Password Recovery</a></li>
                <li><a runat="server" href="~/Utilities_UI/DHPO_WebService.aspx">DHPO WebService</a></li>
                <li><a runat="server" href="~/Utilities_UI/DHA_Sheryan_Professionals.aspx">DHA Professional LMU</a></li>
                <li><a runat="server" href="~/Utilities_UI/DHA_Sheryan_GetProfessional_Utlity.aspx">DHA_Sheryan_GetProfessional_Utlity</a></li>
                <li><a runat="server" href="~/Utilities_UI/IdamDha.aspx">IDAM DHA Check</a></li>
                <%--<li><a runat="server" href="~/Utilities_UI/DHPO_Cancellation.aspx">DHPO Cancellation</a></li>--%>
            </ul>
        </fieldset>
    </div>
</asp:Content>
