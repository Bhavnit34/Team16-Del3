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
    public partial class EditRequest : System.Web.UI.Page
    {
        int requestid = 1;
        int userID = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            requestid = Convert.ToInt32(Request.QueryString["request"]);
            if (!IsPostBack)
            {

                SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                connect.Open();

                string modulesql = "Select moduleCode, moduleTitle from [Module] where userID=" + userID;
                SqlCommand modulecommand = new SqlCommand(modulesql, connect);
                SqlDataReader modules = modulecommand.ExecuteReader();
                while (modules.Read())
                {
                    string modulecode = modules.GetString(0);
                    string modulename = modules.GetString(1);
                    string module = modulecode + " : " + modulename;
                    DropDownList1.Items.Add(module);

                }
                connect.Close();
                //Declare variables and make them empty
                string modcode = "";
                int weekID = 0;
                string day = "";
                int start = 0;
                int end = 0;
                int park = 0;


                connect.Open();

                //Query that comes up with the info on the selected request (I set requestID=154 to test)
                string requestquery = "Select * from [Request] where requestID=" + requestid;

                SqlCommand requestsql = new SqlCommand(requestquery, connect);
                SqlDataReader requestreader = requestsql.ExecuteReader();

                if (requestreader.Read())
                {
                    modcode = requestreader.GetString(1);
                    weekID = requestreader.GetInt32(3);
                    day = requestreader.GetString(4);
                    start = requestreader.GetInt32(5);
                    end = requestreader.GetInt32(6);

                }
                connect.Close();
                connect.Open();
                //find park
                string parkquery = "SELECT [Park].parkID FROM [Park] INNER JOIN [Building] ON [Park].parkID = [Building].buildingID INNER JOIN [Room] ON [Building].buildingID = [Room].buildingID INNER JOIN [BookedRoom] ON [Room].roomID = [BookedRoom].roomID WHERE [BookedRoom].requestID=" + requestid;
                SqlCommand parksql = new SqlCommand(parkquery, connect);
                SqlDataReader parkreader = parksql.ExecuteReader();
                if (parkreader.Read())
                {
                    park = parkreader.GetInt32(0);
                }
                connect.Close();
                RadioButtonList1.SelectedIndex = park - 1;

                //Sets selected weeks from request
                connect.Open();
                string weeksql = "Select * from [Week] where weekID =" + weekID + "";
                SqlCommand weekcommand = new SqlCommand(weeksql, connect);
                SqlDataReader weeks = weekcommand.ExecuteReader();
                while (weeks.Read())
                {
                    if (weeks.GetInt32(1) == 1)
                    { Week1.Checked = true; }
                    if (weeks.GetInt32(2) == 1)
                    { Week2.Checked = true; }
                    if (weeks.GetInt32(3) == 1)
                    { Week3.Checked = true; }
                    if (weeks.GetInt32(4) == 1)
                    { Week4.Checked = true; }
                    if (weeks.GetInt32(5) == 1)
                    { Week5.Checked = true; }
                    if (weeks.GetInt32(6) == 1)
                    { Week6.Checked = true; }
                    if (weeks.GetInt32(7) == 1)
                    { Week7.Checked = true; }
                    if (weeks.GetInt32(8) == 1)
                    { Week8.Checked = true; }
                    if (weeks.GetInt32(9) == 1)
                    { Week9.Checked = true; }
                    if (weeks.GetInt32(10) == 1)
                    { Week10.Checked = true; }
                    if (weeks.GetInt32(11) == 1)
                    { Week11.Checked = true; }
                    if (weeks.GetInt32(12) == 1)
                    { Week12.Checked = true; }
                    if (weeks.GetInt32(13) == 1)
                    { Week13.Checked = true; }
                    if (weeks.GetInt32(14) == 1)
                    { Week14.Checked = true; }
                    if (weeks.GetInt32(15) == 1)
                    { Week15.Checked = true; }

                }
                connect.Close();

                //Sets the module title to the one from the request we are editing.
                connect.Open();
                string modnamesql = "Select moduleID from [Module] where moduleCode='" + modcode + "'";
                SqlCommand modcommand = new SqlCommand(modnamesql, connect);
                SqlDataReader modulereader = modcommand.ExecuteReader();
                int moduleTitle = 1;
                if (modulereader.Read())
                {
                    moduleTitle = modulereader.GetInt32(0);
                }
                DropDownList1.SelectedIndex = moduleTitle - 1;

                connect.Close();

                //Facilities
                List<int> facilitiesIDs = new List<int>();
                connect.Open();
                string facilitiessql = "select facilityID from [RequestFacilities] where requestID=" + requestid;
                SqlCommand facilitiescommand = new SqlCommand(facilitiessql, connect);
                SqlDataReader facilities = facilitiescommand.ExecuteReader();

                while (facilities.Read())
                {
                    facilitiesIDs.Add(facilities.GetInt32(0));
                }

                for (int i = 0; i < facilitiesIDs.Count; i++)
                {
                    if (facilitiesIDs[i] == 1)
                    {
                        RadioButtonListRoomType.SelectedIndex = 0;
                    }
                    if (facilitiesIDs[i] == 2)
                    {
                        RadioButtonListRoomType.SelectedIndex = 1;
                    }
                    if (facilitiesIDs[i] == 3)
                    {
                        RadioButtonListArrangement.SelectedIndex = 0;
                    }
                    if (facilitiesIDs[i] == 4)
                    {
                        RadioButtonListArrangement.SelectedIndex = 1;
                    }
                    if (facilitiesIDs[i] == 5)
                    {
                        RadioButtonListProjector.SelectedIndex = 0;
                    }
                    if (facilitiesIDs[i] == 6)
                    {
                        RadioButtonListProjector.SelectedIndex = 1;
                    }
                    if (facilitiesIDs[i] == 7)
                    {
                        CheckBoxCB.Checked = true;
                    }
                    if (facilitiesIDs[i] == 8)
                    {
                        CheckBoxWB.Checked = true;
                    }
                    if (facilitiesIDs[i] == 9)
                    {
                        RadioButtonListWheelchair.SelectedIndex = 0;
                    }
                    if (facilitiesIDs[i] == 10)
                    {
                        RadioButtonListVisualiser.SelectedIndex = 0;
                    }
                    if (facilitiesIDs[i] == 11)
                    {
                        RadioButtonListComputer.SelectedIndex = 0;
                    }

                }

                //Set times on the timetable
                System.Web.UI.WebControls.CheckBox[,] boxes = new System.Web.UI.WebControls.CheckBox[5, 9];
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

                if (day == "Monday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[0, i].Checked = true;
                    }
                }
                if (day == "Tuesday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[1, i].Checked = true;
                    }
                } if (day == "Wednesday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[2, i].Checked = true;
                    }
                } if (day == "Thursday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[3, i].Checked = true;
                    }
                } if (day == "Friday")
                {
                    for (int i = start - 1; i < end; i++)
                    {
                        boxes[4, i].Checked = true;
                    }
                }
                connect.Close();
                connect.Open();

                /* SQL to retrieve database data */
                string preferencesquery = "SELECT period, hr24Format, defaultLocation FROM [Preferences] WHERE userID=" + userID;
                SqlCommand preferencessql = new SqlCommand(preferencesquery, connect);
                SqlDataReader preferences = preferencessql.ExecuteReader();
                if (preferences.Read())
                {
                    /* Sets variables to retrieved data */
                    int periodText;
                    int hr24FormatText;
                    string defaultLocationText;
                    periodText = preferences.GetInt32(0);
                    hr24FormatText = preferences.GetInt32(1);
                    defaultLocationText = preferences.GetString(2);

                    //Set table column headers for periods
                    if (periodText == 1)
                    {
                        ButtonPeriod1.Text = "Period 1";
                        ButtonPeriod2.Text = "Period 2";
                        ButtonPeriod3.Text = "Period 3";
                        ButtonPeriod4.Text = "Period 4";
                        ButtonPeriod5.Text = "Period 5";
                        ButtonPeriod6.Text = "Period 6";
                        ButtonPeriod7.Text = "Period 7";
                        ButtonPeriod8.Text = "Period 8";
                        ButtonPeriod9.Text = "Period 9";
                    }
                    //Set column headers for times
                    else if (periodText == 0)
                    {
                        //24 hour format
                        if (hr24FormatText == 1)
                        {
                            ButtonPeriod1.Text = "09:00 - 09:50";
                            ButtonPeriod2.Text = "10:00 - 10:50";
                            ButtonPeriod3.Text = "11:00 - 11:50";
                            ButtonPeriod4.Text = "12:00 - 12:50";
                            ButtonPeriod5.Text = "13:00 - 13:50";
                            ButtonPeriod6.Text = "14:00 - 14:50";
                            ButtonPeriod7.Text = "15:00 - 15:50";
                            ButtonPeriod8.Text = "16:00 - 16:50";
                            ButtonPeriod9.Text = "17:00 - 17:50";
                        }
                        //12 hour format
                        else if (hr24FormatText == 0)
                        {
                            ButtonPeriod1.Text = "09:00 - 09:50";
                            ButtonPeriod2.Text = "10:00 - 10:50";
                            ButtonPeriod3.Text = "11:00 - 11:50";
                            ButtonPeriod4.Text = "12:00 - 12:50";
                            ButtonPeriod5.Text = "01:00 - 01:50";
                            ButtonPeriod6.Text = "02:00 - 02:50";
                            ButtonPeriod7.Text = "03:00 - 03:50";
                            ButtonPeriod8.Text = "04:00 - 04:50";
                            ButtonPeriod9.Text = "05:00 - 05:50";
                        }
                    }
                }
                connect.Close();
                connect.Open();
                //Find all rooms
                string findrooms = "Select roomName from [Room]";
                SqlCommand roomscommand = new SqlCommand(findrooms, connect);
                SqlDataReader rooms = roomscommand.ExecuteReader();

                DropDownListRoomsAlt.Items.Add("Please Select");
                DropDownListRooms.Items.Add("Please Select");
                //Add the results to the dropdownlist
                while (rooms.Read())
                {
                    DropDownListRooms.Items.Add(rooms.GetString(0).ToString());
                    DropDownListRoomsAlt.Items.Add(rooms.GetString(0).ToString());
                }
                connect.Close();
            }
            if (!IsPostBack)
                RadioButtonList1_SelectedIndexChanged(null, null);
        }

        public void SearchRooms()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            conn.Open();

            //Clear the dropdownlists showing the rooms at every call of the search function.
            DropDownListRooms.Items.Clear();
            DropDownListRoomsAlt.Items.Clear();
            DropDownListRooms.Items.Add("Please select");
            DropDownListRoomsAlt.Items.Add("Please select");
            /* Get the information from the page content */
            string board = "";
            string boardtwo = "";
            string roomtype = RadioButtonListRoomType.Text;

            int buildingID = 0;
            string building = DropDownListBuildings.Text;

            if (building != "")
            {
                string buildingidquery = "Select buildingID from [Building] where buildingName='" + building + "'";
                SqlCommand buildingcommand = new SqlCommand(buildingidquery, conn);
                buildingID = Convert.ToInt32(buildingcommand.ExecuteScalar().ToString());
            }
            if (roomtype == "Lecture")
            { roomtype = "1"; }
            else if (roomtype == "Seminar")
            { roomtype = "2"; }
            string arrangement = RadioButtonListArrangement.Text;
            if (arrangement == "Tiered")
            { arrangement = "3"; }
            else if (arrangement == "Flat")
            { arrangement = "4"; }
            string projector = RadioButtonListProjector.Text;
            if (projector == "Data Projector")
            { projector = "5"; }
            else if (projector == "Double Projector")
            { projector = "6"; }
            if (CheckBoxCB.Checked == true)
            { board = "7"; }
            if (CheckBoxWB.Checked == true)
            { boardtwo = "8"; }
            int wheeli = RadioButtonListWheelchair.SelectedIndex;
            int visualiseri = RadioButtonListVisualiser.SelectedIndex;
            int computeri = RadioButtonListComputer.SelectedIndex;
            string wheel;
            string visualiser;
            string computer;
            if (wheeli == 0)
                wheel = "9";
            else
                wheel = "";
            if (visualiseri == 0)
                visualiser = "10";
            else
                visualiser = "";
            if (computeri == 0)
                computer = "11";
            else
                computer = "";

            /* Make SQL addition for if any facilities have been selected */
            string facilitysql = "";
            if (roomtype != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + roomtype + ")";
            if (arrangement != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + arrangement + ")";
            if (projector != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + projector + ")";
            if (wheel != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + wheel + ")";
            if (visualiser != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + visualiser + ")";
            if (computer != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + computer + ")";
            if (board != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + board + ")";
            if (boardtwo != "")
                facilitysql += " AND RoomID IN (SELECT DISTINCT RoomID FROM [RoomFacilities] WHERE facilityID = " + boardtwo + ")";
            if (building != "")
                facilitysql += " AND [Building].buildingID=" + buildingID;

            string roomquery = "";
            /* SQL to find rooms */
            if (TextBoxCapacity.Text != "")
            {
                int number = 0;
                bool isNumeric = int.TryParse(TextBoxCapacity.Text, out number);
                if (isNumeric)
                {
                    roomquery = "SELECT roomName FROM [Room] LEFT JOIN [Building] ON [Room].buildingID = [Building].buildingID LEFT JOIN [Park] ON [Building].parkID = [Park].parkID WHERE [Room].capacity >='" + TextBoxCapacity.Text + "' AND [Park].parkName ='" + RadioButtonList1.Text + "'";
                }
                else
                    roomquery = "SELECT roomName FROM [Room] LEFT JOIN [Building] ON [Room].buildingID = [Building].buildingID LEFT JOIN [Park] ON [Building].parkID = [Park].parkID WHERE [Park].parkName ='" + RadioButtonList1.Text + "'";
            }
            else
                roomquery = "SELECT roomName FROM [Room] LEFT JOIN [Building] ON [Room].buildingID = [Building].buildingID LEFT JOIN [Park] ON [Building].parkID = [Park].parkID WHERE [Park].parkName ='" + RadioButtonList1.Text + "'";
            /* Add facilities information if any were selected */
            if (facilitysql != "")
                roomquery += facilitysql;


            SqlCommand roomsql = new SqlCommand(roomquery, conn);
            SqlDataReader rooms = roomsql.ExecuteReader();
            while (rooms.Read())
            {
                DropDownListRooms.Items.Add(rooms.GetString(0).ToString());
                DropDownListRoomsAlt.Items.Add(rooms.GetString(0).ToString());
            }
            conn.Close();
        }

        //Submit Request button
        protected void Button1_Click(object sender, EventArgs e)
        {
            //VALIDATION
            errorMessage.Text = "";
            int number = 0;
            bool isNumeric = int.TryParse(TextBoxCapacity.Text, out number);
            if (isNumeric)
            {
                if (Convert.ToInt32(TextBoxCapacity.Text) > 0)
                {
                    if (!((LabelRoom3.Text == "None") && (LabelRoom2.Text == "None") && (LabelRoom1.Text == "None")))
                    {
                        if (!((Week1.Checked == false) && (Week2.Checked == false) && (Week3.Checked == false) && (Week4.Checked == false) && (Week5.Checked == false) && (Week6.Checked == false) && (Week7.Checked == false) && (Week8.Checked == false) && (Week9.Checked == false) && (Week10.Checked == false) && (Week11.Checked == false) && (Week12.Checked == false) && (Week13.Checked == false) && (Week14.Checked == false) && (Week15.Checked == false)))
                        {
                            if (!((CheckBoxM1.Checked == false) && (CheckBoxM2.Checked == false) && (CheckBoxM3.Checked == false) && (CheckBoxM4.Checked == false) && (CheckBoxM5.Checked == false) && (CheckBoxM6.Checked == false) && (CheckBoxM7.Checked == false) && (CheckBoxM8.Checked == false) && (CheckBoxM9.Checked == false) && (CheckBoxT1.Checked == false) && (CheckBoxT2.Checked == false) && (CheckBoxT3.Checked == false) && (CheckBoxT4.Checked == false) && (CheckBoxT5.Checked == false) && (CheckBoxT6.Checked == false) && (CheckBoxT7.Checked == false) && (CheckBoxT8.Checked == false) && (CheckBoxT9.Checked == false) && (CheckBoxW1.Checked == false) && (CheckBoxW2.Checked == false) && (CheckBoxW3.Checked == false) && (CheckBoxW4.Checked == false) && (CheckBoxW5.Checked == false) && (CheckBoxW6.Checked == false) && (CheckBoxW7.Checked == false) && (CheckBoxW8.Checked == false) && (CheckBoxW9.Checked == false) && (CheckBoxJ1.Checked == false) && (CheckBoxJ2.Checked == false) && (CheckBoxJ3.Checked == false) && (CheckBoxJ4.Checked == false) && (CheckBoxJ5.Checked == false) && (CheckBoxJ6.Checked == false) && (CheckBoxJ7.Checked == false) && (CheckBoxJ8.Checked == false) && (CheckBoxJ9.Checked == false) && (CheckBoxF1.Checked == false) && (CheckBoxF2.Checked == false) && (CheckBoxF3.Checked == false) && (CheckBoxF4.Checked == false) && (CheckBoxF5.Checked == false) && (CheckBoxF6.Checked == false) && (CheckBoxF7.Checked == false) && (CheckBoxF8.Checked == false) && (CheckBoxF9.Checked == false)))
                            {
                                /* Get the module code from the selected module title */
                                string moduleTitleText = DropDownList1.SelectedValue;
                                string moduleCodeText = "";
                                int charindex = moduleTitleText.IndexOf(":") - 1;
                                if (charindex > 0)
                                {
                                    moduleCodeText = moduleTitleText.Substring(0, charindex);
                                }
                                string edit = Request.QueryString["edit"];
                                if (edit == "1")
                                {
                                    SqlConnection connection12 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                    connection12.Open();
                                    string deleterequest = "DELETE FROM [Request] WHERE requestID=" + requestid;
                                    string deletebooked = "DELETE FROM [BookedRoom] WHERE requestID=" + requestid;
                                    string deletepreferred = "DELETE FROM [PreferredRoom] WHERE requestID=" + requestid;
                                    string deletefacilities = "DELETE FROM [RequestFacilities] WHERE requestID=" + requestid;
                                    SqlCommand deletefacilitiessql = new SqlCommand(deletefacilities, connection12);
                                    

                                    SqlCommand deletebookedsql = new SqlCommand(deletebooked, connection12);

                                    SqlCommand deletepreferredsql = new SqlCommand(deletepreferred, connection12);
                                    SqlCommand deleterequestsql = new SqlCommand(deleterequest, connection12);
                                    

                                    
                                    deletebookedsql.ExecuteNonQuery();
                                    deletepreferredsql.ExecuteNonQuery();
                                    deletefacilitiessql.ExecuteNonQuery();
                                    deleterequestsql.ExecuteNonQuery();
                                }

                                int semesterText = 2;

                                /*Initialise week variables*/
                                int week1;
                                int week2;
                                int week3;
                                int week4;
                                int week5;
                                int week6;
                                int week7;
                                int week8;
                                int week9;
                                int week10;
                                int week11;
                                int week12;
                                int week13;
                                int week14;
                                int week15;
                                /*Set week variable to 1 or 0 based on selection*/
                                if (Week1.Checked == true)
                                    week1 = 1;
                                else
                                    week1 = 0;
                                if (Week2.Checked == true)
                                    week2 = 1;
                                else
                                    week2 = 0;
                                if (Week3.Checked == true)
                                    week3 = 1;
                                else
                                    week3 = 0;
                                if (Week4.Checked == true)
                                    week4 = 1;
                                else
                                    week4 = 0;
                                if (Week5.Checked == true)
                                    week5 = 1;
                                else
                                    week5 = 0;
                                if (Week6.Checked == true)
                                    week6 = 1;
                                else
                                    week6 = 0;
                                if (Week7.Checked == true)
                                    week7 = 1;
                                else
                                    week7 = 0;
                                if (Week8.Checked == true)
                                    week8 = 1;
                                else
                                    week8 = 0;
                                if (Week9.Checked == true)
                                    week9 = 1;
                                else
                                    week9 = 0;
                                if (Week10.Checked == true)
                                    week10 = 1;
                                else
                                    week10 = 0;
                                if (Week11.Checked == true)
                                    week11 = 1;
                                else
                                    week11 = 0;
                                if (Week12.Checked == true)
                                    week12 = 1;
                                else
                                    week12 = 0;
                                if (Week13.Checked == true)
                                    week13 = 1;
                                else
                                    week13 = 0;
                                if (Week14.Checked == true)
                                    week14 = 1;
                                else
                                    week14 = 0;
                                if (Week15.Checked == true)
                                    week15 = 1;
                                else
                                    week15 = 0;

                                /* Find a weekID relating to week selection */
                                int weekIDText;
                                string weekquery = "SELECT COUNT(weekID) FROM [Week] WHERE week1= " + week1 + " AND week2= " + week2 + " AND week3= " + week3 + " AND week4= " + week4 + " AND week5= " + week5 + " AND week6= " + week6 + " AND week7= " + week7 + " AND week8= " + week8 + " AND week9= " + week9 + " AND week10= " + week10 + " AND week11= " + week11 + " AND week12= " + week12 + " AND week13= " + week13 + " AND week14= " + week14 + " AND week15= " + week15;
                                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                connection.Open();
                                SqlCommand weeksql = new SqlCommand(weekquery, connection);
                                int testtwo = Convert.ToInt32(weeksql.ExecuteScalar().ToString());
                                connection.Close();

                                /* If there is a corresponding weekID in database, select it */
                                if (testtwo != 0)
                                {
                                    string weekquery2 = "SELECT weekID FROM [Week] WHERE week1= " + week1 + " AND week2= " + week2 + " AND week3= " + week3 + " AND week4= " + week4 + " AND week5= " + week5 + " AND week6= " + week6 + " AND week7= " + week7 + " AND week8= " + week8 + " AND week9= " + week9 + " AND week10= " + week10 + " AND week11= " + week11 + " AND week12= " + week12 + " AND week13= " + week13 + " AND week14= " + week14 + " AND week15= " + week15;
                                    SqlConnection connection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                    connection2.Open();
                                    SqlCommand weeksql2 = new SqlCommand(weekquery2, connection2);
                                    weekIDText = Convert.ToInt32(weeksql2.ExecuteScalar().ToString());
                                    connection2.Close();
                                }
                                /* If there is no corresponding weekID, make a new one and use that */
                                else
                                {
                                    string insweekquery = "INSERT INTO [Week] VALUES(" + week1 + "," + week2 + "," + week3 + "," + week4 + "," + week5 + "," + week6 + "," + week7 + "," + week8 + "," + week9 + "," + week10 + "," + week11 + "," + week12 + "," + week13 + "," + week14 + "," + week15 + ")";
                                    SqlConnection conne = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                    conne.Open();
                                    SqlCommand insweeksql = new SqlCommand(insweekquery, conne);
                                    insweeksql.ExecuteNonQuery();
                                    conne.Close();
                                    string newweek = "SELECT MAX(weekID) FROM [Week]";
                                    SqlConnection connec = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                    connec.Open();
                                    SqlCommand maxweeksql = new SqlCommand(newweek, connec);
                                    weekIDText = Convert.ToInt32(maxweeksql.ExecuteScalar().ToString());
                                    connec.Close();
                                }

                                /* Make  an array for each day storing each period */
                                bool[] mondayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
                                if (CheckBoxM1.Checked == true)
                                    mondayrequest[0] = true;
                                if (CheckBoxM2.Checked == true)
                                    mondayrequest[1] = true;
                                if (CheckBoxM3.Checked == true)
                                    mondayrequest[2] = true;
                                if (CheckBoxM4.Checked == true)
                                    mondayrequest[3] = true;
                                if (CheckBoxM5.Checked == true)
                                    mondayrequest[4] = true;
                                if (CheckBoxM6.Checked == true)
                                    mondayrequest[5] = true;
                                if (CheckBoxM7.Checked == true)
                                    mondayrequest[6] = true;
                                if (CheckBoxM8.Checked == true)
                                    mondayrequest[7] = true;
                                if (CheckBoxM9.Checked == true)
                                    mondayrequest[8] = true;

                                bool[] tuesdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
                                if (CheckBoxT1.Checked == true)
                                    tuesdayrequest[0] = true;
                                if (CheckBoxT2.Checked == true)
                                    tuesdayrequest[1] = true;
                                if (CheckBoxT3.Checked == true)
                                    tuesdayrequest[2] = true;
                                if (CheckBoxT4.Checked == true)
                                    tuesdayrequest[3] = true;
                                if (CheckBoxT5.Checked == true)
                                    tuesdayrequest[4] = true;
                                if (CheckBoxT6.Checked == true)
                                    tuesdayrequest[5] = true;
                                if (CheckBoxT7.Checked == true)
                                    tuesdayrequest[6] = true;
                                if (CheckBoxT8.Checked == true)
                                    tuesdayrequest[7] = true;
                                if (CheckBoxT9.Checked == true)
                                    tuesdayrequest[8] = true;

                                bool[] wednesdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
                                if (CheckBoxW1.Checked == true)
                                    wednesdayrequest[0] = true;
                                if (CheckBoxW2.Checked == true)
                                    wednesdayrequest[1] = true;
                                if (CheckBoxW3.Checked == true)
                                    wednesdayrequest[2] = true;
                                if (CheckBoxW4.Checked == true)
                                    wednesdayrequest[3] = true;
                                if (CheckBoxW5.Checked == true)
                                    wednesdayrequest[4] = true;
                                if (CheckBoxW6.Checked == true)
                                    wednesdayrequest[5] = true;
                                if (CheckBoxW7.Checked == true)
                                    wednesdayrequest[6] = true;
                                if (CheckBoxW8.Checked == true)
                                    wednesdayrequest[7] = true;
                                if (CheckBoxW9.Checked == true)
                                    wednesdayrequest[8] = true;

                                bool[] thursdayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
                                if (CheckBoxJ1.Checked == true)
                                    thursdayrequest[0] = true;
                                if (CheckBoxJ2.Checked == true)
                                    thursdayrequest[1] = true;
                                if (CheckBoxJ3.Checked == true)
                                    thursdayrequest[2] = true;
                                if (CheckBoxJ4.Checked == true)
                                    thursdayrequest[3] = true;
                                if (CheckBoxJ5.Checked == true)
                                    thursdayrequest[4] = true;
                                if (CheckBoxJ6.Checked == true)
                                    thursdayrequest[5] = true;
                                if (CheckBoxJ7.Checked == true)
                                    thursdayrequest[6] = true;
                                if (CheckBoxJ8.Checked == true)
                                    thursdayrequest[7] = true;
                                if (CheckBoxJ9.Checked == true)
                                    thursdayrequest[8] = true;

                                bool[] fridayrequest = new bool[10] { false, false, false, false, false, false, false, false, false, false };
                                if (CheckBoxF1.Checked == true)
                                    fridayrequest[0] = true;
                                if (CheckBoxF2.Checked == true)
                                    fridayrequest[1] = true;
                                if (CheckBoxF3.Checked == true)
                                    fridayrequest[2] = true;
                                if (CheckBoxF4.Checked == true)
                                    fridayrequest[3] = true;
                                if (CheckBoxF5.Checked == true)
                                    fridayrequest[4] = true;
                                if (CheckBoxF6.Checked == true)
                                    fridayrequest[5] = true;
                                if (CheckBoxF7.Checked == true)
                                    fridayrequest[6] = true;
                                if (CheckBoxF8.Checked == true)
                                    fridayrequest[7] = true;
                                if (CheckBoxF9.Checked == true)
                                    fridayrequest[8] = true;

                                /*Make a list of every selected room*/
                                int numberOfRooms = 0;
                                int numberAltRooms = 0;

                                string label = "None";
                                bool l1 = LabelRoom1.Text.Equals(label);
                                bool l2 = LabelRoom2.Text.Equals(label);
                                bool l3 = LabelRoom3.Text.Equals(label);
                                if (!l1) { numberOfRooms++; }
                                if (!l2) { numberOfRooms++; }
                                if (!l3) { numberOfRooms++; }
                                string roomname = LabelRoom1.Text;
                                string roomname2 = LabelRoom2.Text;
                                string roomname3 = LabelRoom3.Text;

                                bool l1alt = LabelRoomAlt1.Text.Equals(label);
                                bool l2alt = LabelRoomAlt2.Text.Equals(label);
                                bool l3alt = LabelRoomAlt3.Text.Equals(label);
                                if (!l1alt) { numberAltRooms++; }
                                if (!l2alt) { numberAltRooms++; }
                                if (!l3alt) { numberAltRooms++; }
                                string roomnamealt = LabelRoomAlt1.Text;
                                string roomname2alt = LabelRoomAlt2.Text;
                                string roomname3alt = LabelRoomAlt3.Text;
                                int roomid1Alt;
                                int roomid2Alt;
                                int roomid3Alt;
                                List<int> roomlistAlt = new List<int>();

                                int roomid;
                                int roomid2;
                                int roomid3;

                                List<int> roomlist = new List<int>();
                                if (numberOfRooms == 1)
                                {
                                    if (roomname != "")
                                    {
                                        string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + roomname + "'";
                                        SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection7.Open();
                                        SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
                                        roomid = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());
                                        connection7.Close();
                                        roomlist.Add(roomid);
                                    }
                                }
                                else if (numberOfRooms == 2)
                                {
                                    if (roomname != "")
                                    {
                                        string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + roomname + "'";
                                        SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection7.Open();
                                        SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
                                        roomid = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());
                                        connection7.Close();
                                        roomlist.Add(roomid);
                                    }
                                    if (roomname2 != "")
                                    {
                                        string getroomid2 = "SELECT roomID FROM [Room] WHERE roomName='" + roomname2 + "'";
                                        SqlConnection connection72 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection72.Open();
                                        SqlCommand getroomidsql2 = new SqlCommand(getroomid2, connection72);
                                        roomid2 = Convert.ToInt32(getroomidsql2.ExecuteScalar().ToString());
                                        connection72.Close();
                                        roomlist.Add(roomid2);
                                    }
                                }
                                else if (numberOfRooms == 3)
                                {
                                    if (roomname != "")
                                    {
                                        string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + roomname + "'";
                                        SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection7.Open();
                                        SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
                                        roomid = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());
                                        connection7.Close();
                                        roomlist.Add(roomid);
                                    }
                                    if (roomname2 != "")
                                    {
                                        string getroomid2 = "SELECT roomID FROM [Room] WHERE roomName='" + roomname2 + "'";
                                        SqlConnection connection72 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection72.Open();
                                        SqlCommand getroomidsql2 = new SqlCommand(getroomid2, connection72);
                                        roomid2 = Convert.ToInt32(getroomidsql2.ExecuteScalar().ToString());
                                        connection72.Close();
                                        roomlist.Add(roomid2);
                                    }
                                    if (roomname3 != "")
                                    {
                                        string getroomid3 = "SELECT roomID FROM [Room] WHERE roomName='" + roomname3 + "'";
                                        SqlConnection connection73 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection73.Open();
                                        SqlCommand getroomidsql3 = new SqlCommand(getroomid3, connection73);
                                        roomid3 = Convert.ToInt32(getroomidsql3.ExecuteScalar().ToString());
                                        connection73.Close();
                                        roomlist.Add(roomid3);
                                    }
                                }
                                /*Makes a list of all the facilityIDs selected*/
                                string board = "";
                                string boardtwo = "";
                                int roomtype = RadioButtonListRoomType.SelectedIndex;
                                int arrangement = RadioButtonListArrangement.SelectedIndex;
                                int projector = RadioButtonListProjector.SelectedIndex;
                                if (CheckBoxCB.Checked == true)
                                    board = "ChalkBoard";
                                if (CheckBoxWB.Checked == true)
                                    boardtwo = "WhiteBoard";
                                string wheel = RadioButtonListWheelchair.SelectedValue;
                                string visualiser = RadioButtonListVisualiser.SelectedValue;
                                string computer = RadioButtonListComputer.SelectedValue;
                                string reqfac = "";
                                List<int> list = new List<int>();
                                if (roomtype != -1)
                                    list.Add(roomtype + 1);
                                if (arrangement != -1)
                                    list.Add(arrangement + 3);
                                if (projector != -1)
                                    list.Add(projector + 5);
                                if (wheel == "Yes")
                                    list.Add(9);
                                if (visualiser == "Yes")
                                    list.Add(10);
                                if (computer == "Yes")
                                    list.Add(11);
                                if (board != "")
                                    list.Add(7);
                                if (boardtwo != "")
                                    list.Add(8);

                                /* Cycle through each array and, if any were selected, create a request with that data */
                                /* The while loops find any multiple period requests */
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
                                                    string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Pending'," + weekIDText + ",'Monday'," + startTime + "," + endTime + "," + semesterText + ",2014,1)";
                                                    SqlConnection connection6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                    connection6.Open();
                                                    SqlCommand insreqsql = new SqlCommand(insreq, connection6);
                                                    insreqsql.ExecuteNonQuery();
                                                    connection6.Close();
                                                    string booked = "";
                                                    if (roomlist.Count != 0)
                                                    {
                                                        SqlConnection conn2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn2.Open();
                                                        for (int y = 0; y < roomlist.Count; y++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomlist[y] + ")";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn2);
                                                            bookedsql.ExecuteNonQuery();
                                                        }

                                                        conn2.Close();
                                                    }
                                                    else
                                                    {
                                                        SqlConnection conn4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn4.Open();
                                                        for (int x = 0; x < numberOfRooms; x++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request]),(SELECT roomID FROM [Room] WHERE roomName='" + DropDownListRooms.Items[x].Value + "'))";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn4);
                                                            bookedsql.ExecuteNonQuery();
                                                        }
                                                        conn4.Close();
                                                    }
                                                    if (list.Count != 0)
                                                    {
                                                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn.Open();
                                                        for (int z = 0; z < list.Count; z++)
                                                        {
                                                            reqfac = "INSERT INTO [RequestFacilities] VALUES ((SELECT MAX(requestID) FROM [Request])," + list[z] + ")";
                                                            SqlCommand reqfacsql = new SqlCommand(reqfac, conn);
                                                            reqfacsql.ExecuteNonQuery();
                                                        }
                                                        conn.Close();
                                                    }
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
                                                    string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Pending'," + weekIDText + ",'Tuesday'," + startTime + "," + endTime + "," + semesterText + ",2014,1)";
                                                    SqlConnection connection6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                    connection6.Open();
                                                    SqlCommand insreqsql = new SqlCommand(insreq, connection6);
                                                    insreqsql.ExecuteNonQuery();
                                                    connection6.Close();
                                                    string booked = "";
                                                    if (roomlist.Count != 0)
                                                    {
                                                        SqlConnection conn2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn2.Open();
                                                        for (int y = 0; y < roomlist.Count; y++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomlist[y] + ")";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn2);
                                                            bookedsql.ExecuteNonQuery();
                                                        }

                                                        conn2.Close();
                                                    }
                                                    else
                                                    {
                                                        SqlConnection conn4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn4.Open();
                                                        for (int x = 0; x < numberOfRooms; x++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request]),(SELECT roomID FROM [Room] WHERE roomName='" + DropDownListRooms.Items[x].Value + "'))";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn4);
                                                            bookedsql.ExecuteNonQuery();
                                                        }
                                                        conn4.Close();
                                                    }
                                                    if (list.Count != 0)
                                                    {
                                                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn.Open();
                                                        for (int z = 0; z < list.Count; z++)
                                                        {
                                                            reqfac = "INSERT INTO [RequestFacilities] VALUES ((SELECT MAX(requestID) FROM [Request])," + list[z] + ")";
                                                            SqlCommand reqfacsql = new SqlCommand(reqfac, conn);
                                                            reqfacsql.ExecuteNonQuery();
                                                        }
                                                        conn.Close();
                                                    }
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
                                                    string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Pending'," + weekIDText + ",'Wednesday'," + startTime + "," + endTime + "," + semesterText + ",2014,1)";
                                                    SqlConnection connection6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                    connection6.Open();
                                                    SqlCommand insreqsql = new SqlCommand(insreq, connection6);
                                                    insreqsql.ExecuteNonQuery();
                                                    connection6.Close();
                                                    string booked = "";
                                                    if (roomlist.Count != 0)
                                                    {
                                                        SqlConnection conn2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn2.Open();
                                                        for (int y = 0; y < roomlist.Count; y++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomlist[y] + ")";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn2);
                                                            bookedsql.ExecuteNonQuery();
                                                        }

                                                        conn2.Close();
                                                    }
                                                    else
                                                    {
                                                        SqlConnection conn4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn4.Open();
                                                        for (int x = 0; x < numberOfRooms; x++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request]),(SELECT roomID FROM [Room] WHERE roomName='" + DropDownListRooms.Items[x].Value + "'))";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn4);
                                                            bookedsql.ExecuteNonQuery();
                                                        }
                                                        conn4.Close();
                                                    }
                                                    if (list.Count != 0)
                                                    {
                                                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn.Open();
                                                        for (int z = 0; z < list.Count; z++)
                                                        {
                                                            reqfac = "INSERT INTO [RequestFacilities] VALUES ((SELECT MAX(requestID) FROM [Request])," + list[z] + ")";
                                                            SqlCommand reqfacsql = new SqlCommand(reqfac, conn);
                                                            reqfacsql.ExecuteNonQuery();
                                                        }
                                                        conn.Close();
                                                    }
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
                                                    string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Pending'," + weekIDText + ",'Thursday'," + startTime + "," + endTime + "," + semesterText + ",2014,1)";
                                                    SqlConnection connection6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                    connection6.Open();
                                                    SqlCommand insreqsql = new SqlCommand(insreq, connection6);
                                                    insreqsql.ExecuteNonQuery();
                                                    connection6.Close();
                                                    string booked = "";
                                                    if (roomlist.Count != 0)
                                                    {
                                                        SqlConnection conn2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn2.Open();
                                                        for (int y = 0; y < roomlist.Count; y++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomlist[y] + ")";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn2);
                                                            bookedsql.ExecuteNonQuery();
                                                        }

                                                        conn2.Close();
                                                    }
                                                    else
                                                    {
                                                        SqlConnection conn4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn4.Open();
                                                        for (int x = 0; x < numberOfRooms; x++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request]),(SELECT roomID FROM [Room] WHERE roomName='" + DropDownListRooms.Items[x].Value + "'))";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn4);
                                                            bookedsql.ExecuteNonQuery();
                                                        }
                                                        conn4.Close();
                                                    }
                                                    if (list.Count != 0)
                                                    {
                                                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn.Open();
                                                        for (int z = 0; z < list.Count; z++)
                                                        {
                                                            reqfac = "INSERT INTO [RequestFacilities] VALUES ((SELECT MAX(requestID) FROM [Request])," + list[z] + ")";
                                                            SqlCommand reqfacsql = new SqlCommand(reqfac, conn);
                                                            reqfacsql.ExecuteNonQuery();
                                                        }
                                                        conn.Close();
                                                    }
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
                                                    string insreq = "INSERT INTO [Request] VALUES ('" + moduleCodeText + "','Pending'," + weekIDText + ",'Friday'," + startTime + "," + endTime + "," + semesterText + ",2014,1)";
                                                    SqlConnection connection6 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                    connection6.Open();
                                                    SqlCommand insreqsql = new SqlCommand(insreq, connection6);
                                                    insreqsql.ExecuteNonQuery();
                                                    connection6.Close();
                                                    string booked = "";
                                                    if (roomlist.Count != 0)
                                                    {
                                                        SqlConnection conn2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn2.Open();
                                                        for (int y = 0; y < roomlist.Count; y++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request])," + roomlist[y] + ")";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn2);
                                                            bookedsql.ExecuteNonQuery();
                                                        }

                                                        conn2.Close();
                                                    }
                                                    else
                                                    {
                                                        SqlConnection conn4 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn4.Open();
                                                        for (int x = 0; x < numberOfRooms; x++)
                                                        {
                                                            booked = "INSERT INTO [BookedRoom] VALUES ((SELECT MAX(requestID) FROM [Request]),(SELECT roomID FROM [Room] WHERE roomName='" + DropDownListRooms.Items[x].Value + "'))";
                                                            SqlCommand bookedsql = new SqlCommand(booked, conn4);
                                                            bookedsql.ExecuteNonQuery();
                                                        }
                                                        conn4.Close();
                                                    }
                                                    if (list.Count != 0)
                                                    {
                                                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                                        conn.Open();
                                                        for (int z = 0; z < list.Count; z++)
                                                        {
                                                            reqfac = "INSERT INTO [RequestFacilities] VALUES ((SELECT MAX(requestID) FROM [Request])," + list[z] + ")";
                                                            SqlCommand reqfacsql = new SqlCommand(reqfac, conn);
                                                            reqfacsql.ExecuteNonQuery();
                                                        }
                                                        conn.Close();
                                                    }
                                                    ended = false;
                                                    break;
                                            }
                                        }
                                    }
                                }


                                if (numberAltRooms == 1)
                                {
                                    if (roomnamealt != "")
                                    {
                                        string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + roomnamealt + "'";
                                        SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection7.Open();
                                        SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
                                        roomid1Alt = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());
                                        connection7.Close();
                                        roomlistAlt.Add(roomid1Alt);
                                    }
                                }
                                else if (numberAltRooms == 2)
                                {
                                    if (roomnamealt != "")
                                    {
                                        string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + roomnamealt + "'";
                                        SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection7.Open();
                                        SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
                                        roomid1Alt = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());
                                        connection7.Close();
                                        roomlistAlt.Add(roomid1Alt);
                                    }
                                    if (roomname2alt != "")
                                    {
                                        string getroomid2 = "SELECT roomID FROM [Room] WHERE roomName='" + roomname2alt + "'";
                                        SqlConnection connection72 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection72.Open();
                                        SqlCommand getroomidsql2 = new SqlCommand(getroomid2, connection72);
                                        roomid2Alt = Convert.ToInt32(getroomidsql2.ExecuteScalar().ToString());
                                        connection72.Close();
                                        roomlistAlt.Add(roomid2Alt);
                                    }
                                }
                                else if (numberAltRooms == 3)
                                {
                                    if (roomnamealt != "")
                                    {
                                        string getroomid = "SELECT roomID FROM [Room] WHERE roomName='" + roomnamealt + "'";
                                        SqlConnection connection7 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection7.Open();
                                        SqlCommand getroomidsql = new SqlCommand(getroomid, connection7);
                                        roomid1Alt = Convert.ToInt32(getroomidsql.ExecuteScalar().ToString());
                                        connection7.Close();
                                        roomlistAlt.Add(roomid1Alt);
                                    }
                                    if (roomname2alt != "")
                                    {
                                        string getroomid2 = "SELECT roomID FROM [Room] WHERE roomName='" + roomname2alt + "'";
                                        SqlConnection connection72 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection72.Open();
                                        SqlCommand getroomidsql2 = new SqlCommand(getroomid2, connection72);
                                        roomid2Alt = Convert.ToInt32(getroomidsql2.ExecuteScalar().ToString());
                                        connection72.Close();
                                        roomlistAlt.Add(roomid2Alt);
                                    }
                                    if (roomname3alt != "")
                                    {
                                        string getroomid3 = "SELECT roomID FROM [Room] WHERE roomName='" + roomname3alt + "'";
                                        SqlConnection connection73 = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                                        connection73.Open();
                                        SqlCommand getroomidsql3 = new SqlCommand(getroomid3, connection73);
                                        roomid3Alt = Convert.ToInt32(getroomidsql3.ExecuteScalar().ToString());
                                        connection73.Close();
                                        roomlistAlt.Add(roomid3Alt);
                                    }
                                }

                                int altroomcount = roomlistAlt.Count;
                                for (int i = 0; i < altroomcount; i++)
                                {
                                    int RoomToAdd = roomlistAlt[i];

                                    connection.Open();
                                    string altroomsql = "Insert into [PreferredRoom] values((SELECT MAX(requestID) FROM [Request])," + RoomToAdd + ")";
                                    SqlCommand altroomcommand = new SqlCommand(altroomsql, connection);
                                    altroomcommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                                //Messagebox

                                
                                clearEverything();
                            }
                            else
                                errorMessage.Text = "Please Select At Least One Period.";
                        }
                        else
                            errorMessage.Text = "Please Select At Least One Week.";
                    }
                    else
                        errorMessage.Text = "Please Select At Least One Room.";
                }
                else
                    errorMessage.Text = "Please Select a Valid Capacity.";
            }
            else
                errorMessage.Text = "Please Enter a Number for Capacity.";
        }


        protected void All_Click(object sender, EventArgs e)
        {
            Week1.Checked = true;
            Week2.Checked = true;
            Week3.Checked = true;
            Week4.Checked = true;
            Week5.Checked = true;
            Week6.Checked = true;
            Week7.Checked = true;
            Week8.Checked = true;
            Week9.Checked = true;
            Week10.Checked = true;
            Week11.Checked = true;
            Week12.Checked = true;
            Week13.Checked = true;
            Week14.Checked = true;
            Week15.Checked = true;
        }

        protected void Twelve_Click(object sender, EventArgs e)
        {
            Week1.Checked = true;
            Week2.Checked = true;
            Week3.Checked = true;
            Week4.Checked = true;
            Week5.Checked = true;
            Week6.Checked = true;
            Week7.Checked = true;
            Week8.Checked = true;
            Week9.Checked = true;
            Week10.Checked = true;
            Week11.Checked = true;
            Week12.Checked = true;
            Week13.Checked = false;
            Week14.Checked = false;
            Week15.Checked = false;
        }

        protected void Odd_Click(object sender, EventArgs e)
        {
            Week1.Checked = true;
            Week3.Checked = true;
            Week5.Checked = true;
            Week7.Checked = true;
            Week9.Checked = true;
            Week11.Checked = true;
            Week13.Checked = true;
            Week15.Checked = true;
            Week2.Checked = false;
            Week4.Checked = false;
            Week6.Checked = false;
            Week8.Checked = false;
            Week10.Checked = false;
            Week12.Checked = false;
            Week14.Checked = false;
        }

        protected void Even_Click(object sender, EventArgs e)
        {
            Week2.Checked = true;
            Week4.Checked = true;
            Week6.Checked = true;
            Week8.Checked = true;
            Week10.Checked = true;
            Week12.Checked = true;
            Week14.Checked = true;
            Week1.Checked = false;
            Week3.Checked = false;
            Week5.Checked = false;
            Week7.Checked = false;
            Week9.Checked = false;
            Week11.Checked = false;
            Week13.Checked = false;
            Week15.Checked = false;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            Week1.Checked = false;
            Week2.Checked = false;
            Week3.Checked = false;
            Week4.Checked = false;
            Week5.Checked = false;
            Week6.Checked = false;
            Week7.Checked = false;
            Week8.Checked = false;
            Week9.Checked = false;
            Week10.Checked = false;
            Week11.Checked = false;
            Week12.Checked = false;
            Week13.Checked = false;
            Week14.Checked = false;
            Week15.Checked = false;
        }

        int mondayway = 0;
        protected void ButtonMonday_Click(object sender, EventArgs e)
        {
            if (mondayway == 0)
            {
                CheckBoxM1.Checked = true;
                CheckBoxM2.Checked = true;
                CheckBoxM3.Checked = true;
                CheckBoxM4.Checked = true;
                CheckBoxM5.Checked = true;
                CheckBoxM6.Checked = true;
                CheckBoxM7.Checked = true;
                CheckBoxM8.Checked = true;
                CheckBoxM9.Checked = true;
                mondayway = 1;
            }
            else
            {
                CheckBoxM1.Checked = false;
                CheckBoxM2.Checked = false;
                CheckBoxM3.Checked = false;
                CheckBoxM4.Checked = false;
                CheckBoxM5.Checked = false;
                CheckBoxM6.Checked = false;
                CheckBoxM7.Checked = false;
                CheckBoxM8.Checked = false;
                CheckBoxM9.Checked = false;
                mondayway = 0;
            }

        }

        int tuesdayway = 0;
        protected void ButtonTuesday_Click(object sender, EventArgs e)
        {
            if (tuesdayway == 0)
            {
                CheckBoxT1.Checked = true;
                CheckBoxT2.Checked = true;
                CheckBoxT3.Checked = true;
                CheckBoxT4.Checked = true;
                CheckBoxT5.Checked = true;
                CheckBoxT6.Checked = true;
                CheckBoxT7.Checked = true;
                CheckBoxT8.Checked = true;
                CheckBoxT9.Checked = true;
                tuesdayway = 1;
            }
            else
            {
                CheckBoxT1.Checked = false;
                CheckBoxT2.Checked = false;
                CheckBoxT3.Checked = false;
                CheckBoxT4.Checked = false;
                CheckBoxT5.Checked = false;
                CheckBoxT6.Checked = false;
                CheckBoxT7.Checked = false;
                CheckBoxT8.Checked = false;
                CheckBoxT9.Checked = false;
                tuesdayway = 0;
            }
        }

        int wednesdayway = 0;
        protected void ButtonWednesday_Click(object sender, EventArgs e)
        {
            if (wednesdayway == 0)
            {
                CheckBoxW1.Checked = true;
                CheckBoxW2.Checked = true;
                CheckBoxW3.Checked = true;
                CheckBoxW4.Checked = true;
                CheckBoxW5.Checked = true;
                CheckBoxW6.Checked = true;
                CheckBoxW7.Checked = true;
                CheckBoxW8.Checked = true;
                CheckBoxW9.Checked = true;
                wednesdayway = 1;
            }
            else
            {
                CheckBoxW1.Checked = false;
                CheckBoxW2.Checked = false;
                CheckBoxW3.Checked = false;
                CheckBoxW4.Checked = false;
                CheckBoxW5.Checked = false;
                CheckBoxW6.Checked = false;
                CheckBoxW7.Checked = false;
                CheckBoxW8.Checked = false;
                CheckBoxW9.Checked = false;
                wednesdayway = 0;
            }
        }

        int thursdayway = 0;
        protected void ButtonThursday_Click(object sender, EventArgs e)
        {
            if (thursdayway == 0)
            {
                CheckBoxJ1.Checked = true;
                CheckBoxJ2.Checked = true;
                CheckBoxJ3.Checked = true;
                CheckBoxJ4.Checked = true;
                CheckBoxJ5.Checked = true;
                CheckBoxJ6.Checked = true;
                CheckBoxJ7.Checked = true;
                CheckBoxJ8.Checked = true;
                CheckBoxJ9.Checked = true;
                thursdayway = 1;
            }
            else
            {
                CheckBoxJ1.Checked = false;
                CheckBoxJ2.Checked = false;
                CheckBoxJ3.Checked = false;
                CheckBoxJ4.Checked = false;
                CheckBoxJ5.Checked = false;
                CheckBoxJ6.Checked = false;
                CheckBoxJ7.Checked = false;
                CheckBoxJ8.Checked = false;
                CheckBoxJ9.Checked = false;
                thursdayway = 0;
            }
        }

        int fridayway = 0;
        protected void ButtonFriday_Click(object sender, EventArgs e)
        {
            if (fridayway == 0)
            {
                CheckBoxF1.Checked = true;
                CheckBoxF2.Checked = true;
                CheckBoxF3.Checked = true;
                CheckBoxF4.Checked = true;
                CheckBoxF5.Checked = true;
                CheckBoxF6.Checked = true;
                CheckBoxF7.Checked = true;
                CheckBoxF8.Checked = true;
                CheckBoxF9.Checked = true;
                fridayway = 1;
            }
            else
            {
                CheckBoxF1.Checked = false;
                CheckBoxF2.Checked = false;
                CheckBoxF3.Checked = false;
                CheckBoxF4.Checked = false;
                CheckBoxF5.Checked = false;
                CheckBoxF6.Checked = false;
                CheckBoxF7.Checked = false;
                CheckBoxF8.Checked = false;
                CheckBoxF9.Checked = false;
                fridayway = 0;
            }
        }

        int oneway = 0;
        protected void ButtonPeriod1_Click(object sender, EventArgs e)
        {
            if (oneway == 0)
            {
                CheckBoxM1.Checked = true;
                CheckBoxT1.Checked = true;
                CheckBoxW1.Checked = true;
                CheckBoxJ1.Checked = true;
                CheckBoxF1.Checked = true;
                oneway = 1;
            }
            else
            {
                CheckBoxM1.Checked = false;
                CheckBoxT1.Checked = false;
                CheckBoxW1.Checked = false;
                CheckBoxJ1.Checked = false;
                CheckBoxF1.Checked = false;
                oneway = 0;
            }
        }

        int twoway = 0;
        protected void ButtonPeriod2_Click(object sender, EventArgs e)
        {
            if (twoway == 0)
            {
                CheckBoxM2.Checked = true;
                CheckBoxT2.Checked = true;
                CheckBoxW2.Checked = true;
                CheckBoxJ2.Checked = true;
                CheckBoxF2.Checked = true;
                twoway = 1;
            }
            else
            {
                CheckBoxM2.Checked = false;
                CheckBoxT2.Checked = false;
                CheckBoxW2.Checked = false;
                CheckBoxJ2.Checked = false;
                CheckBoxF2.Checked = false;
                twoway = 0;
            }
        }

        int threeway = 0;
        protected void ButtonPeriod3_Click(object sender, EventArgs e)
        {
            if (threeway == 0)
            {
                CheckBoxM3.Checked = true;
                CheckBoxT3.Checked = true;
                CheckBoxW3.Checked = true;
                CheckBoxJ3.Checked = true;
                CheckBoxF3.Checked = true;
                threeway = 1;
            }
            else
            {
                CheckBoxM3.Checked = false;
                CheckBoxT3.Checked = false;
                CheckBoxW3.Checked = false;
                CheckBoxJ3.Checked = false;
                CheckBoxF3.Checked = false;
                threeway = 0;
            }
        }

        int fourway = 0;
        protected void ButtonPeriod4_Click(object sender, EventArgs e)
        {
            if (fourway == 0)
            {
                CheckBoxM4.Checked = true;
                CheckBoxT4.Checked = true;
                CheckBoxW4.Checked = true;
                CheckBoxJ4.Checked = true;
                CheckBoxF4.Checked = true;
                fourway = 1;
            }
            else
            {
                CheckBoxM4.Checked = false;
                CheckBoxT4.Checked = false;
                CheckBoxW4.Checked = false;
                CheckBoxJ4.Checked = false;
                CheckBoxF4.Checked = false;
                fourway = 0;
            }
        }

        int fiveway = 0;
        protected void ButtonPeriod5_Click(object sender, EventArgs e)
        {
            if (fiveway == 0)
            {
                CheckBoxM5.Checked = true;
                CheckBoxT5.Checked = true;
                CheckBoxW5.Checked = true;
                CheckBoxJ5.Checked = true;
                CheckBoxF5.Checked = true;
                fiveway = 1;
            }
            else
            {
                CheckBoxM5.Checked = false;
                CheckBoxT5.Checked = false;
                CheckBoxW5.Checked = false;
                CheckBoxJ5.Checked = false;
                CheckBoxF5.Checked = false;
                fiveway = 0;
            }
        }

        int sixway = 0;
        protected void ButtonPeriod6_Click(object sender, EventArgs e)
        {
            if (sixway == 0)
            {
                CheckBoxM6.Checked = true;
                CheckBoxT6.Checked = true;
                CheckBoxW6.Checked = true;
                CheckBoxJ6.Checked = true;
                CheckBoxF6.Checked = true;
                sixway = 1;
            }
            else
            {
                CheckBoxM6.Checked = false;
                CheckBoxT6.Checked = false;
                CheckBoxW6.Checked = false;
                CheckBoxJ6.Checked = false;
                CheckBoxF6.Checked = false;
                sixway = 0;
            }
        }

        int sevenway = 0;
        protected void ButtonPeriod7_Click(object sender, EventArgs e)
        {
            if (sevenway == 0)
            {
                CheckBoxM7.Checked = true;
                CheckBoxT7.Checked = true;
                CheckBoxW7.Checked = true;
                CheckBoxJ7.Checked = true;
                CheckBoxF7.Checked = true;
                sevenway = 1;
            }
            else
            {
                CheckBoxM7.Checked = false;
                CheckBoxT7.Checked = false;
                CheckBoxW7.Checked = false;
                CheckBoxJ7.Checked = false;
                CheckBoxF7.Checked = false;
                sevenway = 0;
            }
        }

        int eightway = 0;
        protected void ButtonPeriod8_Click(object sender, EventArgs e)
        {
            if (eightway == 0)
            {
                CheckBoxM8.Checked = true;
                CheckBoxT8.Checked = true;
                CheckBoxW8.Checked = true;
                CheckBoxJ8.Checked = true;
                CheckBoxF8.Checked = true;
                eightway = 1;
            }
            else
            {
                CheckBoxM8.Checked = false;
                CheckBoxT8.Checked = false;
                CheckBoxW8.Checked = false;
                CheckBoxJ8.Checked = false;
                CheckBoxF8.Checked = false;
                eightway = 0;
            }
        }

        int nineway = 0;
        protected void ButtonPeriod9_Click(object sender, EventArgs e)
        {
            if (nineway == 0)
            {
                CheckBoxM9.Checked = true;
                CheckBoxT9.Checked = true;
                CheckBoxW9.Checked = true;
                CheckBoxJ9.Checked = true;
                CheckBoxF9.Checked = true;
                nineway = 1;
            }
            else
            {
                CheckBoxM9.Checked = false;
                CheckBoxT9.Checked = false;
                CheckBoxW9.Checked = false;
                CheckBoxJ9.Checked = false;
                CheckBoxF9.Checked = false;
                nineway = 0;
            }
        }

        /* Deselect any selected periods */
        public void ClearPeriods()
        {
            CheckBoxM1.Checked = false;
            CheckBoxM2.Checked = false;
            CheckBoxM3.Checked = false;
            CheckBoxM4.Checked = false;
            CheckBoxM5.Checked = false;
            CheckBoxM6.Checked = false;
            CheckBoxM7.Checked = false;
            CheckBoxM8.Checked = false;
            CheckBoxM9.Checked = false;
            CheckBoxT1.Checked = false;
            CheckBoxT2.Checked = false;
            CheckBoxT3.Checked = false;
            CheckBoxT4.Checked = false;
            CheckBoxT5.Checked = false;
            CheckBoxT6.Checked = false;
            CheckBoxT7.Checked = false;
            CheckBoxT8.Checked = false;
            CheckBoxT9.Checked = false;
            CheckBoxW1.Checked = false;
            CheckBoxW2.Checked = false;
            CheckBoxW3.Checked = false;
            CheckBoxW4.Checked = false;
            CheckBoxW5.Checked = false;
            CheckBoxW6.Checked = false;
            CheckBoxW7.Checked = false;
            CheckBoxW8.Checked = false;
            CheckBoxW9.Checked = false;
            CheckBoxJ1.Checked = false;
            CheckBoxJ2.Checked = false;
            CheckBoxJ3.Checked = false;
            CheckBoxJ4.Checked = false;
            CheckBoxJ5.Checked = false;
            CheckBoxJ6.Checked = false;
            CheckBoxJ7.Checked = false;
            CheckBoxJ8.Checked = false;
            CheckBoxJ9.Checked = false;
            CheckBoxF1.Checked = false;
            CheckBoxF2.Checked = false;
            CheckBoxF3.Checked = false;
            CheckBoxF4.Checked = false;
            CheckBoxF5.Checked = false;
            CheckBoxF6.Checked = false;
            CheckBoxF7.Checked = false;
            CheckBoxF8.Checked = false;
            CheckBoxF9.Checked = false;
        }
        protected void ButtonClearPeriods_Click(object sender, EventArgs e)
        {
            ClearPeriods();
        }


        protected void TextBoxCapacity_TextChanged(object sender, EventArgs e)
        {
            SearchRooms();
        }

        protected void RadioButtonListRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchRooms();
        }

        protected void RadioButtonListArrangement_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchRooms();
        }

        protected void RadioButtonListProjector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchRooms();
        }

        protected void RadioButtonListWheelchair_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchRooms();
        }

        protected void RadioButtonListVisualiser_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchRooms();
        }

        protected void RadioButtonListComputer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchRooms();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildings();
            SearchRooms();
        }

        public void buildings()
        {
            DropDownListBuildings.Items.Clear();
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            connect.Open();
            int selectedpark = RadioButtonList1.SelectedIndex + 1;
            string buildingsql = "Select buildingName from [Building] where parkID =" + selectedpark;
            SqlCommand buildingscommand = new SqlCommand(buildingsql, connect);
            SqlDataReader buildings = buildingscommand.ExecuteReader();
            while (buildings.Read())
            {
                DropDownListBuildings.Items.Add(buildings.GetString(0));
            }

            connect.Close();
        }

        protected void DropDownListRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            string label = "None";
            string label1 = LabelRoom1.Text;
            string label2 = LabelRoom2.Text;
            string label3 = LabelRoom3.Text;
            string selectedroom = DropDownListRooms.SelectedValue;
            bool l1 = label1.Equals(label);
            bool l2 = label2.Equals(label);
            bool l3 = label3.Equals(label);

            if (l1)
            {
                LabelRoom1.Text = selectedroom;
            }
            else if (l2)
            {
                LabelRoom2.Text = selectedroom;
            }
            else if (l3)
            {
                LabelRoom3.Text = selectedroom;
            }
            DropDownListRooms.Items.Remove(selectedroom);
            DropDownListRoomsAlt.Items.Remove(selectedroom);
        }

        protected void DropDownListRoomsAlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string label = "None";
            string label1 = LabelRoomAlt1.Text;
            string label2 = LabelRoomAlt2.Text;
            string label3 = LabelRoomAlt3.Text;
            string selectedroom = DropDownListRoomsAlt.SelectedValue;
            bool l1 = label1.Equals(label);
            bool l2 = label2.Equals(label);
            bool l3 = label3.Equals(label);

            if (l1)
            {
                LabelRoomAlt1.Text = selectedroom;
            }
            else if (l2)
            {
                LabelRoomAlt2.Text = selectedroom;
            }
            else if (l3)
            {
                LabelRoomAlt3.Text = selectedroom;
            }
            DropDownListRoomsAlt.Items.Remove(selectedroom);
        }

        protected void ButtonDeleteRoom1_Click(object sender, EventArgs e)
        {
            string label = "None";
            string roomname = LabelRoom1.Text;
            bool l1 = LabelRoom1.Text.Equals(label);
            if (!l1)
            {
                DropDownListRooms.Items.Add(roomname);
                DropDownListRoomsAlt.Items.Add(roomname);
                LabelRoom1.Text = "None";
            }
        }

        protected void ButtonDeleteRoom2_Click(object sender, EventArgs e)
        {
            string label = "None";
            string roomname = LabelRoom2.Text;
            bool l1 = LabelRoom2.Text.Equals(label);
            if (!l1)
            {
                DropDownListRooms.Items.Add(roomname);
                DropDownListRoomsAlt.Items.Add(roomname);
                LabelRoom2.Text = "None";
            }
        }

        protected void ButtonDeleteRoom3_Click(object sender, EventArgs e)
        {
            string label = "None";
            string roomname = LabelRoom3.Text;
            bool l1 = LabelRoom3.Text.Equals(label);
            if (!l1)
            {
                DropDownListRooms.Items.Add(roomname);
                DropDownListRoomsAlt.Items.Add(roomname);
                LabelRoom3.Text = "None";
            }
        }

        protected void ButtonDeleteRoomAlt1_Click(object sender, EventArgs e)
        {
            string label = "None";
            string roomname = LabelRoomAlt1.Text;
            bool l1 = LabelRoomAlt1.Text.Equals(label);
            if (!l1)
            {
                DropDownListRoomsAlt.Items.Add(roomname);
                LabelRoomAlt1.Text = "None";
            }
        }

        protected void ButtonDeleteRoomAlt2_Click(object sender, EventArgs e)
        {
            string label = "None";
            string roomname = LabelRoomAlt2.Text;
            bool l1 = LabelRoomAlt2.Text.Equals(label);
            if (!l1)
            {
                DropDownListRoomsAlt.Items.Add(roomname);
                LabelRoomAlt2.Text = "None";
            }
        }

        protected void ButtonDeleteRoomAlt3_Click(object sender, EventArgs e)
        {
            string label = "None";
            string roomname = LabelRoomAlt3.Text;
            bool l1 = LabelRoomAlt3.Text.Equals(label);
            if (!l1)
            {
                DropDownListRoomsAlt.Items.Add(roomname);
                LabelRoomAlt3.Text = "None";
            }
        }

        protected void DropDownListBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {

            SearchRooms();
        }

        public void clearEverything()
        {
            ClearPeriods();
            Week1.Checked = false;
            Week2.Checked = false;
            Week3.Checked = false;
            Week4.Checked = false;
            Week5.Checked = false;
            Week6.Checked = false;
            Week7.Checked = false;
            Week8.Checked = false;
            Week9.Checked = false;
            Week10.Checked = false;
            Week11.Checked = false;
            Week12.Checked = false;
            Week13.Checked = false;
            Week14.Checked = false;
            Week15.Checked = false;

            TextBoxCapacity.Text = "";
            TextBox2.Text = "";
            RadioButtonListComputer.SelectedIndex = -1;
            RadioButtonListVisualiser.SelectedIndex = -1;
            RadioButtonListWheelchair.SelectedIndex = -1;
            CheckBoxWB.Checked = false;
            CheckBoxCB.Checked = false;
            RadioButtonListProjector.SelectedIndex = -1;
            RadioButtonListArrangement.SelectedIndex = -1;
            RadioButtonListRoomType.SelectedIndex = -1;
            DropDownList1.SelectedIndex = 0;
            RadioButtonList1.SelectedIndex = -1;
            DropDownListBuildings.Items.Clear();

            string label = "None";
            string roomname = LabelRoom1.Text;
            bool l1 = LabelRoom1.Text.Equals(label);
            if (!l1)
            {
                DropDownListRooms.Items.Add(roomname);
                DropDownListRoomsAlt.Items.Add(roomname);
                LabelRoom1.Text = "None";
            }

            string roomname2 = LabelRoom2.Text;
            bool l2 = LabelRoom2.Text.Equals(label);
            if (!l2)
            {
                DropDownListRooms.Items.Add(roomname2);
                DropDownListRoomsAlt.Items.Add(roomname2);
                LabelRoom2.Text = "None";
            }
            string roomname3 = LabelRoom3.Text;
            bool l3 = LabelRoom3.Text.Equals(label);
            if (!l3)
            {
                DropDownListRooms.Items.Add(roomname3);
                DropDownListRoomsAlt.Items.Add(roomname3);
                LabelRoom3.Text = "None";
            }

            string roomnameAlt = LabelRoomAlt1.Text;
            bool l4 = LabelRoomAlt1.Text.Equals(label);
            if (!l4)
            {
                DropDownListRoomsAlt.Items.Add(roomnameAlt);
                LabelRoomAlt1.Text = "None";
            }
            string roomnameAlt2 = LabelRoomAlt2.Text;
            bool l5 = LabelRoomAlt2.Text.Equals(label);
            if (!l5)
            {
                DropDownListRoomsAlt.Items.Add(roomnameAlt2);
                LabelRoomAlt2.Text = "None";
            }
            string roomnameAlt3 = LabelRoomAlt3.Text;
            bool l6 = LabelRoomAlt1.Text.Equals(label);
            if (!l6)
            {
                DropDownListRoomsAlt.Items.Add(roomnameAlt3);
                LabelRoomAlt3.Text = "None";
            }
        }
        protected void ButtonClearAll_Click(object sender, EventArgs e)
        {
            clearEverything();
            SearchRooms();
        }


    }
}