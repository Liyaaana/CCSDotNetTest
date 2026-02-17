<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="AddPreviousYearSeats.aspx.cs" Inherits="AddPreviousYearSeats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style3
        {
            height: 22px;
        }
        .style5
        {
            height: 22px;
            width: 467px;
        }
        .style6
        {
            width: 467px;
        }
        .style7
        {
            width: 467px;
            height: 25px;
        }
        .style9
        {
            height: 25px;
        }
        .style10
        {
            width: 467px;
            height: 54px;
        }
        .style12
        {
            height: 54px;
        }
        .style14
        {
            width: 467px;
            height: 42px;
        }
        .style16
        {
            height: 42px;
        }
        .style22
    {
        font-size: x-large;
    }
        .style23
        {
            width: 203px;
        }
        .style24
        {
            height: 42px;
            width: 203px;
            font-size: x-large;
            font-weight: bold;
        }
        .style25
        {
            height: 25px;
            width: 203px;
        }
        .style26
        {
            height: 54px;
            width: 203px;
        }
        .style27
        {
            width: 203px;
            font-size: large;
        }
        .style31
        {
            width: 467px;
            height: 23px;
        }
        .style32
        {
            width: 203px;
            height: 23px;
        }
        .style33
        {
            height: 23px;
        }
    .style34
    {
        font-size: xx-large;
        font-weight: bold;
    }
    .style35
    {
        font-size: xx-large;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr style="height:100px;">
        <td class="style5">
            </td>
                   
             <td  colspan="2" class="style1" style="font-size: 5px; font-weight: bold;">
            <br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span 
                     class="style35">&nbsp;&nbsp;</span><span class="style22">&nbsp;<span 
                     class="style34">Add Previous Year Seats</span></span><br />
            <br />
        </td>
            
        <td class="style3">
            </td>
        <td class="style3">
            </td>
        <td class="style3">
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;</td>
        <td class="style27">
            &nbsp;</td>
        <td colspan="1" rowspan="1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            </td>
        <td class="style24">
            State&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style16">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Height="29px" 
                Width="400px" style="margin-left: 0px">
            </asp:DropDownList>
        </td>
        <td class="style16">
            </td>
        <td class="style16">
            </td>
    </tr>
    <tr>
        <td class="style14">
            </td>
        <td class="style24">
            District&nbsp;&nbsp;&nbsp;
        </td>
        <td class="style16">
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged" Height="29px" 
                Width="400px" style="margin-left: 0px">
            </asp:DropDownList>
        </td>
        <td class="style16">
            </td>
        <td class="style16">
            </td>
    </tr>
    <tr>
        <td class="style7">
            </td>
        <td class="style25">
            &nbsp;</td>
        <td class="style9">
            </td>
        <td class="style9">
            </td>
        <td class="style9">
            </td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style26">
            &nbsp;</td>
        <td class="style12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" ShowFooter="True" Height="266px" Width="511px" 
                style="font-weight: 700; background-color: #CCCCCC" >
                <Columns>
                    <asp:BoundField DataField="partyname" HeaderText="Party Name" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Prev Year Seat">
                        <FooterTemplate>
                      <asp:Button ID="Button1"  runat="server" onclick="Button1_Click" 
                                style="font-weight: 700" Text="UPDATE" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1"  Max="60" AutoComplete="Off" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" AutoComplete="Off" 
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                           <%-- <asp:RangeValidator runat="server" ID="range1" MinimumValue="0" MaximumValue="60" ControlToValidate="TextBox1"  ErrorMessage="Max Value is 60"></asp:RangeValidator>--%>
                        </ItemTemplate>
                        <HeaderStyle Font-Size="Medium" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Pre_yr_seat" HeaderText="Seat" >
                 
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                 
                </Columns>
                <HeaderStyle Font-Size="X-Large" />
            </asp:GridView> 
            </td>
        <td class="style12">
            </td>
        <td class="style12">
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style23">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            </td>
        <td class="style23">
            </td>
        <td>
            &nbsp;</td>
        <td>
            </td>
        <td>
            </td>
    </tr>
    <tr>
        <td class="style31">
            </td>
        <td class="style32">
            </td>
        <td class="style33">
            </td>
        <td class="style33">
            </td>
        <td class="style33">
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style23">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>