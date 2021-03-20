using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace User
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Adds information into the database
            if (Page.IsValid)
            {
                //Set the insert param
                var parameter = SqlDataSource1.InsertParameters;
                parameter["StudentID"].DefaultValue = IDText.Text;
                parameter["FirstName"].DefaultValue = TextBox2.Text;
                parameter["LastName"].DefaultValue = TextBox3.Text;
                parameter["Password"].DefaultValue = TextBox4.Text;

                //insert and bind data table
                try
                {
                    SqlDataSource1.Insert();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    ErrLabel.Text = ex.Message;
                }
            }
        }
    }
}