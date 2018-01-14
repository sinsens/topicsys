<%@ Page Title="审核出题信息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="Topicsys.Web.v_topic.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
    </div>
    <div class="card-body">

        <div class="form-group">
            条件：<asp:DropDownList runat="server" ID="myCondition" OnSelectedIndexChanged="apply_MyCondition" AutoPostBack="true">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>已审核</asp:ListItem>
                <asp:ListItem>未审核</asp:ListItem>
                <asp:ListItem>已通过审核</asp:ListItem>
                <asp:ListItem>未通过审核</asp:ListItem>
            </asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            关键字：<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>
        </div>
        状态说明：0为待审核，1为审核不通过,2为已通过审核
        <br />
        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
            BorderWidth="1px" DataKeyNames="topic_id" OnRowDataBound="gridView_RowDataBound"
            AutoGenerateColumns="false" PageSize="10" RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
            <Columns>
                <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="topic_teacher_gh" HeaderText="导师工号" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="teacher_name" HeaderText="导师姓名" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="dept_name" HeaderText="系别" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="class_name" HeaderText="班级" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="topic_name" HeaderText="论文题目" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="topic_num" HeaderText="可选人数" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="topic_stat" HeaderText="审核状态" ItemStyle-HorizontalAlign="Center" />
                <asp:HyperLinkField HeaderText="审核" ControlStyle-Width="50" DataNavigateUrlFields="topic_id" DataNavigateUrlFormatString="audit.aspx?topic_id={0}"
                    Text="审核" />
                <asp:TemplateField ControlStyle-Width="50" HeaderText="审核" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="审核"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="input-group">
            <asp:Button ID="btnDelete" runat="server" Text="批量通过审核" OnClick="btnDelete_Click" OnClientClick="return confirm('确认通过审核？')" />
        </div>
    </div>
</asp:Content>