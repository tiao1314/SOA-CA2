using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOA_CA2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Use unique names for variables to avoid conflicts with control IDs
            string enteredUsername = username.Text.Trim();
            string enteredPassword = password.Text.Trim();
            string role = admin.Checked ? "Administrator" : "Student";

            if (IsValidUser(enteredUsername, enteredPassword, role))
            {
                if (role == "Administrator")
                {
                    Response.Redirect("Admin Main Page.aspx");
                }
                else
                {
                    Response.Redirect("Student Page.aspx");
                }
            }
            else
            {
                // Show an alert for invalid login
                Response.Write("<script>alert('Invalid username, password, or role.');</script>");
            }
        }

        private bool IsValidUser(string username, string password, string role)
        {
            // Replace this with actual validation logic
            if (role == "Administrator" && username == "admin" && password == "adminpass")
                return true;
            if (role == "Student" && username == "student" && password == "studentpass")
                return true;

            return false;
        }
    }
}
