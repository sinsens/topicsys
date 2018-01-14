<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Topicsys.Web.t_class.Add" Title="添加班级" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %>
        <a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            系别：
            <asp:DropDownList ID="ddlDept_id" runat="server" OnSelectedIndexChanged="ddlDept_id_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            专业：
            <asp:DropDownList ID="ddlMajor_id" runat="server" AutoPostBack="True"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            名称：
            <asp:TextBox ID="txtclass_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            备注：
            <asp:TextBox ID="txtclass_note" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>