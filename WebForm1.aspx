<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AccessManagementService.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>
<body>
    <table id="tbDetails">
        <tr>
            <td>ID</td>
            <td>Name</td>
            <td>Mobile</td>
            <td>Location</td>
        </tr>
        <tbody>
        </tbody>
    </table>


    <script>

        function BindTable() {

            $.ajax({
                type: "POST",
                url: "WebService1.asmx/bindtable",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var json = JSON.parse(msg.d);
                    $.each(json, function (index, obj) {
                        var row = '<tr><td> ' + obj.pid + ' </td> <td> ' + obj.p_name + ' </td> <td>' + obj.p_mobile + '</td> <td>' + obj.p_location + '</td> </tr>'
                        $("#tbDetails tbody").append(row);
                    });
                }
            });

        }


        $(document).ready(function () {
            BindTable();
        });
    </script>

</body>
</html>
