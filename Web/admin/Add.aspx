<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Topicsys.Web.t_admin.Add" Title="添加系统角色" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        请注意，本页面添加的是具有最高权限的教务管理员角色
        <div class="form-group">
            登录名：<asp:TextBox ID="txtuser_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            密码：<asp:TextBox ID="txtpwd" runat="server"></asp:TextBox><p>留空或密码长度小于6则使用默认密码abc12345</p>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>