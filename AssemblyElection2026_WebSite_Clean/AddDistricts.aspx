<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="AddDistricts.aspx.cs" Inherits="AddDistricts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style6
        {
            width: 424px;
        }
        .style7
        {
            width: 424px;
            height: 25px;
        }
        .style9
        {
            height: 25px;
        }
        .style14
        {
            width: 424px;
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
        .style27
        {
            width: 424px;
            height: 80px;
        }
        .style28
        {
            height: 87px;
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
        .style41
        {
            height: 87px;
            width: 522px;
        }
        .style44
        {
            width: 424px;
            height: 20px;
        }
        .style45
        {
            height: 20px;
            width: 522px;
        }
        .style46
        {
            height: 20px;
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
            DISTRICTS</span><span class="style29"><br />
            </span></span><br />
            <br />
            </td>
                   
    </tr>
    <tr>
        <td class="style27">
            </td>
      
        <td class="style27">
            &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="State" Font-Bold="True" 
                Font-Size="Large" width="177px" Height="18px"
               ></asp:Label>
            <br />
 </td>
        <td class="style27">
            <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" 
                Height="30px" Width="355px" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td class="style21">
            </td>
    </tr>
  
    <tr>
        <td class="style27">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;</td>
        <td class="style27">
            &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="District Name" Font-Bold="True" 
                Font-Size="Large" width="177px" Height="18px"
               ></asp:Label>
            <br />
 </td>
        <td colspan="1" rowspan="1" class="style41">
           
            <br />
           
            <asp:TextBox ID="TextBox1" runat="server" Width="236px" AutoComplete="Off" 
                Height="30px"></asp:TextBox>
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
        <td class="style44">
            </td>
        <td class="style27">
            &nbsp;&nbsp;&nbsp;<asp:Label 
                ID="Label2" runat="server" Text="Total Seats" Font-Bold="True" width="145px"
                Font-Size="Large" Height="26px"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             </td>
        <td class="style45">
            <asp:TextBox ID="TextBox2" runat="server"  autocomplete="off" Width="235px" 
                Height="30px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
        </td>
        <td class="style46">
            </td>
        <td class="style46">
            </td>
    </tr>
    <tr>
        <td class="style14">
            </td>
        <td class="style19">
            &nbsp;</td>
        <td class="style33">
            &nbsp;</td>
        <td class="style16">
            </td>
        <td class="style16">
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
                style="background-color: #CCCCCC" Width="634px">
                <Columns>
                    <asp:BoundField DataField="Statename" HeaderText="States" />
                    <asp:BoundField DataField="Districtname" HeaderText="Districts" />
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