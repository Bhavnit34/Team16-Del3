<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Availibility.aspx.cs" Inherits="Team11.Availibility" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Stylesheet" type="text/css" href="Styles/CreateRequest.css" />
    <link rel="Stylesheet" type="text/css" href="Styles/Availability.css"/>    
    
    <script type="text/javascript" language="javascript">
         $(document).ready(function () {

            //Ad-Hoc Type
            if ($("#MainContent_RadioButtonListView_0").is(":checked")) {
                $("#MainContent_RadioButtonListView_0").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListView_1").is(":checked")) {
                $("#MainContent_RadioButtonListView_1").parent().addClass("btn btn-danger");
            };

            //Park
            if ($("#MainContent_RadioButtonListPark_0").is(":checked")) {
                $("#MainContent_RadioButtonListPark_0").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListPark_1").is(":checked")) {
                $("#MainContent_RadioButtonListPark_1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListPark_2").is(":checked")) {
                $("#MainContent_RadioButtonListPark_2").parent().addClass("btn btn-danger");
            };

            //Days and Periods 
            if ($("#MainContent_CheckBoxM1").is(":checked")) {
                $("#MainContent_CheckBoxM1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM2").is(":checked")) {
                $("#MainContent_CheckBoxM2").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM3").is(":checked")) {
                $("#MainContent_CheckBoxM3").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM4").is(":checked")) {
                $("#MainContent_CheckBoxM4").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM5").is(":checked")) {
                $("#MainContent_CheckBoxM5").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM6").is(":checked")) {
                $("#MainContent_CheckBoxM6").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM7").is(":checked")) {
                $("#MainContent_CheckBoxM7").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM8").is(":checked")) {
                $("#MainContent_CheckBoxM8").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM9").is(":checked")) {
                $("#MainContent_CheckBoxM9").parent().addClass("btn btn-danger");
            };
            //Tuesday
            if ($("#MainContent_CheckBoxT1").is(":checked")) {
                $("#MainContent_CheckBoxT1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT2").is(":checked")) {
                $("#MainContent_CheckBoxT2").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT3").is(":checked")) {
                $("#MainContent_CheckBoxT3").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT4").is(":checked")) {
                $("#MainContent_CheckBoxT4").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT5").is(":checked")) {
                $("#MainContent_CheckBoxT5").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT6").is(":checked")) {
                $("#MainContent_CheckBoxT6").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT7").is(":checked")) {
                $("#MainContent_CheckBoxT7").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT8").is(":checked")) {
                $("#MainContent_CheckBoxT8").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT9").is(":checked")) {
                $("#MainContent_CheckBoxT9").parent().addClass("btn btn-danger");
            };
            //Wednesday
            if ($("#MainContent_CheckBoxW1").is(":checked")) {
                $("#MainContent_CheckBoxW1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW2").is(":checked")) {
                $("#MainContent_CheckBoxW2").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW3").is(":checked")) {
                $("#MainContent_CheckBoxW3").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW4").is(":checked")) {
                $("#MainContent_CheckBoxW4").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW5").is(":checked")) {
                $("#MainContent_CheckBoxW5").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW6").is(":checked")) {
                $("#MainContent_CheckBoxW6").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW7").is(":checked")) {
                $("#MainContent_CheckBoxW7").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW8").is(":checked")) {
                $("#MainContent_CheckBoxW8").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW9").is(":checked")) {
                $("#MainContent_CheckBoxW9").parent().addClass("btn btn-danger");
            };
            //THURSDAY
            if ($("#MainContent_CheckBoxJ1").is(":checked")) {
                $("#MainContent_CheckBoxJ1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ2").is(":checked")) {
                $("#MainContent_CheckBoxJ2").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ3").is(":checked")) {
                $("#MainContent_CheckBoxJ3").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ4").is(":checked")) {
                $("#MainContent_CheckBoxJ4").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ5").is(":checked")) {
                $("#MainContent_CheckBoxJ5").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ6").is(":checked")) {
                $("#MainContent_CheckBoxJ6").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ7").is(":checked")) {
                $("#MainContent_CheckBoxJ7").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ8").is(":checked")) {
                $("#MainContent_CheckBoxJ8").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ9").is(":checked")) {
                $("#MainContent_CheckBoxJ9").parent().addClass("btn btn-danger");
            };
            //Friday
            if ($("#MainContent_CheckBoxF1").is(":checked")) {
                $("#MainContent_CheckBoxF1").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF2").is(":checked")) {
                $("#MainContent_CheckBoxF2").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF3").is(":checked")) {
                $("#MainContent_CheckBoxF3").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF4").is(":checked")) {
                $("#MainContent_CheckBoxF4").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF5").is(":checked")) {
                $("#MainContent_CheckBoxF5").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF6").is(":checked")) {
                $("#MainContent_CheckBoxF6").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF7").is(":checked")) {
                $("#MainContent_CheckBoxF7").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF8").is(":checked")) {
                $("#MainContent_CheckBoxF8").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF9").is(":checked")) {
                $("#MainContent_CheckBoxF9").parent().addClass("btn btn-danger");
            };
            //Park

            if ($('#MainContent_RadioButtonList1_0').is(":checked")) {
                $('#MainContent_RadioButtonList1_0').parent().addClass("btn btn-danger");
            };
            if ($('#MainContent_RadioButtonList1_1').is(":checked")) {
                $('#MainContent_RadioButtonList1_1').parent().addClass("btn btn-danger");
            };
            if ($('#MainContent_RadioButtonList1_2').is(":checked")) {
                $('#MainContent_RadioButtonList1_2').parent().addClass("btn btn-danger");
            };

            //Days and Periods 
            if ($("#MainContent_CheckBoxM10").is(":checked")) {
                $("#MainContent_CheckBoxM10").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM11").is(":checked")) {
                $("#MainContent_CheckBoxM11").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM12").is(":checked")) {
                $("#MainContent_CheckBoxM12").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM13").is(":checked")) {
                $("#MainContent_CheckBoxM13").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM14").is(":checked")) {
                $("#MainContent_CheckBoxM14").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM15").is(":checked")) {
                $("#MainContent_CheckBoxM15").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM16").is(":checked")) {
                $("#MainContent_CheckBoxM16").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM17").is(":checked")) {
                $("#MainContent_CheckBoxM17").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxM18").is(":checked")) {
                $("#MainContent_CheckBoxM18").parent().addClass("btn btn-danger");
            };
            //Tuesday
            if ($("#MainContent_CheckBoxT10").is(":checked")) {
                $("#MainContent_CheckBoxT10").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT11").is(":checked")) {
                $("#MainContent_CheckBoxT11").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT12").is(":checked")) {
                $("#MainContent_CheckBoxT12").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT13").is(":checked")) {
                $("#MainContent_CheckBoxT13").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT14").is(":checked")) {
                $("#MainContent_CheckBoxT14").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT15").is(":checked")) {
                $("#MainContent_CheckBoxT15").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT16").is(":checked")) {
                $("#MainContent_CheckBoxT16").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT17").is(":checked")) {
                $("#MainContent_CheckBoxT17").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxT18").is(":checked")) {
                $("#MainContent_CheckBoxT18").parent().addClass("btn btn-danger");
            };
            //Wednesday
            if ($("#MainContent_CheckBoxW10").is(":checked")) {
                $("#MainContent_CheckBoxW10").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW11").is(":checked")) {
                $("#MainContent_CheckBoxW11").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW12").is(":checked")) {
                $("#MainContent_CheckBoxW12").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW13").is(":checked")) {
                $("#MainContent_CheckBoxW13").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW14").is(":checked")) {
                $("#MainContent_CheckBoxW14").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW15").is(":checked")) {
                $("#MainContent_CheckBoxW15").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW16").is(":checked")) {
                $("#MainContent_CheckBoxW16").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW17").is(":checked")) {
                $("#MainContent_CheckBoxW17").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxW18").is(":checked")) {
                $("#MainContent_CheckBoxW18").parent().addClass("btn btn-danger");
            };
            //THURSDAY
            if ($("#MainContent_CheckBoxJ10").is(":checked")) {
                $("#MainContent_CheckBoxJ10").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ11").is(":checked")) {
                $("#MainContent_CheckBoxJ11").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ12").is(":checked")) {
                $("#MainContent_CheckBoxJ12").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ13").is(":checked")) {
                $("#MainContent_CheckBoxJ13").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ14").is(":checked")) {
                $("#MainContent_CheckBoxJ14").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ15").is(":checked")) {
                $("#MainContent_CheckBoxJ15").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ16").is(":checked")) {
                $("#MainContent_CheckBoxJ16").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ17").is(":checked")) {
                $("#MainContent_CheckBoxJ17").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxJ18").is(":checked")) {
                $("#MainContent_CheckBoxJ18").parent().addClass("btn btn-danger");
            };
            //fRIDAY
            if ($("#MainContent_CheckBoxF10").is(":checked")) {
                $("#MainContent_CheckBoxF10").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF11").is(":checked")) {
                $("#MainContent_CheckBoxF11").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF12").is(":checked")) {
                $("#MainContent_CheckBoxF12").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF13").is(":checked")) {
                $("#MainContent_CheckBoxF13").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF14").is(":checked")) {
                $("#MainContent_CheckBoxF14").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF15").is(":checked")) {
                $("#MainContent_CheckBoxF15").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF16").is(":checked")) {
                $("#MainContent_CheckBoxF16").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF17").is(":checked")) {
                $("#MainContent_CheckBoxF17").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxF18").is(":checked")) {
                $("#MainContent_CheckBoxF18").parent().addClass("btn btn-danger");
            };


        });
    </script>


