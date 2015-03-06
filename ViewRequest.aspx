<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRequest.aspx.cs" Inherits="Team11.ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Stylesheet" type="text/css" href="Styles/ViewRequest.css"/>  
   
    <script type="text/javascript" language="javascript">
     $(document).ready(function () {

            //Semester
            if ($("#MainContent_RadioButtonListFilterSemester_0").is(":checked")) {
                $("#MainContent_RadioButtonListFilterSemester_0").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListFilterSemester_1").is(":checked")) {
                $("#MainContent_RadioButtonListFilterSemester_1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListFilterSemester_2").is(":checked")) {
                $("#MainContent_RadioButtonListFilterSemester_2").parent().addClass("btn btn-danger");
            };

            //Status
            if ($("#MainContent_RadioButtonListFilterStatus_0").is(":checked")) {
                $("#MainContent_RadioButtonListFilterStatus_0").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListFilterStatus_1").is(":checked")) {
                $("#MainContent_RadioButtonListFilterStatus_1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListFilterStatus_2").is(":checked")) {
                $("#MainContent_RadioButtonListFilterStatus_2").parent().addClass("btn btn-danger");
            };

    });
    </script>


</asp:Content>

<%-- Page Title Content --%>
<asp:Content ID="TitlesContent" runat="server" ContentPlaceHolderID="TitleContent">
    <h1>View Requests</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   

<div id="SearchBar" runat="server">

     <div class="canister">
        <div class="canistertitle">
            <h2>Filter Results</h2>
        </div>
        <div class="canistercontainer">
            <div class="row">
                <div class="text-center center col-md-4 col-sm-4">
                    <h2>Module</h2>
                </div>
                <div class="text-center center col-md-4 col-sm-4">
                    <h2>Semester</h2>
                </div>
                <div class="text-center center col-md-4 col-sm-4">
                    <h2>Status</h2>
                </div>
            </div>
            <div class="row">
                <div class="text-center center col-md-4 col-sm-4">
                    <asp:DropDownList class="form-control" ID="DropDownListFilterModule" runat="server" AutoPostBack="true" onselectedindexchanged="DropDownListFilterModule_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="text-center center col-md-4 col-sm-4">
                    <asp:RadioButtonList class="center" ID="RadioButtonListFilterSemester" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonListFilterSemester_SelectedIndexChanged">
                        <asp:ListItem class="btn btn-primary" Selected="True">All</asp:ListItem>
                        <asp:ListItem class="btn btn-primary">1</asp:ListItem>
                        <asp:ListItem class="btn btn-primary">2</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="text-center center col-md-4 col-sm-4">
                    <asp:RadioButtonList class="center" ID="RadioButtonListFilterStatus" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonListFilterStatus_SelectedIndexChanged">
                        <asp:ListItem class="btn btn-primary" Selected="True">ALL</asp:ListItem>
                        <asp:ListItem class="btn btn-primary">Pending</asp:ListItem>
                        <asp:ListItem class="btn btn-primary">Accepted</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-3 col-sm-3">
                    <h3>Park</h3>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <h3>Building</h3>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <h3>Room</h3>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <h3>Year</h3>
                </div>
            </div>
            <div class="row">
                <div class="text-center col-md-3 col-sm-3">
                     <asp:DropDownList class="form-control" ID="DropDownListFilterPark" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListFilterPark_SelectedIndexChanged">
                        <asp:ListItem Value="0">Any</asp:ListItem>
                        <asp:ListItem Value="1">Central</asp:ListItem>
                        <asp:ListItem Value="2">East</asp:ListItem>
                        <asp:ListItem Value="3">West</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <asp:DropDownList class="form-control" ID="DropDownListFilterBuilding" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListFilterBuilding_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                    <asp:DropDownList class="form-control" ID="DropDownListFilterRooms" runat="server" AutoPostBack="true" onselectedindexchanged="DropDownListFilterRooms_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="text-center col-md-3 col-sm-3">
                   <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" AutoPostBack="true" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem>Please Select a Year To Filter By</asp:ListItem>
                        <asp:ListItem>12/13</asp:ListItem>
                        <asp:ListItem>13/14</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="ButtonRefreshSearch" runat="server" onclick="ButtonRefreshSearch_Click" Text="Search" Visible="False" />
                </div>
            </div>
        </div>
    </div>
        
    
</div>
<div runat="server" id="AllButtons">

<div class="canister">
    <div class="canistertitle">
        <h2>Details / Delete / Copy / Edit</h2>
    </div>
    <div class="canistercontainer">
        <div class="row">
            <div class="center col-md-12 col-sm-12">
                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" EnableViewState="true">
                    <asp:ListItem>Please Choose a Reference</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="center col-md-3 col-sm-3">
                <asp:Button style="margin-top:5px;" class="btn btn-success btn-block" ID="Button1" runat="server" OnClick="Button1_Click" Text="Details" />
            </div>
            <div class="center col-md-3 col-sm-3">
                <asp:Button style="margin-top:5px;" class="btn btn-success btn-block" ID="Button2" runat="server" OnClick="Button2_Click" Text="Edit" />
            </div>
            <div class="center col-md-3 col-sm-3">
                <asp:Button style="margin-top:5px;" class="btn btn-success btn-block" ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
            </div>
             <div class="center col-md-3 col-sm-3">
                 <asp:Button style="margin-top:5px;" class="btn btn-success btn-block" ID="Button4" runat="server" OnClick="Button4_Click" Text="Copy" />
            </div>
        </div>
    </div>
</div>
</br>
    <div id="requestDetails" runat="server" style="height: 191px" visible="false">
        
         <div style="visibility:hidden">
        <asp:Label ID="departmentLabel" runat="server" Text="Label"></asp:Label>
           <asp:Label ID="buildingLabel" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="parkLabel" runat="server" Text="Label"></asp:Label>
        </div>

        <div style="position:absolute; background-color:white; margin-top:-10px;" class="marg canister">
            <div class="canistertitle">
                <h2>Booking Details</h2>
            </div>
            <div class="canistercontainer">
                <div class="row">
                    <div class="center col-md-4 col-sm-4">
                        <h3>Reference Number</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Module Code</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Module Title</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="requestidLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="modulecodeLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="moduletitleLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                 <div class="row">
                    <div class="center col-md-4 col-sm-4">
                        <h3>Day</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Period(s)</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Week(s)</h3>
                    </div>
                </div>
                 <div class="row">
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="dayLabel" runat="server" Text="Label"></asp:Label>
                        </div>
                    <div class="center col-md-4 col-sm-4">
                         <asp:Label ID="periodLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="weeksLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="center col-md-4 col-sm-4">
                        <h3>Booked Rooms</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Alt Rooms</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Facilities Requested</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="bookedroomLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="altroomLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="facilitiesLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="center col-md-4 col-sm-4">
                        <h3>Semester</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Year</h3>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <h3>Status</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="center col-md-4 col-sm-4">
                         <asp:Label ID="semesterLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="yearLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="center col-md-4 col-sm-4">
                        <asp:Label ID="statusLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 col-sm-10 col-md-offset-1 col-sm-offset-1">
                    <asp:Button class="btn btn-success btn-block" ID="ButtonHideDetails" runat="server" OnClick="ButtonHideDetails_Click" Text="Hide" />  
                    </div>
                </div>
            </div>
        </div>

   
   
    </div>
           
            
      
           

    </div>
            <div runat="server" id="ViewTable" style="margin-top: 0px">hello</div>
            
    
    
    
    </asp:Content>
