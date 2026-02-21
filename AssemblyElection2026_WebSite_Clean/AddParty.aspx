<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="AddParty.aspx.cs" Inherits="AddParty" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
         font-weight: bold;
    }
        .style6
        {
            width: 491px;
        }
        .style7
        {
            width: 491px;
            height: 19px;
        }
        .style10
        {
            width: 491px;
            height: 64px;
        }
        .style14
        {
            width: 491px;
            height: 38px;
        }
        .style16
        {
            height: 38px;
        }
        .style18
    {
            width: 120px;
        }
        .style27
        {
            height: 168px;
        }
        .style29
        {
            height: 19px;
        }
        .style30
        {
            height: 64px;
        width: 381px;
    }
        #File1
        {
            margin-bottom: 0px;
        }
        .style35
        {
        width: 491px;
        height: 26px;
    }
        .style36
        {
        width: 120px;
        height: 26px;
        font-size: large;
    }
        .style37
        {
            height: 26px;
        }
        .style38
        {
        font-size: x-large;
        font-family: "Times New Roman", Times, serif;
    }
        .style39
        {
            width: 381px;
            height: 26px;
        }
        .style40
        {
            width: 381px;
            height: 38px;
        }
        .style41
        {
            width: 381px;
            height: 19px;
        }
        .style42
        {
            width: 120px;
            height: 64px;
        }
        .style43
        {
            width: 381px;
        }
        .style44
    {
        width: 120px;
        font-size: large;
    }
        .auto-style2 {
            width: 380px;
            height: 21px;
        }
        .auto-style4 {
            width: 380px;
            height: 64px;
        }
        .auto-style5 {
            width: 380px;
        }
        .auto-style13 {
            width: 166px;
            font-size: large;
            height: 21px;
        }
        .auto-style14 {
            width: 381px;
            height: 21px;
        }
        .auto-style15 {
            height: 21px;
        }
        .auto-style20 {
            width: 166px;
            height: 64px;
        }
        .auto-style21 {
            width: 166px;
        }
        .auto-style30 {
            width: 380px;
            height: 50px;
        }
        .auto-style31 {
            width: 166px;
            font-size: large;
            height: 50px;
        }
        .auto-style32 {
            width: 381px;
            height: 50px;
        }
        .auto-style33 {
            height: 50px;
        }
        .auto-style34 {
            width: 380px;
            height: 46px;
        }
        .auto-style35 {
            width: 166px;
            font-size: large;
            height: 46px;
        }
        .auto-style36 {
            width: 381px;
            height: 46px;
        }
        .auto-style37 {
            height: 46px;
        }
        .auto-style38 {
            width: 380px;
            height: 14px;
        }
        .auto-style39 {
            width: 166px;
            font-size: large;
            height: 14px;
        }
        .auto-style40 {
            width: 381px;
            height: 14px;
        }
        .auto-style41 {
            height: 14px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="font-size: 15px; height: 461px;">
    <tr>
    
        <%--<td class="style5" colspan="5">
            <br class="style22" />
            <span class="style22">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style23">&nbsp;</span><span 
                class="style34">Add 
            Party To Bugs<br />
            </span></span><br />
            <br />
            </td>--%>
                   
    </tr>
    <tr>
        <td class="style27" colspan="5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;<br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span class="style38">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="ADD NEW PARTY" 
                CssClass="style38"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style34">
            </td>
        <td class="auto-style35">
            State           
        </td>
        <td class="auto-style36">
            <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" Height="37px" Width="355px" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td class="auto-style37">
            </td>
    </tr>
    <tr>
        <td class="auto-style30">
            </td>
        <td class="auto-style31">
            District           
        </td>
        <td class="auto-style32">
            <asp:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="True" 
                Height="37px" Width="355px" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td class="auto-style33">
            </td>
    </tr>
    <tr>
        <td class="auto-style2">
            </td>
        <td class="auto-style13">
            Add Party</td>
        <td class="auto-style14">
            <%--<asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>--%>
         <asp:TextBox ID="TextBox1" runat="server" AutoComplete="Off" 
                ontextchanged="Page_Load" Height="27px" Width="350px"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Only Letters  & Special characters allowed" ValidationExpression="^[a-zA-Z\s\W]+$" Display="Dynamic">
                            </asp:RegularExpressionValidator>
        </td>
        <td class="auto-style15">
            </td>
        <td class="auto-style15">
            </td>
    </tr>
<%--    <tr>
        <td class="style7">
            </td>
        <td class="style44">
            Party Face </td>
        <td class="style41">
           <asp:FileUpload ID="FileUpload4" runat="server" Height="35px" 
                style="margin-bottom: 0px" Width="355px" /> </td>
        <td class="style29">
            </td>
        <td class="style29">
            </td>
    </tr>
    <tr>
        <td class="style7">
            </td>
        <td class="style44">
            Party Logo </td>
        <td class="style41">
           <asp:FileUpload ID="FileUpload2" runat="server" Height="35px" 
                style="margin-bottom: 0px" Width="355px" /> </td>
        <td class="style29">
            </td>
        <td class="style29">
            </td>
    </tr>--%>
    <tr>
        <td class="auto-style38">
            </td>
        <td class="auto-style39">
            Party Colour </td>
        <td class="auto-style40">
           <asp:FileUpload ID="FileUpload1" runat="server" Height="35px" 
                style="margin-bottom: 0px" Width="355px" /> </td>
        <td class="auto-style41">
        
        
            </td>
        <td class="auto-style41">
            </td>
    </tr>
    
    <tr>
        <td class="auto-style4">
            </td>
        
        
        <td class="auto-style20">
            </td>
        <td class="style30">
        
        
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Medium" 
                Height="31px" onclick="Button1_Click" Text="Save" Width="84px" 
                style="background-color: #C0C0C0" />
            
            
            <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Size="Medium" PostBackUrl="~/Bug.aspx" 
                Height="31px" onclick="Button1_Click" Text="Back" Width="84px" 
                style="background-color: #C0C0C0; margin-left: 73px; margin-top: 1px;" />
            
            
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
        <td class="auto-style21">
            &nbsp;</td>
        <td class="style43">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" Font-Size="Medium" Height="16px" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                onrowupdating="GridView1_RowUpdating" ShowFooter="True" 
                style="background-color: #CCCCCC; margin-top: 0px;" Width="547px" >
                <Columns>
                    <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                   <%-- <asp:TemplateField HeaderText="Colour">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" 
                                ImageUrl='<%# "count_img.aspx?id="+Eval("id") %>' Width="17%" />
                            <asp:FileUpload ID="FileUpload3" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                style="font-weight: 700" Text="Update" />
                        </FooterTemplate>
                    </asp:TemplateField>--%>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <HeaderStyle Font-Bold="True" Font-Size="Medium" />
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
<table>
<tr>
<td></td>
<td>

</td></tr>
</table>

</asp:Content>



