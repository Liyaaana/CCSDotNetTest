<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="Constituency_insertion.aspx.cs" Inherits="Constituency_insertion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style6
        {
        width: 402px;
    }
        .style7
        {
            width: 402px;
            height: 25px;
        }
        .style9
        {
            height: 25px;
        }
        .style10
        {
        width: 402px;
        height: 54px;
    }
        .style12
        {
            height: 54px;
        }
        .style17
    {
        width: 130px;
    }
    .style19
    {
        width: 130px;
        height: 25px;
    }
    .style20
    {
        width: 130px;
        height: 54px;
    }
        .style21
        {
            
        }
        .style22
        {
            font-size: x-large;
        }
        .style23
        {
            width: 402px;
            height: 23px;
        }
        .style24
        {
            width: 130px;
            height: 23px;
        }
        .style25
        {
            height: 23px;
        }
        .style26
        {
            width: 100%;
            height: 54px;
        }
    .style27
    {
        font-family: "Times New Roman", Times, serif;
    }
    .style28
    {
        font-size: xx-large;
    }
        .style29
        {
            width: 402px;
            height: 62px;
        }
        .style30
        {
            width: 130px;
            height: 62px;
        }
        .style31
        {
            height: 62px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style10">
            </td>
                   
             <td  colspan="2" class="style26" 
            style="font-size: 21px; font-weight: bold;">
            <br class="style28" />
                 <span class="style28">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span 
                     class="style21"><span class="style28">&nbsp; <span class="style27">
                 CONSTITUENCY INSERTION</span></span><span class="style22"><br />
                 </span></span><br />
            <br />
        </td>
            
        <td class="style12">
            </td>
        <td class="style12">
            </td>
        <td class="style12">
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;</td>
        <td class="style17">
            &nbsp;</td>
        <td colspan="1" rowspan="1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style17">
            <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: large; text-align: right;" 
                Text="State Name"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Height="35px" 
                Width="400px" style="margin-left: 0px">
            </asp:DropDownList>
        </td>
        
        <td class="style62">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td class="style68">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
   
    <tr>
        <td class="style29">
            </td>
        <td class="style30">
            <asp:Label ID="Label3" runat="server" style="text-align: right; font-size: large;" 
                Text="District" Font-Size="Medium" Font-Bold="True"></asp:Label>
            </td>
        <td class="style31">
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged" Height="35px" 
                Width="400px" style="margin-left: 0px">
            </asp:DropDownList>
            <br />
        </td>
        <td class="style31">
            </td>
        <td class="style31">
            </td>
    </tr>
   
    <tr>
        <td class="style7">
            </td>
        <td class="style19">
            <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: large" 
                Text="Constituency"></asp:Label>
            </td>
        <td class="style9">
            <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
                Height="30px" Width="400px" AutoComplete="Off" style="margin-left: 0px"></asp:TextBox>
                 <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Only Letters allowed" ValidationExpression="^[^\W\d]+$"></asp:RegularExpressionValidator>--%>
            </td>
        <td class="style9">
            </td>
        <td class="style9">
            </td>
    </tr>
    <tr>
        <td class="style10">
            </td>
        <td class="style20">
            </td>
        <td class="style12">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                style="font-weight: 700; background-color: #C0C0C0;" 
                Text="Save" Height="30px" Width="151px" />
        </td>
        <td class="style12">
            </td>
        <td class="style12">
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style17">
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
        <td class="style17">
            </td>
        <td>
            &nbsp;</td>
        <td>
            </td>
        <td>
            </td>
    </tr>
    <tr>
        <td class="style23">
            </td>
        <td class="style24">
            </td>
        <td class="style25">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                onrowupdating="GridView1_RowUpdating" Width="833px" Font-Size="Medium" 
                style="font-weight: 700; background-color: #CCCCCC">
                <Columns>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <FooterStyle Font-Size="X-Large" />
            </asp:GridView>
        </td>
        <td class="style25">
            &nbsp;</td>
        <td class="style25">
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style17">
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
