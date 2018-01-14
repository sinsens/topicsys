<%@ Page Title="查看学生列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Topicsys.Web.v_student.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./add.aspx" style="float: right">添加</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            关键字：<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>
        </div>
        <br />
        状态说明：0为正常，9为已注销
        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
            BorderWidth="1px" DataKeyNames="id" OnRowDataBound="gridView_RowDataBound"
            AutoGenerateColumns="false" PageSize="10" RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
            <Columns>
                <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="dept_name" HeaderText="系别" SortExpression="dept_name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="class_name" HeaderText="班级" SortExpression="class_name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="student_xh" HeaderText="学号" SortExpression="student_xh" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="student_name" HeaderText="姓名" SortExpression="student_name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="student_stat" HeaderText="状态" SortExpression="student_stat" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="student_note" HeaderText="备注" SortExpression="student_note" ItemStyle-HorizontalAlign="Center" />
                <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                    Text="编辑" />
                <asp:TemplateField ControlStyle-Width="50" HeaderText="删除" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="form-group">
            <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
        </div>
    </div>
</asp:Content>