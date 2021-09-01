<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="AspMultitier.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <div class="card-header">
                    <h4>Name: <%= model.Name %></h4>
                </div>
                <div class="card-body">
                    <table class="table">
                        <tr>
                            <th>Email :</th><th><%= model.Email %></th>
                        </tr>
                         <tr>
                            <th>Department :</th><th><%= model.Department %></th>
                        </tr>

                         <tr>
                            <th>Salary :</th><th><%= model.Salary %></th>
                        </tr>
                         <tr>
                            <th>Gender :</th><th><%= model.Gender %></th>
                        </tr> 
                        <tr>
                            <th>Address :</th><th><%= model.Address %></th>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
