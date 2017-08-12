<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscMenuLink.ascx.cs" ClassName="AccessManagementService.Controls.MenuLink" Inherits="AccessManagementService.Controls.UscMenuLink" %>

              <% if (ViewCheck())
                                                       { %>
                            <li>
                                <a href="<%= LinkHref %>"><%= LinkText %> </a>
                            </li>
                            <%} %>