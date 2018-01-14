<%@ Page Title="导出学生选题结果" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="export_teacher.aspx.cs" Inherits="Topicsys.Web.select.export_teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><% =this.Title %>
    </div>
    <div class="card-body">
        <div class="form-group">
            <label for="ddlType">导出类型：</label>
            <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                <asp:ListItem Value="major">按专业</asp:ListItem>
                <asp:ListItem Value="class">按班级</asp:ListItem>
                <asp:ListItem Value="topic">按选题</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div class="form-group">
            <label for="ddlType">数据选项：</label>
            <asp:DropDownList ID="ddlParm" runat="server">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnExport" Text="开始导出" runat="server" OnClick="btnExport_Click" />
        </div>
    </div>
</asp:Content>