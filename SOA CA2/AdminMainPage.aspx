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
            <!-- Student Management  -->
            <div class="menu-title">Student Management</div>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" 
                OnRowEditing="gvStudents_RowEditing" OnRowUpdating="gvStudents_RowUpdating" 
                OnRowDeleting="gvStudents_RowDeleting" OnRowCancelingEdit="gvStudents_RowCancelingEdit" 
                CssClass="table">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True"/>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <!-- Student Add  -->
            <div class="form-group">
                <label for="name">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="age">Age:</label>
                <asp:TextBox ID="txtage" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
    <label for="username">Username:</label>
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
</div>
            <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" CssClass="menu-button" OnClick="btnAddStudent_Click" />
        </div>

        <div class="menu-container">
            <!-- Course Management Section -->
            <div class="menu-title">Course Management</div>
            <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" 
                OnRowEditing="gvCourses_RowEditing" OnRowUpdating="gvCourses_RowUpdating" 
                OnRowDeleting="gvCourses_RowDeleting" OnRowCancelingEdit="gvCourses_RowCancelingEdit" 
                CssClass="table">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Course" HeaderText="Course" />
                    <asp:BoundField DataField="Credit" HeaderText="Credit" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <!-- Course Add  -->
            <div class="form-group">
                <label for="course">Course Name:</label>
                <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="credit">Credits:</label>
                <asp:TextBox ID="txtcredit" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" CssClass="menu-button" OnClick="btnAddCourse_Click" />
        </div>
    </form>
</body>
</html>
