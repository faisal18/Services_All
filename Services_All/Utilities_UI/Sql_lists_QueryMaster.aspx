<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sql_lists_QueryMaster.aspx.cs" Inherits="Services_All.Utilities_UI.Sql_lists_QueryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>SQL QUERY MASTER</h1>
    </div>

    <div>
        <asp:Label runat="server" Text="Select Connection"></asp:Label>
    </div>
    <div>
        <asp:DropDownList runat="server" ID="ddl_Connecion" AutoPostBack="true" OnSelectedIndexChanged="ddl_Connecion_SelectedIndexChanged">
            <asp:ListItem>Select Connection</asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Panel runat="server" ID="pnl_database" Visible="false">
        <div>
            <asp:Label runat="server" Text="Select Database"></asp:Label>
        </div>
        <div>
            <asp:DropDownList runat="server" ID="ddl_databases" AutoPostBack="true" OnSelectedIndexChanged="ddl_databases_SelectedIndexChanged">
                <asp:ListItem>Select Database</asp:ListItem>

            </asp:DropDownList>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_table" Visible="false">
        <div>
            <asp:Label runat="server" Text="Select Table"></asp:Label>
        </div>
        <div>
            <asp:DropDownList runat="server" ID="ddl_tables" AutoPostBack="true" OnSelectedIndexChanged="ddl_tables_SelectedIndexChanged">
                <asp:ListItem>Select Table</asp:ListItem>

            </asp:DropDownList>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_columns" Visible="false">
        <div>
            <asp:Label runat="server" Text="Order by Column"></asp:Label>
        </div>
        <div>
            <asp:DropDownList runat="server" ID="ddl_columns" AutoPostBack="true" OnSelectedIndexChanged="ddl_columns_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </asp:Panel>

    <div>
        <asp:Panel runat="server" ID="pnl_submit" Visible="false">
            <div>
                <asp:Label runat="server" Text="Enter DhabarDhuzz"></asp:Label>
            </div>
            <div>
                <textarea runat="server" id="txt_richbox" style="resize: none; height: 196px; width: 921px; margin: 0px;"></textarea>
            </div>
            <div>
                <asp:Button runat="server" ID="btn_submit" Text="Submit" OnClick="btn_submit_Click" />
            </div>
        </asp:Panel>
    </div>

    <div>
        <asp:Label runat="server" ID="lbl_result"></asp:Label>
    </div>
    <div style="width: 100%; height: 400px; overflow: scroll">
       <%-- <asp:GridView runat="server" ID="grid_view" Width="100%" AutoGenerateColumns="true"
            AllowPaging="true" PageSize="20" OnPageIndexChanging="grid_view_PageIndexChanging"
            CellPadding="10" CellSpacing="5">
        </asp:GridView>--%>
         <asp:GridView runat="server" ID="grid_view" Width="100%" AutoGenerateColumns="true" CellPadding="10" CellSpacing="5">
        </asp:GridView>
    </div>

</asp:Content>
