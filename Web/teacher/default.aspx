<%@ Page Title="查看导师/教务管理员列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Topicsys.Web.v_teacher.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./add.aspx" style="float: right">添加</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            关键字：<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>
        </div>
        状态说明：0为正常，9为注销，其他为异常状态<br />
        类型说明：0为导师，1为教研室主任
        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
            BorderWidth="1px" DataKeyNames="id"
            AutoGenerateColumns="false" PageSize="10" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="dept_name" HeaderText="系别" SortExpression="dept_name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="teacher_gh" HeaderText="工号" SortExpression="teacher_gh" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="teacher_name" HeaderText="姓名" SortExpression="teacher_name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="teacher_stat" HeaderText="状态" SortExpression="teacher_stat" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="teacher_note" HeaderText="备注" SortExpression="teacher_note" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="teacher_type" HeaderText="类型" SortExpression="teacher_type" ItemStyle-HorizontalAlign="Center" />
                <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                    Text="编辑" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>