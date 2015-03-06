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
    public partial class AddEditModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBoxModuleCode.Text != "" && TextBoxModuleName.Text != "")
            {
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ParkConnectionString"].ToString());
                conn.Open();
                string check = "SELECT COUNT(moduleID) FROM [Module] WHERE moduleTitle='" + TextBoxModuleName + "' AND moduleCode='" + TextBoxModuleCode + "'";
                SqlCommand checkcommand = new SqlCommand(check, conn);
                int checksum = Convert.ToInt32(checkcommand.ExecuteScalar().ToString());
                conn.Close();
                if (checksum == 0)
                {
                    conn.Open();
                    string insertquery = "Insert into [Module] Values('" + TextBoxModuleCode.Text + "','" + TextBoxModuleName.Text + "','1')";
                    SqlCommand insertcommand = new SqlCommand(insertquery, conn);
                    insertcommand.ExecuteNonQuery();
                    LabelResponse.Text = "Module was sucessfully added to the Database";
                    conn.Close();
                }
                else { LabelResponse.Text = "Please enter a different Module Code/Title"; }
            }
            else { LabelResponse.Text = "Please Enter Module Code/Title"; }
        }
    }
}