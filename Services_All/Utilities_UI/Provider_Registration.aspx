<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Provider_Registration.aspx.cs" Inherits="Services_All.Utilities_UI.Provider_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Provider Registration</h1>
    </div>
    <div>
        <asp:RadioButton runat="server" ID="rd_registerprovider" Text="Register Provider" AutoPostBack="true" Checked="true" OnCheckedChanged="rd_registerprovider_CheckedChanged" />
    </div>
    <div>
        <asp:RadioButton runat="server" ID="rd_editprovider" Text="Edit Provider" AutoPostBack="true" OnCheckedChanged="rd_editprovider_CheckedChanged" />
    </div>
    <div>
        <asp:RadioButton runat="server" ID="rd_editprovidertype" Text="Edit Provider Type" AutoPostBack="true" OnCheckedChanged="rd_editprovidertype_CheckedChanged" />
    </div>
    <div>
        <asp:RadioButton runat ="server" ID="rd_editproviderlicense" Text="Edit Provider License" AutoPostBack="true" OnCheckedChanged="rd_editproviderlicense_CheckedChanged" />
    </div>

    <asp:Panel runat="server" ID="pnl_registerprovider" Visible="true">
        <div>
            <div>
                <asp:Label runat="server" ID="lbl_pbmnpicode" Text="PBM NPI Code"></asp:Label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_pbmnpicode"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" ID="lbl_providername" Text="Provider Name"></asp:Label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_providername"></asp:TextBox>
            </div>
            <div runat="server" id="div_old_license" style="display: none;">
                <div>
                <asp:Label runat="server" ID="lbl_old_license" Text="Old License ID"></asp:Label>
                    </div>
                <div>
                    <asp:TextBox runat="server" ID="txt_old_license"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Label runat="server" ID="lbl_licenseid" Text="License ID"></asp:Label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_licenseid"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" ID="lbl_haadusername" Text="Haad Username"></asp:Label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_haadusername"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" ID="lbl_haadpassword" Text="Haad Password"></asp:Label>
            </div>
            <div>
                <asp:TextBox runat="server" ID="txt_haadpassword"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" ID="lbl_region" Text="Region"></asp:Label>
            </div>
            <div>
                <asp:DropDownList runat="server" ID="ddl_region">
                    <asp:ListItem Value="1">Abu Dhabi</asp:ListItem>
                    <asp:ListItem Value="2">Dubai</asp:ListItem>
                    <asp:ListItem Value="3">Northern Emirates</asp:ListItem>
                    <asp:ListItem Value="4">Bahrain</asp:ListItem>
                    <asp:ListItem Value="5">Oman</asp:ListItem>
                    <asp:ListItem Value="6">KSA</asp:ListItem>
                    <asp:ListItem Value="7">Qatar</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div runat="server" id="div_region" style="display: none;">
                <div>
                    <asp:Label runat="server" ID="lbl_status" Text="isActive"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="ddl_isactive">
                        <asp:ListItem Value="True">True</asp:ListItem>
                        <asp:ListItem Value="False">False</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_editprovidertype" Visible="false">
        <div>
            <asp:Label runat="server" ID="pnl2_lbl_licenseid" Text="License ID"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="pnl2_txt_licenseid"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="pnl2_lbl_switchtype" Text="Switch Type"></asp:Label>
        </div>
        <div>
            <asp:DropDownList runat="server" ID="pnl2_ddl_switchtype">
                <asp:ListItem Value="2">Integrated</asp:ListItem>
                <asp:ListItem Value="1">Non-Integrated</asp:ListItem>
            </asp:DropDownList>
        </div>
    </asp:Panel>

    <div>
        <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
    </div>

    <div>
        <textarea runat="server" id="txt_richbox" style="resize: none; height: 196px; width: 921px; margin: 0px;" readonly="readonly"></textarea>
    </div>

</asp:Content>
