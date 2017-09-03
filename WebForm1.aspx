﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AccessManagementService.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            var row = "";
            $.ajax({
                type: "POST",
                url: "test4.aspx/GetDetails",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $.each(msg.d, function (index, obj) {
                        row += "<tr><td>" + obj.productcode + "</td><td>" + obj.productname + "</td><td>" + obj.costprice + "</td></tr>";

                    });

                    $("#tbDetails tbody").append(row);
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <input id="Button1" type="button" value="button" />
            <table id="tbDetails" width="800" runat="server" clientidmode="Static">
                <tbody>
                    <tr>
                        <td>productcode</td>
                        <td>productname</td>
                        <td>costprice</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
