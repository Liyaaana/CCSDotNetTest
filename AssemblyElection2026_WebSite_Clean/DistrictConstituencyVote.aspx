<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="DistrictConstituencyVote.aspx.cs" Inherits="DistrictConstituencyVote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style3
        {
            height: 25px;
        }
        .style4
        {
        }
        .style6
        {
            height: 25px;
            width: 318px;
        }
    .style7
    {
        height: 139px;
    }
    .style9
    {
        width: 139px;
    }
    .style11
    {
        height: 25px;
        width: 139px;
    }
        .style16
        {
            width: 197px;
        }
        .style18
        {
            height: 25px;
            width: 197px;
        }
        .style19
        {
            width: 61px;
        }
        .style21
        {
            height: 25px;
            width: 61px;
        }
        .style24
        {
            height: 25px;
            width: 87px;
        }
        .style32
        {
            width: 318px;
            height: 230px;
        }
        .style35
        {
            width: 197px;
            height: 230px;
        }
        .style36
        {
            width: 61px;
            height: 230px;
        }
        .style37
        {
            width: 139px;
            height: 230px;
        }
        .style38
        {
            height: 230px;
        }
        .style39
        {
            font-size:xx-large;
            font-weight:bold;
            
        }
        .style42
        {
            width: 626px;
        }
        .style44
        {
        height: 12px;
    }
        .style46
        {
            width: 958px;
            height: 31px;
        }
        .style47
        {
            width: 779px;
            height: 42px;
        }
        .style51
        {
            width: 318px;
        }
        .style53
        {
            width: 87px;
            height: 42px;
        }
        .style58
    {
        font-size: xx-large;
    }
        .style59
        {
            width: 87px;
        }
        .style60
        {
            width: 197px;
            height: 42px;
        }
        .style61
        {
            width: 100px;
            height: 31px;
        }
        .style62
        {
            width: 60px;
            height: 31px;
        }
        .style67
        {
            height: 31px;
        }
        .style68
        {
            width: 197px;
            height: 31px;
        }
        .style69
        {
            width: 779px;
            height: 31px;
        }
        .style74
        {
            width: 100px;
            height: 139px;
        }
        .style75
        {
            height: 139px;
            width: 5px;
        }
        .style76
        {
            width: 5px;
        }
        .style77
        {
            height: 25px;
            width: 5px;
        }
        .style78
        {
            height: 230px;
            width: 5px;
        }
        .style79
        {
            width: 5px;
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
    <td class="style74"></td>
    <td class="style75"></td>
        <td class="style7" colspan="9">
          
            
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span 
                    class="style39">District Constituency Lead Status&nbsp;&nbsp;</span><span class="style58">&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        </td>
    </tr>
      <tr>
      <td style="width:100px"></td>
        <td class="style76">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;</td>
        <td class="style53">
            <asp:Label ID="Label1" runat="server" style="text-align: right; font-size: large;" 
                Text="State" Font-Size="Medium" Font-Bold="True"></asp:Label>
          </td>
        <td class="style60">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Height="35px" 
                Width="430px" 
                style="margin-bottom: 7px;  font-size: Medium; margin-left: 11px;">
            </asp:DropDownList>
            </td>
        <td class="style47">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;</td>
        <td >
            </td>
        <td >
            </td>
        <td >
            </td>
        <td>
            
            </td>
        <td >
            </td>
        <td >
            </td>
    </tr>
      <tr>
      <td class="style61"></td>
        <td class="style79">
            </td>
        <td class="style62">
            &nbsp;<asp:Label ID="Label2" runat="server" style="text-align: right; font-size: large;" 
                Text="District" Font-Size="Medium" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td class="style68">
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged" Height="35px" 
                Width="430px" 
                style="margin-bottom: 7px;  font-size: Medium; margin-left: 10px;">
            </asp:DropDownList>
          </td>
        <td class="style46">
            </td>
        <td class="style69">
            </td>
        <td class="style67" >
            </td>
        <td class="style67" >
            </td>
        <td class="style67" >
            </td>
        <td class="style67">
            
            </td>
        <td class="style67" >
            </td>
        <td class="style67" >
            </td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style77">
            &nbsp;</td>
        <td class="style24">
            &nbsp;</td>
        <td class="style18">
            </td>
        <td class="style21">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
        <td class="style3">
            &nbsp;</td>
        <td class="style3">
            </td>
        <td class="style3">
            </td>
    </tr>
    <tr>
        <td class="style32">
            </td>
        <td class="style78">
             &nbsp;</td>
        <td class="style59">
             &nbsp;</td>
        <td class="style35">
             <asp:GridView ID="GridView1" 
                runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" ShowFooter="True" Width="560px" Height="63px" 
                 style="background-color: #CCCCCC; margin-left: 0px;" Font-Size="Medium" 
                 Visible="False" >
               
                <Columns>
                    <asp:BoundField DataField="Statename" HeaderText="State Name" Visible="false" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency"  />
                     <asp:BoundField DataField="id" HeaderText="id"  Visible="false"/>
                   <%-- <asp:BoundField DataField="ConstName" HeaderText="Constituency" />--%>
                    <asp:TemplateField HeaderText="Lead" >
                        <FooterTemplate>
                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                style="font-weight: 700" Text="Update" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox" runat="server" autocomplete="off"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox"
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                    
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total Vote">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" autocomplete="off"></asp:TextBox>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lead" HeaderText="Lead" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                   <asp:BoundField DataField="total_vote" HeaderText="Total Vote" />
                    
                </Columns>
                 <HeaderStyle Font-Size="Medium" />
            </asp:GridView>
             </td>
        <td class="style36">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        <td class="style37">
            </td>
        <td class="style37">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;</td>
        <td class="style38">
            </td>
        <td class="style38">
            </td>
        <td class="style38">
            </td>
    </tr>
    <tr>
        <td class="style4" colspan="10">
            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="style42">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                   <td class="style43">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" Width="721px" Caption="ON AIR" 
                style="background-color: #CCCCCC;  font-size: Medium;" Height="160px">
                <Columns>
                   <%-- <asp:BoundField DataField="Statename" HeaderText="StateName" />--%>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CantiName" HeaderText="CandidateName" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="Status" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                                style="font-weight: 700;background-color:red; color:White" Text="TO OFF AIR"  />
                        </ItemTemplate>
                        <HeaderStyle Font-Size="Medium" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Font-Size="X-Large" />
            </asp:GridView>
                    </td>
                    
             <td class="style44">
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" Width="710px" Caption="OFF AIR" 
                style="text-align: justify; margin-left: 23px; background-color: #CCCCCC;  font-size: Medium;" 
                            Height="160px">
                <Columns>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CantiName" HeaderText="CandidateName" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                style="font-weight: 700;background-color:green; color:White" Text="TO ON AIR" />
                        </ItemTemplate>
                        <HeaderStyle Font-Size="Medium" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Font-Size="X-Large" />
            </asp:GridView>
                    </td>
                    <td class="style44">
                        &nbsp;</td>
                    <td class="style44">
                        </td>
                    <td class="style44">
                        &nbsp;</td>
                    <td class="style44">
                    </td>
                </tr>
                <tr>
                    <%--<td class="style42">
                        <asp:GridView 
                ID="GridView4" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" Height="160px" Width="721px" style="margin-right: 31px; background-color: #CCCCCC;  font-size: Medium;" 
                 Caption="VIP ON AIR">
                <Columns>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CantiName" HeaderText="CandidateName" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="Status" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                            <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                                style="font-weight: 700;background-color:red; color:White" Text="TO OFF AIR" />
                        </ItemTemplate>
                        <HeaderStyle Font-Size="Medium" />
                    </asp:TemplateField>
                </Columns>
                            <HeaderStyle Font-Size="Medium" />
            </asp:GridView>
                    </td>--%>
                    <td>
            <%--<asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" Height="160px" 
                
                            
                            style="margin-top: 1px; margin-left: 19px; background-color: #CCCCCC; font-size: large;" Width="715px" 
                Caption="VIP OFF AIR">
                <Columns>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CantiName" HeaderText="CandidateName" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" >
                    <HeaderStyle Font-Size="Medium" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox5" runat="server" />
                            <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                                style="font-weight: 700;background-color:green; color:White" Text="TO ON AIR" />
                        </ItemTemplate>
                        <HeaderStyle Font-Size="Medium" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Font-Size="X-Large" />
            </asp:GridView>
                    </td>--%>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td class="style51">
            &nbsp;</td>
        <td class="style76">
            &nbsp;</td>
        <td class="style59">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        <td class="style16">
            &nbsp;</td>
        <td class="style19">
            &nbsp;</td>
        <td class="style9">
             &nbsp;
             <br />
        </td>
        <td class="style9">
            <br />
            </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style51">
            &nbsp;</td>
        <td class="style76">
            &nbsp;</td>
        <td class="style59">
            &nbsp;</td>
        <td class="style16">
            &nbsp;</td>
        <td class="style19">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td class="style9">
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