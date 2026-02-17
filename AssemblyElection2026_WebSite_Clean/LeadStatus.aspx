<%@ Page Language="C#" 
    MasterPageFile="~/Election.Master" 
    AutoEventWireup="true" 
    CodeFile="LeadStatus.aspx.cs" 
    Inherits="LeadStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table width="100%">
        <tr>
            <td align="center">
                <h2><b>LEAD AND STATUS</b></h2>
            </td>
        </tr>
    </table>

    <br />

    <!-- STATE -->
    <asp:Label ID="Label1" runat="server" Text="State" Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server"
        AutoPostBack="True"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
        Width="300px">
    </asp:DropDownList>

    <br /><br />

    <!-- DISTRICT -->
    <asp:Label ID="Label3" runat="server" Text="District" Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server"
        AutoPostBack="True"
        OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
        Width="300px">
    </asp:DropDownList>

    <br /><br />

    <!-- CONSTITUENCY -->
    <asp:Label ID="Label2" runat="server" Text="Constituency" Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server"
        AutoPostBack="True"
        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
        Width="300px">
    </asp:DropDownList>

    <br /><br />

    <!-- MAIN GRID -->
    <asp:GridView ID="GridView1"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        Visible="False"
        ShowFooter="True"
        Width="800px">

        <Columns>

            <asp:BoundField DataField="CantiName" HeaderText="Candidate Name" />

            <asp:TemplateField HeaderText="Lead">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server"
                        Text="Update"
                        OnClick="Button1_Click" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total Vote">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="lead" HeaderText="Current Lead" />
            <asp:BoundField DataField="Status" HeaderText="Current Status" />
            <asp:BoundField DataField="total_vote" HeaderText="Current Vote" />

        </Columns>
    </asp:GridView>

    <br /><br />

    <!-- ON AIR GRID -->
    <asp:GridView ID="GridView2"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        Visible="False"
        Width="800px">

        <Columns>

            <asp:BoundField DataField="constituencyname" HeaderText="Constituency" />
            <asp:BoundField DataField="CantiName" HeaderText="Candidate" />
            <asp:BoundField DataField="Status" HeaderText="Status" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                    <asp:Button ID="Button2" runat="server"
                        Text="TO OFF AIR"
                        OnClick="Button2_Click" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <br /><br />

    <!-- OFF AIR GRID -->
    <asp:GridView ID="GridView3"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="Id"
        Visible="False"
        Width="800px">

        <Columns>

            <asp:BoundField DataField="constituencyname" HeaderText="Constituency" />
            <asp:BoundField DataField="CantiName" HeaderText="Candidate" />
            <asp:BoundField DataField="Status" HeaderText="Status" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                    <asp:Button ID="Button3" runat="server"
                        Text="TO ON AIR"
                        OnClick="Button3_Click" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</asp:Content>
