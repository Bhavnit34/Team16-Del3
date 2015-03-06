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
            }
        }
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
    }
}