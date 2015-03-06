using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;

namespace Team11
{
    public partial class test : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                connect.Open();

                //Find all rooms
                string findrooms = "Select roomName from [Room]";
                SqlCommand roomscommand = new SqlCommand(findrooms, connect);
                SqlDataReader rooms = roomscommand.ExecuteReader();

                //Add the results to the dropdownlist
                while (rooms.Read())
                {
                    DropDownListRooms.Items.Add(rooms.GetString(0).ToString());
                }
                connect.Close();
            }
        }
        protected void RadioButtonListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Search preference by Room or Date, hide the unselected one
            if (this.RadioButtonListView.SelectedIndex == 0)
            {
                this.divByRoom.Visible = true;
                this.divByDate.Visible = false;
            }
            else
            {
                this.divByRoom.Visible = false;
                this.divByDate.Visible = true;
            }

        }
        protected void RadioButtonListPark_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Retrieve all Buildings belonging to the selected park and add them to dropdownlist
            DropDownListBuilding.Items.Clear();
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            connect.Open();
            int parkID = RadioButtonListPark.SelectedIndex + 1;
            string findbuildings = "Select buildingName from [Building] where parkID =' " + parkID + "'";
            SqlCommand buildingscommand = new SqlCommand(findbuildings, connect);

            SqlDataReader buildings = buildingscommand.ExecuteReader();
            while (buildings.Read())
            {
                DropDownListBuilding.Items.Add(buildings.GetString(0).ToString());
            }
            connect.Close();
        }
        protected void DropDownListBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRooms.Items.Clear();
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            connect.Open();

            //Find the BuildingID of the selected Building
            string findbuildingID = "Select buildingID from [Building] where buildingName='" + DropDownListBuilding.SelectedValue + "'";
            SqlCommand IDcommand = new SqlCommand(findbuildingID, connect);
            string buildingID = IDcommand.ExecuteScalar().ToString();

            //Find the rooms belonging to that buildingID
            string findrooms = "Select roomName from [Room] where buildingID =' " + buildingID + "'";
            SqlCommand roomscommand = new SqlCommand(findrooms, connect);
            SqlDataReader rooms = roomscommand.ExecuteReader();

            //Add the results to the dropdownlist
            while (rooms.Read())
            {
                DropDownListRooms.Items.Add(rooms.GetString(0).ToString());
            }
            connect.Close();
        }

        public void roomavailibility()
        {

            CheckBox[,] boxes = new CheckBox[5, 9];
            boxes[0, 0] = CheckBoxM1;
            boxes[0, 1] = CheckBoxM2;
            boxes[0, 2] = CheckBoxM3;
            boxes[0, 3] = CheckBoxM4;
            boxes[0, 4] = CheckBoxM5;
            boxes[0, 5] = CheckBoxM6;
            boxes[0, 6] = CheckBoxM7;
            boxes[0, 7] = CheckBoxM8;
            boxes[0, 8] = CheckBoxM9;
            boxes[1, 0] = CheckBoxT1;
            boxes[1, 1] = CheckBoxT2;
            boxes[1, 2] = CheckBoxT3;
            boxes[1, 3] = CheckBoxT4;
            boxes[1, 4] = CheckBoxT5;
            boxes[1, 5] = CheckBoxT6;
            boxes[1, 6] = CheckBoxT7;
            boxes[1, 7] = CheckBoxT8;
            boxes[1, 8] = CheckBoxT9;
            boxes[2, 0] = CheckBoxW1;
            boxes[2, 1] = CheckBoxW2;
            boxes[2, 2] = CheckBoxW3;
            boxes[2, 3] = CheckBoxW4;
            boxes[2, 4] = CheckBoxW5;
            boxes[2, 5] = CheckBoxW6;
            boxes[2, 6] = CheckBoxW7;
            boxes[2, 7] = CheckBoxW8;
            boxes[2, 8] = CheckBoxW9;
            boxes[3, 0] = CheckBoxJ1;
            boxes[3, 1] = CheckBoxJ2;
            boxes[3, 2] = CheckBoxJ3;
            boxes[3, 3] = CheckBoxJ4;
            boxes[3, 4] = CheckBoxJ5;
            boxes[3, 5] = CheckBoxJ6;
            boxes[3, 6] = CheckBoxJ7;
            boxes[3, 7] = CheckBoxJ8;
            boxes[3, 8] = CheckBoxJ9;
            boxes[4, 0] = CheckBoxF1;
            boxes[4, 1] = CheckBoxF2;
            boxes[4, 2] = CheckBoxF3;
            boxes[4, 3] = CheckBoxF4;
            boxes[4, 4] = CheckBoxF5;
            boxes[4, 5] = CheckBoxF6;
            boxes[4, 6] = CheckBoxF7;
            boxes[4, 7] = CheckBoxF8;
            boxes[4, 8] = CheckBoxF9;
            //Start off by finding all week records that have at least one week in common to the weeks the user has selected. 
            //Declare a new arraylist where we will store the WeekIDs

            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            connect.Open();
            string selectedroom = DropDownListRooms.SelectedValue;

            int selectedweek = DropDownListWeekNumber.SelectedIndex + 1;

            string sqlquery = "Select distinct * from (([Room] Inner Join [BookedRoom]  On [Room].roomID=[BookedRoom].roomID) Inner join [Request] on [BookedRoom].requestID=[Request].requestID) inner join [Week] on [Request].weekID=[Week].weekID where [Room].roomName='" + selectedroom + "' and [Week].week" + selectedweek + "=1";
            SqlCommand roomcommand = new SqlCommand(sqlquery, connect);
            SqlDataReader roominfo = roomcommand.ExecuteReader();

            bool endofF = false;
            if (roominfo.Read())
            {
                endofF = true;
            }

            while (endofF)
            {

                string day = roominfo.GetString(10);
                int start = roominfo.GetInt32(11);
                int end = roominfo.GetInt32(12);

                if (day == "Monday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[0, i].Enabled = false;
                    }
                }
                if (day == "Tuesday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[1, i].Enabled = false;
                    }
                } if (day == "Wednesday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[2, i].Enabled = false;
                    }
                } if (day == "Thursday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[3, i].Enabled = false;
                    }
                } if (day == "Friday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[4, i].Enabled = false;
                    }
                }
                if (roominfo.Read() == false)
                {
                    endofF = false;
                    break;
                }
                //break;
                //remove break
            }

            connect.Close();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            clearcheckboxes();
            roomavailibility();
        }

        protected void DropDownListRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearcheckboxes();
            roomavailibility();
        }

        protected void DropDownListWeekNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearcheckboxes();
            roomavailibility();
        }

        public void clearcheckboxes()
        {

            CheckBox[,] boxes = new CheckBox[5, 9];
            boxes[0, 0] = CheckBoxM1;
            boxes[0, 1] = CheckBoxM2;
            boxes[0, 2] = CheckBoxM3;
            boxes[0, 3] = CheckBoxM4;
            boxes[0, 4] = CheckBoxM5;
            boxes[0, 5] = CheckBoxM6;
            boxes[0, 6] = CheckBoxM7;
            boxes[0, 7] = CheckBoxM8;
            boxes[0, 8] = CheckBoxM9;
            boxes[1, 0] = CheckBoxT1;
            boxes[1, 1] = CheckBoxT2;
            boxes[1, 2] = CheckBoxT3;
            boxes[1, 3] = CheckBoxT4;
            boxes[1, 4] = CheckBoxT5;
            boxes[1, 5] = CheckBoxT6;
            boxes[1, 6] = CheckBoxT7;
            boxes[1, 7] = CheckBoxT8;
            boxes[1, 8] = CheckBoxT9;
            boxes[2, 0] = CheckBoxW1;
            boxes[2, 1] = CheckBoxW2;
            boxes[2, 2] = CheckBoxW3;
            boxes[2, 3] = CheckBoxW4;
            boxes[2, 4] = CheckBoxW5;
            boxes[2, 5] = CheckBoxW6;
            boxes[2, 6] = CheckBoxW7;
            boxes[2, 7] = CheckBoxW8;
            boxes[2, 8] = CheckBoxW9;
            boxes[3, 0] = CheckBoxJ1;
            boxes[3, 1] = CheckBoxJ2;
            boxes[3, 2] = CheckBoxJ3;
            boxes[3, 3] = CheckBoxJ4;
            boxes[3, 4] = CheckBoxJ5;
            boxes[3, 5] = CheckBoxJ6;
            boxes[3, 6] = CheckBoxJ7;
            boxes[3, 7] = CheckBoxJ8;
            boxes[3, 8] = CheckBoxJ9;
            boxes[4, 0] = CheckBoxF1;
            boxes[4, 1] = CheckBoxF2;
            boxes[4, 2] = CheckBoxF3;
            boxes[4, 3] = CheckBoxF4;
            boxes[4, 4] = CheckBoxF5;
            boxes[4, 5] = CheckBoxF6;
            boxes[4, 6] = CheckBoxF7;
            boxes[4, 7] = CheckBoxF8;
            boxes[4, 8] = CheckBoxF9;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boxes[i, j].Checked = false;
                    boxes[i, j].Enabled = true;
                }
            }
        }

        //Find available rooms (by date)
        protected void ButtonFindRooms_Click(object sender, EventArgs e)
        {
            DropDownListRoomsByDate.Items.Clear();
            CheckBox[,] boxes = new CheckBox[5, 9];
            boxes[0, 0] = CheckBoxM10;
            boxes[0, 1] = CheckBoxM11;
            boxes[0, 2] = CheckBoxM12;
            boxes[0, 3] = CheckBoxM13;
            boxes[0, 4] = CheckBoxM14;
            boxes[0, 5] = CheckBoxM15;
            boxes[0, 6] = CheckBoxM16;
            boxes[0, 7] = CheckBoxM16;
            boxes[0, 8] = CheckBoxM18;
            boxes[1, 0] = CheckBoxT10;
            boxes[1, 1] = CheckBoxT11;
            boxes[1, 2] = CheckBoxT12;
            boxes[1, 3] = CheckBoxT13;
            boxes[1, 4] = CheckBoxT14;
            boxes[1, 5] = CheckBoxT15;
            boxes[1, 6] = CheckBoxT16;
            boxes[1, 7] = CheckBoxT17;
            boxes[1, 8] = CheckBoxT18;
            boxes[2, 0] = CheckBoxW10;
            boxes[2, 1] = CheckBoxW11;
            boxes[2, 2] = CheckBoxW12;
            boxes[2, 3] = CheckBoxW13;
            boxes[2, 4] = CheckBoxW14;
            boxes[2, 5] = CheckBoxW15;
            boxes[2, 6] = CheckBoxW16;
            boxes[2, 7] = CheckBoxW17;
            boxes[2, 8] = CheckBoxW18;
            boxes[3, 0] = CheckBoxJ10;
            boxes[3, 1] = CheckBoxJ11;
            boxes[3, 2] = CheckBoxJ12;
            boxes[3, 3] = CheckBoxJ13;
            boxes[3, 4] = CheckBoxJ14;
            boxes[3, 5] = CheckBoxJ15;
            boxes[3, 6] = CheckBoxJ16;
            boxes[3, 7] = CheckBoxJ17;
            boxes[3, 8] = CheckBoxJ18;
            boxes[4, 0] = CheckBoxF10;
            boxes[4, 1] = CheckBoxF11;
            boxes[4, 2] = CheckBoxF12;
            boxes[4, 3] = CheckBoxF13;
            boxes[4, 4] = CheckBoxF14;
            boxes[4, 5] = CheckBoxF15;
            boxes[4, 6] = CheckBoxF16;
            boxes[4, 7] = CheckBoxF17;
            boxes[4, 8] = CheckBoxF18;
            string day = "";
            int week = DropDownListWeeks.SelectedIndex + 1;
            int periodStart = 0;

            for (int j = 0; j < 9; j++)
            {
                if (boxes[0, j].Checked)
                {
                    day = "Monday";
                    periodStart = j + 1;
                }
                else if (boxes[1, j].Checked)
                {
                    day = "Tuesday";
                    periodStart = j + 1;
                }
                else if (boxes[2, j].Checked)
                {
                    day = "Wednesday";
                    periodStart = j + 1;
                }
                else if (boxes[3, j].Checked)
                {
                    day = "Thursday";
                    periodStart = j + 1;
                }
                else if (boxes[4, j].Checked)
                {
                    day = "Friday";
                    periodStart = j + 1;
                }
            }

            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            connect.Open();
            string findroomsql = "SELECT roomName FROM [Room] WHERE RoomID NOT IN (SELECT roomID FROM [BookedRoom] INNER JOIN [Request] ON [BookedRoom].requestID = [Request].requestID INNER JOIN [Week] ON [Request].weekID = [Week].weekID WHERE [Request].day ='" + day + "' AND [Request].periodStart = " + periodStart + " AND [Week].week" + week + " = 1)";
            SqlCommand roomcommand = new SqlCommand(findroomsql, connect);
            SqlDataReader rooms = roomcommand.ExecuteReader();

            while (rooms.Read())
            {
                DropDownListRoomsByDate.Items.Add(rooms.GetString(0).ToString());

            }
            connect.Close();

        }

        //Book buttons
        protected void ButtonBookByDate_Click(object sender, EventArgs e)
        {
            SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            connection7.Open();

            CheckBox[,] boxes = new CheckBox[5, 9];
            boxes[0, 0] = CheckBoxM10;
            boxes[0, 1] = CheckBoxM11;
            boxes[0, 2] = CheckBoxM12;
            boxes[0, 3] = CheckBoxM13;
            boxes[0, 4] = CheckBoxM14;
            boxes[0, 5] = CheckBoxM15;
            boxes[0, 6] = CheckBoxM16;
            boxes[0, 7] = CheckBoxM16;
            boxes[0, 8] = CheckBoxM18;
            boxes[1, 0] = CheckBoxT10;
            boxes[1, 1] = CheckBoxT11;
            boxes[1, 2] = CheckBoxT12;
            boxes[1, 3] = CheckBoxT13;
            boxes[1, 4] = CheckBoxT14;
            boxes[1, 5] = CheckBoxT15;
            boxes[1, 6] = CheckBoxT16;
            boxes[1, 7] = CheckBoxT17;
            boxes[1, 8] = CheckBoxT18;
            boxes[2, 0] = CheckBoxW10;
            boxes[2, 1] = CheckBoxW11;
            boxes[2, 2] = CheckBoxW12;
            boxes[2, 3] = CheckBoxW13;
            boxes[2, 4] = CheckBoxW14;
            boxes[2, 5] = CheckBoxW15;
            boxes[2, 6] = CheckBoxW16;
            boxes[2, 7] = CheckBoxW17;
            boxes[2, 8] = CheckBoxW18;
            boxes[3, 0] = CheckBoxJ10;
            boxes[3, 1] = CheckBoxJ11;
            boxes[3, 2] = CheckBoxJ12;
            boxes[3, 3] = CheckBoxJ13;
            boxes[3, 4] = CheckBoxJ14;
            boxes[3, 5] = CheckBoxJ15;
            boxes[3, 6] = CheckBoxJ16;
            boxes[3, 7] = CheckBoxJ17;
            boxes[3, 8] = CheckBoxJ18;
            boxes[4, 0] = CheckBoxF10;
            boxes[4, 1] = CheckBoxF11;
            boxes[4, 2] = CheckBoxF12;
            boxes[4, 3] = CheckBoxF13;
            boxes[4, 4] = CheckBoxF14;
            boxes[4, 5] = CheckBoxF15;
            boxes[4, 6] = CheckBoxF16;
            boxes[4, 7] = CheckBoxF17;
            boxes[4, 8] = CheckBoxF18;

            //Retrieve module name
            string moduleName = DropDownListModulesByDate.SelectedValue;
            string modulesquery = "SELECT moduleCode FROM [Module] WHERE moduleTitle ='" + moduleName + "'";
            SqlCommand modulessql = new SqlCommand(modulesquery, connection7);
            string moduleCodeText = modulessql.ExecuteScalar().ToString();

            bool[] mondayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[0, i].Checked)
                {
                    mondayrequest[i] = true;
                }
            }
            bool[] tuesdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[1, i].Checked)
                {
                    tuesdayrequest[i] = true;
                }
            }
            bool[] wednesdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[2, i].Checked)
                {
                    wednesdayrequest[i] = true;
                }
            }
            bool[] thursdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[3, i].Checked)
                {
                    thursdayrequest[i] = true;
                }
            }
            bool[] fridayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[4, i].Checked)
                {
                    fridayrequest[i] = true;
                }
            }
            //Weeks part
            int weeknumber = DropDownListWeeks.SelectedIndex;
            int[] weeksarray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            weeksarray[weeknumber] = 1;

            int weekIDText;
            string weekquery = "SELECT COUNT(weekID) FROM [Week] WHERE week1= " + weeksarray[0] + " AND week2= " + weeksarray[1] + " AND week3= " + weeksarray[2] + " AND week4= " + weeksarray[3] + " AND week5= " + weeksarray[4] + " AND week6= " + weeksarray[5] + " AND week7= " + weeksarray[6] + " AND week8= " + weeksarray[7] + " AND week9= " + weeksarray[8] + " AND week10= " + weeksarray[9] + " AND week11= " + weeksarray[10] + " AND week12= " + weeksarray[11] + " AND week13= " + weeksarray[12] + " AND week14= " + weeksarray[13] + " AND week15= " + weeksarray[14];
            SqlCommand weeksql = new SqlCommand(weekquery, connection7);
            int testtwo = Convert.ToInt32(weeksql.ExecuteScalar().ToString());

            /* If there is a corresponding weekID in database, select it */
            if (testtwo != 0)
            {
                string weekquery2 = "SELECT weekID FROM [Week] WHERE week1= " + weeksarray[0] + " AND week2= " + weeksarray[1] + " AND week3= " + weeksarray[2] + " AND week4= " + weeksarray[3] + " AND week5= " + weeksarray[4] + " AND week6= " + weeksarray[5] + " AND week7= " + weeksarray[6] + " AND week8= " + weeksarray[7] + " AND week9= " + weeksarray[8] + " AND week10= " + weeksarray[9] + " AND week11= " + weeksarray[10] + " AND week12= " + weeksarray[11] + " AND week13= " + weeksarray[12] + " AND week14= " + weeksarray[13] + " AND week15= " + weeksarray[14];
                SqlCommand weeksql2 = new SqlCommand(weekquery2, connection7);
                weekIDText = Convert.ToInt32(weeksql2.ExecuteScalar().ToString());
            }
            /* If there is no corresponding weekID, make a new one and use that */
            else
            {
                string insweekquery = "INSERT INTO [Week] VALUES(" + weeksarray[0] + "," + weeksarray[1] + "," + weeksarray[2] + "," + weeksarray[3] + "," + weeksarray[4] + "," + weeksarray[5] + "," + weeksarray[6] + "," + weeksarray[7] + "," + weeksarray[8] + "," + weeksarray[9] + "," + weeksarray[10] + "," + weeksarray[11] + "," + weeksarray[12] + "," + weeksarray[13] + "," + weeksarray[14] + ")";

                SqlCommand insweeksql = new SqlCommand(insweekquery, connection7);
                insweeksql.ExecuteNonQuery();
                string newweek = "SELECT MAX(weekID) FROM [Week]";
                SqlCommand maxweeksql = new SqlCommand(newweek, connection7);
                weekIDText = Convert.ToInt32(maxweeksql.ExecuteScalar().ToString());
            }


            string selectedroom = DropDownListRoomsByDate.Text;


            string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + selectedroom + "'";
            SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
            int roomid = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());

            for (int i = 0; i < 9; i++)
            {
                if (mondayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (mondayrequest[n] == true && mondayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Monday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (tuesdayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (tuesdayrequest[n] == true && tuesdayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Tuesday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (wednesdayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (wednesdayrequest[n] == true && wednesdayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Wednesday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (thursdayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (thursdayrequest[n] == true && thursdayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Thursday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (fridayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (fridayrequest[n] == true && fridayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Friday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }



                }
            }
            connection7.Close();
        }


        protected void ButtonBookByRoom_Click(object sender, EventArgs e)
        {
            SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            connection7.Open();
            CheckBox[,] boxes = new CheckBox[5, 9];
            boxes[0, 0] = CheckBoxM1;
            boxes[0, 1] = CheckBoxM2;
            boxes[0, 2] = CheckBoxM3;
            boxes[0, 3] = CheckBoxM4;
            boxes[0, 4] = CheckBoxM5;
            boxes[0, 5] = CheckBoxM6;
            boxes[0, 6] = CheckBoxM7;
            boxes[0, 7] = CheckBoxM8;
            boxes[0, 8] = CheckBoxM9;
            boxes[1, 0] = CheckBoxT1;
            boxes[1, 1] = CheckBoxT2;
            boxes[1, 2] = CheckBoxT3;
            boxes[1, 3] = CheckBoxT4;
            boxes[1, 4] = CheckBoxT5;
            boxes[1, 5] = CheckBoxT6;
            boxes[1, 6] = CheckBoxT7;
            boxes[1, 7] = CheckBoxT8;
            boxes[1, 8] = CheckBoxT9;
            boxes[2, 0] = CheckBoxW1;
            boxes[2, 1] = CheckBoxW2;
            boxes[2, 2] = CheckBoxW3;
            boxes[2, 3] = CheckBoxW4;
            boxes[2, 4] = CheckBoxW5;
            boxes[2, 5] = CheckBoxW6;
            boxes[2, 6] = CheckBoxW7;
            boxes[2, 7] = CheckBoxW8;
            boxes[2, 8] = CheckBoxW9;
            boxes[3, 0] = CheckBoxJ1;
            boxes[3, 1] = CheckBoxJ2;
            boxes[3, 2] = CheckBoxJ3;
            boxes[3, 3] = CheckBoxJ4;
            boxes[3, 4] = CheckBoxJ5;
            boxes[3, 5] = CheckBoxJ6;
            boxes[3, 6] = CheckBoxJ7;
            boxes[3, 7] = CheckBoxJ8;
            boxes[3, 8] = CheckBoxJ9;
            boxes[4, 0] = CheckBoxF1;
            boxes[4, 1] = CheckBoxF2;
            boxes[4, 2] = CheckBoxF3;
            boxes[4, 3] = CheckBoxF4;
            boxes[4, 4] = CheckBoxF5;
            boxes[4, 5] = CheckBoxF6;
            boxes[4, 6] = CheckBoxF7;
            boxes[4, 7] = CheckBoxF8;
            boxes[4, 8] = CheckBoxF9;


            bool[] mondayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[0, i].Checked)
                {
                    mondayrequest[i] = true;
                }
            }
            bool[] tuesdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[1, i].Checked)
                {
                    tuesdayrequest[i] = true;
                }
            }
            bool[] wednesdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[2, i].Checked)
                {
                    wednesdayrequest[i] = true;
                }
            }
            bool[] thursdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[3, i].Checked)
                {
                    thursdayrequest[i] = true;
                }
            }
            bool[] fridayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            for (int i = 0; i < 9; i++)
            {
                if (boxes[4, i].Checked)
                {
                    fridayrequest[i] = true;
                }
            }

            //Retrieve module name
            string moduleName = DropDownListModuleByRoom.SelectedValue;
            string modulesquery = "SELECT moduleCode FROM [Module] WHERE moduleTitle ='" + moduleName + "'";
            SqlCommand modulessql = new SqlCommand(modulesquery, connection7);
            string moduleCodeText = modulessql.ExecuteScalar().ToString();

            int weeknumber = DropDownListWeekNumber.SelectedIndex;
            int[] weeksarray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            weeksarray[weeknumber] = 1;

            int weekIDText;
            string weekquery = "SELECT COUNT(weekID) FROM [Week] WHERE week1= " + weeksarray[0] + " AND week2= " + weeksarray[1] + " AND week3= " + weeksarray[2] + " AND week4= " + weeksarray[3] + " AND week5= " + weeksarray[4] + " AND week6= " + weeksarray[5] + " AND week7= " + weeksarray[6] + " AND week8= " + weeksarray[7] + " AND week9= " + weeksarray[8] + " AND week10= " + weeksarray[9] + " AND week11= " + weeksarray[10] + " AND week12= " + weeksarray[11] + " AND week13= " + weeksarray[12] + " AND week14= " + weeksarray[13] + " AND week15= " + weeksarray[14];
            SqlCommand weeksql = new SqlCommand(weekquery, connection7);
            int testtwo = Convert.ToInt32(weeksql.ExecuteScalar().ToString());

            /* If there is a corresponding weekID in database, select it */
            if (testtwo != 0)
            {
                string weekquery2 = "SELECT weekID FROM [Week] WHERE week1= " + weeksarray[0] + " AND week2= " + weeksarray[1] + " AND week3= " + weeksarray[2] + " AND week4= " + weeksarray[3] + " AND week5= " + weeksarray[4] + " AND week6= " + weeksarray[5] + " AND week7= " + weeksarray[6] + " AND week8= " + weeksarray[7] + " AND week9= " + weeksarray[8] + " AND week10= " + weeksarray[9] + " AND week11= " + weeksarray[10] + " AND week12= " + weeksarray[11] + " AND week13= " + weeksarray[12] + " AND week14= " + weeksarray[13] + " AND week15= " + weeksarray[14];
                SqlCommand weeksql2 = new SqlCommand(weekquery2, connection7);
                weekIDText = Convert.ToInt32(weeksql2.ExecuteScalar().ToString());
            }
            /* If there is no corresponding weekID, make a new one and use that */
            else
            {
                string insweekquery = "INSERT INTO [Week] VALUES(" + weeksarray[0] + "," + weeksarray[1] + "," + weeksarray[2] + "," + weeksarray[3] + "," + weeksarray[4] + "," + weeksarray[5] + "," + weeksarray[6] + "," + weeksarray[7] + "," + weeksarray[8] + "," + weeksarray[9] + "," + weeksarray[10] + "," + weeksarray[11] + "," + weeksarray[12] + "," + weeksarray[13] + "," + weeksarray[14] + ")";

                SqlCommand insweeksql = new SqlCommand(insweekquery, connection7);
                insweeksql.ExecuteNonQuery();
                string newweek = "SELECT MAX(weekID) FROM [Week]";
                SqlCommand maxweeksql = new SqlCommand(newweek, connection7);
                weekIDText = Convert.ToInt32(maxweeksql.ExecuteScalar().ToString());
            }

            string selectedroom = DropDownListRooms.Text;


            string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + selectedroom + "'";
            SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
            int roomid = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());

            for (int i = 0; i < 9; i++)
            {
                if (mondayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (mondayrequest[n] == true && mondayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Monday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (tuesdayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (tuesdayrequest[n] == true && tuesdayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Tuesday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (wednesdayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (wednesdayrequest[n] == true && wednesdayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Wednesday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (thursdayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (thursdayrequest[n] == true && thursdayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Thursday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (fridayrequest[i] == true)
                {
                    int startTime = i + 1;
                    int duration = 0;
                    int n = i - 1;
                    bool ended = true;
                    while (ended)
                    {
                        n++;
                        switch (fridayrequest[n] == true && fridayrequest[n + 1] == true)
                        {
                            case true:
                                duration++;
                                i++;
                                break;
                            case false:
                                int endTime = startTime + duration;
                                string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Accepted'," + weekIDText + ",'Friday'," + startTime + "," + endTime + ",2,2014)";
                                SqlCommand insreqsql = new SqlCommand(insreq, connection7);
                                insreqsql.ExecuteNonQuery();
                                string booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomid + ")";
                                SqlCommand bookedsql = new SqlCommand(booked, connection7);
                                bookedsql.ExecuteNonQuery();
                                ended = false;
                                break;
                        }
                    }
                }
            }
        }

    }
}