<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRequest.aspx.cs" Inherits="Team11.CreateRequest" MaintainScrollPositionOnPostback = "true"%>

<%-- Create Request Header Content --%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            //Room Type
            if ($("#MainContent_RadioButtonListRoomType_0").is(":checked")) {
                $("#MainContent_RadioButtonListRoomType_0").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_RadioButtonListRoomType_1").is(":checked")) {
                $("#MainContent_RadioButtonListRoomType_1").parent().addClass("btn btn-danger");
            };

            //Arrangement
            if ($('#MainContent_RadioButtonListArrangement_0').is(":checked")) {
                $('#MainContent_RadioButtonListArrangement_0').parent().addClass("btn btn-danger");
            };
            if ($('#MainContent_RadioButtonListArrangement_1').is(":checked")) {
                $('#MainContent_RadioButtonListArrangement_1').parent().addClass("btn btn-danger");
            };

            //Wheelchair Access
            if ($('#MainContent_RadioButtonListWheelchair_0').is(":checked")) {
                $('#MainContent_RadioButtonListWheelchair_0').parent().addClass("btn btn-danger");
            };
            if ($('#MainContent_RadioButtonListWheelchair_1').is(":checked")) {
                $('#MainContent_RadioButtonListWheelchair_1').parent().addClass("btn btn-danger");
            };

            //Board Type
            if ($("#MainContent_CheckBoxWB").is(":checked")) {
                $("#MainContent_CheckBoxWB").parent().addClass("btn btn-danger");
            };
            if ($("#MainContent_CheckBoxCB").is(":checked")) {
                $("#MainContent_CheckBoxCB").parent().addClass("btn btn-danger");
            };

            //Data Projectors
            if ($('#MainContent_RadioButtonListProjector_0').is(":checked")) {
                $('#MainContent_RadioButtonListProjector_0').parent().addClass("btn btn-danger");
            };
            if ($('#MainContent_RadioButtonListProjector_1').is(":checked")) {
                $('#MainContent_RadioButtonListProjector_1').parent().addClass("btn btn-danger");
            };
            //Visualiser
            if ($('#MainContent_RadioButtonListVisualiser_0').is(":checked")) {
                $('#MainContent_RadioButtonListVisualiser_0').parent().addClass("btn btn-danger");
            };
            if ($('#MainContent_RadioButtonListVisualiser_1').is(":checked")) {
                $('#MainContent_RadioButtonListVisualiser_1').parent().addClass("btn btn-danger");
            };
            //Fixed Computer
            if ($('#MainContent_RadioButtonListComputer_0').is(":checked")) {
                $('#MainContent_RadioButtonListComputer_0').parent().addClass("btn btn-danger");
            };
            if ($('#MainContent_RadioButtonListComputer_1').is(":checked")) {
                $('#MainContent_RadioButtonListComputer_1').parent().addClass("btn btn-danger");
            };

            //Weeks
            if ($("#MainContent_Week1").is(":checked")) {
                $("#MainContent_Week1").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week2").is(":checked")) {
                $("#MainContent_Week2").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week3").is(":checked")) {
                $("#MainContent_Week3").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week4").is(":checked")) {
                $("#MainContent_Week4").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week5").is(":checked")) {
                $("#MainContent_Week5").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week6").is(":checked")) {
                $("#MainContent_Week6").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week7").is(":checked")) {
                $("#MainContent_Week7").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week8").is(":checked")) {
                $("#MainContent_Week8").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week9").is(":checked")) {
                $("#MainContent_Week9").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week10").is(":checked")) {
                $("#MainContent_Week10").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week11").is(":checked")) {
                $("#MainContent_Week11").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week12").is(":checked")) {
                $("#MainContent_Week12").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week13").is(":checked")) {
                $("#MainContent_Week13").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week14").is(":checked")) {
                $("#MainContent_Week14").parent().addClass("btn btn-danger");
            }
            if ($("#MainContent_Week15").is(":checked")) {
                $("#MainContent_Week15").parent().addClass("btn btn-danger");
            }

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

            //Semester
            if ($("#MainContent_RadioButtonListSemester_1").is(":checked")) {
                $("#MainContent_RadioButtonListSemester_1").parent().addClass("btn btn-danger");
            };


        });
                
    </script>
    <!-- Create Request CSS -->
    <link rel="Stylesheet" type="text/css" href="Styles/CreateRequest.css" />
  
