<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Topicsys.Web.t_admin.Modify" Title="修改系统角色" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            ID：<asp:Label ID="lblid" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            登录名：<asp:Label ID="lbluser_name" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            密码：<asp:TextBox ID="txtpwd" runat="server"></asp:TextBox><p>留空或密码长度小于6则表示不修改密码</p>
        </div>
        <div class="form-group">
            状态：<asp:DropDownList ID="ddlStat" runat="server">
                <asp:ListItem Value="0">启用</asp:ListItem>
                <asp:ListItem Value="9">已注销</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>