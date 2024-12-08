<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMainPage.aspx.cs" Inherits="SOA_CA2.AdminMainPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Main Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: flex-start;
            height: 100vh;
        }

     .menu-container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 600px;
            margin: 20px;
        }

     .menu-title {
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 10px;
        }

     .form-group {
            margin-bottom: 10px;
        }

     .form-group label {
            display: block;
            margin-bottom: 5px;
        }

     .form-group input {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
        }

     .menu-button {
            width: 100%;
            padding: 10px;
            background-color: #007BFF;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-top: 10px;
        }

     .menu-button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu-container">
            <!-- Student Management -->
            <div class="menu-title">Student Management</div>
            <asp:GridView ID="gvStudents" DataKeyNames="Username, Id" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username"  ReadOnly="True"/>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True"/>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                </Columns>
            </asp:GridView>

            <!-- Add student form -->
            <div class="form-group">
                <label for="name">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="age">Age:</label>
                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="username">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" CssClass="menu-button" OnClick="btnAddStudent_Click" />

            <!-- Student edit form -->
            <div class="form-group">
                <label for="modifyStudentUsername">Username:</label>
                <asp:TextBox ID="modifyStudentUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="modifyStudentName">Name:</label>
                <asp:TextBox ID="modifyStudentName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="modifyStudentAge">Age:</label>
                <asp:TextBox ID="modifyStudentAge" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="modifyStudentEmail">Email:</label>
                <asp:TextBox ID="modifyStudentEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="modifyStudentPassword">Password:</label>
                <asp:TextBox ID="modifyStudentPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnModifyStudent" runat="server" Text="Modify Student" CssClass="menu-button" OnClick="btnModifyStudent_Click" />
        </div>

        <div class="menu-container">
            <!-- Course Management Section -->
            <div class="menu-title">Course Management</div>
            <asp:GridView ID="gvCourses" runat="server" DataKeyNames="Id" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Course" HeaderText="Course" />
                    <asp:BoundField DataField="Credit" HeaderText="Credit" />
                </Columns>
            </asp:GridView>

            <!-- Add course form -->
            <div class="form-group">
                <label for="course">Course Name:</label>
                <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="credit">Credits:</label>
                <asp:TextBox ID="txtCredit" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" CssClass="menu-button" OnClick="btnAddCourse_Click" />

            <!-- Course edit form -->
            <div class="form-group">
                <label for="modifyCourseId">Course ID:</label>
                <asp:TextBox ID="modifyCourseId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="modifyCourseName">Course Name:</label>
                <asp:TextBox ID="modifyCourseName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="modifyCourseCredit">Credits:</label>
                <asp:TextBox ID="modifyCourseCredit" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnModifyCourse" runat="server" Text="Modify Course" CssClass="menu-button" OnClick="btnModifyCourse_Click" />
        </div>
    </form>
</body>
</html>