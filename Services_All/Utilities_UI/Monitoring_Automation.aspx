<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Monitoring_Automation.aspx.cs" Inherits="Services_All.Utilities_UI.Monitoring_Automation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Monitoring Automation</h1>

    <div>
        <asp:Label runat="server" Text="Client"></asp:Label>
    </div>
    <div>
        <asp:DropDownList runat="server" ID="ddl_client" AutoPostBack="true" OnSelectedIndexChanged="ddl_client_SelectedIndexChanged"
            DataTextField="Text" DataValueField="Value">
        </asp:DropDownList>
    </div>

    <div>
        <asp:Label runat="server" Text="Products">
        </asp:Label>
    </div>
    <div>
        <asp:DropDownList runat="server" ID="ddl_products" AutoPostBack="true" OnSelectedIndexChanged="ddl_products_SelectedIndexChanged"
            DataTextField="Text" DataValueField="Value">
        </asp:DropDownList>
    </div>

    <div>
        <asp:Label runat="server" Text="Services">
        </asp:Label>
    </div>
    <div>
        <asp:DropDownList runat="server" ID="ddl_services" AutoPostBack="true" OnSelectedIndexChanged="ddl_services_SelectedIndexChanged"
            DataTextField="Text" DataValueField="Value">
        </asp:DropDownList>
    </div>

    <div>
        <asp:Label runat="server" Text="Logs"></asp:Label>
    </div>
    <div>
        <asp:DropDownList runat="server" ID="ddl_logs" AutoPostBack="true"
            DataTextField="Text" DataValueField="Value">
        </asp:DropDownList>
    </div>


    <div>
        <fieldset>
            <legend>Modules</legend>
   <%-- <div>
        <asp:Label runat="server" Text="Select Module"></asp:Label>
    </div>--%>
    <div>
        <asp:DropDownList runat="server" ID="ddl_operations" AutoPostBack="true" OnSelectedIndexChanged="ddl_operations_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="Service">Service</asp:ListItem>
            <asp:ListItem Value="Log">Log</asp:ListItem>
            <asp:ListItem Value="Server">Server</asp:ListItem>
        </asp:DropDownList>
    </div>
            </fieldset>
        </div>

    <div>
        <asp:Panel runat="server" Visible="true" ID="pnl_service">
            <div>
                <fieldset>
                    <legend>Operations</legend>
                    <div>
                        <asp:RadioButtonList runat="server" ID="rdl_servicesoperation">
                            <asp:ListItem Value="start">Start</asp:ListItem>
                            <asp:ListItem Value="stop">Stop</asp:ListItem>
                            <asp:ListItem Value="status">Status</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </fieldset>
            </div>

    <div>
        <asp:Button runat="server" ID="btn_service" Text="Submit" OnClick="btn_service_Click" />
    </div>
    </asp:Panel>
    </div>

    <div>
        <asp:Panel runat="server" Visible="false" ID="pnl_logs">
            <div>
                <fieldset>
                    <legend>Operations</legend>
                    <div>
                        <asp:Label runat="server" Text="Number of lines"></asp:Label>
                        <asp:TextBox runat="server" ID="txt_logs_numberoflines"></asp:TextBox>
                    </div>
                    <div>
                        <asp:RadioButtonList runat="server" ID="rdl_logs">
                            <asp:ListItem Selected="True" Value="head">Head</asp:ListItem>
                            <asp:ListItem Value="tail">Tail</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </fieldset>
            </div>

            <div>
                <asp:Button runat="server" ID="btn_logs" Text="Submit" OnClick="btn_logs_Click" />
            </div>

        </asp:Panel>
    </div>

    <div>
        <asp:Panel runat="server" Visible="false" ID="pnl_server">
            <div>
                <fieldset>
                    <legend>Operations</legend>
                    <div>
                        <asp:RadioButtonList runat="server" ID="rdl_server">
                            <asp:ListItem Selected="True" Value="CPU">CPUUsage</asp:ListItem>
                            <asp:ListItem Value="Memory">MemoryUtilization</asp:ListItem>
                            <asp:ListItem Value="Disk">DiskSpace</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <asp:Button runat="server" ID="btn_server" Text="Submit" OnClick="btn_server_Click" />
                    </div>
                </fieldset>
            </div>
        </asp:Panel>
    </div>


    <div>
        <asp:Panel runat="server" Visible="false" ID="pnl_insert">
            <div>
                <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
            </div>
        </asp:Panel>
    </div>



    <div id="ResultBox">
        <textarea runat="server" id="txt_richbox" style="resize: none; height: 196px; width: 921px; margin: 0px;" readonly="readonly"></textarea>
    </div>
    <div>
        <asp:Label runat="server" ID="lbl_error"></asp:Label>
    </div>



</asp:Content>
