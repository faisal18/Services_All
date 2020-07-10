<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AIMSDeployment.aspx.cs" Inherits="Services_All.Utilities_UI.AIMSDeployment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Aims Deployment</h1>
    </div>
    <div>
        <div>
            <h4>Select Server</h4>
        </div>
        <div>
            <asp:DropDownList runat="server" ID="ddl_servers_list">
                <asp:ListItem Value="QA">QA Server</asp:ListItem>
                <asp:ListItem Value="Automation">Automation</asp:ListItem>
                <asp:ListItem Value="KingsJalila">Kings Jalila</asp:ListItem>
                <asp:ListItem Value="Jumeriah">Jumeriah</asp:ListItem>
                <asp:ListItem Value="Oman">Oman</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <h4>Select Process</h4>
        </div>
        <div>
            <asp:RadioButtonList runat="server" ID="rd_Process_list" AutoPostBack="true" OnSelectedIndexChanged="rd_Process_list_SelectedIndexChanged">
                <asp:ListItem Value="deploy" Selected="True">Deploy Module</asp:ListItem>
                <asp:ListItem Value="Start">Start Module</asp:ListItem>
                <asp:ListItem Value="Stop">Stop Module</asp:ListItem>
                <asp:ListItem Value="update">Update Module</asp:ListItem>
                <asp:ListItem Value="Switch">Switch Port</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <h4>Select Modules</h4>
        </div>
        <div>
            <asp:CheckBoxList runat="server" ID="chk_modules" AutoPostBack="true" OnSelectedIndexChanged="chk_modules_SelectedIndexChanged">
                <asp:ListItem Value="ESB">ESB Artifact</asp:ListItem>
                <asp:ListItem Value="Workflow">Workflow Artifact</asp:ListItem>
                <asp:ListItem Value="EDI">EDI Artifact</asp:ListItem>
                <asp:ListItem Value="PO">Post Office Artifact</asp:ListItem>
                <asp:ListItem Value="Validation">Validation Artifact</asp:ListItem>
                <asp:ListItem Value="Integration-Reports">Integration Reports Artifact</asp:ListItem>
                <asp:ListItem Value="features">Features Artifact</asp:ListItem>
                <asp:ListItem Value="DataSync">DataSync Artifact</asp:ListItem>
                <asp:ListItem Value="EAuth-Downloader">EAuth Downloader Artifact</asp:ListItem>

                <asp:ListItem Value="NGINX">NGINX Module</asp:ListItem>
                <asp:ListItem Value="Portal">Portal Module</asp:ListItem>
                <asp:ListItem Value="Jboss">JBoss Module</asp:ListItem>
                <asp:ListItem Value="ConnectAPI">ConnectAPI Module</asp:ListItem>
                <asp:ListItem Value="Gateway">Gateway Module</asp:ListItem>

            </asp:CheckBoxList>
        </div>



        <asp:Table runat="server" ID="tbl_divs">

            <asp:TableRow runat="server" ID="tbl_row_gateway" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Gateway API version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_gateway"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow runat="server" ID="tbl_row_connectAPI" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Connect API version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_connectapi"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_portal" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Portal Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_portal"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_jboss" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="JBOSS Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_jboss_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_esb" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="ESB Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_ESB_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_edi" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="EDI Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_EDI_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_workflow" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Workflow Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_Workflow_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_po" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Post Office Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_PO_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_connectAPI_operation" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Connect API Port"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_connectAPI_port"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow runat="server" ID="tbl_row_validation" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Validation Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_Validation_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_IReports" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Integration Reports Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txT_IReports_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_features" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Features Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_features_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_datasynch" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="Data Sync Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_datasynch_version"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" ID="tbl_row_eauth_downloader" Visible="false">
                <asp:TableCell>
                    <asp:Label runat="server" Text="EAuth Downloader Version"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_eauth_downloader"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>


        </asp:Table>

        <div>
            <asp:Button runat="server" Text="Submit" ID="btn_submit" OnClick="btn_submit_Click" />
        </div>

        <div>
            <br />
            <textarea runat="server" id="txt_rich_box" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
        </div>
    </div>
</asp:Content>
