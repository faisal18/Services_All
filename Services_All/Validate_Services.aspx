<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Validate_Services.aspx.cs" Inherits="Services_All.Valdiate_Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div id="title">
        <h1>Validate Services</h1>
    </div>
    <div id="content">

        <div>
            <asp:Table runat="server" ID="table_divs" CellPadding="5" CellSpacing="10">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_erx" Text="ERX Validate" AutoPostBack="true" OnCheckedChanged="rd_erx_CheckedChanged" Checked="true" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_lmu" Text="LMU Validate" AutoPostBack="true" OnCheckedChanged="rd_lmu_CheckedChanged" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_pbmswitch_dimensions" Text="PBMSwitch Dimensions" AutoPostBack="true" OnCheckedChanged="rd_pbmswitch_dimensions_CheckedChanged" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_dhpo" Text="DHPO Validate" AutoPostBack="true" OnCheckedChanged="rd_dhpo_CheckedChanged" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_ceed_gateway" Text="Ceed Gateway" AutoPostBack="true" OnCheckedChanged="rd_ceed_gateway_CheckedChanged" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_pbmswitch_member" Text="PBMSwitch Member" Enabled="false" AutoPostBack="true" OnCheckedChanged="rd_pbmswitch_member_CheckedChanged" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_clinician" Text="Clinician Validate" AutoPostBack="true" OnCheckedChanged="rd_clinician_CheckedChanged" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_member_registration" Text="Member Registration" AutoPostBack="true" OnCheckedChanged="rd_member_registration_CheckedChanged" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_pbmswitch_payer" Text="PBMSwitch Payer" AutoPostBack="true" OnCheckedChanged="rd_pbmswitch_payer_CheckedChanged" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:RadioButton runat="server" ID="rd_shafafiya" Text="Shafafiya Validate" AutoPostBack="true" OnCheckedChanged="rd_shafafiya_CheckedChanged" />
                    </asp:TableCell>

                </asp:TableRow>
            </asp:Table>
        </div>
        <div>
            <textarea runat="server" id="txt_richbox" style="resize: none; height: 196px; width: 921px; margin: 0px;" readonly="readonly"></textarea>
        </div>
        <div>
            <asp:Button runat="server" ID="submit" Text="Check" OnClick="submit_Click" />
        </div>
        <div>
            <asp:Label runat="server" ID="lbl_response">

            </asp:Label>
        </div>
    </div>


</asp:Content>
