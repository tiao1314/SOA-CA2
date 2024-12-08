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

            // check user creds
            if (IsValidUser(enteredUsername, enteredPassword, role))
            {
                if (role == "Administrator")
                {
                    Response.Redirect("AdminMainPage.aspx");
                }
                else
                {
                    // get studentid and put in a session
                    int studentId = GetStudentId(enteredUsername);
                    if (studentId > 0)
                    {
                        Session["StudentId"] = studentId;
                        Response.Redirect("StudentPage.aspx");
                    }
                    else
                    {
                        
                        Response.Write("<script>alert('Failed to retrieve student ID.');</script>");
                    }
                }
            }
            else
            {
               
                Response.Write("<script>alert('Invalid username, password, or role.');</script>");
            }
        }

        // check the user creds within the database
        private bool IsValidUser(string username, string password, string role)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            string query = "";

            
            if (role == "Administrator")
            {
                query = "SELECT * FROM admin WHERE username =? AND password =?";
            }
            else if (role == "Student")
            {
                query = "SELECT * FROM student WHERE username =? AND password =?";
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

                        // Check if any rows are returned
                        return reader.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                    return false;
                }
            }
        }

        // get student id with username
        private int GetStudentId(string username)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            string query = "SELECT id FROM student WHERE username =?";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", username);
                        object result = cmd.ExecuteScalar();

                        
                        if (result != null && int.TryParse(result.ToString(), out int studentId))
                        {
                            return studentId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            return 0;
        }
    }
}
