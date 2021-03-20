using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace User
{
    public partial class Login_Page : System.Web.UI.Page
    {
        //outside of the main code used to connect, command, and read the database
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //in the page_load in asp.net for testing
            // used to connect the database to this specific cs file
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            //save the info on the table (will be changed so only visible for admin)
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // attached to the button to login to the application
            if (Page.IsValid)
            {
                try
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from Register Where StudentID='" + TextBox1.Text + "'and Password= '" + TextBox2.Text + "'";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Label3.Text = "Not Failed";
                    }
                    else
                    {
                        Label3.Text = "Failed";
                    }
                }
                catch (Exception ex)
                {
                    Label3.Text = ex.Message;
                }
            }
        }
    }
}