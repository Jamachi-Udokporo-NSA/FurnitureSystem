﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ACustomerDelete.aspx.cs" Inherits="FurnitureFrontOffice.ACustomerDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: bisque">
    <form id="form1" runat="server">
        <div>
            Are you sure you want to delete this customer?<br />
            <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Width="67px" />
            <asp:Button ID="btnNo" runat="server" Text="No" Width="62px" OnClick="btnNo_Click" />
        </div>
    </form>
</body>
</html>
