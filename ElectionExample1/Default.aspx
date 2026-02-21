<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ElectionExample1.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Election Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Welcome to Election System</h2>

        <asp:Button ID="btnVote" runat="server" Text="Go to Vote Page"
            OnClick="btnVote_Click" />
    </form>
</body>
</html>
