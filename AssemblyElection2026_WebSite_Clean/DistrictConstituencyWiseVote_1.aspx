<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="DistrictConstituencyWiseVote_1.aspx.cs" Inherits="DistrictConstituencyLead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style2
        {
            font-size: x-large;
        }
        .style3
        {
            height: 30px;
        }
        .auto-style1 {
            width: 353px;
        }
        .auto-style2 {
            height: 30px;
            width: 353px;
        }
        .auto-style3 {
            width: 499px;
        }
        .auto-style4 {
            height: 30px;
            width: 499px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            </td>
        <td class="style3">
            </td>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#0033CC" 
                Text="Thiruvananthapuram" CssClass="style2"></asp:Label>
        </td>
        <td class="auto-style4">
            &nbsp;
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#0033CC" 
                Text="Kollam" CssClass="style2"></asp:Label>
        </td>
        <td class="style3">
            &nbsp;
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#0033CC" 
                Text="Pathanamthitta" CssClass="style2"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" 
                ShowFooter="True" Height="200px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ConstituencyName" HeaderText="Constituency" />
                    <asp:TemplateField HeaderText="Leading Party">
                        <itemtemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="120px"></asp:DropDownList>
                        </itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vote">
                        <FooterTemplate>
                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                style="font-weight: 700; font-size: medium" Text="Update" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
        <td class="auto-style3">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" 
                ShowFooter="True" Height="330px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ConstituencyName" HeaderText="Constituency" />
                    <asp:TemplateField HeaderText="Leading Party">
                        <itemtemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="120px"></asp:DropDownList>
                        </itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vote">
                        <FooterTemplate>
                            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                                style="font-weight: 700; font-size: medium" Text="Update" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
        <td>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" 
                ShowFooter="True" Height="328px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ConstituencyName" HeaderText="Constituency" />
                    <asp:TemplateField HeaderText="Leading Party">
                        <itemtemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" Width="120px"></asp:DropDownList>
                        </itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vote">
                        <FooterTemplate>
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                style="font-weight: 700; font-size: medium" Text="Update" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#0033CC" 
                Text="Alappuzha" CssClass="style2"></asp:Label>
        </td>
        <td class="auto-style3">
            &nbsp;
            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#0033CC" 
                Text="Kottayam" CssClass="style2"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" 
                ShowFooter="True" Height="236px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ConstituencyName" HeaderText="Constituency" />
                    <asp:TemplateField HeaderText="Leading Party">
                        <itemtemplate>
                            <asp:DropDownList ID="DropDownList4" runat="server" Width="120px"></asp:DropDownList>
                        </itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vote">
                        <FooterTemplate>
                            <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                                style="font-weight: 700; font-size: medium" Text="Update" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
        <td class="auto-style3">
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" 
                ShowFooter="True" Height="325px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ConstituencyName" HeaderText="Constituency" />
                    <asp:TemplateField HeaderText="Leading Party">
    <itemtemplate>
        <asp:DropDownList ID="DropDownList5" runat="server" Width="120px"></asp:DropDownList>
    </itemtemplate>
</asp:TemplateField>
                    <asp:TemplateField HeaderText="Vote">
                        <FooterTemplate>
                            <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                                style="font-weight: 700; font-size: medium" Text="Update" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style1">
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
   
</table>
</asp:Content>
