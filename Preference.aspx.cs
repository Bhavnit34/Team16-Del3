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
using System.Text.RegularExpressions;

namespace Team11
{
    public partial class Preference : System.Web.UI.Page
    {
        int periodval;
        int hr24val;
        string locationval;
        string loadingval;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                conn.Open();
                string preferencesquery = "SELECT period, hr24Format, defaultLocation, defaultPage, header1, header2, header3 FROM [Preferences] WHERE userID='1'";
                SqlCommand preferencessql = new SqlCommand(preferencesquery, conn);
                SqlDataReader preferences = preferencessql.ExecuteReader();
                if (preferences.Read())
                {
                    int periodText = preferences.GetInt32(0);
                    int hr24FormatText = preferences.GetInt32(1);
                    string defaultLocationText = preferences.GetString(2);
                    string defaultPageText = preferences.GetString(3);
                    string header1Text = preferences.GetString(4);
                    string header2Text = preferences.GetString(5);
                    string header3Text = preferences.GetString(6);

                    if (defaultPageText == "Create")
                        create.Checked = true;
                    else if (defaultPageText == "View")
                        view.Checked = true;
                    else if (defaultPageText == "Adhoc")
                        adhoc.Checked = true;

                    if (defaultLocationText == "Central")
                        central.Checked = true;
                    else if (defaultLocationText == "East")
                        east.Checked = true;
                    else if (defaultLocationText == "West")
                        west.Checked = true;
                    else
                        any.Checked = true;

                    if (hr24FormatText == 1)
                        hr24.Checked = true;
                    else if (hr24FormatText == 0)
                        hr12.Checked = true;

                    if (periodText == 1)
                        period.Checked = true;
                    else if (periodText == 0)
                        time.Checked = true;

                    header1.SelectedValue = header1Text;
                    header2.SelectedValue = header2Text;
                    header3.SelectedValue = header3Text;
                }
                conn.Close();


                //Populate Buildings List
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
                connection.Open();
                string allBuildingsQuery = "Select buildingName from [Building]";
                SqlCommand allBuildingsql = new SqlCommand(allBuildingsQuery, connection);
                SqlDataReader buildings = allBuildingsql.ExecuteReader();
                while(buildings.Read()){
                    //check buildingName isnt east, west or central
                    if((buildings.GetString(0) == "East") || (buildings.GetString(0) == "West") || (buildings.GetString(0) == "Central"))
                        continue;
                    //check for double occurance of James France
                    if((buildings.GetString(0) == "James France") && (DropDownListAllBuildings.Items.Count > 2))
                        continue;
                    DropDownListAllBuildings.Items.Add(buildings.GetString(0));
                }
                connection.Close();


            } //end isPostBack
        } //end function
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (create.Checked)
                loadingval = "Create";
            else if (view.Checked)
                loadingval = "View";
            else if (adhoc.Checked)
                loadingval = "Adhoc";

            if (central.Checked)
                locationval = "Central";
            else if (east.Checked)
                locationval = "East";
            else if (west.Checked)
                locationval = "West";
            else if (any.Checked)
                locationval = "";

            if (hr24.Checked)
                hr24val = 1;
            else if (hr12.Checked)
                hr24val = 0;

            if (period.Checked)
                periodval = 1;
            else if (time.Checked)
                periodval = 0;

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
            string preferencesquerynew = "Update [Preferences] SET period=" + periodval + ", hr24Format=" + hr24val + ", defaultLocation='" + locationval + "', defaultPage='" + loadingval + "', header1='" + header1.SelectedValue + "', header2='" + header2.SelectedValue + "', header3='" + header3.SelectedValue + "' WHERE userID=1";
            SqlCommand preferencessql = new SqlCommand(preferencesquerynew, conn);
            conn.Open();
            preferencessql.ExecuteNonQuery();
            conn.Close();
        }

        protected void DropDownListAllBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update the list of rooms based on the chosen building
            DropDownListAllRooms.Items.Clear();
           
            bool JF = false; //boolean to check for James France as the chosen room
            if (DropDownListAllBuildings.SelectedValue == "James France")
                JF = true;


            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
            connection.Open();
            string buildingCodeQuery = "Select buildingCode from [Building] where buildingName = '" + DropDownListAllBuildings.SelectedValue +"'";
            SqlCommand buildingCodesql = new SqlCommand(buildingCodeQuery, connection);
            SqlDataReader building = buildingCodesql.ExecuteReader();
            while(building.Read())
                buildingCodeQuery = building.GetString(0);
            connection.Close();
            connection.Open();
            string allBuildingsQuery = "";
            if (JF) //Change the query if the building chosen is James France, to allow for buildingCode CC and D
            {
                allBuildingsQuery = "Select roomName from [Room] where buildingCode in ('CC','D')";
            }
            else //else run query as normal
            {
                allBuildingsQuery = "Select roomName from [Room] where buildingCode = '" + buildingCodeQuery + "'";
            }
                
                SqlCommand allBuildingsql = new SqlCommand(allBuildingsQuery, connection);
                SqlDataReader buildings = allBuildingsql.ExecuteReader();
                while (buildings.Read()) //loop through the query results
                {
                    DropDownListAllRooms.Items.Add(buildings.GetString(0)); //append the rooms to a dropdown list
                }
                connection.Close();
            
        }

        protected void addFacility_Click(object sender, EventArgs e)
        {
            //Validate the input
            string input = addFacilityText.Text;
            if (!(Regex.IsMatch(input, @"^[a-zA-Z]+$"))) //regex match against letters only
            {
                //JavaScript alert message
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Facility name not valid');", true);
                return;
            }

            //Connect to database
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
            connection.Open();
            string room = DropDownListAllRooms.SelectedValue; //get chosen room
            string getFacilityQuery = "Select facilityName from [Facility] left join [RoomFacilities] on [Facility].facilityID = [RoomFacilities].facilityID";
            getFacilityQuery += " Where roomName = '" + room + "'";

            SqlCommand getFacilitysql = new SqlCommand(getFacilityQuery, connection);
            SqlDataReader facility = getFacilitysql.ExecuteReader();
            List<string> fac = new List<string>(); //initalize array of facilities
            while (facility.Read())
                fac.Add(facility.GetString(0)); //push facilities into an array
            
            connection.Close();

            //loop through array and see if the facility already exists
            for (int i = 0; i < fac.Count; i++)
            {
                if (fac[i].ToUpper() == input.ToUpper())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + input + " already exists in this room');", true); //JavaScript Alert Message
                    return;
                }

            }



            connection.Open();


        }
    }
}