<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="Bug.aspx.cs" Inherits="Bug" MaintainScrollPositionOnPostBack="true" %>

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
        .auto-style1 {
            margin-top: 0px;
        }
    .auto-style2 {
        height: 51px;
    }
        .auto-style3 {
            width: 262px;
        }
        .auto-style4 {
            height: 34px;
            width: 262px;
        }
        .auto-style5 {
            height: 91px;
            width: 262px;
        }
        .auto-style6 {
            width: 262px;
            height: 26px;
        }
        .auto-style7 {
            height: 97px;
            width: 262px;
        }
        .auto-style8 {
            height: 51px;
            width: 262px;
        }
        .auto-style9 {
            margin-left: 0px;
        }
        .auto-style10 {
            width: 606px;
        }
        .auto-style11 {
            height: 34px;
            width: 606px;
        }
        .auto-style12 {
            height: 91px;
            width: 606px;
        }
        .auto-style13 {
            height: 26px;
            width: 606px;
        }
        .auto-style14 {
            height: 97px;
            width: 606px;
        }
        .auto-style15 {
            height: 51px;
            width: 606px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td class="auto-style3">
            &nbsp;</td>
                   
        <td class="auto-style10">
            &nbsp;</td>
                   
        <td  colspan="4">
            <br  />
           
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
            <br />
            </td>
                   
    </tr>
    <tr>
        <td class="auto-style4">
            &nbsp;</td>
        <td class="auto-style11">
            <asp:Button ID="Button0" runat="server" OnClick="Button2_Click" 
                Text="Add New Party" style="font-weight: 700" Height="101px" 
                Width="327px" Font-Bold="True" Font-Size="Larger"/></td>
        <td  colspan="4" class="style6">
            &nbsp;</td>
    </tr>
 

    <tr>
        <td class="auto-style5">
  
            &nbsp;</td>
        <td class="auto-style12">
  
            <asp:GridView ID="BhGridView" runat="server" AutoGenerateColumns="False" 
                Caption="Kerala Bug" DataKeyNames="id" Font-Bold="True" 
                onrowdeleting="BhGridView_RowDeleting" onrowcancelingedit="BhGridView_RowCancelingEdit"
                onrowediting="BhGridView_RowEditing" onrowupdating="BhGridView_RowUpdating"
               ShowFooter="True" 
                style="background-color: #CCCCCC" Width="930px" Height="236px" CssClass="auto-style9">
                <Columns>
                    <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                    <asp:TemplateField>
                        <FooterTemplate>
                            <asp:Button ID="Button1" runat="server" onclick="BhBtn_Click" 
                                style="font-weight: 700" Text="UPDATE" />
                               <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" 
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
            &nbsp;</td>
        <td class="style9">
  
            &nbsp;</td>
        <td class="style3">
  
            &nbsp;</td>
        <td class="style3">
           
            </td>
    </tr>
    <tr>
        <td class="auto-style6"  >
  
            &nbsp;</td>
        <td class="auto-style13"  >
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:GridView ID="LDFGridView" runat="server" AutoGenerateColumns="False" 
                Caption="LDF Bug" DataKeyNames="id" Font-Bold="True" 
                onrowdeleting="LDFGridView_RowDeleting" onrowcancelingedit="LDFGridView_RowCancelingEdit"
                onrowediting="LDFGridView_RowEditing" onrowupdating="LDFGridView_RowUpdating"
               ShowFooter="True" 
                style="background-color: #CCCCCC" Width="927px" Height="236px">
                <Columns>
                    <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                    <asp:TemplateField>
                        <FooterTemplate>
                            <asp:Button ID="Button3" runat="server" onclick="LDFBtn_Click" 
                                style="font-weight: 700" Text="UPDATE" />
                               <asp:Button ID="Button4" runat="server" OnClick="Button2_Click" 
                Text="Add New Party" style="font-weight: 700"/>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="LDFtxtBh1" runat="server" AutoComplete="Off" Max="60"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                ControlToValidate="LDFtxtBh1" ErrorMessage="Only Numbers allowed" 
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
        <td class="style7"  >
  
            &nbsp;</td>
        <td class="style10">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
        <td class="style8">
            </td>
    </tr>
    <tr>
        <td class="auto-style6"  >
            &nbsp;</td>
        <td class="auto-style13"  >
            &nbsp;</td>
        <td class="style7"  >
            &nbsp;</td>
        <td class="style10">
            &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6"  >
            &nbsp;</td>
        <td class="auto-style13"  >
  
            <asp:GridView ID="UDFGridView" runat="server" AutoGenerateColumns="False" 
                Caption="UDF Bug" DataKeyNames="id" Font-Bold="True" 
                onrowdeleting="UDFGridView_RowDeleting" onrowcancelingedit="UDFGridView_RowCancelingEdit"
                onrowediting="UDFGridView_RowEditing" onrowupdating="UDFGridView_RowUpdating"
               ShowFooter="True" 
                style="background-color: #CCCCCC" Width="928px" Height="236px">
                <Columns>
                    <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                    <asp:TemplateField>
                        <FooterTemplate>
                            <asp:Button ID="Button5" runat="server" onclick="UDFBtn_Click" 
                                style="font-weight: 700" Text="UPDATE" />
                               <asp:Button ID="Button6" runat="server" OnClick="Button2_Click" 
                Text="Add New Party" style="font-weight: 700"/>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="UDFtxtBh1" runat="server" AutoComplete="Off" Max="60"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ControlToValidate="UDFtxtBh1" ErrorMessage="Only Numbers allowed" 
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
        <td class="style7"  >
            &nbsp;</td>
        <td class="style10">
            &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7">
  
            &nbsp;</td>
        <td class="auto-style14">
  
            <asp:GridView ID="NDAGridView" runat="server" AutoGenerateColumns="False" 
                Caption="NDA Bug" DataKeyNames="id" Font-Bold="True" 
                onrowdeleting="NDAGridView_RowDeleting" onrowcancelingedit="NDAGridView_RowCancelingEdit"
                onrowediting="NDAGridView_RowEditing" onrowupdating="NDAGridView_RowUpdating"
               ShowFooter="True" 
                style="background-color: #CCCCCC" Width="927px" Height="236px">
                <Columns>
                    <asp:BoundField DataField="partyname" HeaderText="Party Name" />
                    <asp:TemplateField>
                        <FooterTemplate>
                            <asp:Button ID="Button7" runat="server" onclick="NDABtn_Click" 
                                style="font-weight: 700" Text="UPDATE" />
                               <asp:Button ID="Button8" runat="server" OnClick="Button2_Click" 
                Text="Add New Party" style="font-weight: 700"/>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="NDAtxtBh1" runat="server" AutoComplete="Off" Max="60"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                ControlToValidate="NDAtxtBh1" ErrorMessage="Only Numbers allowed" 
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
        <td class="style12" >
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </td>
        <td class="style12">
            </td>
    </tr>
   
  
    <tr>
        <td class="auto-style8">
            </td>
        <td class="auto-style15">
            </td>
        <td class="auto-style2" >
            </td>
        <td class="auto-style2">
            </td>
    </tr>
   
  
</table>
</asp:Content>
