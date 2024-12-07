using System;
using System.Data.Odbc;
using System.Web.UI;

namespace SOA_CA2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text.Trim();
            string enteredPassword = password.Text.Trim();
            string role = student.Checked ? "Student" : "Administrator";

            if (IsValidUser(enteredUsername, enteredPassword, role))
            {
                if (role == "Administrator")
                {
                    Response.Redirect("AdminMainPage.aspx");
                }
                else
                {
                    Response.Redirect("StudentPage.aspx");
                }
            }
            else
            {
                // alert invalid login
                Response.Write("<script>alert('Invalid username, password, or role.');</script>");
            }
        }

        private bool IsValidUser(string username, string password, string role)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            string query = "";

            if (role == "Administrator")
            {
                query = "SELECT * FROM admin WHERE username = ? AND password = ?";
            }
            else if (role == "Student")
            {
                query = "SELECT * FROM student WHERE username = ? AND password = ?";
            }

            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                       
                        cmd.Parameters.AddWithValue("?", username);
                        cmd.Parameters.AddWithValue("?", password);

                        OdbcDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            return true; 
                        }
                        else
                        {
                            return false; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                    return false;
                }
            }
        }
    }
}
