<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="TPO_API.aspx.cs" Inherits="Services_All.Utilities_UI.TPO_API" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>TPO API Automation</h1>






    <div id="usercontrol">
        <div>
            <asp:Label runat="server" ID="lbl_ddl_caller" Text="Select User License"></asp:Label>
        </div>
        <div>
            <asp:DropDownList runat="server" ID="ddl_caller" AutoPostBack="true" OnSelectedIndexChanged="ddl_caller_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" ID="lbl_UserName" Text="Username"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_sender_username" Enabled="false"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="lbl_password" Text="Password">
        
            </asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txt_sender_password" Enabled="false"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button runat="server" ID="btn_add_newuser" Text="Add New User" OnClick="btn_add_newuser_Click" />
            <br />
            <div>
                <asp:Panel runat="server" ID="pnl_add_user" Visible="false">
                    <div>
                        <asp:Label runat="server" ID="lbl_pnl_add_license" Text="License"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl_add_license"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" ID="lbl_pnl_add_username" Text="UserName"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl_add_username"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" ID="lbl_pnl_add_password" Text="Password"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl_add_password"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button runat="server" ID="btn_add_user_submit" Text="Add" OnClick="btn_add_user_submit_Click" />
                        <asp:Button runat="server" ID="btn_cancel_user_submit" Text="Cancel" OnClick="btn_cancel_user_submit_Click" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>



    <%--<asp:Table runat="server" ID="tbl_credentials">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Sender Username"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txt_sender_username" Text="Provider"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Sender Password"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txt_sender_password" Text="P@ssw0rd"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>--%>

    <div>
        <br />
        <br />
        <asp:Label runat="server" Text="Select Module"></asp:Label>
        <asp:DropDownList runat="server" ID="ddl_Methods_Selection" AutoPostBack="true" OnSelectedIndexChanged="ddl_Methods_Selection_SelectedIndexChanged">
            <asp:ListItem Value="null">Select Module</asp:ListItem>
            <asp:ListItem Value="Claim">Claims Management</asp:ListItem>
            <asp:ListItem Value="Authorization">Authorization Management</asp:ListItem>
            <asp:ListItem Value="ERX">ERX Management</asp:ListItem>
            <asp:ListItem Value="Lab">LAB Management</asp:ListItem>
            <asp:ListItem Value="Rad">RAD Management</asp:ListItem>
            <asp:ListItem Value="Attachments">Attachment Management</asp:ListItem>
            <%--<asp:ListItem Value="Custom">Custom</asp:ListItem>--%>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" Text="Select Method"></asp:Label>
        <asp:DropDownList runat="server" ID="ddl_panel_selection" AutoPostBack="true" OnSelectedIndexChanged="ddl_panel_selection_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
    </div>

<%--    <asp:Panel runat="server" ID="pnl_custom" Visible ="false">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Iteration Count"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_iteration_count"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload runat="server" ID="file_upload_custom" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>--%>

    <asp:Panel runat="server" ID="pnl_GetNew" Visible="false">
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_Search" Visible="false">

        <asp:Table runat="server" ID="tbl_searchFiles">
            <%-- <asp:TableRow>
                <asp:TableCell>
                     <asp:Label runat="server" Text="Index Number"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_IndexNumber"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Page Number"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_PageNumber"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>--%>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Sender License"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_SenderLicense"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Direction"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="ddl_direction">
                        <asp:ListItem Value="0">Received</asp:ListItem>
                        <asp:ListItem Value="1">Sent</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                     <asp:Label runat="server" Text="From Date (yyyy-MM-dd HH:mm)"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_FromDate"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                     <asp:Label runat="server" Text="To Date (yyyy-MM-dd HH:mm)"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_ToDate"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Download Status"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="ddl_download_status">
                        <asp:ListItem Value="2">All Transactions</asp:ListItem>
                        <asp:ListItem Value="0">Not Downloaded</asp:ListItem>
                        <asp:ListItem Value="1">Downloaded</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                     <asp:Label runat="server" Text="File Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_filename"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Transaction/Order ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_FilesSystemID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_View" Visible="false">

        <asp:Table runat="server" ID="tbl_GetFiles">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Files System ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl2_FilesSystemID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Direction"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="pnl2_ddl_direction">
                        <asp:ListItem Value="0">Received</asp:ListItem>
                        <asp:ListItem Value="1">Sent</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_PostFile" Visible="false">
        <div>
            <asp:CheckBox runat="server" ID="chck_filename" Text="Auto-Increament File Name" />
            <asp:CheckBox runat="server" ID="chck_fileID" Text="Auto-Increament File ID" />
        </div>
        <div runat="server" id="div_rdbox" style="display:none;">
            <asp:RadioButtonList runat="server" ID="rd_list_transaction_type" AutoPostBack="true" OnSelectedIndexChanged="rd_list_transaction_type_SelectedIndexChanged">
                <asp:ListItem Enabled="true" Value="Submission" Selected="True">Submission</asp:ListItem>
                <asp:ListItem Enabled="true" Value="Resubmission">Resubmission</asp:ListItem>
                <asp:ListItem Enabled="true" Value="Prescription-Dispense">Prescription Dispense</asp:ListItem>
                <asp:ListItem Enabled="true" Value="Laboratory-Dispense">Laboratory Dispense</asp:ListItem>
                <asp:ListItem Enabled="true" Value="Radiology-Dispense">Radiology Dispense</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div runat ="server" id="div_iterationBOX" style="display:none;">
            <asp:Label runat="server" Text="Iteration Count"></asp:Label>
            <asp:TextBox runat="server" ID="txt_iterationCount">1</asp:TextBox>
            <asp:CheckBox runat="server" ID="chk_filegenerate" Text="Generate and not send file" />
        </div>
        <div>
            <asp:FileUpload runat="server" ID="file_uploader" AllowMultiple="true" />
            <%--<asp:RegularExpressionValidator ID="regexValidator" runat="server"
                ControlToValidate="file_uploader"
                ErrorMessage="Only XML Files are allowed"
                ValidationExpression="(.*\.([Xx][Mm][Ll])|([Jj][Ss][Oo][Nn])$)">
            </asp:RegularExpressionValidator>--%>

        </div>
        <div>
            <textarea runat="server" id="txt_richbox_postFile" style="resize: none; height: 500px; width: 700px; margin: 0px;"></textarea>
        </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_SetDownloaded" Visible="false">
        <asp:Table runat="server" ID="tbl_SAD">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Files System ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl3_txt_filessystemid"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_View_PrescriptionOrder" Visible ="False">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="File System ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl4_FilesSystemID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Member ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl4_MemberID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_CheckActivityStatus" Visible ="False">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="File System ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl6_SystemID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Activity ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl6_ActivityID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>



    <asp:Panel runat="server" ID="pnl_Find_PrescriptionOrder" Visible="false">

        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell><asp:Label runat="server" Text="National ID"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl5_nationalID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label runat="server" Text="Member ID"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pnl5_memberID"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_Upload_Attachment" Visible="false">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload runat="server" ID="file_upload_attachment" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_Download_Attachment" Visible="false">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="File ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txt_download_file_id"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>


    <div>
        <br />

        <asp:Button runat="server" ID="btn_submit" Text="Submit Request" OnClick="btn_submit_Click" />
    </div>

    <div>
        <br />
        <textarea runat="server" id="txt_rich_box" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>
</asp:Content>
