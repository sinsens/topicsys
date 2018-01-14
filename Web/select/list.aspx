<%@ Page Title="查看可选题目列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="Topicsys.Web.select.list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
    </div>
    <div class="card-body">
        <div class="form-group">
            关键字：<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>
        </div>

        <br />
        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
            BorderWidth="1px" DataKeyNames="topic_id" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" OnRowCommand="gridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="teacher_name" HeaderText="导师" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="topic_name" HeaderText="论文题目" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="select_sum" HeaderText="已选人数" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="topic_num" HeaderText="可选人数" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="class_name" HeaderText="可选班级" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:ButtonField ButtonType="Button" HeaderText="操作" Text="申请该题目" CommandName="ApplyFor" />
            </Columns>

            <RowStyle HorizontalAlign="Center"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>


