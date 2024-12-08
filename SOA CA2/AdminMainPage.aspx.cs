using System;
using System.Data;
using System.Data.Odbc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOA_CA2
{
    public partial class AdminMainPage : System.Web.UI.Page
    {
        // database connection string
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents(); 
                LoadCourses(); 
            }
        }

        // get students from database
        private void LoadStudents()
        {
            string query = "SELECT * FROM student";
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
                        gvStudents.DataSource = dt;
                        gvStudents.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // get courses from database
        private void LoadCourses()
        {
            string query = "SELECT * FROM course";
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
                        gvCourses.DataSource = dt;
                        gvCourses.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // Add a new student
        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string age = txtAge.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string username = txtUsername.Text.Trim();

            string query = "INSERT INTO student (Name, Age, Email, Password, Username) VALUES (?,?,?,?,?)";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", name);
                        cmd.Parameters.AddWithValue("?", age);
                        cmd.Parameters.AddWithValue("?", email);
                        cmd.Parameters.AddWithValue("?", password);
                        cmd.Parameters.AddWithValue("?", username);

                        cmd.ExecuteNonQuery();
                        LoadStudents();
                        ShowSuccessMessage("Student added successfully.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // Add a new course
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string course = txtCourse.Text.Trim();
            string credit = txtCredit.Text.Trim();

            string query = "INSERT INTO course (Course, Credit) VALUES (?,?)";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", course);
                        cmd.Parameters.AddWithValue("?", credit);

                        cmd.ExecuteNonQuery();
                        LoadCourses();
                        ShowSuccessMessage("Course added successfully.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // Update student info
        protected void btnModifyStudent_Click(object sender, EventArgs e)
        {
            string username = modifyStudentUsername.Text.Trim();
            string name = modifyStudentName.Text.Trim();
            string age = modifyStudentAge.Text.Trim();
            string email = modifyStudentEmail.Text.Trim();
            string password = modifyStudentPassword.Text.Trim();

            string query = "UPDATE student SET Name =?, Age =?, Email =?, Password =? WHERE Username =?";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", name);
                        cmd.Parameters.AddWithValue("?", age);
                        cmd.Parameters.AddWithValue("?", email);
                        cmd.Parameters.AddWithValue("?", password);
                        cmd.Parameters.AddWithValue("?", username);

                        cmd.ExecuteNonQuery();
                        LoadStudents();
                        ShowSuccessMessage("Student updated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // Update course info
        protected void btnModifyCourse_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(modifyCourseId.Text.Trim(), out int courseId))
            {
                ShowErrorMessage("Invalid Course ID. Please enter a valid integer value.");
                return;
            }
            string course = modifyCourseName.Text.Trim();
            string credit = modifyCourseCredit.Text.Trim();

            string query = "UPDATE course SET Course =?, Credit =? WHERE Id =?";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", course);
                        cmd.Parameters.AddWithValue("?", credit);
                        cmd.Parameters.AddWithValue("?", courseId);

                        cmd.ExecuteNonQuery();
                        LoadCourses();
                        ShowSuccessMessage("Course updated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
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

        // Delete student from the database
        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentId = Convert.ToInt32(gvStudents.DataKeys[e.RowIndex].Values["Id"].ToString());
            string query = "DELETE FROM student WHERE Id =?";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", studentId);
                        cmd.ExecuteNonQuery();
                        LoadStudents();
                        ShowSuccessMessage("Student deleted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // Delete course from the database
        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int courseId = Convert.ToInt32(gvCourses.DataKeys[e.RowIndex].Values["Id"].ToString());
            string query = "DELETE FROM course WHERE Id =?";
            using (OdbcConnection conn = new OdbcConnection(connString))
            {
                try
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", courseId);
                        cmd.ExecuteNonQuery();
                        LoadCourses();
                        ShowSuccessMessage("Course deleted successfully.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }
    }
}
