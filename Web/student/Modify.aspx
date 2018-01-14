<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Topicsys.Web.t_student.Modify" Title="修改学生信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            <label>系别</label>
            <asp:DropDownList ID="ddlDept_id" runat="server" OnSelectedIndexChanged="ddlDept_id_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            <label>专业</label>
            <asp:DropDownList ID="ddlMajor_id" runat="server" OnSelectedIndexChanged="ddlMajor_id_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            <label>班级</label>
            <asp:DropDownList ID="txtstudent_class_id" runat="server"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            学号：<asp:TextBox ID="txtstudent_xh" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            姓名：<asp:TextBox ID="txtstudent_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            备注：<asp:TextBox ID="txtstudent_note" runat="server" TextMode="MultiLine"></asp:TextBox>
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


