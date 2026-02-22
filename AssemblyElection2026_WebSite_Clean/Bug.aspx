<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="Bug.aspx.cs" Inherits="Bug" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">    
    </script>
   
    <style type="text/css">
        .style3
        {
            height: 91px;
        }
        .style4
        {
            height: 91px;
            width: 661px;
        }
        .style6
        {
            height: 34px;
        }
        .style7
        {
            width: 661px;
            height: 26px;
        }
        .style8
        {
            height: 26px;
        }
        .style9
        {
            height: 91px;
            width: 115px;
        }
        .style10
        {
            height: 26px;
            width: 115px;
        }
        .style12
        {
            height: 97px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td>
            &nbsp;</td>
                   
        <td  colspan="4">
            <br  />
           
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
            <br />
            </td>
                   
    </tr>
    <tr>
        <td class="style6">
            <asp:Button ID="Button33" runat="server" OnClick="Button2_Click" 
                Text="Add New Party" style="font-weight: 700" Height="101px" 
                Width="327px" Font-Bold="True" Font-Size="Larger"/></td>
        <td  colspan="4" class="style6">
            &nbsp;</td>
    </tr>
 

    <tr>
        <td class="style4">
  
            <asp:GridView ID="BhGridView" runat="server" AutoGenerateColumns="False" 
                Caption="Kerala" DataKeyNames="id" Font-Bold="True" 
                onrowdeleting="BhGridView_RowDeleting" onrowcancelingedit="BhGridView_RowCancelingEdit"
                onrowediting="BhGridView_RowEditing" onrowupdating="BhGridView_RowUpdating"
               ShowFooter="True" 
                style="background-color: #CCCCCC" Width="754px" Height="236px">
                <Columns>
                    <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                    <asp:TemplateField>
                        <FooterTemplate>
                            <asp:Button ID="Button3" runat="server" onclick="BhBtn_Click" 
                                style="font-weight: 700" Text="UPDATE" />
                               <asp:Button ID="Button33" runat="server" OnClick="Button2_Click" 
                Text="Add New Party" style="font-weight: 700"/>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtBh1" runat="server" AutoComplete="Off" Max="60"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ControlToValidate="txtBh1" ErrorMessage="Only Numbers allowed" 
                                ValidationExpression="\d+$"></asp:RegularExpressionValidator>
                           <%-- <asp:RangeValidator runat="server" ID="range1" MinimumValue="0" MaximumValue="60" ControlToValidate="TextBox1"  ErrorMessage="Max Value is 60"></asp:RangeValidator>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="New_seat" HeaderText="Seat" />
                   <%-- <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtJK2" runat="server" AutoComplete="Off"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ControlToValidate="txtJK2" ErrorMessage="Only Numbers allowed" 
                                ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Voteshare" HeaderText="Vote Share" />--%>
                     <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            </td>
        <td class="style4">
            </td>
        <td class="style9">
  
            &nbsp;</td>
        <td class="style3">
  
            &nbsp;</td>
        <td class="style3">
           
            </td>
    </tr>
    <tr>
        <td class="style7"  >
            &nbsp;</td>
        <td class="style7"  >
            </td>
        <td class="style10">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
        <td class="style8">
            </td>
    </tr>
    <tr>
        <td class="style12">
            </td>
        <td class="style12" >
            </td>
        <td class="style12">
            </td>
    </tr>
   
  
</table>
</asp:Content>