</asp:Content>

<%-- Page Title Content --%>
<asp:Content ID="TitlesContent" runat="server" ContentPlaceHolderID="TitleContent">
    <h1>Create Request - Round: 3 (Ad-Hoc Only)</h1>
</asp:Content>

<%-- MAIN BODY CONTENT --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:myConnectionString %>" 
        SelectCommand="SELECT [parkName] FROM [Park]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
     ConnectionString="<%$ ConnectionStrings:myConnectionString %>" 
        SelectCommand="SELECT * FROM [BookedRoom]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:myConnectionString %>" 
        SelectCommand="SELECT * FROM [BookedRoom]"></asp:SqlDataSource>

                
        <!-- Module Details -->
            <div class="canister =">
            
                <div class="canistertitle">
                    <h2>Module Details</h2>
                </div>
                <div class="clearfix"></div>

                <div class="row modulerow">
                    <div class="text-center col-md-4 col-sm-4 ">
                        <h3 style="margin-top:-0px;">Department</h3>
                    </div>
                    <div class="text-center col-md-4 col-sm-4">
                        <h3 style="margin-top:0px;">Module</h3>
                    </div>
                    <div class="text-center col-md-4 col-sm-4">
                        <h3 style="margin-top:-0px;">Capacity</h3>
                    </div>
                </div><!-- ./row -->

                <div class="row modulerow">
                    <div class="text-center col-md-4 col-sm-4">
                        <label class="form-control">Computer Science</label>
                    </div>
                    <div class="text-center col-md-4 col-sm-4">
                        <asp:DropDownList class="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
                    </div>
                    <div class="text-center col-md-4 col-sm-4">
                        <asp:TextBox class="form-control" ID="TextBoxCapacity" runat="server" AutoPostBack="True" ontextchanged="TextBoxCapacity_TextChanged" ></asp:TextBox>
                    </div>
                </div><!-- ./row -->
            
            </div><!-- ./canister -->
            
            <div class="clearfix"></div>
            
            <!-- Facilities -->
            <div class="canister">
                
                <div class="canistertitle">
                    <h2>Facility Options</h2>
                </div>

                <div class="canistercontainer">
                    
                    <div class="row">
                        <div class="text-center col-md-4 col-sm-4">
                            <h3 style="margin-top:-0px;">Room Type:</h3>
                        </div>
                        <div class="text-center col-md-4 col-sm-4">
                            <h3 style="margin-top:-0px;">Arrangement:</h3>
                        </div>
                        <div class="text-center col-md-4 col-sm-4">
                            <h3 style="margin-top:-0px;">WheelChair Access:</h3>
                        </div>
                    </div><!-- ./row -->
                    
                    

                    <div class="row">

                        <div class="text-center col-md-4 col-sm-4">
                            <asp:RadioButtonList ID="RadioButtonListRoomType" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonListRoomType_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary moveright">Lecture</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarg">Seminar</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div class="text-center col-md-4 col-sm-4">
                            <asp:RadioButtonList ID="RadioButtonListArrangement" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonListArrangement_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary moverightarrange">Tiered</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarg">Flat</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div class="text-center col-md-4 col-sm-4">
                            <asp:RadioButtonList ID="RadioButtonListWheelchair" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonListWheelchair_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary moverightarrange">Yes</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarg">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div><!-- ./row -->

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-4 col-sm-4">
                            <h3 style="margin-top:4px;">Board Type(s)</h3>
                        </div>
                        <div class="text-center col-md-4 col-sm-4">
                            <h3 style="margin-top:4px;">Data Projector(s)</h3>
                        </div>
                        <div class="text-center col-md-4 col-sm-4">
                            <h3 style="margin-top:4px;">Visualiser</h3>
                        </div>
                    </div><!-- ./row -->

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-4 col-sm-4">
                            <asp:CheckBox class="btn btn-primary" ID="CheckBoxWB" runat="server" Text="White Board" Checked="True" autopostback="true"/>
                            <asp:CheckBox class="btn btn-primary leftmarg" ID="CheckBoxCB" runat="server" Text="Chalk Board" autopostback="true" />
                        </div>
                        <div class="text-center col-md-4 col-sm-4">
                            <asp:RadioButtonList ID="RadioButtonListProjector" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonListProjector_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary">Data Projector</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarg">Double Projector</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="text-center col-md-4 col-sm-4">
                            <asp:RadioButtonList ID="RadioButtonListVisualiser" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonListVisualiser_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary moverightarrange" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarg">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div><!-- ./row -->

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-4 col-sm-4">
                            <h3 style="margin-top:4px;">Fixed Computer</h3>
                        </div>
                        <div class="text-center col-md-8 col-sm-8">
                            <h3 style="margin-top:4px;">Additional Requirements</h3>
                        </div>
                    </div><!-- ./row -->

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-4 col-sm-4">
                            <asp:RadioButtonList ID="RadioButtonListComputer" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonListComputer_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary moverightarrange" Selected="True">Yes</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarg">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="text-center col-md-8 col-sm-8">
                            <asp:TextBox class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                        </div>
                    </div><!-- ./row -->
                </div><!-- ./canister container -->
            </div><!-- ./canister -->

            <div class="clearfix"></div>

            <div class="canister">
                <div class="canistertitle">
                    <h2>Room Selection</h2>
                </div>

                <div class="canistercontainer">
                    <div class="row">
                        <div class="text-center col-md-3 col-sm-3">
                            <h3 style="margin-top:-0px;">Park</h3>
                        </div>
                        <div class="text-center col-md-3 col-sm-3">
                            <h3 style="margin-top:-0px;">Building</h3>
                        </div>
                        <div class="text-center col-md-3 col-sm-3">
                            <h3 style="margin-top:-0px;">Room to book</h3>
                        </div>
                        <div class="text-center col-md-3 col-sm-3">
                            <h3 style="margin-top:-0px;">Alternate Rooms</h3>
                        </div>
                    </div><!-- ./row -->

                    <div class="clearfix"></div>
                    
                    
                    
                    <div class="row">
                        <div class="text-center col-md-3 col-sm-3">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary">Central</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarglittle">East</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarglittle">West</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div class="text-center col-md-3 col-sm-3">
                            <asp:DropDownList class="form-control" ID="DropDownListBuildings" runat="server" AutoPostBack="true" onselectedindexchanged="DropDownListBuildings_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="text-center col-md-3 col-sm-3">
                            <!-- DROP DOWN FOR ROOM BOOKING -->                    
                           
                            <asp:DropDownList class="form-control" ID="DropDownListRooms" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListRooms_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="text-center col-md-3 col-sm-3">
                            <!-- DROPDOWN FOR ALTERNATE ROOM BOOKING -->
                            <asp:DropDownList class="form-control" ID="DropDownListRoomsAlt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListRoomsAlt_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div><!-- ./row -->
                    
                    <div class="clearfix"></div>

                     <!--<asp:UpdatePanel ID="UpdatePanel100" runat="server">
                                                    <ContentTemplate> -->
                    <div class="row">
                        <div class="text-right col-md-3 col-sm-3 col-md-offset-6 col-sm-offset-6">
                            <!-- Book Room 1 label -->
                            <asp:Label ID="LabelRoom1" runat="server" Text="None"></asp:Label>
                            <!-- Book Room 1 Delete Button-->
                            <asp:Button class="btn btn-success moveleft" ID="ButtonDeleteRoom1" runat="server" Text="Delete" onclick="ButtonDeleteRoom1_Click" />
                                   </br>                     
                            <!-- Book Room 2 label -->
                            <asp:Label ID="LabelRoom2" runat="server" Text="None"></asp:Label>
                            <!-- Book Room 2 Delete Button -->
                            <asp:Button ID="ButtonDeleteRoom2" runat="server" 
                                class="btn btn-success moveleft" onclick="ButtonDeleteRoom2_Click" 
                                Text="Delete" />
                            <br />
                            <!-- Book Room 3 label -->
                            <asp:Label ID="LabelRoom3" runat="server" Text="None"></asp:Label>
                            <!-- Book Room 3 Delete Button-->
                            <asp:Button style="margin-right:24px;" ID="ButtonDeleteRoom3" runat="server" 
                                class="btn btn-success moveleft" onclick="ButtonDeleteRoom3_Click" 
                                Text="Delete" />
                            
                        </div>
                        <div class="text-right col-md-3 col-sm-3">
                            <!-- Alt Room 1 label -->
                            <asp:Label ID="LabelRoomAlt1" runat="server" Text="None"></asp:Label>
                            <!-- Alt Room 1 Delete button -->
                            <asp:Button class="btn btn-success moveleft" ID="ButtonDeleteRoomAlt1" runat="server" Text="Delete" onclick="ButtonDeleteRoomAlt1_Click" />
                            </br>
                            <!-- Alt Room 2 label -->
                            <asp:Label ID="LabelRoomAlt2" runat="server" Text="None"></asp:Label>
                            <!-- Alt Room 2 Delete Button -->
                            <asp:Button ID="ButtonDeleteRoomAlt2" runat="server" 
                                class="btn btn-success moveleft" onclick="ButtonDeleteRoomAlt2_Click" 
                                Text="Delete" />
                            </br>
                            <!-- Alt Room 3 label -->
                            <asp:Label ID="LabelRoomAlt3" runat="server" Text="None"></asp:Label>
                            <!-- Alt Room 3 Delete Button -->
                            <asp:Button style="margin-right:24px;" ID="ButtonDeleteRoomAlt3" runat="server" 
                                class="btn btn-success moveleft" onclick="ButtonDeleteRoomAlt3_Click" 
                                Text="Delete" />
                            
                        </div>
                    </div><!-- ./row -->
                </div><!-- ./canistercontainer -->
            </div><!-- ./canister -->
           <!--</ContentTemplate>
                            </asp:UpdatePanel> -->

            <div class="canister">
                <div class="canistertitle">
                    <h2>Times</h2>
                </div>
                <div class="canistercontainer">
                    <div class="row">
                        <div class="text-center col-md-12 col-sm-12">
                            <div class="text-center col-md-12 col-sm-12">
                            <asp:RadioButtonList CssClass="center" ID="RadioButtonListSemester" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem class="btn btn-primary " Enabled="False">Semester 1</asp:ListItem>
                                <asp:ListItem class="btn btn-primary leftmarg" Selected="True">Semester 2</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        </div>
                    </div><!-- ./row -->
                    
                    <div class="clearfix"></div>

                    <div class="row">
                        
                    </div><!-- ./row -->

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-12 col-sm-12">
                            <h3>Week(s)</h3>
                        </div>
                    </div>
                    
                    <div class="clearfix"></div>
             
                    <div class="row">
                        <div class="text-center col-md-12 col-sm-12">
                            <!--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate> -->
                                    <asp:CheckBox class="btn btn-primary" ID="Week1" text="1" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week2" text="2" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week3" text="3" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week4" text="4" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week5" text="5" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week6" text="6" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week7" text="7" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week8" text="8" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week9" text="9" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week10" text="10" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week11" text="11" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week12" text="12" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week13" text="13" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week14" text="14" runat="server" AutoPostBack="true" />
                                    <asp:CheckBox class="btn btn-primary" ID="Week15" text="15" runat="server" AutoPostBack="true" />
                                    
                               <!-- </ContentTemplate>
                            </asp:UpdatePanel> -->
                        </div><!-- ./col -->
                    </div><!-- ./row -->
                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-12 col-sm-12">
                            <asp:Button class="btn btn-success topmarg" ID="All" runat="server" onclick="All_Click" Text="All" />
                            <asp:Button class="btn btn-success topmarg" ID="Twelve" runat="server" onclick="Twelve_Click" Text="1-12" />
                            <asp:Button class="btn btn-success topmarg" ID="Odd" runat="server" onclick="Odd_Click" Text="Odd" />
                            <asp:Button class="btn btn-success topmarg" ID="Even" runat="server" onclick="Even_Click" Text="Even" />
                            <asp:Button class="btn btn-warning topmarg" ID="Clear" runat="server" onclick="Clear_Click" Text="Clear All" />
                        </div>
                    </div><!-- ./row -->

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-12 col-sm-12">
                            <h3>Day(s) and Period(s)</h3>
                        </div>
                    </div><!-- ./row -->

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="text-center col-md-12 col-sm-12">
                            <!-- Periods and Times Table -->
                            <table class="center">
                                <tr>
                                    <td class="style2">
                                        <asp:Button class="btn btn-warning" ID="ButtonClearPeriods" runat="server" onclick="ButtonClearPeriods_Click" Text="Clear Periods" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod1" runat="server" Text="Period 1" onclick="ButtonPeriod1_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod2" runat="server" Text="Period 2" onclick="ButtonPeriod2_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod3" runat="server" Text="Period 3" onclick="ButtonPeriod3_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod4" runat="server" Text="Period 4" onclick="ButtonPeriod4_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod5" runat="server" Text="Period 5" onclick="ButtonPeriod5_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod6" runat="server" Text="Period 6" onclick="ButtonPeriod6_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod7" runat="server" Text="Period 7" onclick="ButtonPeriod7_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod8" runat="server" Text="Period 8" onclick="ButtonPeriod8_Click" />
                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success" ID="ButtonPeriod9" runat="server" Text="Period 9" onclick="ButtonPeriod9_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonMonday" runat="server" Text="Monday" onclick="ButtonMonday_Click" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM1" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM2" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM3" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM4" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM5" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM6" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM7" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM8" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxM9" runat="server" autopostback="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonTuesday" runat="server" Text="Tuesday" onclick="ButtonTuesday_Click" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT1" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT2" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT3" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT4" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT5" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT6" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT7" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT8" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxT9" runat="server" autopostback="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonWednesday" runat="server" Text="Wednesday" onclick="ButtonWednesday_Click" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW1" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW2" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW3" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW4" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW5" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW6" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW7" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW8" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxW9" runat="server" autopostback="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonThursday" runat="server" Text="Thursday" onclick="ButtonThursday_Click" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ1" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ2" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ3" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ4" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ5" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ6" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ7" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ8" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxJ9" runat="server" autopostback="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Button class="btn btn-success btn-block" ID="ButtonFriday" runat="server" Text="Friday" onclick="ButtonFriday_Click" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF1" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF2" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF3" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF4" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF5" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF6" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF7" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF8" runat="server" autopostback="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox class="btn btn-primary btn-block" text="x" ID="CheckBoxF9" runat="server" autopostback="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td> </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                     <asp:Button class="btn btn-success btn-block topmarg" ID="Button1" runat="server" onclick="Button1_Click" Text="Submit Request" />
                       
                                    </td>
                                    <td colspan="5">
                                     <asp:Button class="btn btn-warning btn-block topmarg" ID="ButtonClearAll" runat="server" onclick="ButtonClearAll_Click" Text="Clear All" />
                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="errorMessage" runat="server" Text="" />
                                    </td>
                                </tr>
                            </table>
                        </div><!-- ./col -->
                    </div><!-- ./row -->

                    <div class="clearfix"></div>
                    </br>
                    <div class="row">
                        <div class="text-center col-md-6 col-sm-6">
                            </div>
                        <div class="text-center col-md-6 col-sm-6">
                            </div>
                    </div><!-- ./row -->
                </div><!-- ./canistercontainer -->
            </div><!-- ./canister -->


</asp:Content>
