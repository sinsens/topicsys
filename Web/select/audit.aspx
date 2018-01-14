<%@ Page Title="审核学生选题" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="audit.aspx.cs" Inherits="Topicsys.Web.select.audit" %>

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
        状态提示信息：0为等待导师审核,1为一审不通过,2为审核通过,3为二审不通过等待分配,5为已发布结果
        <br />
        <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3" OnPageIndexChanging="gridView_PageIndexChanging"
            BorderWidth="1px" DataKeyNames="select_id" OnRowDataBound="gridView_RowDataBound"
            AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
            <Columns>
                <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                    </ItemTemplate>

                    <ControlStyle Width="30px"></ControlStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="class_name" HeaderText="班级" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="major_name" HeaderText="专业" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="select_student_xh" HeaderText="学号" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="select_stat" HeaderText="状态" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="topic_num" HeaderText="论文题目" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:CommandField ButtonType="Button" CancelText="通过审核" DeleteText="不通过" EditText="" />
                <asp:TemplateField ControlStyle-Width="50" HeaderText="审核" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="审核"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <RowStyle HorizontalAlign="Center"></RowStyle>
        </asp:GridView>
        <div class="form-group">
            <asp:Button ID="btnDelete" runat="server" Text="批量通过审核" OnClick="btnDelete_Click" />
        </div>
    </div>
</asp:Content>