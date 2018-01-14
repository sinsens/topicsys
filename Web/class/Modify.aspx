<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Topicsys.Web.t_class.Modify" Title="修改班级信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
        <a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            <label>系别</label>
            <asp:DropDownList ID="ddlDept_id" runat="server" OnSelectedIndexChanged="ddlDept_id_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            <label>专业</label>
            <asp:DropDownList ID="ddlMajor_id" runat="server" AutoPostBack="True"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            名称：<asp:TextBox ID="txtclass_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            备注：<asp:TextBox ID="txtclass_note" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            状态：<asp:DropDownList ID="ddlStat" runat="server">
                <asp:ListItem Value="0">启用</asp:ListItem>
                <asp:ListItem Value="1">注销</asp:ListItem>
            </asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>