</asp:Content>

<%-- Page Title Content --%>
<asp:Content ID="TitlesContent" runat="server" ContentPlaceHolderID="TitleContent">
    <h1>Ad-Hoc</h1>
</asp:Content>

<%-- Body Content --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="canister none">
        <div class="canistertitle none">
            <h2>Ad-Hoc by Room / Date</h2>
        </div>
        <div class="canistercontainer none">
            <div class="row">
                <div class="text-center col-md-12 col-sm-12 none">
                    <asp:RadioButtonList class="center none" ID="RadioButtonListView" runat="server" AutoPostBack="true" onselectedindexchanged="RadioButtonListView_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem class="none btn btn-primary">By Room</asp:ListItem>
                        <asp:ListItem class="none btn btn-primary">By Date</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div><!-- ./row -->
    </div><!-- ./canister -->

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ParkConnectionString %>" 
        SelectCommand="SELECT [parkName] FROM [Park]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:myConnectionString %>" 
        SelectCommand="SELECT [moduleTitle] FROM [Module]"></asp:SqlDataSource>
    
    <!-- BY ROOM -->
    <div id="divByRoom" runat="server" visible="false">

        <div class="canister">
            <div class="canistertitle">
                <h2>Room Selection</h2>
            </div>
            <div class="canistercontainer">
                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Park</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Building</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Room</h3>
                    </div>
                </div><!-- ./row -->

                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:RadioButtonList class="center" ID="RadioButtonListPark" runat="server" AutoPostBack="true" onselectedindexchanged="RadioButtonListPark_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem class="btn btn-primary">Central</asp:ListItem>
                            <asp:ListItem class="btn btn-primary">East</asp:ListItem>
                            <asp:ListItem class="btn btn-primary">West</asp:ListItem>
                    </asp:RadioButtonList>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:DropDownList class="form-control" ID="DropDownListBuilding" runat="server" AutoPostBack="true" onselectedindexchanged="DropDownListBuilding_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:DropDownList class="form-control" ID="DropDownListRooms" runat="server" AutoPostBack="true" onselectedindexchanged="DropDownListRooms_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div><!-- ./row -->

                <div class="row">
                    <div class="text-center center col-md-12 col-sm-12">
                        <h3>Week</h3>
                    </div>
                </div>

                <div class="row">
                    <div class="text-center center col-md-12 col-sm-12">
                         <asp:DropDownList class="form-control" ID="DropDownListWeekNumber" runat="server" AutoPostBack="true" onselectedindexchanged="DropDownListWeekNumber_SelectedIndexChanged">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div><!-- ./canistercontainer -->
        </div><!-- ./canister -->

        
       


            <div class="canister">
                <div class="canistertitle">
                    <h2>Day and Period Selection</h2>
                </div>
                <div class="canistercontainer">
                    <div class="row">
                        <div class="text-center center col-md-12 col-sm-12">
                            <table width="800px" height="180px" class="center">
                                <tr>
                                    <td>
                                        <asp:Button class="btn btn-warning btn-block" ID="ButtonClearPeriods" runat="server" onclick="ButtonClearPeriods_Click" Text="Clear Periods" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod1" runat="server" onclick="ButtonPeriod1_Click" Text="Period 1" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod2" runat="server" onclick="ButtonPeriod2_Click" Text="Period 2" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod3" runat="server" onclick="ButtonPeriod3_Click" Text="Period 3" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod4" runat="server" onclick="ButtonPeriod4_Click" Text="Period 4" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod5" runat="server" onclick="ButtonPeriod5_Click" Text="Period 5" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod6" runat="server" onclick="ButtonPeriod6_Click" Text="Period 6" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod7" runat="server" onclick="ButtonPeriod7_Click" Text="Period 7" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod8" runat="server" onclick="ButtonPeriod8_Click" Text="Period 8" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod9" runat="server" onclick="ButtonPeriod9_Click" Text="Period 9" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button style="height:40px;" class="btn btn-success btn-block" ID="ButtonMonday" runat="server" onclick="ButtonMonday_Click" Text="Monday" />
                                    </td>
                                    <td>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM1" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button  class="fullheight btn btn-info btn-block" ID="LabelM1" runat="server" Text="Label" Visible="False" onclick="LabelM1_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:Button  class="fullheight btn btn-info btn-block" ID="LabelM2" runat="server" Text="Label" Visible="False" onclick="LabelM2_Click"></asp:Button>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM2" Text="x" runat="server"  autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM3" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button  class="fullheight btn btn-info btn-block" ID="LabelM3" runat="server" Text="Label" Visible="False" onclick="LabelM3_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM4" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button  class="btn btn-info btn-block" ID="LabelM4" runat="server" Text="Label" Visible="False" onclick="LabelM4_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM5" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button  class="btn btn-info btn-block" ID="LabelM5" runat="server" Text="Label" Visible="False" onclick="LabelM5_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM6" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button  class="btn btn-info btn-block" ID="LabelM6" runat="server" Text="Label" Visible="False" onclick="LabelM6_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM7" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button  class="btn btn-info btn-block" ID="LabelM7" runat="server" Text="Label" Visible="False" onclick="LabelM7_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox  class="btn btn-primary btn-block" ID="CheckBoxM8" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button  class="btn btn-info btn-block" ID="LabelM8" runat="server" Text="Label" Visible="False" onclick="LabelM8_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxM9" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelM9" runat="server" Text="Label" Visible="False" onclick="LabelM9_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button style="height:40px;" class="btn btn-success btn-block" ID="ButtonTuesday" runat="server" onclick="ButtonTuesday_Click" Text="Tuesday" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT1" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT1" runat="server" Text="Label" Visible="False" onclick="LabelT1_Click" ></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT2" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT2" runat="server" Text="Label" Visible="False" onclick="LabelT2_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT3" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT3" runat="server" Text="Label" Visible="False" onclick="LabelT3_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT4" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT4" runat="server" Text="Label" Visible="False" onclick="LabelT4_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT5" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT5" runat="server" Text="Label" Visible="False" onclick="LabelT5_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT6" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT6" runat="server" Text="Label" Visible="False" onclick="LabelT6_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT7" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT7" runat="server" Text="Label" Visible="False" onclick="LabelT7_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT8" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT8" runat="server" Text="Label" Visible="False" onclick="LabelT8_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxT9" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelT9" runat="server" Text="Label" Visible="False" onclick="LabelT9_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button style="height:40px;" class="btn btn-success btn-block" ID="ButtonWednesday" runat="server" onclick="ButtonWednesday_Click" Text="Wednesday" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW1" runat="server" Text="Label" Visible="False" onclick="LabelW1_Click"></asp:Button>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW1" Text="x" runat="server"  autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW2" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW2" runat="server" Text="Label" Visible="False" onclick="LabelW2_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW3" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW3" runat="server" Text="Label" Visible="False" onclick="LabelW3_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW4" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW4" runat="server" Text="Label" Visible="False" onclick="LabelW4_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW5" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW5" runat="server" Text="Label" Visible="False" onclick="LabelW5_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW6" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW6" runat="server" Text="Label" Visible="False" onclick="LabelW6_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW7" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW7" runat="server" Text="Label" Visible="False" onclick="LabelW7_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW8" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW8" runat="server" Text="Label" Visible="False" onclick="LabelW8_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxW9" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelW9" runat="server" Text="Label" Visible="False" onclick="LabelW9_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button style="height:40px;" class="btn btn-success btn-block" ID="ButtonThursday" runat="server" onclick="ButtonThursday_Click" Text="Thursday" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ1" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ1" runat="server" Text="Label" Visible="False" onclick="LabelJ1_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ2" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ2" runat="server" Text="Label" Visible="False" onclick="LabelJ2_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ3" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ3" runat="server" Text="Label" Visible="False" onclick="LabelJ3_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ4" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ4" runat="server" Text="Label" Visible="False" onclick="LabelJ4_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ5" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ5" runat="server" Text="Label" Visible="False" onclick="LabelJ5_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ6" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ6" runat="server" Text="Label" Visible="False" onclick="LabelJ6_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ7" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ7" runat="server" Text="Label" Visible="False" onclick="LabelJ7_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ8" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ8" runat="server" Text="Label" Visible="False" onclick="LabelJ8_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxJ9" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelJ9" runat="server" Text="Label" Visible="False" onclick="LabelJ9_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button style="height:40px;" class="btn btn-success btn-block" ID="ButtonFriday" runat="server" onclick="ButtonFriday_Click" Text="Friday" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF1" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF1" runat="server" Text="Label" Visible="False" onclick="LabelF1_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF2" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF2" runat="server" Text="Label" Visible="False" onclick="LabelF2_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF3" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF3" runat="server" Text="Label" Visible="False" onclick="LabelF3_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF4" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF4" runat="server" Text="Label" Visible="False" onclick="LabelF4_Click" style="height: 26px"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF5" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF5" runat="server" Text="Label" Visible="False" onclick="LabelF5_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF6" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF6" runat="server" Text="Label" Visible="False" onclick="LabelF6_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF7" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF7" runat="server" Text="Label" Visible="False" onclick="LabelF7_Click" style="width: 47px"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF8" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF8" runat="server" Text="Label" Visible="False" onclick="LabelF8_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" ID="CheckBoxF9" Text="x" runat="server"  autopostback="true" />
                                        <asp:Button class="btn btn-info btn-block" ID="LabelF9" runat="server" Text="Label" Visible="False" onclick="LabelF9_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="10">
                                        <asp:Button style="margin-top:5px;" class="btn btn-success btn-block" ID="ButtonBookByRoom" runat="server" Text="Book" onclick="ButtonBookByRoom_Click" />
                                    </td>
                                    
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div><!-- ./canister -->
                
            
        <br />
        <br />
        
        
        
        <div id="requestDetails" runat="server" style="height: 191px" visible="false">
        
        <div class="canister">
            <div class="canistertitle">
                <h2>Details</h2>
            </div>
            <div class="canistercontainer details">
                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Reference</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Department</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Module Code</h3>
                    </div>
                   
                </div><!-- ./row -->
                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="requestidLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="departmentLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="modulecodeLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    
                </div><!-- ./row -->
                <div class="row">
                     <div class="text-center center col-md-4 col-sm-4">
                        <h3>Module Title</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Semester</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Year</h3>
                    </div>
                </div>
                <div class="row">
                     <div class="text-center center col-md-4 col-sm-4">
                       <asp:Label ID="moduletitleLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="semesterLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="yearLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Day</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Period</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Week(s)</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="dayLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="periodLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="weeksLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Park</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Building</h3>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <h3>Room</h3>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="text-center center col-md-4 col-sm-4">
                         <asp:Label ID="parkLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="buildingLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="text-center center col-md-4 col-sm-4">
                        <asp:Label ID="bookedroomLabel" runat="server" Text="Label"></asp:Label>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                            <asp:Button style="margin-top:10px;" class="btn btn-block btn-success" ID="ButtonHideDetails" runat="server" OnClick="ButtonHideDetails_Click" Text="Hide" />
                    </div>
                    
                </div>
                </div><!-- ./canister -->
            </div><!-- ./canistercontainer -->
        </div>

    
    <div style="display:none">
        <asp:Label ID="altroomLabel" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="facilitiesLabel" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="statusLabel" runat="server" Text="Label"></asp:Label>
   </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </div><!-- ./Adhoc by room -->



        
        
                <div ID="divBookingByRoom" runat="server" visible="false">

                <div style="margin-top:-200px;" class="canister">
                    <div class="canistertitle">
                        <h2>Booking</h2>
                    </div>
                    <div class="canistercontainer">
                        <div class="row">
                            <div class="text-center center col-md-3 col-sm-3">
                                <h3>Module</h3>
                            </div>
                            <div class="text-center center col-md-3 col-sm-3">
                                <h3>Day(s) and Period(s)</h3>
                            </div>
                            <div class="text-center center col-md-3 col-sm-3">
                                <h3>Week</h3>
                            </div>
                            <div class="text-center center col-md-3 col-sm-3">
                                <h3>Room</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="text-center center col-md-3 col-sm-3">
                                <asp:DropDownList class="form-control" ID="DropDownListModuleByRoom" runat="server" DataSourceID="SqlDataSource2" DataTextField="moduleTitle" DataValueField="moduleTitle">
                                </asp:DropDownList>
                            </div>
                            <div class="text-center center col-md-3 col-sm-3">
                                <asp:Label ID="LabelPeriod" runat="server"></asp:Label>
                            </div>
                            <div class="text-center center col-md-3 col-sm-3">
                                <asp:Label ID="LabelWeek" runat="server" Text="Label"></asp:Label>
                            </div>
                            <div class="text-center center col-md-3 col-sm-3">
                                <asp:Label ID="LabelRoom" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="center col-md-6 col-sm-6">
                                <asp:Button style="margin-top:10px;" class="btn btn-success btn-block" ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="Confirm" />
                            </div>
                            <div class="col-md-6 col-sm-6">
                            <asp:Button style="margin-top:10px;" class="btn btn-warning btn-block" ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
                                    
                            </div>
                            <asp:Label ID="LabelError" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                   
                    
                </div>
           
                
      
    
    <!-- BY Date -->
    
    <div id="divByDate" runat="server" visible="false">
        
        <div class="canister">
            <div class="canistertitle">
                <h2>Ad-Hoc by Date</h2>
            </div>
            <div class="canistercontainer">
                <div class="row">
                    <div class="text-center center col-md-12 col-sm-12">
                        <h3>Week Required</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center center col-md-12 col-sm-12">
                        <asp:DropDownList class="form-control" ID="DropDownListWeeks" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div><!-- ./row -->
                <div class="row">
                    <div class="col-md-12 col-sm-12 text-center center">
                        
                                <table width="700px" class="center" style="margin-top:10px;">
                                    <tr>
                                        <td>
                                            <asp:Button class="btn btn-warning btn-block" ID="ButtonClearPeriods0" runat="server" onclick="ButtonClearPeriods_Click1" Text="Clear Periods" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod10" runat="server" onclick="ButtonPeriod1_Click1" Text="Period 1" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod11" runat="server" onclick="ButtonPeriod2_Click1" Text="Period 2" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod12" runat="server" onclick="ButtonPeriod3_Click1" Text="Period 3" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod13" runat="server" onclick="ButtonPeriod4_Click1" Text="Period 4" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod14" runat="server" onclick="ButtonPeriod5_Click1" Text="Period 5" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod15" runat="server" onclick="ButtonPeriod6_Click1" Text="Period 6" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod16" runat="server" onclick="ButtonPeriod7_Click1" Text="Period 7" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod17" runat="server" onclick="ButtonPeriod8_Click1" Text="Period 8" />
                                        </td>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonPeriod18" runat="server" onclick="ButtonPeriod9_Click1" Text="Period 9" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonMonday0" runat="server" onclick="ButtonMonday_Click1" Text="Monday" />
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM10" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM11" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM12" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM13" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM14" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM15" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM16" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM17" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxM18" runat="server" autopostback="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonTuesday0" runat="server" onclick="ButtonTuesday_Click1" Text="Tuesday" />
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT10" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT11" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT12" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT13" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT14" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT15" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT16" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT17" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxT18" runat="server" autopostback="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonWednesday0" runat="server" onclick="ButtonWednesday_Click1" Text="Wednesday" />
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW10" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW11" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW12" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW13" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW14" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW15" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW16" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW17" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxW18" runat="server" autopostback="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonThursday0" runat="server" onclick="ButtonThursday_Click1" Text="Thursday" />
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ10" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ11" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ12" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ13" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ14" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ15" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ16" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ17" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxJ18" runat="server" autopostback="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button class="btn btn-success btn-block" ID="ButtonFriday0" runat="server" onclick="ButtonFriday_Click1" Text="Friday" />
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF10" runat="server" autopostback="true" />
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF11" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF12" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF13" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF14" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF15" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF16" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF17" runat="server" autopostback="true"/>
                                        </td>
                                        <td>
                                            <asp:CheckBox class="btn btn-primary btn-block" Text="x" ID="CheckBoxF18" runat="server" autopostback="true"/>
                                        </td>
                                    </tr>
                                </table>
                           
                    </div>
                </div>
                <div class="row">
                    <div class="text-center center col-md-6 col-sm-6">
                        <asp:Button class="btn btn-success btn-block" style="margin-top:10px;" ID="ButtonFindRooms" runat="server" Text="Find Rooms" onclick="ButtonFindRooms_Click" />
                    </div>
                    <div class="text-center center col-md-6 col-sm-6">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                    <asp:DropDownList class="form-control" style="margin-top:10px;" ID="DropDownListRoomsByDate" runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center center col-md-12 col-sm-12">
                        <asp:DropDownList style="margin-top:10px;" class="form-control" ID="DropDownListModulesByDate" runat="server" DataSourceID="SqlDataSource2" DataTextField="moduleTitle" DataValueField="moduleTitle">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="text-center center col-md-12 col-sm-12">
                        <asp:Button style="margin-top:10px;" class="btn btn-success btn-block" ID="BookByDate" runat="server" Text="Book" onclick="ButtonBookByDate_Click" />
                    </div>
                </div>


            </div>
        </div>
        
        
           
        <br />
        
        <br />
        <br />
        
        <br />
        
        <br />
        
        <br />
    </div>
</asp:Content>
