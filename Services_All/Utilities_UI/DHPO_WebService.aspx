<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="DHPO_WebService.aspx.cs" Inherits="Services_All.Utilities_UI.DHPO_WebService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>DHPO Web Service</h1>



    <div>
        <asp:Label runat="server" Text="License"></asp:Label>
    </div>
    <div>
        <asp:DropDownList runat="server" ID="ddl_caller" AutoPostBack="true" OnSelectedIndexChanged="ddl_caller_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div>
        <asp:Label runat="server" Text="Username"></asp:Label>
    </div>
    <div>
        <asp:TextBox runat="server" ID="txt_sender_username"></asp:TextBox>
    </div>
    <div>
        <asp:Label runat="server" Text="Password"></asp:Label>
    </div>
    <div>
        <asp:TextBox runat="server" ID="txt_sender_password"></asp:TextBox>
    </div>

     <%--ADD USER--%>
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
    <%--ADD USER END--%>

    <br />
    <div>
        <h4>Select Enviorment</h4>
    </div>
    <div>
        <asp:RadioButtonList runat="server" ID="rd_enviorment">
            <asp:ListItem Value="rd_qa">QA</asp:ListItem>
            <asp:ListItem Value="rd_prod" Selected="True">Production</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <h4>Select WebService Method</h4>
    </div>
    <div>
        <asp:DropDownList runat="server" ID="ddl_method" AutoPostBack="true" OnSelectedIndexChanged="ddl_method_SelectedIndexChanged">
            <asp:ListItem Value="CheckForNewPriorAuthorizationTransactions">CheckForNewPriorAuthorizationTransactions</asp:ListItem>
            <asp:ListItem Value="DownloadTransactionFile">DownloadTransactionFile</asp:ListItem>
            <asp:ListItem Value="GetNewPriorAuthorizationTransactions">GetNewPriorAuthorizationTransactions</asp:ListItem>
            <asp:ListItem Value="GetNewTransactions">GetNewTransactions</asp:ListItem>
            <asp:ListItem Value="SearchTransactions">SearchTransactions</asp:ListItem>
            <asp:ListItem Value="SetTransactionDownloaded">SetTransactionDownloaded</asp:ListItem>
            <asp:ListItem Value="UploadTransaction">UploadTransaction</asp:ListItem>
        </asp:DropDownList>

    </div>


    <div>
        <asp:Panel runat="server" ID="pnl1_fileID" Visible="false">
            <div>
                <asp:Label runat="server" ID="lbl_fileID" Text="File ID"></asp:Label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_fileID"></asp:TextBox>
            </div>
        </asp:Panel>
    </div>

    <div>
        <asp:Panel runat="server" ID="pnl2_uploadfiles" Visible="false">
             <div>

                <asp:DropDownList runat="server" ID="ddl_uploadfile" AutoPostBack="true" OnSelectedIndexChanged="ddl_uploadfile_SelectedIndexChanged">
                    <asp:ListItem Value="">Select Preloaded File</asp:ListItem>
                    <asp:ListItem Value="claim">Claim Submission</asp:ListItem>
                    <asp:ListItem Value="remittance">Remittance Advice</asp:ListItem>
                    <asp:ListItem Value="priorrequest">Prior Request</asp:ListItem>
                    <asp:ListItem Value="priorauthorization">Prior Authorization</asp:ListItem>
                    <asp:ListItem Value="erxrequest">Erx Request</asp:ListItem>
                    <asp:ListItem Value="erxauhtorization">Erx Authorization</asp:ListItem>

                </asp:DropDownList>

            </div>
            
            <div>
                <asp:FileUpload runat="server" ID="file_upload" AllowMultiple="true" />
            </div>

           

            <br />

            <h4>Upload file parameter(Optional)</h4>
            <div>
                <asp:CheckBox runat="server" ID="chk_fileID" Text="Iterate File ID"  />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chk_fileName" Text="Iterate File Name" />
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chk_fileDate" Text="Convert Date" />
            </div>

            <h4>Post file through text</h4>
             <div>
                <asp:Label runat="server" ID="lbl_filename" Text="File Name"></asp:Label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_filename"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chk_sendmultiple" Text="Send file multiple times" AutoPostBack="true" OnCheckedChanged="chk_sendmultiple_CheckedChanged"/>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_file_iterationcount" Visible="false" Text="1"></asp:TextBox>
            </div>
            <div>
                <br />
                <textarea runat="server" id="txt_richbox_postFile" style="resize: both; height: 200px; width: 900px; margin: 0px;"></textarea>
            </div>

        </asp:Panel>
    </div>


    <div>
        <br />

        <asp:Button runat="server" ID="btn_submit" Text="Submit Request" OnClick="btn_submit_Click" />
    </div>


    <div>
        <br />
        <textarea runat="server" id="txt_rich_box" style="resize: both; height: 200px; width: 900px; margin: 0px;" readonly="readonly"></textarea>
    </div>

    <div>
         <asp:GridView runat="server" ID="grid_view" Width="100%" AutoGenerateColumns="true"
                    AllowPaging="true" PageSize="20" OnPageIndexChanging="grid_view_PageIndexChanging"
                    CellPadding="10" CellSpacing="5">
             <Columns>
                 <asp:TemplateField HeaderText="Download File">
                     <ItemTemplate>
                         <asp:LinkButton runat="server" ID="link_download" CommandArgument =" <%# Container.DataItemIndex %>" CommandName="file_download" OnCommand="link_download_Command" Text="Download"></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="Set as Downloaded">
                     <ItemTemplate>
                         <asp:LinkButton runat="server" ID="link_setdownloaded" CommandArgument="<%# Container.DataItemIndex %>" CommandName="set_downloaded" OnCommand="link_setdownloaded_Command" Text="Set as Downloaded"></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>

             </asp:GridView>
    </div>




</asp:Content>
