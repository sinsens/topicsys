<%@ Page Title="审核选题信息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="Topicsys.Web.v_topic.status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="add.aspx" style="float: right">添加</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            关键字：<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>
        </div>

        <br />

        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging" BorderWidth="1px" DataKeyNames="topic_id" AutoGenerateColumns="false" PageSize="10" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="topic_name" HeaderText="论文题目" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="select_sum" HeaderText="已选人数" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="topic_num" HeaderText="可选人数" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="class_name" HeaderText="可选班级" ItemStyle-HorizontalAlign="Center" />
                <asp:HyperLinkField HeaderText="编辑" Target="_blank" ControlStyle-Width="50" DataNavigateUrlFields="topic_id" DataNavigateUrlFormatString="/select/audit.aspx?topic_id={0}"
                    Text="编辑" />
                <asp:TemplateField ControlStyle-Width="50" HeaderText="注销" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="注销"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>