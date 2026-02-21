<%@ Page Language="C#" MasterPageFile="~/Election.Master" AutoEventWireup="true" CodeFile="VIP_Onair.aspx.cs" Inherits="VIP_Onair" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style8
        {
            width: 61px;
        }
        .style9
        {
            width: 292px;
            height: 409px;
        }
        .style10
        {
            width: 662px;
        }
        .style11
        {
            height: 23px;
        }
        .style13
        {
            width: 809px;
            height: 23px;
        }
        .style14
        {
            width: 61px;
            height: 23px;
        }
        .style15
        {
            width: 662px;
            height: 23px;
        }
        .style18
        {
            width: 40px;
            height: 42px;
        }
        .style19
        {
            width: 149px;
            height: 42px;
        }
        .style21
        {
            height: 30px;
        }
        .style25
        {
            width: 61px;
            height: 409px;
        }
        .style32
       {
           width: 809px;
       }
       .style33
       {
            height: 409px;
        }
       .style34
       {
           width: 809px;
           height: 409px;
       }
    .style36
    {
        font-family: "Times New Roman", Times, serif;
        font-size: x-large;
        font-weight: bold;
    }
    .style37
    {
        width: 117px;
    }
        .style38
        {
            width: 117px;
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td colspan="5">
             <br  />
             <span >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;<span class="style36">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span>
            <asp:Label ID="Label2" runat="server" CssClass="style36" 
                Text="    VIP CANDIDATE&nbsp; ON AIR&nbsp; &amp; OFF AIR"></asp:Label>
            </span><b>
            <br />
            <br />
            <br />
            </b>
            <br />
            </td>
    </tr>
    <tr>
        <td class="style18">
            </td>
        <td class="style19">
            </td>
        <td class="style38">
            <asp:Label ID="Label1" runat="server" style=" font-size: large;"  
                Text="State" Font-Size="Medium" font-Weight="Bold" Font-Bold="True"></asp:Label>
            <br />
        </td>
        <td class="style21">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Height="34px" 
                Width="289px" style="margin-left: 0px">
            </asp:DropDownList>
            <br />
        </td>
        <td class="style21">
            </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="style37">
            <asp:Label ID="Label3" runat="server" style=" font-size: large;"  
                Text="District" Font-Size="Medium" font-Weight="Bold" Font-Bold="True"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged" Height="34px" 
                Width="289px" style="margin-left: 0px">
            </asp:DropDownList>
            </td>
        <td>
            &nbsp;</td>
    </tr>
  
</table>
<table style="height: 309px; margin-top: 0px;" >
  <tr>
        <td class="style33">
            </td>
        <td class="style33">
            </td>
        <td class="style34">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" Width="820px" Caption="ON AIR" Height="102px" 
                
                style="font-size:Large;font-weight:bold; font-family: 'Times New Roman', Times, serif; margin-top: 35px;">
                <Columns>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency" >
                   <%-- <HeaderStyle Font-Size="X-Large" />--%>
                    </asp:BoundField>
                    <asp:BoundField DataField="CantiName" HeaderText="CandidateName" >
                   <%-- <HeaderStyle Font-Size="X-Large" />--%>
                    </asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="Status" >
                   <%-- <HeaderStyle Font-Size="X-Large" />--%>
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                                style="font-weight:900; background-color:red; color:White"  Text="TO OFF AIR" />
                        </ItemTemplate>
                        <HeaderStyle Font-Size="Medium" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Font-Size="X-Large" />
            </asp:GridView>
        </td>
        <td class="style25">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td class="style34">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="id" Width="820px" Caption="OFF AIR" Height="102px" 
                style="font-size:Large;font-weight:bold;font-family: 'Times New Roman', Times, serif;  margin-top: 35px;">
                <Columns>
                    <asp:BoundField DataField="constituencyname" HeaderText="Constituency" >
                   <%-- <HeaderStyle Font-Size="X-Large" />--%>
                    </asp:BoundField>
                    <asp:BoundField DataField="CantiName" HeaderText="CandidateName" >
                   <%-- <HeaderStyle Font-Size="X-Large" />--%>
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" >
                    <%--<HeaderStyle Font-Size="X-Large" />--%>
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                style="font-weight: 900; background-color:green; color:White" Text="TO ON AIR"  />
                        </ItemTemplate>
                        <HeaderStyle Font-Size="Medium" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Font-Size="X-Large"/>
            </asp:GridView>
        </td>
        <td class="style9">
            &nbsp;
            </td>
    </tr>
    <tr>
        <td >
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="style32">
            &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
        <td class="style10">
            &nbsp;</td>
    </tr>
    <tr>
        <td >
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="style32">
            &nbsp;</td>
        <td class="style8">
            &nbsp;</td>
        <td class="style10">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
