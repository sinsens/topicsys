<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Topicsys.Web.t_major.Modify" Title="修改专业信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
        <a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            ID：<asp:Label ID="lblid" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            专业名称：<asp:TextBox ID="txtmajor_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            所属系别：
	<asp:DropDownList ID="txtmajor_dept_id" runat="server"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            是否启用：
            <asp:DropDownList ID="txtmajor_stat" runat="server">
                <asp:ListItem Value="0">启用</asp:ListItem>
                <asp:ListItem Value="1">注销</asp:ListItem>
            </asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            备注：
            <asp:TextBox ID="txtmajor_note" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>