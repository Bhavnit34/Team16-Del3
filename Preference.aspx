<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preference.aspx.cs" Inherits="Team11.Preference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <!-- Preference CSS -->
    <link rel="Stylesheet" type="text/css" href="Styles/Preference.css" />

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            //Loading Page
            if ($("#MainContent_create").is(":checked")) {
                $("#MainContent_create").parent().addClass("btn btn-danger");
            };
            
        };
        </script>
</asp:Content>

<%-- Page Title Content --%>
<asp:Content ID="TitlesContent" runat="server" ContentPlaceHolderID="TitleContent">
    <h1>Preferences</h1>
</asp:Content>


<%-- Body Content --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="canister">
        <div class="canistertitle">
            <h2>System Preferences</h2>
        </div>
        <div class="canistercontainer">
            <div class="row">
                <div class="text-center col-md-4 col-sm-4">
                    <h3>Default Loading Page</h3>
                </div>
                <div class="text-center col-md-8 col-sm-8">
                    <asp:RadioButton class="btn btn-primary" ID="create" runat="server" GroupName="page" Text="Create Request" />
                    <asp:RadioButton class="btn btn-primary" ID="view" runat="server" GroupName="page" Text="View Request"  />
                    <asp:RadioButton class="btn btn-primary" ID="adhoc" runat="server" GroupName="page" Text="Ad-Hoc" />
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-4 col-sm-4">
                    <h3>Default Location</h3>
                </div>
                <div class="text-center col-md-8 col-sm-8">
                    
                    <asp:RadioButton class="btn btn-primary" ID="any" runat="server" GroupName="park" Text="Any" />
                    <asp:RadioButton class="btn btn-primary" ID="central" runat="server" GroupName="park" Text="Central Park" />
                    <asp:RadioButton class="btn btn-primary" ID="west" runat="server" GroupName="park" Text="West Park" />
                    <asp:RadioButton class="btn btn-primary" ID="east" runat="server" GroupName="park" Text="East Park" />
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-4 col-sm-4">
                    <h3>Default Time Format</h3>
                </div>
                <div class="text-center col-md-8 col-sm-8">
                    <asp:RadioButton class="btn btn-primary" ID="hr24" runat="server" GroupName="time" Text="24 Hour Format" />
                    <asp:RadioButton class="btn btn-primary" ID="hr12" runat="server" GroupName="time" Text="12 Hour Format" />
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-4 col-sm-4">
                    <h3>Periods or Times</h3>
                </div>
                <div class="text-center col-md-8 col-sm-8">
                    <asp:RadioButton class="btn btn-primary" ID="period" runat="server" GroupName="period" Text="Periods and Duration" />
                    <asp:RadioButton class="btn btn-primary" ID="time" runat="server" GroupName="period" Text="Start and End Time" />
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-6 col-sm-6">
                    <h3>Header 1</h3>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <asp:DropDownList class="form-control" ID="header1" runat="server" >
                        <asp:ListItem Value="facilities">Facilities</asp:ListItem>
                        <asp:ListItem Value="park">Park</asp:ListItem>
                        <asp:ListItem Value="altrooms">Alt Rooms</asp:ListItem>
                        <asp:ListItem Value="building">Building</asp:ListItem>
                        <asp:ListItem Value="semester">Semester</asp:ListItem>
                        <asp:ListItem Value="year">Year</asp:ListItem>
                        <asp:ListItem Value="numberstudents">No. Students</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-6 col-sm-6">
                    <h3>Header 2</h3>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <asp:DropDownList class="form-control" ID="header2" runat="server" >
                        <asp:ListItem Value="facilities">Facilities</asp:ListItem>
                        <asp:ListItem Value="park">Park</asp:ListItem>
                        <asp:ListItem Value="altrooms">Alt Rooms</asp:ListItem>
                        <asp:ListItem Value="building">Building</asp:ListItem>
                        <asp:ListItem Value="semester">Semester</asp:ListItem>
                        <asp:ListItem Value="year">Year</asp:ListItem>
                        <asp:ListItem Value="numberstudents">No. Students</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-6 col-sm-6">
                    <h3>Header 3</h3>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <asp:DropDownList class="form-control" ID="header3" runat="server" >
                        <asp:ListItem Value="facilities">Facilities</asp:ListItem>
                        <asp:ListItem Value="park">Park</asp:ListItem>
                        <asp:ListItem Value="altrooms">Alt Rooms</asp:ListItem>
                        <asp:ListItem Value="building">Building</asp:ListItem>
                        <asp:ListItem Value="semester">Semester</asp:ListItem>
                        <asp:ListItem Value="year">Year</asp:ListItem>
                        <asp:ListItem Value="numberstudents">No. Students</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-6 col-sm-6 col-md-offset-3 col-sm-offset-3">
                    <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" onclick="Button1_Click" Text="Save" />
                </div>
            </div>
        </div><!-- ./canistercontainer -->
    </div><!-- ./canister -->
   

    
   
   
   
</asp:Content>
