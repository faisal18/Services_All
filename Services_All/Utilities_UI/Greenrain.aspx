<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Greenrain.aspx.cs" Inherits="Services_All.Utilities_UI.Greenrain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


    <script type="text/javascript">

        function java_email()
        {
            var email = prompt("Enter receiver email address");
            if (email) {
                var check = prompt("Please confirm address",email);
                if(check)
                {
                    document.getElementById('<%= hdn_email.ClientID%>').value = email;
                }
            }
            
        }

        $(function () {
            $("[id$=txt_pnl6_transFromDate]").datepicker({
                //showOn: 'button',
                buttonImageOnly: true,
                changeMonth: true,
                dateFormat: "yy-mm-dd 00:00",
                //buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
        $(function () {
            $("[id$=txt_pnl6_transToDate]").datepicker({
                //showOn: 'button',
                buttonImageOnly: true,
                changeMonth: true,
                dateFormat: "yy-mm-dd 00:00",
                //buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        })

    </script>
   
    <div id="Wrapper">
        
        <div id="title">
            <h1>Shaffafiya</h1>
        </div>

        <div id="HEAD">

            <div id="methodcontrol">
                <div>
                    <asp:Label runat="server" ID="lbl_ddl_method" Text="Select Method"></asp:Label>
                </div>
                <div id="Methodlist">
                    <asp:DropDownList runat="server" ID="ddl_selectmethod" AutoPostBack="true" OnSelectedIndexChanged="ddl_selectmethod_SelectedIndexChanged">
                        <asp:ListItem Value="1">Add Drug To Eclaim</asp:ListItem>
                        <asp:ListItem Value="2">Check For New Prior Authourization Transactions</asp:ListItem>
                        <asp:ListItem Value="10">Download Transaction File</asp:ListItem>
                        <asp:ListItem Value="3">Get Drug Details</asp:ListItem>
                        <asp:ListItem Value="4">Get New Prior Authourization Transactions</asp:ListItem>
                        <asp:ListItem Value="9">Get New Transacitons</asp:ListItem>
                        <asp:ListItem Value="5">Get Prescription</asp:ListItem>
                        <asp:ListItem Value="6">Search Transactions</asp:ListItem>
                        <asp:ListItem Value="7">Set Transaction Downloaded</asp:ListItem>
                        <asp:ListItem Value="8">Upload Transaction</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

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
                    <asp:TextBox runat="server" ID="txt_UserName" Enabled="false"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ID="lbl_password" Text="Password">
        
                    </asp:Label>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="txt_Password" Enabled="false"></asp:TextBox>
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

        </div>

        <div id="content">
            <div id="mehtods">
                <div id="AddDrugToEclaim">
                    <asp:Panel runat="server" ID="pnl_AddDrgToEclaim" Visible="true">
                        <br />
                        <fieldset>
                            <legend>Add Drug To Eclaim</legend>

                            <%-- <div>
                        <asp:Label runat="server" ID="lbl_pnl1_login" Text="Login"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl1_login"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Label runat="server" ID="lbl_pnl1_pwd" Text="Password"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl1_pwd"></asp:TextBox>
                    </div>--%>

                            <div>
                                <asp:Label runat="server" ID="lbl_pnl1_originalfilecontent" Text="Originial File Content "></asp:Label>
                            </div>
                            <div>
                                <asp:FileUpload runat="server" ID="pnl1_fileupload" />
                            </div>

                            <div>
                                <asp:Label runat="server" ID="lbl_pnl1_originalfilename" Text="Original File Name"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="txt_pnl1_originalfilename"></asp:TextBox>
                            </div>

                            <div>
                                <asp:Label runat="server" ID="lbl_pnl1_baseRate" Text="Base Rate"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="txt_pnl1_baserate"></asp:TextBox>
                            </div>

                            <br />
                            <div>
                                <asp:Button runat="server" ID="btn_pnl1_Submit" Text="Submit" OnClick="btn_pnl1_Submit_Click" />
                            </div>

                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="CheckForNewPA">
                    <asp:Panel runat="server" ID="pnl_CheckForNewPriorAuthourizationTransactions" Visible="false">
                        <fieldset>
                            <br />
                            <legend>Check for New Prior Authourization</legend>

                            <%-- <div>
                        <asp:Label runat="server" ID="lbl_pnl2_login" Text="Login"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl2_login"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Label runat="server" ID="lbl_pnl2_password" Text="Password"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl2_password"></asp:TextBox>
                    </div>--%>

                            <br />
                            <div>
                                <asp:Button runat="server" ID="btn_pnl2_submit" Text="Submit" OnClick="btn_pnl2_submit_Click" />
                            </div>

                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="DownloadTransactionFile">
                    <asp:Panel runat="server" ID="pnl_downloadtransactionfile" Visible="false">
                        <fieldset>
                            <legend>Download Transaction File</legend>
                            <div>
                                <asp:Label runat="server" ID="lbl_pnl10_fileid" Text="File ID">
                                </asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="txt_pnl10_fileid"></asp:TextBox>
                            </div>
                            <br />
                            <div>
                                <asp:Button runat="server" ID="btn_pnl10_submit" Text="Submit" OnClick="btn_pnl10_submit_Click" />
                            </div>
                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="GetDRGDetails">
                    <asp:Panel runat="server" ID="pnl_GetDrugDetails" Visible="false">
                        <fieldset>
                            <br />
                            <legend>Get Drug Details</legend>

                            <%-- <div>
                        <asp:Label runat="server" ID="lbl_pnl3_login" Text="login"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl3_login"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Label runat="server" ID="lbl_pnl3_passsword" Text="Password"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_pnl3_password"></asp:TextBox>
                    </div>--%>

                            <div>
                                <asp:Label runat="server" ID="lbl_pnl3_fileid" Text="File ID"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="txt_pnl3_fileid"></asp:TextBox>
                            </div>

                            <br />
                            <div>
                                <asp:Button runat="server" ID="btn_pnl3_submit" Text="Submit" OnClick="btn_pnl3_submit_Click" />
                            </div>

                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="GetNewPAT">
                    <asp:Panel runat="server" ID="pnl_getNewPat" Visible="false">
                        <fieldset>
                            <br />
                            <legend>Get New Prior Authourisation Transactions</legend>
                            <div>

                                <%-- <div>
                            <asp:Label runat="server" ID="lbl_pnl4_login" Text="login"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl4_login"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label runat="server" ID="lbl_pnl4_password" Text="Password"></asp:Label>
                        </div>
                            <div>
                                <asp:TextBox runat="server" ID="txt_pnl4_password"></asp:TextBox>
                            </div>--%>

                                <br />
                                <div>
                                    <asp:Button runat="server" ID="btn_pnl4_submit" Text="Submit" OnClick="btn_pnl4_submit_Click" />
                                </div>

                            </div>
                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="GetNewTransacitons">
                    <asp:Panel runat="server" ID="pnl_getnewtransactions" Visible="false">
                        <fieldset>
                            <legend>Get New Transactions</legend>
                            <br />
                            <asp:Button runat="server" ID="btn_pnl9_submit" Text="Submit" OnClick="btn_pnl9_submit_Click" />
                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="GetPrescription">
                    <asp:Panel runat="server" ID="pnl_getPrescription" Visible="false">
                        <fieldset>
                            <br />
                            <legend>Get Prescription</legend>
                            <div>

                                <%-- <div>
                            <asp:Label runat="server" ID="lbl_pnl5_login" Text="login"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl5_login"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label runat="server" ID="lbl_pnl5_password" Text="Password"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl5_password"></asp:TextBox>
                        </div>--%>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl5_payerid" Text="Payer ID"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl5_payerid"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl5_memberid" Text="Member ID"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl5_memberid"></asp:TextBox>
                                </div>

                                <br />
                                <div>
                                    <asp:Button runat="server" ID="btn_pnl5_submit" Text="Submit" OnClick="btn_pnl5_submit_Click" />
                                </div>

                            </div>
                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="SearchTransaction">
                    <asp:Panel runat="server" ID="pnl_searchtransaction" Visible="false">
                        <fieldset>
                            <br />
                            <legend>Search Transactions</legend>
                            <div>

                                <%--   <div>
                            <asp:Label runat="server" ID="lbl_pnl6_login" Text="Login"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl6_login"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label runat="server" ID="lbl_pnl6_password" Text="Password"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl6_password"></asp:TextBox>
                        </div>--%>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_direction" Text="Direction*"></asp:Label>
                                </div>
                                <div>

                                    <asp:DropDownList runat="server" ID="ddl_pnl6_driection">
                                        <asp:ListItem Value="1">Sent Transactions</asp:ListItem>
                                        <asp:ListItem Value="2">Received Transactions</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <%--<asp:TextBox runat="server" ID="txt_pnl6_direction"></asp:TextBox></div>--%>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_callerlicense" Text="Caller License"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl6_callerlicense"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_ePartner" Text="E-Partner"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl6_ePartner"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_transID" Text="Transaction ID*"></asp:Label>
                                </div>
                                <div>

                                    <asp:DropDownList runat="server" ID="ddl_pnl6_transID">
                                        <asp:ListItem Value="-1">All</asp:ListItem>
                                        <asp:ListItem Value="2">Claim Submission</asp:ListItem>
                                        <asp:ListItem Value="4">Person Register</asp:ListItem>
                                        <asp:ListItem Value="8">Remittance Advice</asp:ListItem>
                                        <asp:ListItem Value="16">Prior Request</asp:ListItem>
                                        <asp:ListItem Value="32">Prior Auhourization</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <%--<asp:TextBox runat="server" ID="txt_pnl6_transID"></asp:TextBox></div>--%>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_transStatus" Text="Transaction Status*"></asp:Label>
                                </div>
                                <div>

                                    <asp:DropDownList runat="server" ID="ddl_pnl6_transStatus">
                                        <asp:ListItem Value="1">Non-Downloaded Transactions</asp:ListItem>
                                        <asp:ListItem Value="2">Downloaded Transactions</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <%--<asp:TextBox runat="server" ID="txt_pnl6_transStatus"></asp:TextBox></div>--%>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_transFilename" Text="Transaction File Name"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl6_transFilename"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_transFromDate" Text="Transaction From Date"></asp:Label>
                                </div>
                                <div>

                                    <asp:TextBox runat="server" ID="txt_pnl6_transFromDate"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_transToDate" Text="Transaction To Date"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl6_transToDate"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_minRecCount" Text="Minimum Record Count*"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl6_minRecCount"></asp:TextBox>
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl6_maxRecCount" Text="Maximum Record Count*"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl6_maxRecCount"></asp:TextBox>
                                </div>

                                <br />
                                <div>
                                    <asp:Button runat="server" ID="btn_pnl6_submit" Text="Submit" OnClick="btn_pnl6_submit_Click" />
                                </div>

                            </div>
                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="SetTransactionDownloaded">
                    <asp:Panel runat="server" ID="pnl_setTranDownloaded" Visible="false">
                        <fieldset>
                            <br />
                            <legend>Set Transaction Downloaded</legend>
                            <div>

                                <%--    <div>
                            <asp:Label runat="server" ID="lbl_pnl7_login" Text="Login"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl7_login"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label runat="server" ID="lbl_pnl7_password" Text="Password"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl7_password"></asp:TextBox>
                        </div>--%>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl7_fileid" Text="File ID"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl7_fileid"></asp:TextBox>
                                </div>

                                <br />
                                <div>
                                    <asp:Button runat="server" ID="btn_pnl7_submit" Text="Submit" OnClick="btn_pnl7_submit_Click" />
                                </div>

                            </div>
                        </fieldset>
                    </asp:Panel>
                </div>

                <div id="UploadTransaction">
                    <asp:Panel runat="server" ID="pnl_uploadTransaction" Visible="false">
                        <fieldset>
                            <br />
                            <legend>Upload Transaction</legend>
                            <div>

                                <%-- <div>
                            <asp:Label runat="server" ID="lbl_pnl8_login" Text="Login"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl8_login"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label runat="server" ID="lbl_pnl8_password" Text="Password"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="txt_pnl8_password"></asp:TextBox>
                        </div>--%>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl8_fileupload" Text="File Content"></asp:Label>
                                </div>
                                <div>
                                    <asp:FileUpload runat="server" ID="pnl8_fileupload" />
                                </div>

                                <div>
                                    <asp:Label runat="server" ID="lbl_pnl8_filename" Text="File Name"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_pnl8_filename"></asp:TextBox>
                                </div>

                                <br />
                                <div>
                                    <asp:Button runat="server" ID="btn_pnl8_submit" Text="Submit" OnClick="btn_pnl8_submit_Click" />
                                </div>

                            </div>
                        </fieldset>
                    </asp:Panel>
                </div>
            </div>
            <div style="visibility:hidden">
                <asp:HiddenField ID="hdn_email" Value="" runat="server" />
                <%--<input type="text" id="hdn_email" value="yooo" />--%>
            </div>
            <div id="ResultBox">
                <textarea runat="server" id="txt_richbox" style="resize: none; height: 196px; width: 921px; margin: 0px;" readonly="readonly"></textarea>
            </div>
            <div>
                <asp:Label runat="server" ID="lbl_error"></asp:Label>
            </div>           
            <div>
                <asp:GridView runat="server" ID="grid_view" Width="100%" AutoGenerateColumns="true"
                    AllowPaging="true" PageSize="20" OnPageIndexChanging="grid_view_PageIndexChanging"
                    CellPadding="10" CellSpacing="5">
                    <Columns>
                        <asp:TemplateField HeaderText="Download File">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="link_download" CommandArgument='<%# Container.DataItemIndex %>' CommandName="file_download" OnCommand="link_download_command" Text="Download"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Set File Downloaded">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="link_setdownloaded" CommandArgument='<%# Container.DataItemIndex %>' CommandName="set_downloaded" OnCommand="link_download_command" Text="Mark as Downloaded"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="link_sendemail" CommandArgument='<%# Container.DataItemIndex %>' CommandName="send_email" OnCommand="link_download_command" OnClientClick="return java_email()" Text="Send Email"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div>
            </div>
        </div>
    </div>


</asp:Content>
