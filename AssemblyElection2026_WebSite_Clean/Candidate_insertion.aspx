<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="Candidate_insertion.aspx.cs" Inherits="Candidate_insertion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       
        .style4
        {
            width: 527px;
        }
                   
    .style16
    {
        width: 436px;
    }
   
        .style35
    {
        width: 152px;
    }
    .style36
    {
        width: 332px;
    }
    .style40
    {
        width: 124px;
    }
   
        .style41
        {
            font-size: x-large;
            font-weight: bold;
        }
   
        .style42
        {
            width: 211px;
        }
   
        .auto-style1 {
            width: 332px;
            height: 40px;
        }
        .auto-style2 {
            width: 124px;
            height: 40px;
        }
        .auto-style3 {
            width: 436px;
            height: 40px;
        }
        .auto-style4 {
            width: 211px;
            height: 40px;
        }
        .auto-style5 {
            width: 152px;
            height: 40px;
        }
        .auto-style6 {
            height: 40px;
        }
        .auto-style7 {
            width: 527px;
            height: 40px;
        }
   
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <br />
            <br />
            <br />
            <br />
            </td>
        <td class="style41" >
            CANDIDATE&nbsp;INSERTION
               
        </td>
       
    </tr>
    <tr>
        <td class="auto-style1">
            </td>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server"  Text="State " Font-Size="Large" 
                Font-Bold="True"></asp:Label>
            </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Height="35px" 
                Width="430px">
            </asp:DropDownList>
            </td>
            
            <td class="auto-style4">
            <asp:Label ID="Label10" runat="server" 
                Text="Party " Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DropDownList4" runat="server" Height="35px" Width="430px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
            
        <td class="auto-style5">
            </td>
        <td class="auto-style6">
        </td>
        <td class="auto-style7">
            </td>
    </tr>
    <tr>
        <td class="auto-style1">
            </td>
        <td class="auto-style2">
            <asp:Label ID="Label9" runat="server"  Text="District " Font-Size="Large" 
                Font-Bold="True"></asp:Label>
            </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged" Height="35px" 
                Width="430px">
            </asp:DropDownList>
            </td>
            
            <td class="auto-style4">
            <asp:Label ID="Label17" runat="server" 
                Text="Sub Party " Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DropDownList5" runat="server" Height="35px" Width="430px">
            </asp:DropDownList>
            </td>
            
        <td class="auto-style5">
            </td>
        <td class="auto-style6">
            </td>
        <td class="auto-style7">
            </td>
    </tr>
    <tr>
        <td class="auto-style1">
            </td>
        <td class="auto-style2">
            <asp:Label ID="Label2" runat="server"  Text="Constituency" Font-Bold="True" 
                Font-Size="Large"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged" Height="30px" 
                Width="430px">
            </asp:DropDownList>
        </td>
        <td class="auto-style4">
            <asp:Label ID="Label16" runat="server" 
                 Text="Image" 
                Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
        <td class="auto-style6">
            <asp:FileUpload ID="FileUpload1" runat="server" Height="35px" 
                style="margin-bottom: 0px" Width="430px" />
            </td>
        <td class="auto-style6">
            </td>
    </tr>
    <tr>
        <td >
            &nbsp;</td>
        <td>
            <asp:Label ID="Label3" runat="server" 
                Text="Candidate" Font-Bold="True" Font-Size="Large"></asp:Label>
        </td>
        <td >
            <asp:TextBox ID="TextBox1" autocomplete="off" runat="server" Height="30px"
                Width="426px"></asp:TextBox>
        </td>
        <td class="style42" >
            <asp:Label ID="Label15" runat="server" 
                 Text="Logo" Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
        <td>
            <asp:FileUpload ID="FileUpload2" runat="server" Height="35px" Width="430px" />
            </td>
        <td>
            </td>
    </tr>
    <tr>
        <td class="auto-style6">
            </td>
        <td class="auto-style6" >
            </td>
        <td class="auto-style6" >
            </td>
        <td class="auto-style4" >
            <asp:Label ID="Label14" runat="server" 
                 Text="Party Colour" 
                Font-Size="Large" Font-Bold="True"></asp:Label>
            </td>
        <td class="auto-style6" >
              <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Only Letters allowed" ValidationExpression="^[^\W\d]+$"></asp:RegularExpressionValidator>--%>
            <asp:FileUpload ID="FileUpload3" runat="server" Width="430px" height="35px"/>
        </td>
        <td class="auto-style6">
            </td>
    </tr>
    <tr>
        <td class="auto-style6">
            </td>
        <td class="auto-style6" >
            </td>
        <td class="auto-style6" >
            </td>
        <td class="auto-style4" >
            </td>
        <td class="auto-style6" >
            <asp:CheckBox ID="CheckBox1" runat="server" Text="VIP" />
        </td>
        <td class="auto-style6">
            </td>
    </tr>
    <tr>
        <td >
            &nbsp;</td>
        <td>
            </td>
        <td> 
            </td>
        <td class="style42" >
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                style="font-weight: 700;width: 200px; background-color: #C0C0C0;" 
                Text="Submit" Height="36px" 
                Width="148px" Font-Bold="True" Font-Size="Medium" />
            </td>
        <td >
            &nbsp;</td>
        <td >
            </td>
    </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" ShowFooter="True" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating" 
        style="font-weight: 700; background-color: #CCCCCC; margin-right: 0px; margin-top: 65px;" 
        Width="917px" Height="359px">
    <Columns>
        <asp:BoundField DataField="CantiName" HeaderText="Candidate" />
        <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "count_image.aspx?id=" + Eval("id") %>' Width="27%" />
                <asp:FileUpload ID="FileUpload4" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Logo">
            <ItemTemplate>
                <asp:Image ID="Image2" runat="server" ImageUrl='<%# "logo_img.aspx?id=" + Eval("id") %>' Width="27%" />
                <asp:FileUpload ID="FileUpload5" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Party Colour">
            <ItemTemplate>
                <asp:Image ID="Image3" runat="server" ImageUrl='<%# "party_img.aspx?id=" + Eval("id") %>' Width="27%" />
                <asp:FileUpload ID="FileUpload6" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" style="font-weight: 700" Text="Update" />
            </FooterTemplate>
        </asp:TemplateField>
     
        <asp:CommandField ShowEditButton="True" />
        <asp:CommandField ShowDeleteButton="True" />
        
    </Columns>
</asp:GridView>
</asp:Content>
