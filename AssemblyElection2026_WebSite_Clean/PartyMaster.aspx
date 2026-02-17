<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="PartyMaster.aspx.cs" Inherits="PartyMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <td style type="text/css">
   <style type="text/css">     
    
     .style29
        {
            font-size: x-large;
            font-weight: bold;
        }
    .style30
    {
        width: 80px;
    }
    .style31
    {
        width: 213px;
    }
    .style32
    {
    }
    .style33
    {
        width: 213px;
        height: 63px;
    }
    .style34
    {
        width: 300px;
        height: 63px;
    }
    .style36
    {
        width: 102px;
    }
    .style37
    {
        width: 102px;
        height: 63px;
    }
    .style38
    {
        width: 102px;
        font-size: large;
    }
    .style39
    {
        font-size: xx-large;
        font-weight: bold;
    }
    .style40
    {
        font-size: xx-large;
    }
       .style41
       {
           width: 100px;
       }
       .style42
       {
           height: 234px;
       }
    </style>
   
    <table style="width:100%">
   
   
    <tr>
        <td class="style33">
    </td> 
        <td class="style37">
            </td>                   
        <td class="style34">
            &nbsp;</td>                   
    </tr>
   
   
    <tr>
        <td class="style31">
    </td> 
        <td class="style32" colspan="2">
            <br />
            <span >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style40">&nbsp;</span><span class="style39">ADD PARTY</span><span class="style29"><br />
            <br />
            </span></span><br />
            </td>                   
    </tr>
    <tr>
    <td class="style31">
    </td>   
        <td style="font-weight:bold; font-size: large;" class="style36">
            Party Name</td>
        <td style="font-weight:bold" class="style32">
            <asp:TextBox ID="TextBox1" runat="server" AutoComplete="Off" 
                ontextchanged="Page_Load" Width="364px"></asp:TextBox>
               <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Only Letters allowed" ValidationExpression="^[a-zA-Z(\)\.]*$"></asp:RegularExpressionValidator>--%>   
        </td>
        <td>
            &nbsp;</td>       
    </tr>
    <tr>
    <td class="style31">
    </td> 
        <td style="font-weight:bold" class="style38">
            Party Colour</td>
        <td style="font-weight:bold" class="style32">
           <asp:FileUpload ID="FileUpload1" runat="server" Height="35px" Width="363px" /> </td>
        <td class="style30">
            &nbsp;</td>
       
    </tr>
    <tr>   
        <td class="style31">
    </td> 
        <td style="font-weight:bold" class="style38">
            Party Logo</td>
        <td style="font-weight:bold" class="style32">
            <asp:FileUpload ID="FileUpload2" runat="server" Height="35px" 
                style="margin-bottom: 0px" Width="362px" />
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Medium" 
                Height="35px" onclick="Button1_Click" Text="Save" Width="116px" 
                style="background-color: #C0C0C0" />
            </td>
        <td class="style30">
            &nbsp;</td>
       
    </tr>
    <tr>
        <td class="style31">
            &nbsp;</td>
        <td class="style36">
            &nbsp;</td>
        <td class="style32">
            <br />
            <br />
        </td>
        <td>
            
            
            
            &nbsp;</td>
        
    </tr>
   <tr>
   <td></td>
   <td></td>
   <td>
            
            
            
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
    DataKeyNames="id" ShowFooter="True" 
    OnRowCancelingEdit="GridView1_RowCancelingEdit"
    OnRowDeleting="GridView1_RowDeleting" 
    OnRowEditing="GridView1_RowEditing" 
    OnRowUpdating="GridView1_RowUpdating" 
    Font-Size="Larger" Height="148px"
    style="background-color: #CCCCCC" Width="862px">

    <Columns>
        <asp:BoundField DataField="partyname" HeaderText="Party Name" />

        <asp:TemplateField HeaderText="Colour">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server"
                     />
                     <%--ImageUrl='<%# "party_img.aspx?id=" + Eval("Id") %>' Width="20%"--%>
                <asp:FileUpload ID="FileUpload3" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Logo">
            <ItemTemplate>
                <asp:Image ID="Image2" runat="server"
                   /> 
                   <%--ImageUrl='<%# "logo_img.aspx?id=" + Eval("Id") %>' Width="20%" --%>
                <asp:FileUpload ID="FileUpload4" runat="server" />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Button ID="Button2" runat="server" 
                    Text="Update" 
                    OnClick="Button2_Click" 
                    style="font-weight: 700" />
            </FooterTemplate>
        </asp:TemplateField>

        <asp:CommandField ShowEditButton="True" />
        <asp:CommandField ShowDeleteButton="True" />
 
   
    </Columns>

    <HeaderStyle Font-Bold="True" Font-Size="Medium" />
</asp:GridView>

            
            
        </td>
    <td></td>
   
   </tr>
</table>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    </asp:Content>
