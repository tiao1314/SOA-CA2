using System;
using System.Data;
using System.Data.Odbc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOA_CA2
{
    public partial class AdminMainPage : System.Web.UI.Page
    {
        // Connection string from the web.config file
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load students and courses on page load
                LoadStudents();
                LoadCourses();
            }
        }

        // Load students from database into GridView
        private void LoadStudents()
        {
            string query = "SELECT * FROM student"; // Fetch all students from the database
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
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Load courses from database into GridView
        private void LoadCourses()
        {
            string query = "SELECT * FROM course"; // Fetch all courses from the database
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
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Add student to the database
        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string age = txtage.Text.Trim();
            string email = txtemail.Text.Trim();
            string password = txtpassword.Text.Trim();
            string username = txtUsername.Text.Trim();

            string query = "INSERT INTO student (Name, Age, Email, Password, Username) VALUES (?, ?, ?, ?, ?)";

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
                        // Reload students after adding a new one
                        LoadStudents();
                        Response.Write("<script>alert('Student added successfully.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Add course to the database
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string course = txtCourse.Text.Trim();
            string credit = txtcredit.Text.Trim();

            string query = "INSERT INTO course (Course, Credit) VALUES (?, ?)";

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
                        // Reload courses after adding a new one
                        LoadCourses();
                        Response.Write("<script>alert('Course added successfully.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Editing student row in GridView
        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudents.EditIndex = e.NewEditIndex;
            LoadStudents();

        }

        // Updating student details
        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string username = gvStudents.DataKeys[e.RowIndex].Values["Username"].ToString();
            string name = ((TextBox)gvStudents.Rows[e.RowIndex].FindControl("txtNameEdit")).Text.Trim();
            string age = ((TextBox)gvStudents.Rows[e.RowIndex].FindControl("txtAgeEdit")).Text.Trim();
            string email = ((TextBox)gvStudents.Rows[e.RowIndex].FindControl("txtEmailEdit")).Text.Trim();
            string password = ((TextBox)gvStudents.Rows[e.RowIndex].FindControl("txtPasswordEdit")).Text.Trim();

            string query = "UPDATE student SET Name = ?, Age = ?, Email = ?, Password = ? WHERE Username = ?";

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
                        gvStudents.EditIndex = -1;
                        LoadStudents();
                        Response.Write("<script>alert('Student updated successfully.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Delete student record
        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentId = Convert.ToInt32(gvStudents.DataKeys[e.RowIndex].Values["Id"].ToString());

            string query = "DELETE FROM student WHERE Id = ?";

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
                        Response.Write("<script>alert('Student deleted successfully.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Editing course 
        protected void gvCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCourses.EditIndex = e.NewEditIndex;
            LoadCourses();
        }

        // Updating course detail
        protected void gvCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int courseId = Convert.ToInt32(gvCourses.DataKeys[e.RowIndex].Values["Id"].ToString());
            string course = ((TextBox)gvCourses.Rows[e.RowIndex].FindControl("txtCourseEdit")).Text.Trim();
            string credit = ((TextBox)gvCourses.Rows[e.RowIndex].FindControl("txtCreditEdit")).Text.Trim();

            string query = "UPDATE course SET Course = ?, Credit = ? WHERE Id = ?";

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
                        gvCourses.EditIndex = -1;
                        LoadCourses();
                        Response.Write("<script>alert('Course updated successfully.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Deleting course row
        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int courseId = Convert.ToInt32(gvCourses.DataKeys[e.RowIndex].Values["Id"].ToString());

            string query = "DELETE FROM course WHERE Id = ?";

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
                        Response.Write("<script>alert('Course deleted successfully.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Cancel editing student or course
        protected void gvStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudents.EditIndex = -1;
            LoadStudents();
        }

        protected void gvCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCourses.EditIndex = -1;
            LoadCourses();
        }
    }
}
