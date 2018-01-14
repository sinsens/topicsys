<%@ Page Title="查看选题结果" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="Topicsys.Web.t_select.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><% =this.Title %>
    </div>
    <div class="card-body">
        状态提示信息：0为等待导师审核,1为一审不通过,2为审核通过,3为二审不通过等待分配,5为已发布结果
        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging" BorderWidth="1px" DataKeyNames="select_id" AutoGenerateColumns="false" PageSize="10" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="teacher_name" HeaderText="导师" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="topic_name" HeaderText="论文题目" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="select_stat" HeaderText="状态" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>