<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vote.aspx.cs" Inherits="ElectionExample1.Vote" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Vote Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Cast Your Vote</h2>

        <asp:RadioButtonList ID="rblCandidates" runat="server">
            <asp:ListItem>Candidate A</asp:ListItem>
            <asp:ListItem>Candidate B</asp:ListItem>
            <asp:ListItem>Candidate C</asp:ListItem>
        </asp:RadioButtonList>

        <br />

        <asp:Button ID="btnSubmit" runat="server" Text="Submit Vote"
            OnClick="btnSubmit_Click" />

        <br /><br />

        <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
    </form>
</body>
</html>
