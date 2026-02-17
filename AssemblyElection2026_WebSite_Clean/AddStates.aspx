<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="AddStates.aspx.cs" Inherits="AddStates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style6
        {
            width: 399px;
        }
        .style7
        {
            width: 399px;
            height: 25px;
        }
        .style9
        {
            height: 25px;
        }
        .style14
        {
            width: 399px;
            height: 36px;
        }
        .style16
        {
            height: 36px;
        }
        .style18
    {
            width: 82px;
        }
    .style19
    {
        width: 82px;
        height: 36px;
    }
    .style20
    {
        width: 82px;
        height: 25px;
    }
        .style23
        {
            font-family: "Courier New", Courier, monospace;
        font-size: xx-large;
    }
        .style26
        {
            width: 82px;
            font-size: x-large;
            height: 50px;
        }
        .style27
        {
            width: 399px;
            height: 50px;
        }
        .style28
        {
        height: 50px;
    }
        .style29
        {
            font-size: x-large;
            font-weight: bold;
        }
    .style30
    {
        font-size: xx-large;
        font-weight: bold;
    }
    .style31
    {
        height: 50px;
        width: 522px;
    }
    .style32
    {
        width: 522px;
    }
    .style33
    {
        height: 36px;
        width: 522px;
    }
    .style34
    {
        height: 25px;
        width: 522px;
    }
    .style35
    {
        width: 399px;
        height: 46px;
    }
    .style36
    {
        width: 82px;
        font-size: x-large;
        height: 46px;
    }
    .style37
    {
        height: 46px;
        width: 522px;
    }
    .style38
    {
        height: 46px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="font-size: 15px">
    <tr>
        <td colspan="4">
            <br />
            <span >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
            &nbsp;&nbsp;&nbsp;<span class="style23">&nbsp;</span><span class="style30">ADD 
            STATES</span><span class="style29"><br />
            </span></span><br />
            <br />
            </td>
                   
    </tr>
    <tr>
        <td class="style27">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;</td>
        <td class="style26">
            &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="State    Name   " Font-Bold="True" 
                Font-Size="Large" width="145px" Height="26px"
               ></asp:Label>
 </td>
        <td colspan="1" rowspan="1" class="style31">
           
            <br />
           
            <asp:TextBox ID="TextBox1" runat="server" Width="236px" AutoComplete="Off" 
                Height="24px"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Only Letters  & Special characters allowed" ValidationExpression="^[a-zA-Z\s\W]+$" Display="Dynamic">
                            </asp:RegularExpressionValidator>        
        </td>
        <td class="style28">
            </td>
        <td class="style28">
            </td>
    </tr>
    <tr>
        <td class="style35">
            </td>
        <td class="style36">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                ID="Label2" runat="server" Text="Total Seats" Font-Bold="True" width="143px"
                Font-Size="Large" Height="26px"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             </td>
        <td class="style37">
            <asp:TextBox ID="TextBox2" runat="server"  autocomplete="off" Width="235px" 
                Height="24px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
        </td>
        <td class="style38">
            </td>
        <td class="style38">
            </td>
    </tr>
    <tr>
        <td class="style7">
            </td>
        <td class="style20">
            </td>
        <td class="style34">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" 
                Font-Bold="True" Font-Size="Large" Height="40px" Width="105px" 
                style="background-color: #C0C0C0" />
            </td>
        <td class="style9">
            </td>
        <td class="style9">
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style18">
            &nbsp;</td>
        <td class="style32">
            <br />
            <asp:GridView ID="GridView1" runat="server" autocomplete="off" 
                AutoGenerateColumns="False" DataKeyNames="id" Font-Size="Large" Height="157px" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                style="background-color: #CCCCCC" Width="483px">
                <Columns>
                    <asp:BoundField DataField="Statename" HeaderText="States" />
                    <asp:BoundField DataField="Total_Seat" HeaderText="Total Seats" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
                <HeaderStyle Font-Size="Larger" />
            </asp:GridView>
           
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

</asp:Content>