<%@ Page Title="查看公告列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Topicsys.Web.notice.List" %>

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
        <asp:GridView ID="gridView" runat="server" AllowPaging="True"
            Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
            BorderWidth="1px" DataKeyNames="id" OnRowDataBound="gridView_RowDataBound"
            AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center"
            OnRowCreated="gridView_OnRowCreated">
            <Columns>
                <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                    </ItemTemplate>

                    <ControlStyle Width="30px"></ControlStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="notice_user_name" HeaderText="发布人"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="notice_title" HeaderText="公告标题"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="notice_date" HeaderText="发布时间"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:HyperLinkField Target="_blank" HeaderText="查看" ControlStyle-Width="50"
                    DataNavigateUrlFields="id" DataNavigateUrlFormatString="/Show.aspx?id={0}"
                    Text="查看">
                    <ControlStyle Width="50px"></ControlStyle>
                </asp:HyperLinkField>
                <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50"
                    DataNavigateUrlFields="id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                    Text="编辑">
                    <ControlStyle Width="50px"></ControlStyle>
                </asp:HyperLinkField>
                <asp:TemplateField ControlStyle-Width="50" HeaderText="删除" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="删除"></asp:LinkButton>
                    </ItemTemplate>

                    <ControlStyle Width="50px"></ControlStyle>
                </asp:TemplateField>
            </Columns>

            <RowStyle HorizontalAlign="Center"></RowStyle>
        </asp:GridView>
        <div class="form-group">
            <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
        </div>
    </div>
</asp:Content>