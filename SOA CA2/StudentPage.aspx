<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="SOA_CA2.StudentPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Page</title>
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

     .form-group select {
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
            <!-- Course Selection -->
            <div class="menu-title">Course Selection</div>
            <div class="form-group">
                <label for="courseList">Select Course:</label>
                <asp:DropDownList ID="ddlCourses" runat="server"></asp:DropDownList>
            </div>
            <asp:Button ID="btnSelectCourse" runat="server" Text="Select Course" CssClass="menu-button" OnClick="btnSelectCourse_Click" />
        </div>
    </form>
</body>
</html>