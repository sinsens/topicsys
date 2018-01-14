<%@ Page Title="查看待分配学生列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="list2.aspx.cs" Inherits="Topicsys.Web.t_select.List2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><% =this.Title %>
    </div>
    <div class="card-body">
        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging" BorderWidth="1px" DataKeyNames="select_id" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="major_name" HeaderText="专业" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="class_name" HeaderText="班级" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="select_student_xh" HeaderText="学号" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="student_name" HeaderText="姓名" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:HyperLinkField HeaderText="操作" DataNavigateUrlFields="select_student_xh" DataNavigateUrlFormatString="allocate.aspx?xh={0}" Text="分配选题" />
            </Columns>

            <RowStyle HorizontalAlign="Center"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>