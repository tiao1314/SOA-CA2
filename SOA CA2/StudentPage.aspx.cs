using System;
using System.Data;
using System.Data.Odbc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOA_CA2
{
    public partial class StudentPage : System.Web.UI.Page
    {
        // Database connection 
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        // load course info
        private void LoadCourses()
        {
            string query = "SELECT id, course FROM course";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // dropdown list for the course
                        ddlCourses.DataSource = dt;
                        ddlCourses.DataTextField = "course";
                        ddlCourses.DataValueField = "id";
                        ddlCourses.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // on click select course
        protected void btnSelectCourse_Click(object sender, EventArgs e)
        {
            int selectedCourseId = Convert.ToInt32(ddlCourses.SelectedValue);

            // get student ID from Session
            if (Session["StudentId"] != null && int.TryParse(Session["StudentId"].ToString(), out int studentId))
            {
                // inset into the many to many 
                string insertQuery = "INSERT INTO student_course (student_id, course_id) VALUES (?,?)";
                using (OdbcConnection conn = new OdbcConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        using (OdbcCommand cmd = new OdbcCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("?", studentId);
                            cmd.Parameters.AddWithValue("?", selectedCourseId);
                            cmd.ExecuteNonQuery();
                            ShowSuccessMessage("Course selected successfully.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex.Message);
                    }
                }
            }
            else
            {
                
                ShowErrorMessage("Failed to retrieve student ID. Please try again.");
            }
        }

        
        private void ShowErrorMessage(string message)
        {
            Response.Write("<script>alert('Error: " + message + "');</script>");
        }

        
        private void ShowSuccessMessage(string message)
        {
            Response.Write("<script>alert('" + message + "');</script>");
        }
    }
}
