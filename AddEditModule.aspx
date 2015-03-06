<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditModule.aspx.cs" Inherits="Team11.AddEditModule" %>

<%-- Header Content --%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Stylesheet" type="text/css" href="Styles/AddEditModule.css" />
</asp:Content>

<%-- Page Title Content --%>
<asp:Content ID="TitlesContent" runat="server" ContentPlaceHolderID="TitleContent">
    <h1>Module Management</h1>
</asp:Content>

<%-- Body Content --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Add Module -->
        <div class="canister">
            <div class="canistertitle">
                <h2>Add Module</h2>
            </div>
            <div class="canistercontainer">
                <div class="row">
                    <div class="text-center col-md-4 col-sm-4">
                        <h3 class="minustopmarg">Module Title</h3>
                    </div>
                    <div class="text-center col-md-8 col-sm-8">
                        <asp:TextBox class="form-control" ID="TextBoxModuleName" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="text-center col-md-4 col-sm-4">
                        <h3 class="minustopmarg">Module Code</h3>
                    </div>
                    <div class="text-center col-md-8 col-sm-8">
                        <asp:TextBox class="form-control" ID="TextBoxModuleCode" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center col-md-4 col-sm-4 col-md-offset-2 col-sm-offset-2">
                        <asp:Button class="btn btn-success btn-block full" ID="Button1" runat="server" onclick="Button1_Click" Text="Add" Width="96px" />
                    </div>
                    <div class="text-center col-md-4 col-sm-4">
                        <button class="btn btn-success btn-block">Clear All</button>
                    </div>
                    <asp:Label ID="LabelResponse" runat="server" Text=""></asp:Label>
                </div>
            </div><!-- ./canistercontainer -->
        </div><!-- ./canister -->

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:myConnectionString %>" 
        DeleteCommand="DELETE FROM [Module] WHERE [moduleID] = @moduleID" 
        InsertCommand="INSERT INTO [Module] ([moduleCode], [moduleTitle]) VALUES (@moduleCode, @moduleTitle)" 
        SelectCommand="SELECT [moduleCode], [moduleTitle], [moduleID] FROM [Module] WHERE ([userID] = @userID)" 
        
        UpdateCommand="UPDATE [Module] SET [moduleCode] = @moduleCode, [moduleTitle] = @moduleTitle WHERE [moduleID] = @moduleID">
            <DeleteParameters>
                <asp:Parameter Name="moduleID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="moduleCode" Type="String" />
                <asp:Parameter Name="moduleTitle" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="userID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="moduleCode" Type="String" />
                <asp:Parameter Name="moduleTitle" Type="String" />
                <asp:Parameter Name="moduleID" Type="Int32" />
            </UpdateParameters>
    </asp:SqlDataSource>
    </br>
    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="moduleID" 
        DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" 
        Width="927px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="moduleCode" HeaderText="moduleCode" 
                SortExpression="moduleCode" />
            <asp:BoundField DataField="moduleTitle" HeaderText="moduleTitle" 
                SortExpression="moduleTitle" />
            <asp:BoundField DataField="moduleID" HeaderText="moduleID" 
                InsertVisible="False" ReadOnly="True" SortExpression="moduleID" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#CC0066" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

        </br>

    <div class="tablecontainer">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:myConnectionString %>" 
        InsertCommand="INSERT INTO [Module] ([moduleCode], [moduleTitle]) VALUES (@moduleCode, @moduleTitle)" 
        
            SelectCommand="SELECT [moduleCode], [moduleTitle] FROM [Module] WHERE ([userID] = @userID)">
        <InsertParameters>
            <asp:Parameter Name="moduleCode" Type="String" />
            <asp:Parameter Name="moduleTitle" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="userID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    </div>
</asp:Content>
