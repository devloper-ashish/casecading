<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
            <asp:Label Text="Country" runat="server"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

            <asp:Label Text="State" runat="server"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlstate" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

            <asp:Label Text="District" runat="server"></asp:Label>
            <asp:DropDownList runat="server" ID="ddldist"></asp:DropDownList>

        </div>
    </form>
</body>
</html>
