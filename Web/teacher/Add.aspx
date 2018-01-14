<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="Topicsys.Web.t_teacher.Add" Title="添加导师信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightContent" runat="server">
    <div class="card-header">
        <% =this.Title %><a href="./default.aspx" style="float: right">返回</a>
    </div>
    <div class="card-body">
        <div class="form-group">
            导师类型：<asp:DropDownList ID="txtteacher_type" runat="server">
                <asp:ListItem Value="0">导师</asp:ListItem>
                <asp:ListItem Value="1">教研室主任</asp:ListItem>
            </asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            工号：<asp:TextBox ID="txtteacher_gh" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            姓名：<asp:TextBox ID="txtteacher_name" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            所属系别：<asp:DropDownList ID="txtteacher_dept_id" runat="server" OnSelectedIndexChanged="txtteacher_dept_id_SelectedIndexChanged"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            所属专业：<asp:DropDownList ID="txtteacher_major_id" runat="server"></asp:DropDownList><span class="fa fa-angle-double-down"></span>
        </div>
        <div class="form-group">
            备注：<asp:TextBox ID="txtteacher_note" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <p>
            默认密码为abc+教师工号<p />
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="保存"
                OnClick="btnSave_Click"></asp:Button>
        </div>
    </div>
</asp:Content>


