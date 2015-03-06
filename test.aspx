<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Team11.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 101%;
        }
        .style2
        {
            width: 141px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ParkConnectionString %>" 
        SelectCommand="SELECT [parkName] FROM [Park]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ParkConnectionString %>" 
        SelectCommand="SELECT [moduleTitle] FROM [Module]"></asp:SqlDataSource>
    <asp:RadioButtonList ID="RadioButtonListView" runat="server">
        <asp:ListItem>By Room</asp:ListItem>
        <asp:ListItem>By Date</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <div id="divByRoom" runat="server" visible="false">
        Park:<asp:RadioButtonList ID="RadioButtonListPark" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="parkName" 
            DataValueField="parkName">
        </asp:RadioButtonList>
        Building:<br />
        <asp:DropDownList ID="DropDownListBuilding" runat="server">
        </asp:DropDownList>
        <br />
        Room:<br />
        <asp:DropDownList ID="DropDownListRooms" runat="server">
        </asp:DropDownList>
        <br />
        Week required :
        <asp:DropDownList ID="DropDownListWeekNumber" runat="server">
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
        <br />
        Module:<asp:DropDownList ID="DropDownListModuleByRoom" runat="server" 
            DataSourceID="SqlDataSource2" DataTextField="moduleTitle" 
            DataValueField="moduleTitle">
        </asp:DropDownList>
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonClearPeriods" runat="server" 
                                onclick="ButtonClearPeriods_Click" Text="Clear Periods" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod1" runat="server" onclick="ButtonPeriod1_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod2" runat="server" onclick="ButtonPeriod2_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod3" runat="server" onclick="ButtonPeriod3_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod4" runat="server" onclick="ButtonPeriod4_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod5" runat="server" onclick="ButtonPeriod5_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod6" runat="server" onclick="ButtonPeriod6_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod7" runat="server" onclick="ButtonPeriod7_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod8" runat="server" onclick="ButtonPeriod8_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod9" runat="server" onclick="ButtonPeriod9_Click" 
                                Text="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonMonday" runat="server" onclick="ButtonMonday_Click" 
                                Text="Monday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM1" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM2" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM3" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM4" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM5" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM6" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM7" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM8" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM9" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonTuesday" runat="server" onclick="ButtonTuesday_Click" 
                                Text="Tuesday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT1" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT2" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT3" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT4" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT5" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT6" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT7" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT8" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT9" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonWednesday" runat="server" onclick="ButtonWednesday_Click" 
                                Text="Wednesday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW1" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW2" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW3" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW4" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW5" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW6" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW7" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW8" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW9" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonThursday" runat="server" onclick="ButtonThursday_Click" 
                                Text="Thursday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ1" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ2" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ3" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ4" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ5" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ6" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ7" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ8" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ9" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonFriday" runat="server" onclick="ButtonFriday_Click" 
                                Text="Friday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF1" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF2" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF3" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF4" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF5" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF6" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF7" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF8" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF9" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Button ID="Search" runat="server" Text="Search" />
        <asp:Button ID="ButtonBookByRoom" runat="server" Text="Book" />
        <br />
        <br />
    </div>
    <br />
    <div id="divByDate" runat="server" visible="false">
        Week Required:<br />
        <asp:DropDownList ID="DropDownListWeeks" runat="server">
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
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonClearPeriods0" runat="server" 
                                onclick="ButtonClearPeriods_Click" Text="Clear Periods" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod10" runat="server" onclick="ButtonPeriod1_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod11" runat="server" onclick="ButtonPeriod2_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod12" runat="server" onclick="ButtonPeriod3_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod13" runat="server" onclick="ButtonPeriod4_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod14" runat="server" onclick="ButtonPeriod5_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod15" runat="server" onclick="ButtonPeriod6_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod16" runat="server" onclick="ButtonPeriod7_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod17" runat="server" onclick="ButtonPeriod8_Click" 
                                Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPeriod18" runat="server" onclick="ButtonPeriod9_Click" 
                                Text="Button" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonMonday0" runat="server" onclick="ButtonMonday_Click" 
                                Text="Monday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM10" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM11" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM12" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM13" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM14" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM15" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM16" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM17" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxM18" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonTuesday0" runat="server" onclick="ButtonTuesday_Click" 
                                Text="Tuesday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT10" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT11" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT12" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT13" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT14" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT15" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT16" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT17" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxT18" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonWednesday0" runat="server" 
                                onclick="ButtonWednesday_Click" Text="Wednesday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW10" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW11" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW12" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW13" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW14" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW15" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW16" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW17" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxW18" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonThursday0" runat="server" onclick="ButtonThursday_Click" 
                                Text="Thursday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ10" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ11" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ12" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ13" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ14" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ15" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ16" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ17" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxJ18" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Button ID="ButtonFriday0" runat="server" onclick="ButtonFriday_Click" 
                                Text="Friday" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF10" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF11" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF12" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF13" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF14" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF15" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF16" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF17" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxF18" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Button ID="ButtonFindRooms" runat="server" Text="Find Rooms" />
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                Choose Room:<asp:DropDownList ID="DropDownListRoomsByDate" runat="server">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BookByDate" runat="server" Text="Book" />
&nbsp;&nbsp;&nbsp; Module:
        <asp:DropDownList ID="DropDownListModulesByDate" runat="server">
        </asp:DropDownList>
        <br />
    </div>
    </form>
</body>
</html>
